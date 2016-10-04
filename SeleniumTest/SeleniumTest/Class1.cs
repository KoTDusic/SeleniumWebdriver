using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
    [TestFixture]
    public class Class1
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }
        public void Login(string name,string password)
        {
            driver.Navigate().GoToUrl("http://www.kongregate.com/");
            IWebElement login = driver.FindElement(By.Id("welcome_username"));
            login.SendKeys(name);
            IWebElement pass = driver.FindElement(By.Id("welcome_password"));
            pass.SendKeys(password);
            IWebElement login_button = driver.FindElement(By.Id("welcome_box_sign_in_button"));
            login_button.Click();
        }
        [TearDown]
        public void Teardown()
        {
            //driver.Quit();
        }
        [Test]
        public void Test1()
        {
            Login("testlabatestlaba@gmail.com", "12345");
            IWebElement user_name=driver.FindElement(By.XPath(".//*[@id='nav_welcome_box']/li[1]/a/span[2]"));
            Assert.AreEqual("my_first_test", user_name.Text);
        }
    }
}
