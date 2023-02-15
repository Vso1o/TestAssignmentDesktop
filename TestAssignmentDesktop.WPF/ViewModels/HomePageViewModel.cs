using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestAssignmentDesktop.Business.CrytoInfoReceiver.Interfaces;
using TestAssignmentDesktop.Business.CrytoInfoReceiver;
using TestAssignmentDesktop.Core.Enums;
using TestAssignmentDesktop.WPF.Commands;
using TestAssignmentDesktop.WPF.Models;
using TestAssignmentDesktop.WPF.ViewModels.Base;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;

namespace TestAssignmentDesktop.WPF.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        #region properties
        public event Action<int> ChangePage;
        public event Action<CryptoCurrencyModel> ChangeSelecetedModel;

        private CryptoCurrencyModel _currencyModel;
        public CryptoCurrencyModel SelectedCurrencyModel
        {
            get { return _currencyModel; }
            set
            {
                _currencyModel = value;
                ChangeSelecetedModel.Invoke(value);
                OnPropertyChanged();
            }
        }

        private ICollectionView _currenciesCollectionView;
        public ICollectionView CurrenciesCollectionView
        {
            get { return _currenciesCollectionView; }
            set
            {
                _currenciesCollectionView = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<CryptoCurrencyModel> _cryptoCurrencyModels = new ObservableCollection<CryptoCurrencyModel>();
        public ObservableCollection<CryptoCurrencyModel> CryptoCurrencyModels
        {
            get { return _cryptoCurrencyModels; }
            set
            {
                _cryptoCurrencyModels = value;
                OnPropertyChanged();
            }
        }

        private string _collectionSearchingFilter = string.Empty;
        public string SearchingFilterText
        {
            get { return _collectionSearchingFilter; }
            set
            {
                _collectionSearchingFilter = value;
                OnPropertyChanged();
                CurrenciesCollectionView.Refresh();
            }
        }

        private int _shownCurrenciesCount = 50;
        public int ShownCurrenciesCount
        {
            get { return _shownCurrenciesCount; }
            set
            {
                _shownCurrenciesCount = value;
                OnPropertyChanged();
                CurrenciesCollectionView.Refresh();
            }
        }

        private DataProviders _providers = DataProviders.Coincap;
        public DataProviders Providers
        {
            get { return _providers; }
            set
            {
                _providers = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region commands
        private ICommand _changePageCommand;
        public ICommand ChangePageCommand => _changePageCommand ?? (_changePageCommand = new ActionCommand(() => ChangePage(2)));
        #endregion

        public HomePageViewModel()
        {
            Title = "CryptoCurrency Observer";

            Task.Run(() => GetInitialAssets());
        }

        private ICryptoInfoReceiver GetProvider(DataProviders provider)
        {
            //App is only compatible with CoinCap API due to returned data difference
            return provider switch
            {
                DataProviders.Coincap => new CoinCapReceiver(),
                DataProviders.Coingecko => throw new NotImplementedException(),
                DataProviders.Cryptingup => new CryptingUpReceiver(),
                _ => new CoinCapReceiver()
            };
        }

        private async Task GetInitialAssets()
        {
            var receiver = GetProvider(DataProviders.Coincap);

            var rawList = await receiver.ReceiveAllAssets();

            var result = new ObservableCollection<CryptoCurrencyModel>();

            rawList = rawList.OrderBy(x => x.Rank).ToList();

            rawList.ForEach(asset => result.Add(CryptoCurrencyModel.ConvertFromBase(asset)));

            CryptoCurrencyModels = result;

            SetUpCollectionView();
        }

        private async Task GetAssets(DataProviders dataProvider)
        {
            CryptoCurrencyModels.Clear();
            await GetInitialAssets();
        }

        private void SetUpCollectionView()
        {
            CurrenciesCollectionView = CollectionViewSource.GetDefaultView(_cryptoCurrencyModels);
            CurrenciesCollectionView.Filter = SearchingFilter;
        }

        private bool SearchingFilter(object obj)
        {
            if(obj is CryptoCurrencyModel currencyModel)
            {
                return (currencyModel.Name.Contains(_collectionSearchingFilter)
                    || currencyModel.Code.Contains(_collectionSearchingFilter))
                    && currencyModel.Rank <= _shownCurrenciesCount;
            }
            return false;
        }
    }
}
