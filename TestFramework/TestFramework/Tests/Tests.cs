using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestFramework
{
    [TestFixture]
    public class Tests
    {
        string login_first = "my_first_test";
        string email_first = "testlabatestlaba@gmail.com";
        string password_first = "12345";
        private Steps steps;
        [SetUp]
        public void Init()
        {
            steps = new Steps();
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            //steps.CloseBrowser();
        }
        [Test]
        public void _1ChekLoginingOnSite()
        {
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.IsLoggedIn(login_first));
            steps.LogOut();
        }
        [Test]
        public void _2AvatarUpload()
        {
            steps.LoginKongregate(email_first, password_first);
            Assert.IsTrue(steps.GoToEditProfileAndUploadPhoto());
            steps.LogOut();
        }
    }
}
