using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework.Pages
{
    public class SearchPage : AbstractPage
    {
        public SearchPage(IWebDriver driver) : base(driver) { }
        public bool ContainGame(string name)
        {
            IWebElement game_name_label = driver.FindElement(By.XPath("//ol[@id='results']/li//h2//strong/a[text()='" + name + "']"));
            if (game_name_label == null)
            {
                Log.For(this).InfoFormat("Game {0} finded on search", game_name_label.Text);
                return false; 
            }
            return String.Equals(game_name_label.Text, name);
        }
        public GamePage OpenGame(string game_name)
        {
            IWebElement game_name_label = driver.FindElement(By.XPath("//ol[@id='results']/li//h2//strong/a[text()='" + game_name + "']"));
            game_name_label.Click();
            return new GamePage(driver);
        }
        
    }
}
