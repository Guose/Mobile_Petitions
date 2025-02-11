using Mobile_Petitions.BL;

namespace Mobile_Petitions.SERVICE
{
    public class AgreementService
    {
        private AgreementRepository agreeRepo;

        public void RemoveLastEntry()
        {
            agreeRepo = new AgreementRepository();

            agreeRepo.DeleteDisAgreedScan();
        }
    }
}
