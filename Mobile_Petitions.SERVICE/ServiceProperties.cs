using System.Data;


namespace Mobile_Petitions.SERVICE
{
    public sealed class ServiceProperties
    {
        static readonly ServiceProperties service = new ServiceProperties();

        public static ServiceProperties Service { get { return service; } }

        public bool CredentialsVerified { get; set; }
        public string PetitionSummaryPath { get; set; }
        public bool DeclineAgreement { get; set; }
        public bool ChangeView { get; set; }
        public bool EditEntry { get; set; }
        public bool RememberLoggedInUser { get; set; }
        public string RememberUser { get; set; }
        public string RememberPW { get; set; }
        public string ScannedFirstName { get; set; }
        public string ScannedLastName { get; set; }
    }
}
