using Mobile_Petitions.SERVICE;
using Mobile_Petitions.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mobile_Petitions.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        private LoginService service;

        public LoginView()
        {
            InitializeComponent();
            txtUserName.Focus();
            service = new LoginService();

            if (service.IsRememberMeNULL())
            {
                service.GetRemberedUser();

                txtUserName.Text = ServiceProperties.Service.RememberUser;
                txtPasswordBox.Password = ServiceProperties.Service.RememberPW;
                chkRemember.IsChecked = true;
            }
            
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            bool rememberUser = false;

            if (chkRemember.IsChecked == true)
                rememberUser = true;
                   
            bool credentialsVerified = false;
            credentialsVerified = service.LoginPage(txtUserName.Text, txtPasswordBox.Password, rememberUser);
            ServiceProperties.Service.CredentialsVerified = credentialsVerified;
            ServiceProperties.Service.RememberLoggedInUser = rememberUser;

            if (!credentialsVerified)
            {
                MessageBox.Show("Username and/or Password doesn't match \n\nPlease try again", "Your credentials are not valid", MessageBoxButton.OK, MessageBoxImage.Stop);
                txtUserName.Text = string.Empty;
                txtPasswordBox.Password = string.Empty;
                chkRemember.IsChecked = false;
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtPasswordBox.Focus();
            }
        }

        private void txtPasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSignIn.Focus();
            }
        }

        private void lblForgotPW_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            gbxLogin.Visibility = Visibility.Hidden;
            gbxNewCredentials.Visibility = Visibility.Visible;
        }

        private void lblForgotPW_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void lblForgotPW_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtNewPassWord.Focus();
            }
        }

        private void txtNewPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtReEnterPassWord.Focus();
            }
        }

        private void txtReEnterPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSendEmail.Focus();
            }
        }

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            gbxNewCredentials.Visibility = Visibility.Hidden;
            gbxLogin.Visibility = Visibility.Visible;
        }

        private void lblClose_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void lblClose_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void lblClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
    }
}
