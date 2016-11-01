using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework.Pages
{
     
    public class SendingMessagePage
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "shout_content")]
        private IWebElement message_textarea;
        [FindsBy(How = How.Id, Using = "shout_form_submit")]
        private IWebElement submit_button;
        [FindsBy(How = How.Id, Using = "shout_error_message")]
        private IWebElement error_text;

        public SendingMessagePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void SendMessage(string message)
        {
            message_textarea.Clear();
            message_textarea.SendKeys(message);
            submit_button.Click();
        }
        public bool BlockedTest()
        {
            return (error_text.Text.Length<10)?false:true;
        }
    }
}
