using Mobile_Petitions.SERVICE;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Mobile_Petitions.Views
{
    /// <summary>
    /// Interaction logic for RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : UserControl
    {
        private LoginService service;
        public RegistrationView()
        {
            InitializeComponent();
            txtUserName.Focus();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string password = pwbPassWord.Password;
            string reEnterPW = pwbReEnterPW.Password;
            bool isAdmin = false;

            if (chkAdminRights.IsChecked == true)
                isAdmin = true;

            service = new LoginService();

            if (password == reEnterPW)
                service.RegisterUser(txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZipCode.Text, txtCounty.Text, txtUserName.Text, txtEmail.Text, password, isAdmin);
            else
                MessageBox.Show("The Password you entered doesn't match the re-entered password /n/nPlease re-enter password and select register"
                    , "Re-Enter Credentials", MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void chkAdminRights_Checked(object sender, RoutedEventArgs e)
        {
            //txtAdminUser.Focus();
            //grpAdminRegistration.Visibility = Visibility.Visible;
            //grpRegistration.Visibility = Visibility.Hidden;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            grpAdminRegistration.Visibility = Visibility.Hidden;
            grpRegistration.Visibility = Visibility.Visible;
        }

        private void txtAdminUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                pwbAdminPW.Focus();
            }
        }
        private void pwbAdminPW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin.Focus();
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                pwbPassWord.Focus();
            }
        }

        private void pwbPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                pwbReEnterPW.Focus();
            }
        }

        private void pwbReEnterPW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnRegister.Focus();
            }
        }

        private void lblClose_MouseEnter(object sender, MouseEventArgs e)
        {
            lblClose.Foreground = Brushes.AliceBlue;
            Cursor = Cursors.Hand;
        }

        private void lblClose_MouseLeave(object sender, MouseEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#00FFFFFF");
            lblClose.Foreground = new SolidColorBrush(color);
            Cursor = Cursors.Arrow;
        }

        private void lblClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
    }
}
