using Mobile_Petitions.DAL;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Mobile_Petitions.BL
{
    public class LoginBLRepository : LoginBL, IDisposable
    {
        private Mobile_PetitionsEntities mpx;

        private LoginBL login;

        public LoginBL Login
        {
            get { return login; }
            set { login = value; }
        }

        public bool RetrieveTableRecords()
        {
            try
            {
                using (mpx = new Mobile_PetitionsEntities())
                {
                    var isTableNull = from t in mpx.RememberUsers
                                      select t;

                    if (isTableNull.Any())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GetUserToRemember()
        {
            try
            {
                using (mpx = new Mobile_PetitionsEntities())
                {
                    var latestEntry = from l in mpx.RememberUsers
                                      group l by l.ReUser into rem
                                      select rem.OrderByDescending(t => t.DateEntered).FirstOrDefault();

                    foreach (var item in latestEntry)
                    {
                        AccessDT.Instance.RememberPW = item.RePassword;
                        AccessDT.Instance.RememberUser = item.ReUser;
                    }                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                Dispose();
            }
        }

        public void DeleteRememberedUser()
        {
            try
            {
                mpx = new Mobile_PetitionsEntities();

                var deleteRecords = from u in mpx.RememberUsers
                                    select u;

                foreach (var item in deleteRecords)
                {
                    mpx.DeleteObject(item);
                }
                mpx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RememberUser(string user, string pass)
        {
            try
            {
                using (mpx = new Mobile_PetitionsEntities())
                {
                    DeleteRememberedUser();

                    RememberUser rememberUser = new RememberUser();
                    {
                        rememberUser.ReUser = user;
                        rememberUser.RePassword = pass;
                        rememberUser.DateEntered = DateTime.Now;
                    };
                    mpx.RememberUsers.AddObject(rememberUser);
                    //mpx.AddToRememberUsers(rememberUser);

                    //mpx.ObjectStateManager.ChangeObjectState(mpx.RememberUsers, EntityState.Added);
                    mpx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                Dispose();
            }
        }
        
        public bool GetUserCredentials(string user, string password)
        {
            DataTable dt = new DataTable();
            try
            {
                using (mpx = new Mobile_PetitionsEntities())
                {
                    var queryUser = from u in mpx.Circulators
                                    where u.UserName == user && u.Password == password
                                    select u;                    

                    if (queryUser.SingleOrDefault() != null)
                    {
                        foreach (var item in queryUser)
                        {
                            AccessDT.Instance.UserId = item.CirculatorID;
                        }
                        return true;
                    }
                    else
                    {
                        Dispose();
                        return false;
                    }                   
                }
            }
            catch (Exception ex)
            {
                throw new NullReferenceException(ex.Message);
            }

            finally
            {
                Dispose();
            }
        }

        public void AddUserCredentials(string firstName, string lastName, string address, string city, string state, string zip, string county, string user, string email, string password, bool isAdmin)
        {
            try
            {
                using (mpx = new Mobile_PetitionsEntities())
                {
                    Circulator userInstance = new Circulator();
                    {
                        userInstance.FirstName = firstName;
                        userInstance.LastName = lastName;
                        userInstance.Address = address;
                        userInstance.City = city;
                        userInstance.State = state;
                        userInstance.ZipCode = zip;
                        userInstance.County = county;
                        userInstance.UserName = user;
                        userInstance.Password = password;
                        userInstance.Admin = isAdmin;
                        userInstance.Email = email;

                        // Signature Clip file name needs to be unique.
                        userInstance.CircSigClip = firstName + lastName + "-Sig.tif";
                    };

                    mpx.Circulators.AddObject(userInstance);
                    //mpx.ObjectStateManager.ChangeObjectState(mpx.Circulators, EntityState.Added);
                    mpx.SaveChanges();                    
                }
            }
            catch (Exception ex)
            {
                throw new NullReferenceException(ex.Message);
            }

            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            mpx = null;
        }
    }
}
