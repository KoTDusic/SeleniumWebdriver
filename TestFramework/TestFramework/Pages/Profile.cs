using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework.Pages
{
    public class Profile
    {
        private IWebDriver driver;
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
        
        public Profile(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
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
            IWebElement SucessMessage;
            try
            {
                SucessMessage = driver.FindElement(By.XPath("//div[@id='global']/div/h2"));
                return String.Equals(SucessMessage.Text, "Your profile has been updated.");
            }
            catch
            {
                return false;
            }
        }
        public bool HasGameInRecent(string gameName)
        {
           ResentPlay.Click();
           IReadOnlyCollection<IWebElement> games = driver.FindElements(By.XPath("//div[@id='dynamic-tab-1']/ul//p/strong/a"));
            foreach(IWebElement game in games)
            {
                if (game.Text.Trim() == gameName) return true;
            }
            return false;
        }
        public bool HasPostInFeed(string text)
        {
            IReadOnlyCollection<IWebElement> posts = driver.FindElements(By.XPath("//div[@class='feed_shout_message']/p"));
            foreach (IWebElement post in posts)
            {
                if (post.Text.Trim().ToLower() == text.Trim().ToLower()) return true;
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
            IWebElement like_button = driver.FindElement(By.XPath("//ul[@id='feed_items_container']/li[1]//a[@class='like_link']"));
            like_button.Click();
        }
        public bool TopPostIsLiked()
        {
            IWebElement like_button = driver.FindElement(By.XPath("//ul[@id='feed_items_container']/li[1]//a[@class='like_link']/span"));
            string text = like_button.Text;
            if (text.Trim().Equals("Liked")) return true;
            else return false;
            
        }
    }
}
