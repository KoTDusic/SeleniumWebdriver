using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing.Imaging;
using log4net;
using log4net.Config;

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
        public void LoginTest()
        {
            Log.For(this).Info("Start LoginTest");
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.IsLoggedIn(login_first));
            steps.LogOut();
            Log.For(this).Info("End LoginTest");
        }
        [Test]
        public void AvatarUploadTest()
        {
            Log.For(this).Info("Start AvatarUploadTest");
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.GoToEditProfileAndUploadPhoto());
            steps.LogOut();
            Log.For(this).Info("End AvatarUploadTest");
        }
        [Test]
        public void GameUploadingTest()
        {
            Log.For(this).Info("Start GameUploadingTest");
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.PublishGame());
            steps.LogOut();
            Log.For(this).Info("End GameUploadingTest");

        }
        [Test]
        public void GameSerchByNameTest()
        {
            Log.For(this).Info("Start GameSerchByNameTest");
            Assert.IsTrue(steps.SerachGame(game_for_search));
            Log.For(this).Info("End GameSerchByNameTest");
        }
        [Test]
        public void GameRecomendationsTest()
        {
            Log.For(this).Info("Start GameRecomendationsTest");
            Assert.IsTrue(steps.SearchAndNavigateGameAndCheckRecomendedList
                (game_for_recomendation, game_in_recomended_list));
            Log.For(this).Info("End GameRecomendationsTest");
        }
        [Test]
        public void RateGameTest()
        {
            Log.For(this).Info("Start RateGameTest");
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.RateGame(game_uri));
            steps.LogOut();
            Log.For(this).Info("End RateGameTest");
        }
        [Test]
        public void LastPlayedTest()
        {
            Log.For(this).Info("Start LastPlayedTest");
            steps.LoginKongregate(email_first, password_first);
            steps.OpenGamePage(game2_uri);
            steps.Wait(10000);
            Assert.IsTrue(steps.CheckLastPlayed(game2_name));
            steps.LogOut();
            Log.For(this).Info("End LastPlayedTest");
        }
        [Test]
        public void ChangePasswordTest()
        {
            Log.For(this).Info("Start ChangePasswordTest");
            steps.LoginKongregate(email_first, password_first);
            steps.ChangePasswordAndLogout(old_password, new_password);
            Assert.IsFalse(steps.TryLogin(email_first, password_first));
            steps.RefreshPage();
            steps.LoginKongregate(email_first, new_password);
            steps.ChangePasswordAndLogout(new_password, old_password);
            Log.For(this).Info("End ChangePasswordTest");
        }
        [Test]
        public void FeedPostingTest()
        {
            Log.For(this).Info("Start FeedPostingTest");
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.TryMakePostInFeed(NameGenerator.GenerateUnicName()));
            steps.LogOut();
            Log.For(this).Info("End FeedPostingTest");
        }
        [Test]
        public void LikePostInFeedTest()
        {
            Log.For(this).Info("Start LikePostInFeedTest");
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.TryLikeTopPost());
            steps.LogOut();
            Log.For(this).Info("End LikePostInFeedTest");
        }
        [Test]
        public void AddFriendTest()
        {
            Log.For(this).Info("Start AddFriendTest");
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.TryAddToFriend(friend_page,friend_nick));
            steps.LogOut();
            Log.For(this).Info("End AddFriendTest");
        }
        [Test]
        public void PrivateMessageTest()
        {
            Log.For(this).Info("Start PrivateMessageTest");
            steps.LoginKongregate(login_second, password_second);
            string sended_message = NameGenerator.GenerateUnicName();
            steps.SendMessage(first_user_page, sended_message);
            steps.LogOut();
            steps.LoginKongregate(login_first, password_first);
            string reseved_message = steps.CheckRecevedMessage();
            steps.LogOut();
            Assert.AreEqual(reseved_message, sended_message);
            Log.For(this).Info("End PrivateMessageTest");
        }
        [Test]
        public void MyteTest()
        {
            Log.For(this).Info("Start MyteTest");
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
            Log.For(this).Info("End MyteTest");
        }
        [Test]
        public void AddToPlaylist()
        {
            Log.For(this).Info("Start AddToPlaylist");
            steps.LoginKongregate(login_first, password_first);
            Assert.IsTrue(steps.TrySetInPlaylist(game2_uri));
            steps.LogOut();
            Log.For(this).Info("End AddToPlaylist");
        }
        [Test]
        public void LikeGameTest()
        {
            Log.For(this).Info("Start LikeGameTest");
            steps.LoginKongregate(login_first, password_first);
            Assert.IsTrue(steps.TrySetLike(game2_uri));
            steps.LogOut();
            Log.For(this).Info("End LikeGameTest");
        }
    }
}
