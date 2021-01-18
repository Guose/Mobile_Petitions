using System.Data;

namespace Mobile_Petitions.BL
{
    public sealed class AccessDT
    {
        static readonly AccessDT instance = new AccessDT();

        public static AccessDT Instance { get { return instance; } }
        public DataTable ScannedDTRaw { get; set; }
        public int UserId { get; set; }
        public string RememberUser { get; set; }
        public string RememberPW { get; set; }
        public string ScannedFirstName { get; set; }
        public string ScannedLastName { get; set; }

    }
}
