using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace TestFramework.Pages
{
    public class EditProfile
    {
        private const string BASE_URL = "http://www.kongregate.com/";
        private IWebDriver driver;
        [FindsBy(How = How.Id, Using = "user_uploaded_data")]
        private IWebElement upload_button;
        [FindsBy(How = How.XPath, Using = "//input[@value='Save Changes']")]
        private IWebElement submit_button;
        [FindsBy(How = How.XPath, Using = "//a[text()='Password']")]
        private IWebElement password_btn;

        public EditProfile(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public Profile UploadPhoto()
        {
            string avatar = DriverInstance.GetFilesDirectory() + new Random().Next(1, 4) + ".jpg";
            upload_button.SendKeys(avatar);
            submit_button.Click();
            return new Profile(driver);    
        }
        public void ChangePassword(string current_password, string new_password)
        {
            password_btn.Click();
            IWebElement current_original_password_input = driver.FindElement(By.Id("user_original_password"));
            IWebElement current_password_input = driver.FindElement(By.Id("user_password"));
            current_original_password_input.SendKeys(current_password);
            current_password_input.SendKeys(new_password);
            IWebElement change_password_button = driver.FindElement(By.XPath("//input[@value='Change Password']"));
            change_password_button.Click();

            

        }
    }
}
