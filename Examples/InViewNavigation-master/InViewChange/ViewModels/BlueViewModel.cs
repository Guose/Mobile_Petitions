using System.Windows.Input;

namespace InViewChange.ViewModels
{
    public class BlueViewModel : BaseViewModel
    {
        //Relay command to call 'ToRed' function
        public ICommand ChangeToOrange
        {
            get { return new RelayCommand(ToOrange); }
        }

        //Requires MainViewModel for BaseViewModel
        public BlueViewModel(MainViewModel main) : base(main)
        {

        }

        //Calling BaseViewModel function. Passed BaseViewModel Type
        public void ToOrange(object param)
        {
            Navigate<OrangeViewModel>();
        }
    }
}
