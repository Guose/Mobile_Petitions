using Mobile_Petitions.SERVICE;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Mobile_Petitions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string deleteFileDir = @"..\..\";
            string[] xpsDoc = Directory.GetFiles(deleteFileDir, "*.xps");
            string[] mobilePetExe = Directory.GetFiles(@"C:\Users\Guose\OneDrive\Desktop\SMG\SMG Mobile Petitions\Mobile_Petitions\Mobile_Petitions\bin\Debug\app.publish", "*.exe");

            if (xpsDoc.Length > 0)
            {
                string deleteFile = xpsDoc[0];
                File.Delete(deleteFile);
            }

            if (mobilePetExe.Length > 0)
            {
                string deleteFile = mobilePetExe[0];
                File.Delete(deleteFile);
            }
        }

        private void lblSignOut_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void lblSignOut_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void lblSignOut_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }
    }
}
