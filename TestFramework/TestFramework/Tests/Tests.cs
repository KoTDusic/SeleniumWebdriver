using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing.Imaging;

namespace TestFramework
{
    [TestFixture]
    public class Tests
    {
        private const string login_first = "my_first_test";
        private const string email_first = "testlabatestlaba@gmail.com";
        private const string password_first = "12345";
        private const string game_for_search = "QbQbQb";
        private const string game_for_recomendation = "Robot Phone Home";
        private const string game_in_recomended_list = "Zombie Crypt";
        private const string game2_name = "Swords and Souls";
        private const string game_uri = @"http://www.kongregate.com/games/Chman/robot-phone-home";
        private const string game2_uri = @"http://www.kongregate.com/games/SoulGame/swords-and-souls";
        private Steps steps;
        [SetUp]
        public void Init()
        {
            //((ITakesScreenshot)DriverInstance.GetInstance()).GetScreenshot().SaveAsFile(@"C:\Prokopovich\TestFramework\TestFramework\test1.jpg", ImageFormat.Jpeg);
            steps = new Steps();
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            //steps.CloseBrowser();
        }
        [Test]
        public void _1_ChekLoginingOnSite()
        {
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.IsLoggedIn(login_first));
            steps.LogOut();
        }
        [Test]
        public void _2_AvatarUpload()
        {
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.GoToEditProfileAndUploadPhoto());
            steps.LogOut();
        }
        [Test]
        public void _3_GameUploading()
        {
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.PublishGame());
            
        }
        [Test]
        public void _4_GameSerch()
        {
            Assert.IsTrue(steps.SerachGame(game_for_search));
        }
        [Test]
        public void _5_GameRecomendations()
        {
            Assert.IsTrue(steps.SearchAndNavigateGameAndCheckRecomendedList
                (game_for_recomendation, game_in_recomended_list));
        }
        [Test]
        public void _6_RateGame()
        {
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.RateGame(game_uri));
        }
        [Test]
        public void _7_LastPlayedTest()
        {
            steps.LoginKongregate(email_first, password_first);
            steps.OpenGamePage(game2_uri);
            steps.Wait(2000);
            Assert.IsTrue(steps.CheckLastPlayed(game2_name));
        }
        [Test]
        public void _8_ChangePassword()
        {
                steps.LoginKongregate(email_first, password_first);
                steps.ChangePasswordAndLogout("12345", "123456");
                Assert.IsFalse(steps.TryLogin(email_first, password_first));
                steps.RefreshPage();
                steps.LoginKongregate(email_first, "123456");
                steps.ChangePasswordAndLogout("123456", "12345");
        }
        [Test]
        public void _9_FeedTest()
        {
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.TryMakePostInFeed(NameGenerator.GenerateUnicName()));
        }
        [Test]
        public void _10_LikePostInFeed()
        {
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.TryLikeTopPost());
        }
    }
}
