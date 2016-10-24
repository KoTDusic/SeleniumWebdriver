using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework.Pages
{
    public class GameUploadPageStep1
    {
        IWebDriver driver;
        private const string DEVELOPER_URL = "http://www.kongregate.com/games/new";
        [FindsBy(How = How.Id, Using = "games-_title")]
        private IWebElement title_field;
        [FindsBy(How = How.XPath, Using = "//dd[@id='game_summary_block']//textarea")]
        private IWebElement game_description_field;
        [FindsBy(How = How.Id, Using = "game_category_id")]
        private IWebElement game_category_field;
        [FindsBy(How = How.XPath, Using = "//div[@id='publish_submit']/input")]
        private IWebElement continue_button;
        
        public GameUploadPageStep1(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void OpenPage()
        {
            driver.Navigate().GoToUrl(DEVELOPER_URL);
        }
        public void FillFields(string gameName)
        {
            title_field.SendKeys(gameName);
            game_description_field.SendKeys("test");
            game_category_field.SendKeys("Action");
        }
        public GameUploadPageStep2 PressContinue()
        {
            continue_button.Click();
            return new GameUploadPageStep2(driver);
        }
    }
}
