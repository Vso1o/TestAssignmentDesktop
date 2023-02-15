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

namespace TestAssignmentDesktop.WPF.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        private ICommand _changePageCommand;

        public event Action<int> ChangePage;

        private double _conversionMultiplier = 0;

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

        private CryptoCurrencyModel _currencyModel;
        public CryptoCurrencyModel SelectedCurrencyModel
        {
            get { return _currencyModel; }
            set
            {
                _currencyModel = value;
                OnPropertyChanged();
            }
        }

        private CryptoCurrencyModel _localCurrencyModel;
        public CryptoCurrencyModel SelectedForConversionCurrencyModel
        {
            get { return _localCurrencyModel; }
            set
            {
                _localCurrencyModel = value;
                ResultingString = CalculateConvertionPrice();
                RequestingString = GetNumeralConversionTitle();
                ResultingStringDefinedQuantity = GetNumeralConversionResultingString();
                OnPropertyChanged();
            }
        }

        private string _resultingString = string.Empty;
        public string ResultingString
        {
            get { return _resultingString; }
            set
            {
                _resultingString = value;
                OnPropertyChanged();
            }
        }

        private string _resultingStringDefinedQuantity = string.Empty;
        public string ResultingStringDefinedQuantity
        {
            get { return _resultingStringDefinedQuantity; }
            set
            {
                _resultingStringDefinedQuantity = value;
                OnPropertyChanged();
            }
        }

        private double _quantity = 0;
        public double Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                ResultingStringDefinedQuantity = GetNumeralConversionResultingString();
                OnPropertyChanged();
            }
        }

        private string _requestingString = string.Empty;
        public string RequestingString
        {
            get { return _requestingString; }
            set
            {
                _requestingString = value;
                OnPropertyChanged();
            }
        }

        public ICommand ChangePageCommand => _changePageCommand ?? (_changePageCommand = new ActionCommand(() => ChangePage(1)));

        public DetailsViewModel()
        {
            Title = "CryptoCurrency Details";

            Task.Run(() => GetAssets());
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

        private async Task GetAssets()
        {
            var receiver = GetProvider(DataProviders.Coincap);

            var rawList = await receiver.ReceiveAllAssets();

            var result = new ObservableCollection<CryptoCurrencyModel>();

            rawList = rawList.OrderBy(x => x.Rank).ToList();

            rawList.ForEach(asset => result.Add(CryptoCurrencyModel.ConvertFromBase(asset)));

            CryptoCurrencyModels = result;
        }

        private string CalculateConvertionPrice()
        {
            if (SelectedForConversionCurrencyModel.Code == SelectedCurrencyModel.Code)
                return "You have selected the same currency";
            _conversionMultiplier = SelectedCurrencyModel.USDValue / SelectedForConversionCurrencyModel.USDValue;

            return "One " + SelectedCurrencyModel.Name +
                " worth " + Math.Round(_conversionMultiplier, 5) +
                " " + SelectedForConversionCurrencyModel.Name + "(s)";
        }

        private string GetNumeralConversionTitle()
        {
            if (SelectedForConversionCurrencyModel.Code == SelectedCurrencyModel.Code)
                return "You have selected the same currency";

            return "Enter how many " + SelectedCurrencyModel.Name +
                "(s) you want to buy with" + SelectedForConversionCurrencyModel.Name;
        }

        private string GetNumeralConversionResultingString()
        {
            if (SelectedForConversionCurrencyModel.Code == SelectedCurrencyModel.Code)
                return "You have selected the same currency";

            return Quantity + " " + SelectedCurrencyModel.Name + "(s) worth " +
                (_conversionMultiplier * Quantity) + " " + SelectedForConversionCurrencyModel.Name + "(s)";
        }
    }
}
