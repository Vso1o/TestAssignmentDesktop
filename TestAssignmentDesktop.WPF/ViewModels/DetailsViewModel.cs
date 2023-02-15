using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestAssignmentDesktop.WPF.Commands;
using TestAssignmentDesktop.WPF.Models;
using TestAssignmentDesktop.WPF.ViewModels.Base;

namespace TestAssignmentDesktop.WPF.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        private ICommand _changePageCommand;

        public event Action<int> ChangePage;

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

        public ICommand ChangePageCommand => _changePageCommand ?? (_changePageCommand = new ActionCommand(() => ChangePage(1)));

        public DetailsViewModel()
        {

        }
    }
}
