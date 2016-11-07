using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Interactions;
using System.Threading;
#pragma warning disable 649

namespace TestFramework.Pages
{
    public class Profile : AbstractPage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Edit Profile')]")]
        private IWebElement EditProfileButton;
        [FindsBy(How = How.XPath, Using = "//a[text()='Recent']")]
        private IWebElement ResentPlay;
        [FindsBy(How = How.XPath, Using = "//div[@id='profile_heading']/div/p/a")]
        private IWebElement Last_played_game_text;
        [FindsBy(How = How.Id, Using = "shout_content")]
        private IWebElement Submiting_text;
        [FindsBy(How = How.Id, Using = "shout_box_submission_button")]
        private IWebElement Submiting_button;
        [FindsBy(How = How.XPath, Using = "//div[@id='profile_account_actions']/ul/li[1]/a")]
        private IWebElement FriendButton;
        [FindsBy(How = How.XPath, Using = "//div[@id='friends_pod']//ul//p")]
        private IWebElement FriendName;
        [FindsBy(How = How.XPath, Using = "//div[@id='profile_account_actions']/ul/li[2]/a")]
        private IWebElement PrivateMessageButton;
        [FindsBy(How = How.Id, Using = "my-messages-link")]
        private IWebElement MyMessagesButton;
        [FindsBy(How = How.XPath, Using = "//li[@id='pm_tab']/a")]
        private IWebElement PrivateMessages;
        [FindsBy(How = How.XPath, Using = "//div[@id='shouts_table']/div[1]/div[2]/div[1]/p")]
        private IWebElement TopRecevedMessage;
        [FindsBy(How = How.XPath, Using = "//div[@id='profile_account_actions']/ul/li[3]")]
        private IWebElement MoreOptionsButton;
        [FindsBy(How = How.XPath, Using = "//ul[@id='profile_tools_dropdown']/li[1]/span/a")]
        private IWebElement MuteButton;
        private string post_list_locator = "//div[@class='feed_shout_message']/p";
        private string recent_games_list_locator = "//div[@id='dynamic-tab-1']/ul//p/strong/a";
        private string like_button_locator = "//ul[@id='feed_items_container']/li[1]//a[@class='like_link']";
        private string like_button_text_locator = "//ul[@id='feed_items_container']/li[1]//a[@class='like_link']/span";
        private string sucess_message_locator = "//div[@id='global']/div/h2";
        public Profile(IWebDriver driver) : base(driver) { }
        public EditProfile ClickEditProfile()
        {
            EditProfileButton.Click();
            return new EditProfile(driver);
        }
        public string GetLastPlayedGame()
        {
            return Last_played_game_text.Text.Trim();
        }
        public bool ContainSucessMessage()
        {
            IWebElement SucessMessage = driver.FindElement(By.XPath(sucess_message_locator));
            if (SucessMessage == null) return false;
            Log.For(this).Info("profile has been updated");
            return String.Equals(SucessMessage.Text, "Your profile has been updated.");
        }
        public bool HasGameInRecent(string gameName)
        {
           ResentPlay.Click();
           IReadOnlyCollection<IWebElement> games = driver.FindElements(By.XPath(recent_games_list_locator));
            foreach(IWebElement game in games)
            {
                if (game.Text.Trim() == gameName)
                {
                    Log.For(this).InfoFormat("Game {0} finded", game.Text.Trim());
                    return true;
                }
            }
            return false;
        }
        public bool HasPostInFeed(string text)
        {
            IReadOnlyCollection<IWebElement> posts = driver.FindElements(By.XPath(post_list_locator));
            foreach (IWebElement post in posts)
            {
                if (post.Text.Trim().ToLower() == text.Trim().ToLower())
                {
                    Log.For(this).InfoFormat("Post {0} finded", post.Text.Trim().ToLower());
                    return true;
                }
            }
            return false;
        }
        public void MakePost(string text)
        {
            Submiting_text.SendKeys(text);
            Submiting_button.Click();
        }
        public void ClickLikeButtonOnTopPost()
        {
            IWebElement like_button = driver.FindElement(By.XPath(like_button_locator));
            like_button.Click();
        }
        public bool TopPostIsLiked()
        {
            IWebElement like_button = driver.FindElement(By.XPath(like_button_text_locator));
            string text = like_button.Text;
            return text.Trim().Equals("Liked");
        }
        public void ClickFriendButton()
        {
            FriendButton.Click();
        }
        public string FindTopFriend()
        {
            return FriendName.Text;
        }
        public void OpenMessagesPage()
        {
            MyMessagesButton.Click();
            PrivateMessages.Click();
        }
        public string GetTopRecevedMessage()
        {
            return TopRecevedMessage.Text;
        }
        public SendingMessagePage ClickSendMessage()
        {
            PrivateMessageButton.Click();
            return new SendingMessagePage(driver);
        }

        public void MuteUser()
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(MoreOptionsButton).Click(MuteButton).Perform();
        }
    }
}
