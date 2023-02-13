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

namespace TestAssignmentDesktop.WPF.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        #region properties
        private List<CryptoCurrencyModel> _rawCryptoCurrencyModels = new List<CryptoCurrencyModel>();
        private ObservableCollection<CryptoCurrencyModel> _cryptoCurrencyModels = new ObservableCollection<CryptoCurrencyModel>();
        private CollectionView collectionView;//Develop this idea
        public ObservableCollection<CryptoCurrencyModel> CryptoCurrencyModels
        {
            get { return _cryptoCurrencyModels; }
            set
            {
                _cryptoCurrencyModels = value;
                OnPropertyChanged();
            }
        }

        private int _shownCurrenciesCount = 10;
        public int ShownCurrenciesCount
        {
            get { return _shownCurrenciesCount; }
            set
            {
                _shownCurrenciesCount = value;
                OnPropertyChanged();
                ChangeShownModelsCount();
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
        public ICommand ChangeDisplayedCountCommand
        {
            get
            {
                return new ActionCommand(() =>
                {
                    ChangeShownModelsCount();
                });
            }
        }
        #endregion

        public HomePageViewModel()
        {
            Title = "CryptoCurrency Observer";

            Task.Run(() => GetInitialAssets());
        }

        private ICryptoInfoReceiver GetProvider(DataProviders provider)
        {
            return provider switch
            {
                DataProviders.Coincap => new CoinCapReceiver(),
                DataProviders.Coingecko => throw new NotImplementedException(),
                DataProviders.Cryptingup => throw new NotImplementedException(),
                _ => new CoinCapReceiver()
            };
        }

        private void GetInitialAssets()
        {
            var receiver = GetProvider(DataProviders.Coincap);

            var rawList = receiver.ReceiveAllAssets().Result;

            var result = new ObservableCollection<CryptoCurrencyModel>();

            rawList.ForEach(asset => _rawCryptoCurrencyModels.Add(CryptoCurrencyModel.ConvertFromBase(asset)));

            _rawCryptoCurrencyModels = _rawCryptoCurrencyModels.OrderBy(x => x.Rank).ToList();

            int shownCount = _rawCryptoCurrencyModels.Count() >= _shownCurrenciesCount ? _shownCurrenciesCount : _rawCryptoCurrencyModels.Count();

            _rawCryptoCurrencyModels.GetRange(0, shownCount).ForEach(x => result.Add(x));

            CryptoCurrencyModels = result;
        }

        private void GetAssets(DataProviders dataProvider)
        {
            CryptoCurrencyModels.Clear();
            _rawCryptoCurrencyModels.Clear();
            GetInitialAssets();
        }

        private void ChangeShownModelsCount()
        {
            var result = new ObservableCollection<CryptoCurrencyModel>();
            int shownCount = _rawCryptoCurrencyModels.Count() >= _shownCurrenciesCount ? _shownCurrenciesCount : _rawCryptoCurrencyModels.Count();
            _rawCryptoCurrencyModels.GetRange(0, shownCount).ForEach(x => result.Add(x));
            CryptoCurrencyModels = result;
        }
    }
}
