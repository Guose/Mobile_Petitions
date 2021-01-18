using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mobile_Petitions.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ICommand ChangeToAgreement
        {
            get { return new RelayCommand(ToAgreement); }
        }

        public HomePageViewModel(MainViewModel mainVM) : base(mainVM)
        {

        }

        public void ToAgreement(object param)
        {
            Navigate<AgreementViewModel>();
        }
    }
}
