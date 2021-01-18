using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Mobile_Petitions.SERVICE;
using System.Windows.Media.Imaging;
using System;

namespace Mobile_Petitions.Views
{
    /// <summary>
    /// Interaction logic for SignatureView.xaml
    /// </summary>
    public partial class SignatureView : UserControl
    {
        public SignatureView()
        {
            InitializeComponent();
            scanService = new ScannerService();
        }

        private ScannerService scanService = null;

        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            imgSignature.Source = new BitmapImage(new Uri("/Mobile_Petitions;component/" + scanService.GetSignatureClip(), UriKind.Relative));
            imgSignature.Visibility = Visibility.Visible;
        }        

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            ServiceProperties.Service.ChangeView = true;
        }

        private void lblExit_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void lblExit_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void lblExit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
    }
}
