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
        string login_first = "my_first_test";
        string email_first = "testlabatestlaba@gmail.com";
        string password_first = "12345";
        string game_for_search = "QbQbQb";
        string game_for_recomendation = "Robot Phone Home";
        string game_in_recomended_list = "Zombie Crypt";
        private Steps steps;
        [SetUp]
        public void Init()
        {
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
            steps.PublishGame();
            //((ITakesScreenshot)DriverInstance.GetInstance()).GetScreenshot().SaveAsFile(@"C:\Prokopovich\TestFramework\TestFramework\test1.jpg", ImageFormat.Jpeg);
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
    }
}
