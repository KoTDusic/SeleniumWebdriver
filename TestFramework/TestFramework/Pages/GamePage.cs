using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework.Pages
{
    public class GamePage
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "more_games")]
        private IWebElement more_games_button;
        
        //li[@id='quicklinks_star_ratings_block']//li/a
        public GamePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void MoreGamesClick()
        {
            more_games_button.Click();
        }
        public void OpenPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public bool CheckGameInRecommendedList(string game_name)
        {
            IReadOnlyCollection<IWebElement> game_tags =
                driver.FindElements(By.XPath("//div[@id='more_games_tab_pane']/div/li/div//h4"));
            foreach(IWebElement elem in game_tags)
            {
                if (String.Equals(elem.Text, game_name)) return true;
            }
            return false;
        }
        public string GetCurrentGameRate()
        {
            IWebElement colored_stars=driver.FindElement(By.XPath("//li[@id='quicklinks_star_ratings_block']/ul/li[1]"));
            return colored_stars.GetCssValue("width");
        }
        public void SetRate(int value)
        {
            IReadOnlyCollection<IWebElement> game_tags = driver.FindElements(By.XPath("//li[@id='quicklinks_star_ratings_block']/ul//li/a"));
            game_tags.ElementAt(value-1).Click();
        }
    }
}
