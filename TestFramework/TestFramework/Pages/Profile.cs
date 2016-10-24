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
    }
}
