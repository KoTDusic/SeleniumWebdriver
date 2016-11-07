using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;
using log4net;
using log4net.Config;

namespace TestFramework
{
    public class DriverInstance
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(Steps));
        private static IWebDriver driver;
        public static string GetFilesDirectory()
        {
            //return Path.GetFullPath(@"TestFramework\Res\");
            return @"d:\fix\";
        }
        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                XmlConfigurator.Configure();
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