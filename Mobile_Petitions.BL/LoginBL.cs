namespace Mobile_Petitions.BL
{
    public partial class LoginBL
    {
        private bool rememberMe;
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get { return rememberMe; } set { rememberMe = value; } }
        public bool RememberMe { get; set; }
        public string Email { get; set; }

    }
}
