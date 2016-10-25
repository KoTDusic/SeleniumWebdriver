using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Pages;
using OpenQA.Selenium;
using System.Threading;
//git/cmd в качестве имени версия программы
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
        public bool RateGame(string url)
        {
            GamePage gamePage = new GamePage(driver);
            gamePage.OpenPage(url);
            gamePage.SetRate(3);
            Wait(2000);
            string rate = gamePage.GetCurrentGameRate();
            driver.Navigate().Refresh();
            string new_rate=gamePage.GetCurrentGameRate();
            bool passed=String.Equals(rate,new_rate);
            gamePage.SetRate(1);
            return passed;
        }
        public bool CheckLastPlayed(string game_name)
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.OpenPage();
            Profile profilePage = mainPage.ProfileClick();
            string game=profilePage.GetLastPlayedGame();
            return String.Equals(game.ToLower(), game_name.ToLower());
        }
        public void OpenGamePage(string uri)
        {
            GamePage gamePage = new GamePage(driver);
            gamePage.OpenPage(uri);
        }
        public void Wait(int time)
        {
            Thread.Sleep(time);
        }
        public void ChangePasswordAndLogout(string current_password,string new_password)
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.OpenPage();
            mainPage.ProfileClick().ClickEditProfile().ChangePassword(current_password, new_password);
            mainPage.LogOut();
        }
        public bool TryLogin(string login,string password)
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.OpenPage();
            mainPage.Login(login, password);
            string ErrorMessage = "No account with that email address and password could be found.";
            string GetedReturnMessage = mainPage.GetErrorMessage();
            return !String.Equals(GetedReturnMessage.ToLower(), ErrorMessage.ToLower());
        }
        public bool TryMakePostInFeed(string text)
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.OpenPage();
            Profile profilePage = mainPage.ProfileClick();
            profilePage.MakePost(text);
            RefreshPage();
            return profilePage.HasPostInFeed(text);
        }
        public bool TryLikeTopPost()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.OpenPage();
            Profile profilePage = mainPage.ProfileClick();
            profilePage.ClickLikeButtonOnTopPost();
            RefreshPage();
            bool result = profilePage.TopPostIsLiked();
            profilePage.ClickLikeButtonOnTopPost();
            return result;
        }
        public void RefreshPage()
        {
            driver.Navigate().Refresh();

        }
    }
}
