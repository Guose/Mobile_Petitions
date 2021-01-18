using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using Mobile_Petitions.SERVICE;
using System.Windows.Input;

namespace Mobile_Petitions.Views
{
    /// <summary>
    /// Interaction logic for ScanSimView.xaml
    /// </summary>
    public partial class ScanSimView : UserControl
    {
        private string dlPath = string.Empty;
        private bool flashBlack;
        private ScannerService scannerService;
        //private string state;

        public ScanSimView()
        {
            InitializeComponent();
            flashBlack = false;
            DragEnter += new DragEventHandler(Rectangle_DragEnter);
            Drop += new DragEventHandler(Rectangle_Drop);
        }

        private void Rectangle_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
        }

        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            string[] filepaths = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in filepaths)
            {
                if (File.Exists(file))
                {
                    using (TextReader tr = new StreamReader(file))
                    {
                        dlPath = file;
                        ServiceProperties.Service.PetitionSummaryPath = dlPath;
                    }
                }
            }

            ScanBarcode(dlPath);
        }

        public void ScanBarcode(string path)
        {
            scannerService = new ScannerService(path);

            scannerService.ScanDLBarcode();

            txtFullName.Text = scannerService.ScanFullName;
            txtBirthDate.Text = scannerService.ScanBirthDate;
            txtDriverLicNum.Text = scannerService.ScanDLNumber;
            txtStreetAddress.Text = scannerService.ScanAddress;
            txtCity.Text = scannerService.ScanCity;
            txtState.Text = scannerService.ScanState;            
            txtZip.Text = scannerService.ScanZipCode;
        }

        private void btnScanner_Click(object sender, RoutedEventArgs e)
        {
            if (flashBlack)
            {
                flashBlack = false;
                btnScanner.Foreground = Brushes.White;
                btnScanner.Background = Brushes.Black;
                btnScanner.BorderBrush = Brushes.White;
                btnScanner.Content = "START Scan";
                recDropTextFile.AllowDrop = false;
            }
            else
            {
                flashBlack = true;
                btnScanner.Foreground = Brushes.White;
                btnScanner.Background = Brushes.Red;
                btnScanner.BorderBrush = Brushes.White;
                btnScanner.Content = "STOP Scan";
                recDropTextFile.AllowDrop = true;
            }            
        }

        private void btnSubmitScan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure the information that was entered is correct?", "CHECK SCANNED ENTRY", MessageBoxButton.YesNo, MessageBoxImage.Stop);
                if (result == MessageBoxResult.Yes)
                {
                    scannerService = new ScannerService();
                    scannerService.ScanFullName = txtFullName.Text;
                    scannerService.ScanBirthDate = txtBirthDate.Text;
                    scannerService.ScanDLNumber = txtDriverLicNum.Text;
                    scannerService.ScanCity = txtCity.Text;
                    scannerService.ScanState = txtState.Text;
                    scannerService.ScanZipCode = txtZip.Text;
                    scannerService.ScanAddress = txtStreetAddress.Text;
                    ServiceProperties.Service.EditEntry = false;

                    scannerService.AddSignature();
                }
                else if (result == MessageBoxResult.No)
                {
                    txtFullName.IsEnabled = true;
                    txtDriverLicNum.IsEnabled = true;
                    txtStreetAddress.IsEnabled = true;
                    txtCity.IsEnabled = true;
                    txtState.IsEnabled = true;
                    txtZip.IsEnabled = true;
                    txtBirthDate.IsEnabled = true;
                    ServiceProperties.Service.EditEntry = true;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR MESSAGE", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            ServiceProperties.Service.ChangeView = true;
        }

        private void lblExit_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void lblExit_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void lblExit_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }        
    }
}
