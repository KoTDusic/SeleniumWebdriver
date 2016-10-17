using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework.Pages
{
    public class SearchPage
    {
        IWebDriver driver;
        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public bool ContainGame(string name)
        {
            try
            {
                IWebElement game_name_label = driver.FindElement(By.XPath("//ol[@id='results']/li//h2//strong/a[text()='" + name + "']"));
                return String.Equals(game_name_label.Text, name);
            }
            catch
            {
                return false;
            }
        }
        public GamePage OpenGame(string game_name)
        {
            IWebElement game_name_label = driver.FindElement(By.XPath("//ol[@id='results']/li//h2//strong/a[text()='" + game_name + "']"));
            game_name_label.Click();
            return new GamePage(driver);
        }
        
    }
}
