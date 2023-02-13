using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestAssignmentDesktop.Business.CrytoInfoReceiver;
using TestAssignmentDesktop.Business.CrytoInfoReceiver.Interfaces;
using TestAssignmentDesktop.Core.Enums;
using TestAssignmentDesktop.WPF.Commands;
using TestAssignmentDesktop.WPF.Models;
using TestAssignmentDesktop.WPF.ViewModels.Base;

namespace TestAssignmentDesktop.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private int _pageId = 1;
        public int PageId
        {
            get { return _pageId; }
            set
            {
                _pageId = value;
                OnPropertyChanged();
            }
        }

        public DetailsViewModel DetailsViewModel { get; set; }

        public MainViewModel()
        {
            Title= "CryptoCurrency Observer";
            DetailsViewModel = new DetailsViewModel();
            DetailsViewModel.Id = 14;
        }
    }
}
