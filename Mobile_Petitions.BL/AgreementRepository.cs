using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile_Petitions.DAL;

namespace Mobile_Petitions.BL
{
    public class AgreementRepository : IDisposable
    {
        private Mobile_PetitionsEntities mpx;

        public void DeleteDisAgreedScan()
        {
            try
            {
                using (mpx = new Mobile_PetitionsEntities())
                {
                    var deleteObject = (from o in mpx.Signatures
                                       orderby o.ID descending
                                       select o).FirstOrDefault();

                    mpx.DeleteObject(deleteObject);
                    mpx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { Dispose(); }
        }

        public void Dispose()
        {
            mpx = null;
        }
    }
}
