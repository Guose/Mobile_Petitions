using Mobile_Petitions.BL;

namespace Mobile_Petitions.SERVICE
{
    public class LoginService
    {
        private LoginBLRepository login;

        public bool IsRememberMeNULL()
        {
            login = new LoginBLRepository();
            return login.RetrieveTableRecords();
        }
        public void GetRemberedUser()
        {
            login = new LoginBLRepository();
            login.GetUserToRemember();

            ServiceProperties.Service.RememberUser = AccessDT.Instance.RememberUser;
            ServiceProperties.Service.RememberPW = AccessDT.Instance.RememberPW;
        }

        public bool LoginPage(string userName, string password, bool rememberUser)
        {
            login = new LoginBLRepository();
            bool credentialsMatch;

            credentialsMatch = login.GetUserCredentials(userName, password);

            if (rememberUser)
            {
                login.RememberUser(userName, password);
            }
            else
            {
                login.DeleteRememberedUser();
            }

            return credentialsMatch;
        }

        public void RegisterUser(string firstName, string lastName, string address, string city, string state, string zip, string county, string userName, string email, string password, bool isAdmin)
        {
            login = new LoginBLRepository();

            login.AddUserCredentials(firstName, lastName, address, city, state, zip, county, userName, email, password, isAdmin);
        }        
    }
}
