using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mobile_Petitions.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public BaseViewModel ViewModel { get; set; }

        public MainViewModel()
        {
            Navigate<LoginViewModel>(new LoginViewModel(this));
        }

        public void Navigate<T>(BaseViewModel viewModel) where T : BaseViewModel
        {
            ViewModel = viewModel as T;
            Console.WriteLine(viewModel.GetType());
            OnPropertyChanged("ViewModel");
        }
    }
}
