using System.Windows.Input;

namespace InViewChange.ViewModels
{
    public class OrangeViewModel : BaseViewModel
    {
        public ICommand ChangeToRed
        {
            get { return new RelayCommand(ToRed); }
        }

        public OrangeViewModel(MainViewModel main) : base(main)
        {

        }

        public void ToRed(object param)
        {
            Navigate<RedViewModel>();
        }
    }
}
