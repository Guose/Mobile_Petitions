using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Mobile_Petitions.SERVICE;

namespace Mobile_Petitions.ViewModels
{
    public class SignatureViewModel : BaseViewModel
    {
        public ICommand ChangeToScan
        {
            get { return new RelayCommand(ToScan); }
        }
        public SignatureViewModel(MainViewModel main) : base(main)
        {

        }

        public void ToScan(object param)
        {
            if (ServiceProperties.Service.ChangeView == true)
            {
                ServiceProperties.Service.ChangeView = false;
                Navigate<LoginViewModel>();
            }
            else
            {
                Navigate<HomePageViewModel>();
            }
            
        }
    }
}
