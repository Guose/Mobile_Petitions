using System.Windows.Input;
using Mobile_Petitions.SERVICE;

namespace Mobile_Petitions.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public bool VerifyCredentials { get; set; }

        public ICommand ChangeToScanDL
        {
            get { return new RelayCommand(ToScanDL); }
        }

        public ICommand ChangeToRegistration
        {
            get { return new RelayCommand(ToRegister); }
        }
        public LoginViewModel(MainViewModel main) : base(main)
        {

        }

        public void ToScanDL(object param)
        {
            if (ServiceProperties.Service.CredentialsVerified)
            {
                Navigate<HomePageViewModel>();
            }            
        }

        public void ToRegister(object param)
        {
            Navigate<RegistrationViewModel>();
        }
    }
}
