using Mobile_Petitions.SERVICE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Mobile_Petitions.Views;

namespace Mobile_Petitions.ViewModels
{
    public class AgreementViewModel : BaseViewModel
    {
        public ICommand ChangeToSignature
        {
            get { return new RelayCommand(ToSignature); }
        }

        public AgreementViewModel(MainViewModel main) : base(main)
        {

        }

        public void ToSignature(object param)
        {
            if (ServiceProperties.Service.DeclineAgreement)
                Navigate<HomePageViewModel>();
            else
                Navigate<ScanSimViewModel>();
        }
    }
}
