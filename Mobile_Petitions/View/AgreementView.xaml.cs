using System;
using System.Windows;
using System.Windows.Controls;
using Mobile_Petitions.SERVICE;
using Microsoft.Office.Interop.Word;
using System.Windows.Xps.Packaging;
using System.IO;
using System.Windows.Input;

namespace Mobile_Petitions.Views
{
    /// <summary>
    /// Interaction logic for AgreementView.xaml
    /// </summary>
    public partial class AgreementView : UserControl
    {
        const string _ROOT_DIRECTORY = @"..\..\";
        private XpsDocument xpsDoc;
        public AgreementView()
        {
            InitializeComponent();

            //string deleteXPS = Path.GetDirectoryName(ServiceProperties.Service.PetitionSummaryPath);
            string[] xpsDoc = Directory.GetFiles(_ROOT_DIRECTORY, "*.xps");

            if (xpsDoc.Length > 0)
            {        
                string deleteFile = xpsDoc[0];
                File.Delete(deleteFile);
            }           

            PopulateDocumentViewer();
        }

        private XpsDocument ConvertWordDocToXPSDoc(string wordDocName, string xpsDocName)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Documents.Add(wordDocName);

            Document doc = wordApp.ActiveDocument;

            try
            {
                doc.SaveAs2(xpsDocName, WdSaveFormat.wdFormatXPS);
                wordApp.Quit();

                xpsDoc = new XpsDocument(xpsDocName, FileAccess.Read);
                return xpsDoc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        private void PopulateDocumentViewer()
        {
            DirectoryInfo rootDirectory;
            FileInfo[] files;
            try
            {
                //string summaryPath = Path.GetDirectoryName(_ROOT_DIRECTORY);

                rootDirectory = new DirectoryInfo(_ROOT_DIRECTORY);

                if (rootDirectory != null)
                {
                    files = rootDirectory.GetFiles("*.docx", SearchOption.AllDirectories);
                    string fileName = files[0].FullName;

                    string newXPSDocumentName = string.Concat(Path.GetDirectoryName(fileName), "\\",
                        Path.GetFileNameWithoutExtension(fileName), ".xps");


                    documentViewer.Document = ConvertWordDocToXPSDoc(fileName, newXPSDocumentName).GetFixedDocumentSequence();
                    documentViewer.FitToWidth();

                    Cursor = Cursors.Arrow;

                    string newFileName = Path.GetFileNameWithoutExtension(fileName);

                    lblPetitionNum.Content = newFileName;
                }
            }
            catch (Exception ex)
            {
                Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(ex.Message, "ERROR MESSAGE", MessageBoxButton.OK, MessageBoxImage.Error)),
                    System.Windows.Threading.DispatcherPriority.Normal);
            }
            finally
            {
                if (xpsDoc != null)
                {
                    xpsDoc.Close();
                }                
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (radDecline.IsChecked == true)
            {
                AgreementService agreeServ = new AgreementService();
                ServiceProperties.Service.DeclineAgreement = true;

                agreeServ.RemoveLastEntry();
            }
            else
            {
                ServiceProperties.Service.DeclineAgreement = false;
            }
        }
    }
}
