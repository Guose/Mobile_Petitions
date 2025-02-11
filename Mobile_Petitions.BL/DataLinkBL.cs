using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile_Petitions.DAL;

namespace Mobile_Petitions.BL
{
    public class DataLinkBL : Scanner, IDisposable
    {
        public int RecordCount { get; set; }
        public string[] DataLinkArr { get; set; }

        public string DataLinkCode { get; set; }
        public bool IsDataLink { get; set; }

        Scanner scanner;
        Mobile_PetitionsEntities mpx;


        public int DataLinkCodeM1()
        {
            scanner = new Scanner();
            int i = 0;

            try
            {
                using (mpx = new Mobile_PetitionsEntities())
                {
                    var dataLinkM1 = from m1 in mpx.VRImports
                                     where scanner.DLNumber == m1.DriverLicenseNumber
                                     select m1;

                    if (dataLinkM1.Any())
                    {
                        foreach (var voter in dataLinkM1)
                        {
                            DataLinkArr[i] = voter.ToString();
                        }

                        RecordCount = DataLinkArr.Length;
                    }
                }
                return RecordCount;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally { this.Dispose(); }            
        }

        public int DataLinkCodeM2()
        {
            scanner = new Scanner();
            int i = 0;

            try
            {
                using (mpx = new Mobile_PetitionsEntities())
                {
                    var dataLinkM2 = from m2 in mpx.VRImports
                                     where scanner.Birthdate.ToString("M/d/yyyy") == m2.BirthDate.ToString() 
                                     && scanner.Address == m2.Address 
                                     && scanner.City == m2.City
                                     && scanner.State == m2.State 
                                     && scanner.ZipCode == m2.ZipCode 
                                     && scanner.FirstName == m2.FirstName 
                                     && scanner.MiddleName.Substring(0,1) == m2.MiddleName.Substring(0,1) 
                                     && scanner.LastName == m2.LastName
                                     select m2;

                    if (dataLinkM2.Any())
                    {
                        foreach (var voter in dataLinkM2)
                        {
                            DataLinkArr[i] = voter.ToString();
                        }

                        RecordCount = DataLinkArr.Length;
                    }
                }
                return RecordCount;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally { this.Dispose(); }
        }

        public int DataLinkCodeM3()
        {
            scanner = new Scanner();
            int i = 0;

            try
            {
                using (mpx = new Mobile_PetitionsEntities())
                {
                    var dataLinkM3 = from m3 in mpx.VRImports
                                     where scanner.Birthdate.ToString("M/d/yyyy") == m3.BirthDate.ToString() 
                                     && scanner.Address == m3.Address 
                                     && scanner.City == m3.City
                                     && scanner.State == m3.State 
                                     && scanner.ZipCode == m3.ZipCode 
                                     && scanner.FirstName == m3.FirstName
                                     && scanner.LastName == m3.LastName
                                     select m3;

                    if (dataLinkM3.Any())
                    {
                        foreach (var voter in dataLinkM3)
                        {
                            DataLinkArr[i] = voter.ToString();
                        }

                        RecordCount = DataLinkArr.Length;
                    }
                }
                return RecordCount;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally { this.Dispose(); }
        }

        public void Dispose()
        {
            mpx = null;
            DataLinkArr = null;
        }
    }
}
