using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;

namespace TestFramework
{
    public class DriverInstance
    {
        private static IWebDriver driver;

        private DriverInstance() { }
        public static string GetFilesDirectory()
        {
            return Path.GetFullPath(@"TestFramework\Res\");
            //return @"d:\fix\";1
        }
        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}