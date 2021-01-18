using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InViewChange.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public BaseViewModel ViewModel { get; set; }

        public MainViewModel()
        {
            Navigate<RedViewModel>(new RedViewModel(this));
        }

        public void Navigate<T>(BaseViewModel viewModel) where T : BaseViewModel
        {
            ViewModel = viewModel as T;
            Console.WriteLine(ViewModel.GetType());
            OnPropertyChanged("ViewModel");
        }
    }
}
