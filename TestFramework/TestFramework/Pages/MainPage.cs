using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework.Pages
{
    
    public class MainPage
    {
        private const string BASE_URL = "http://www.kongregate.com/";

        private IWebDriver driver;
        [FindsBy(How = How.Id, Using = "welcome_username")]
        private IWebElement login;
        [FindsBy(How = How.Id, Using = "welcome_password")]
        private IWebElement pass;
        [FindsBy(How = How.Id, Using = "welcome_box_sign_in_button")]
        private IWebElement login_button;
        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'username_holder')]")]
        private IWebElement name_box;
        [FindsBy(How = How.Id, Using = "game_title")]
        private IWebElement search_game_field;
        [FindsBy(How = How.Id, Using = "nav_search_submit_button")]
        private IWebElement search_game_button;
        private IWebElement profile_button;
        private string profile_btn_locator = "//ul[@id='nav_welcome_box']/li[1]/a";
        private string error_message_locator = "//h1[@id='lightboxlogin_message']";
        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }
        public void Login(string name, string password)
        {
            login.SendKeys(name);
            pass.SendKeys(password);
            login_button.Click();
        }
        public string GetLoggedInUserName()
        {
            return name_box.Text;
        }
        public string GetErrorMessage()
        {
            return driver.FindElement(By.XPath(error_message_locator)).Text.Trim();
        }
        public Profile ProfileClick()
        {
            profile_button = driver.FindElement(By.XPath(profile_btn_locator));
            profile_button.Click();
            return new Profile(driver);
        }
        public void LogOut()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("signoutFromSite()");
            //logout_button.Click();
        }
        public SearchPage FindGame(string name)
        {
            search_game_field.SendKeys(name);
            search_game_button.Click();
            return new SearchPage(driver);
        }
    }
}
