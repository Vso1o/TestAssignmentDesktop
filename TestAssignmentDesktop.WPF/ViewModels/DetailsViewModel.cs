using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAssignmentDesktop.WPF.ViewModels.Base;

namespace TestAssignmentDesktop.WPF.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        private int _id = 1;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
    }
}
