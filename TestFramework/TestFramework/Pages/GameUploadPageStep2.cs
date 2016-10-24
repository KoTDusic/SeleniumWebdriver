using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace TestFramework.Pages
{
    public class GameUploadPageStep2
    {
        IWebDriver driver;
        [FindsBy(How = How.XPath, Using = "//div[@id='game-icon-flash-fine-uploader']/div/div/div/input")]
        private IWebElement game_icon_input;
        [FindsBy(How = How.XPath, Using = "//input[@id='preview_version_game_file_uploaded_data']")]
        private IWebElement game_file_input;
        [FindsBy(How = How.XPath, Using = "//input[@id='preview_version_terms_of_service_agreement']")]
        private IWebElement checkbox_terms;
        [FindsBy(How = How.XPath, Using = "//input[@id='preview_version_verify_creator_of_game']")]
        private IWebElement checkbox_creator_of_game;
        [FindsBy(How = How.XPath, Using = "//input[@id='preview_version_verify_no_ads']")]
        private IWebElement checkbox_no_ads;
        [FindsBy(How = How.XPath, Using = "//input[@id='preview_version_verify_no_microtransactions']")]
        private IWebElement checkbox_no_microtransactions;
        [FindsBy(How = How.XPath, Using = "//input[@id='flash_submission_button']")]
        private IWebElement upload_button;
        
        public GameUploadPageStep2(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void FillFields()
        {
            //IWebElement game_icon_input = driver.FindElement(By.XPath("//div[@id='game-icon-flash-fine-uploader']/div/div/div/input"));
            //IWebElement game_file_input = driver.FindElement(By.XPath("//input[@id='preview_version_game_file_uploaded_data']"));
            string path = DriverInstance.GetFilesDirectory();
            game_file_input.SendKeys(path + @"game\123.swf");
            game_icon_input.SendKeys(path + @"game\icon.jpg");
            checkbox_terms.Click();
            checkbox_creator_of_game.Click();
            checkbox_no_ads.Click();
            checkbox_no_microtransactions.Click();
        }
        public void ClickUpload()
        {
            Thread.Sleep(5000);
            upload_button.Click();
        }
        public bool WaitUpload(string gameName)
        {
            IWebElement game_name_field = driver.FindElement(By.XPath("//h1[text()='" + gameName + "']"));
            return game_name_field.Displayed;
        }
    }
}
