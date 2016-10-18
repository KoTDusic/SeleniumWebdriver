using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework.Pages
{
    class GameUploadPageStep2
    {
        IWebDriver driver;
        [FindsBy(How = How.XPath, Using = "//input[@id='preview_version_game_file_uploaded_data']")]
        private IWebElement game_upload_input;
        [FindsBy(How = How.XPath, Using = "//*[@id='screenshots-fine-uploader']/div/div/div/input")]
        private IWebElement gameicon_upload_input;
        public GameUploadPageStep2(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

    }
}
