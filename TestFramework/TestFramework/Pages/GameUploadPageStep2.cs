using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
#pragma warning disable 649

namespace TestFramework.Pages
{
    public class GameUploadPageStep2 : AbstractPage
    {
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
        public GameUploadPageStep2(IWebDriver driver) : base(driver) { }
        public void FillFields()
        {
            string path = DriverInstance.GetFilesDirectory();
            string swf_path = path + @"game\123.swf";
            string icon_path = path + @"game\icon.jpg";
            game_file_input.SendKeys(swf_path);
            game_icon_input.SendKeys(icon_path);
            Log.For(this).InfoFormat("swf path = {0} ", swf_path);
            Log.For(this).InfoFormat("swf path = {0} ", icon_path);
            checkbox_terms.Click();
            checkbox_creator_of_game.Click();
            checkbox_no_ads.Click();
            checkbox_no_microtransactions.Click();
        }
        public void ClickUpload()
        {
            Thread.Sleep(10000);
            Log.For(this).Info("Uploading game...");
            upload_button.Click();
        }
        public bool WaitUpload(string gameName)
        {
            IWebElement game_name_field = driver.FindElement(By.XPath("//h1[text()='" + gameName + "']"));
            if (game_name_field != null) Log.For(this).Info("Game upload");
            return game_name_field.Displayed;
        }
    }
}
