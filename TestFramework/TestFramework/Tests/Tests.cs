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
        private const string login_second = "new_test_user";
        private const string password_first = "12345";
        private const string password_second = "12345";
        private const string game_for_search = "QbQbQb";
        private const string game_for_recomendation = "Robot Phone Home";
        private const string game_in_recomended_list = "Zombie Crypt";
        private const string game2_name = "Swords and Souls";
        private const string game_uri = @"http://www.kongregate.com/games/Chman/robot-phone-home";
        private const string game2_uri = @"http://www.kongregate.com/games/SoulGame/swords-and-souls";
        private const string friend_page = @"http://www.kongregate.com/accounts/KoTDusic";
        private const string first_user_page = @"http://www.kongregate.com/accounts/my_first_test";
        private const string second_user_page = @"http://www.kongregate.com/accounts/new_test_user";
        private const string friend_nick = "KoTDusic";
        private const string old_password = "12345";
        private const string new_password = "123456";
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
        public void ChekLoginingOnSite()
        {
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.IsLoggedIn(login_first));
            steps.LogOut();
        }
        [Test]
        public void AvatarUpload()
        {
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.GoToEditProfileAndUploadPhoto());
            steps.LogOut();
        }
        [Test]
        public void GameUploading()
        {
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.PublishGame());
            steps.LogOut();

        }
        [Test]
        public void GameSerchByName()
        {
            Assert.IsTrue(steps.SerachGame(game_for_search));
        }
        [Test]
        public void GameRecomendations()
        {
            Assert.IsTrue(steps.SearchAndNavigateGameAndCheckRecomendedList
                (game_for_recomendation, game_in_recomended_list));
        }
        [Test]
        public void RateGame()
        {
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.RateGame(game_uri));
            steps.LogOut();
        }
        [Test]
        public void LastPlayedTest()
        {
            steps.LoginKongregate(email_first, password_first);
            steps.OpenGamePage(game2_uri);
            steps.Wait(10000);
            Assert.IsTrue(steps.CheckLastPlayed(game2_name));
            steps.LogOut();
        }
        [Test]
        public void ChangePassword()
        {
                steps.LoginKongregate(email_first, password_first);
                steps.ChangePasswordAndLogout(old_password, new_password);
                Assert.IsFalse(steps.TryLogin(email_first, password_first));
                steps.RefreshPage();
                steps.LoginKongregate(email_first, new_password);
                steps.ChangePasswordAndLogout(new_password, old_password);
        }
        [Test]
        public void FeedTest()
        {
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.TryMakePostInFeed(NameGenerator.GenerateUnicName()));
            steps.LogOut();
        }
        [Test]
        public void LikePostInFeed()
        {
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.TryLikeTopPost());
            steps.LogOut();
        }
        [Test]
        public void AddFriend()
        {
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.TryAddToFriend(friend_page,friend_nick));
            steps.LogOut();
        }
        [Test]
        public void PrivateMessage()
        {
            steps.LoginKongregate(login_second, password_second);
            string sended_message = NameGenerator.GenerateUnicName();
            steps.SendMessage(first_user_page, sended_message);
            steps.LogOut();
            steps.LoginKongregate(login_first, password_first);
            string reseved_message = steps.CheckRecevedMessage();
            Assert.AreEqual(reseved_message, sended_message);
            steps.LogOut();
        }
        [Test]
        public void MyteTest()
        {
            steps.LoginKongregate(login_first, password_first);
            steps.ChangeUserMuteStatus(second_user_page);
            steps.LogOut();
            steps.LoginKongregate(login_second, password_second);
            string sending_message = NameGenerator.GenerateUnicName();
            bool result = steps.TrySendMessage(first_user_page, sending_message);
            steps.LogOut();
            steps.LoginKongregate(login_first, password_first);
            steps.ChangeUserMuteStatus(second_user_page);
            steps.LogOut();
            Assert.IsTrue(result);
        }
        [Test]
        public void AddToPlaylist()
        {
            steps.LoginKongregate(login_first, password_first);
            Assert.IsTrue(steps.TrySetInPlaylist(game2_uri));
            steps.LogOut();
        }
        [Test]
        public void LikeGameTest()
        {
            steps.LoginKongregate(login_first, password_first);
            Assert.IsTrue(steps.TrySetLike(game2_uri));
            steps.LogOut();
        }
    }
}
