using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Pages;
using OpenQA.Selenium;

namespace TestFramework
{
    public class Steps
    {
        IWebDriver driver;
        public void InitBrowser()
        {
            driver = DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            DriverInstance.CloseBrowser();
        }
        public void LoginKongregate(string username, string password)
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.OpenPage();
            mainPage.Login(username, password);
        }
        public bool IsLoggedIn(string username)
        {
            MainPage mainPage = new MainPage(driver);
            return (mainPage.GetLoggedInUserName().Trim().Equals(username));
        }
        public bool GoToEditProfileAndUploadPhoto()
        {
            MainPage mainPage = new MainPage(driver);
            EditProfile editPage = mainPage.ProfileClick().ClickEditProfile();
            Profile profilePage=editPage.UploadPhoto();
            return profilePage.ContainSucessMessage();
        }
        public void LogOut()
        {
            new MainPage(driver).LogOut();
        }
    }
}
