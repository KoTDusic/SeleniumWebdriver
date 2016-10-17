using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.IO;

namespace TestFramework.Pages
{
    class EditProfile
    {
        private const string BASE_URL = "http://www.kongregate.com/";
        private IWebDriver driver;
        [FindsBy(How = How.Id, Using = "user_uploaded_data")]
        IWebElement upload_button;
        [FindsBy(How = How.XPath, Using = "//input[@value='Save Changes']")]
        IWebElement submit_button;
        public EditProfile(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public Profile UploadPhoto()
        {
            string avatar = @"d:\fix\" + new Random().Next(1, 4) + ".jpg";//Path.GetFullPath(@"Res\"+new Random().Next(1,4)+".jpg");
            upload_button.SendKeys(avatar);
            submit_button.Click();
            return new Profile(driver);    
        }
    }
}
