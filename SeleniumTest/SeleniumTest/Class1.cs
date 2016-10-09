using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
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
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(20));
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
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
        public void LoadAvatar()
        {
            IWebElement edit_profile_button = driver.FindElement(By.XPath(".//*[@id='profile_account_actions']/ul/li[1]/a"));
            edit_profile_button.Click();
            IWebElement upload_button = driver.FindElement(By.Id("user_uploaded_data"));
            string avatar = Path.GetFullPath("Images/1.jpg");
            upload_button.SendKeys(avatar);
            IWebElement submit_button = driver.FindElement(By.XPath(".//*[@id='edit_user']/dl/dt[10]/input"));
            submit_button.Click();
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
        [Test]
        public void Test2()
        {
            Login("testlabatestlaba@gmail.com", "12345");
            driver.Navigate().GoToUrl("http://www.kongregate.com/accounts/my_first_test");
            LoadAvatar();
            Assert.Pass();
        }
    }
}
