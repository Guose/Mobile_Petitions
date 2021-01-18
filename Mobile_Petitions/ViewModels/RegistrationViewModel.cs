using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mobile_Petitions.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        public ICommand ChangeToLogin
        {
            get { return new RelayCommand(ToLogin); }
        }
        public RegistrationViewModel(MainViewModel main) : base(main)
        {

        }

        public void ToLogin(object param)
        {
            Navigate<LoginViewModel>();
        }
    }
}
