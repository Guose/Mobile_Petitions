using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Mobile_Petitions.SERVICE;

namespace Mobile_Petitions.ViewModels
{
    public class ScanSimViewModel : BaseViewModel
    {
        //Relay command to call 'ToEditAudit' function
        public ICommand ChangeToAgreement
        {
            get { return new RelayCommand(ToAgreement); }
        }

        public ScanSimViewModel(MainViewModel main) : base(main)
        {

        }

        public void ToAgreement(object param)
        {

            if (ServiceProperties.Service.ChangeView == true)
            {
                ServiceProperties.Service.ChangeView = false;
                ServiceProperties.Service.EditEntry = false;
                Navigate<LoginViewModel>();
            }
            else if (ServiceProperties.Service.ChangeView == false && ServiceProperties.Service.EditEntry == false)
            {
                ServiceProperties.Service.EditEntry = false;
                Navigate<SignatureViewModel>();
            }
            else if (ServiceProperties.Service.EditEntry)
            {
                Navigate<ScanSimViewModel>();
            }
            
        }
    }
}
