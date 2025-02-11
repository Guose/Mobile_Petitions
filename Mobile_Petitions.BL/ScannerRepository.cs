using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Mobile_Petitions.DAL;
using System.Windows;
using System.Globalization;

namespace Mobile_Petitions.BL
{
    public class ScannerRepository : Scanner, IDisposable
    {
        private Mobile_PetitionsEntities mpx;

        public void GetLastRecordScanned()
        {
            try
            {
                using (mpx = new Mobile_PetitionsEntities())
                {
                    var lastScanned = from s in mpx.Signatures
                                      group s by s.ID into scan
                                      select scan.OrderByDescending(l => l.DateSigned).FirstOrDefault();

                    foreach (var item in lastScanned)
                    {
                        AccessDT.Instance.ScannedFirstName = item.FirstName;
                        AccessDT.Instance.ScannedLastName = item.LastName;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public void AddSignature()
        {
            //string month = Birthdate.ToString("M");
            //string day = Birthdate.ToString("d");
            //string year = Birthdate.ToString("yyyy");

            string date = String.Format("{0:M/d/yyyy}", Birthdate);

           // string date = $"{year}/{month}/{day}";

            try
            {
                if (!CheckForDuplicateRecordScanned())
                { 
                    using (mpx = new Mobile_PetitionsEntities())
                    {
                        Signature sigs = new Signature();
                        {
                            sigs.FirstName = FirstName;
                            sigs.MiddleName = MiddleName;
                            sigs.LastName = LastName;
                            sigs.Suffix = Suffix;
                            sigs.BirthDate = DateTime.ParseExact(date, "M/d/yyyy", CultureInfo.InvariantCulture);
                            sigs.DLNumber = DLNumber;
                            sigs.Address = Address;
                            sigs.City = City;
                            sigs.State = State;
                            sigs.Zip = ZipCode;
                            sigs.DateSigned = DateTime.Now;
                            sigs.SignatureClip = FirstName + LastName + "-Sig.tif";
                            sigs.CirculatorID = AccessDT.Instance.UserId;
                        };

                        mpx.Signatures.AddObject(sigs);
                        mpx.ObjectStateManager.ChangeObjectState(sigs, EntityState.Added);
                        mpx.SaveChanges();
                    }
                }
                else
                {
                    MessageBox.Show("DUPLICATE SCAN! /n/nThis person is already in the system and has signed this petition.", "ERROR DUPLICATE SCAN", MessageBoxButton.OKCancel, MessageBoxImage.Stop);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally { Dispose(); }
        }

        private bool CheckForDuplicateRecordScanned()
        {
            try
            {
                using (mpx = new Mobile_PetitionsEntities())
                {
                    var duplicates = from dup in mpx.Signatures
                                     where DLNumber == dup.DLNumber
                                     select dup;

                    return duplicates.Any();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void Dispose()
        {
            mpx = null;
        }
    }
}
