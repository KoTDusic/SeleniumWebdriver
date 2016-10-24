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
            mainPage.OpenPage();
            EditProfile editPage = mainPage.ProfileClick().ClickEditProfile();
            Profile profilePage=editPage.UploadPhoto();
            return profilePage.ContainSucessMessage();
        }
        public void LogOut()
        {
            new MainPage(driver).LogOut();
        }
        public bool SerachGame(string name)
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.OpenPage();
            SearchPage searchPage = mainPage.FindGame(name);
            return searchPage.ContainGame(name);
        }
        public bool SearchAndNavigateGameAndCheckRecomendedList(string game_name,string check_game)
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.OpenPage();
            SearchPage searchPage = mainPage.FindGame(game_name);
            GamePage gamePage = searchPage.OpenGame(game_name);
            gamePage.MoreGamesClick();
            return gamePage.CheckGameInRecommendedList(check_game);
        }
        public bool PublishGame()
        {
            GameUploadPageStep1 uploadPage1 = new GameUploadPageStep1(driver);
            uploadPage1.OpenPage();
            string game_name = NameGenerator.GenerateUnicName();
            uploadPage1.FillFields(game_name);
            GameUploadPageStep2 uploadPage2 = uploadPage1.PressContinue();
            uploadPage2.FillFields();
            uploadPage2.ClickUpload();
            uploadPage2.WaitUpload(game_name);
            MainPage mainPage = new MainPage(driver);
            mainPage.OpenPage();
            Profile profilePage = mainPage.ProfileClick();
            return profilePage.HasGameInRecent(game_name);
        }
    }
}
