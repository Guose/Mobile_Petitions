﻿using Mobile_Petitions.SERVICE;
using System.Windows.Input;

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
