using System;
using System.Data;
using System.IO;
using Mobile_Petitions.BL;
using System.Globalization;

namespace Mobile_Petitions.SERVICE
{
    public class ScannerService
    {
        private ScannerRepository scannerRepo;
        public string ScanFullName { get; set; }
        public string ScanBirthDate { get; set; }
        public string ScanDLNumber { get; set; }
        public string ScanAddress { get; set; }
        public string ScanCity { get; set; }
        public string ScanState { get; set; }
        public string ScanZipCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ScannerService(string path) : this()
        {
            _filePath = path;
        }
        public ScannerService()
        {

        }

        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }


        public string GetSignatureClip()
        {
            string name = string.Empty;

            scannerRepo = new ScannerRepository();
            scannerRepo.GetLastRecordScanned();

            ServiceProperties.Service.ScannedFirstName = AccessDT.Instance.ScannedFirstName;
            ServiceProperties.Service.ScannedLastName = AccessDT.Instance.ScannedLastName;

            name = AccessDT.Instance.ScannedFirstName + AccessDT.Instance.ScannedLastName + "-Sig.tif";

            return name;
        }


        public void AddSignature()
        {
            scannerRepo = new ScannerRepository();

            scannerRepo.Suffix = string.Empty;

            string[] names = ScanFullName.Split(' ');

            string date = $"{ScanBirthDate.Substring(0, 2)}/{ScanBirthDate.Substring(2, 2)}/{ScanBirthDate.Substring(4, 4)}";
            //DateTime bDay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            scannerRepo.FirstName = names[0];
            scannerRepo.MiddleName = names[1];
            scannerRepo.LastName = names[2];
            scannerRepo.Birthdate = DateTime.Parse(date);
            scannerRepo.DLNumber = ScanDLNumber;
            scannerRepo.Address = ScanAddress;
            scannerRepo.City = ScanCity;
            scannerRepo.State = ScanState;
            scannerRepo.ZipCode = ScanZipCode;

            FirstName = scannerRepo.FirstName;
            LastName = scannerRepo.LastName;

            if (names.Length > 3)
            {
                scannerRepo.Suffix = names[3];
            }

            scannerRepo.AddSignature();
        }


        public void ScanDLBarcode()
        {
            DataTable dt = new DataTable();
            int x = 0;
            string[] items = new string[10];
            string[] dlPrefix = new string[] { "DCS", "DCT", " ", "DBB", "DAG",
                "DAI", "DAJ", "DAK", "DAQ", " " };

            string[] newDlPrefix = new string[] { "DAC", "DAD", " " };

            string line = string.Empty;

            try
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    int i = 0;
                    int n = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line != string.Empty && line.Length >= 3 && line.Substring(0, 3) == dlPrefix[i])
                        {
                            bool hasSpace = line.Contains(" ");

                            if (hasSpace && dlPrefix[i].Substring(0, 3) == "DCT")
                            {
                                string[] split = line.Split(null);
                                items[i] = split[0].Substring(3, split[0].Length - 3);
                                i++;
                                items[i] = split[1];
                            }
                            else
                            {
                                items[i] = line.Substring(3, line.Length - 3);
                            }
                            i++;
                        }
                        else if (line != string.Empty && line.Length >= 3 && line.Substring(0, 3) == newDlPrefix[n])
                        {
                            items[i] = line.Substring(3, line.Length - 3);
                            i++;
                            n++;
                        }
                    }
                }

                dt = CreateDLRawDataTable(dt);
                dt.Rows.Add();

                foreach (DataColumn dc in dt.Columns)
                {
                    dt.Rows[0][dc.ColumnName] = items[x];
                    x++;
                }

                AccessDT.Instance.ScannedDTRaw = dt;

                PopulateScannedData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void PopulateScannedData()
        {
            string firstName = AccessDT.Instance.ScannedDTRaw.Rows[0]["First Name"].ToString();
            string middleName = AccessDT.Instance.ScannedDTRaw.Rows[0]["Middle Name"].ToString();
            string lastName = AccessDT.Instance.ScannedDTRaw.Rows[0]["Last Name"].ToString();

            ScanFullName = $"{firstName} {middleName} {lastName}";            
            ScanBirthDate = AccessDT.Instance.ScannedDTRaw.Rows[0]["BirthDate"].ToString();
            ScanDLNumber = AccessDT.Instance.ScannedDTRaw.Rows[0]["License Number"].ToString();
            ScanAddress = AccessDT.Instance.ScannedDTRaw.Rows[0]["Street Address"].ToString();
            ScanCity = AccessDT.Instance.ScannedDTRaw.Rows[0]["City"].ToString();
            ScanState = AccessDT.Instance.ScannedDTRaw.Rows[0]["State"].ToString();
            ScanZipCode = AccessDT.Instance.ScannedDTRaw.Rows[0]["Postal Code"].ToString();
        }

        private DataTable CreateDLRawDataTable(DataTable dt)
        {
            dt.Columns.Add("Last Name", typeof(string));
            dt.Columns.Add("First Name", typeof(string));
            dt.Columns.Add("Middle Name", typeof(string));
            dt.Columns.Add("BirthDate", typeof(string));
            dt.Columns.Add("Street Address", typeof(string));
            dt.Columns.Add("City", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("Postal Code", typeof(string));
            dt.Columns.Add("License Number", typeof(string));

            return dt;
        }
    }
}
