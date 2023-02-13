using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestAssignmentDesktop.Business.CrytoInfoReceiver;
using TestAssignmentDesktop.WPF.Models;
using TestAssignmentDesktop.WPF.ViewModels.Base;

namespace TestAssignmentDesktop.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
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

        private int _shownCurrenciesCount = 10;
        public int ShownCurrenciesCount
        {
            get { return _shownCurrenciesCount; }
            set
            {
                _shownCurrenciesCount = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Title= "CryptoCurrency Observer";
            Task.Run(() => GetAssets());
        }

        private void GetAssets()
        {
            var receiver = new CoinCapReceiver();

            var rawList = receiver.ReceiveAllAssets().Result;

            ObservableCollection<CryptoCurrencyModel> result = new ObservableCollection<CryptoCurrencyModel>();

            rawList.ForEach(asset => result.Add(CryptoCurrencyModel.ConvertFromBase(asset)));

            //CryptoCurrencyModels = new ObservableCollection<CryptoCurrencyModel>();

            /*foreach (var item in result)
            {
                CryptoCurrencyModels.Add(item);
            }*/

            CryptoCurrencyModels = result;
        }
    }
}
