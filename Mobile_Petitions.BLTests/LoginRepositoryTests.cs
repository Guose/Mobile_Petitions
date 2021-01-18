using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mobile_Petitions.BL;
using Mobile_Petitions.DAL;
using Mobile_Petitions.SERVICE;

namespace Mobile_Petitions.BLTests
{
    [TestClass]
    public class LoginRepositoryTests
    {
        [TestMethod()]
        public void RememberUserAndPW()
        {
            ////Arrange
            //var repository = new LoginBLRepository();
            //var expectedUser = "admin";
            //var expectedPw = "admin";
            //repository.RememberUser(expectedUser, expectedPw);

            ////Act
            //repository.GetUserToRemember();
            //var actualUser = AccessDT.Instance.RememberUser;
            //var acutalPW = AccessDT.Instance.RememberPW;

            ////Assert
            //Assert.AreEqual(expectedUser, actualUser);
            //Assert.AreEqual(expectedPw, acutalPW);
        }

        [TestMethod()]
        public void LoginAsAdministrator()
        {
            //Arrange
            var login = new LoginService();
            var expected = true;

            //Act
            var actual = login.LoginPage("admin", "admin", false);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
