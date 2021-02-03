using System;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using VidlyUITests.BaseClass;
using VidlyUITests.Factories;

namespace VidlyUITests
{
    [TestFixture]
    public class Tests : TestBase
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver()
            {
                Url = UrlFactory.LoginPageUrl
            };
            _driver.Manage().Window.Maximize();

            ExtentTest test = null;
        }

        [TearDown]
        public void CloseDriver()
        {
            _driver?.Close();
        }

        [Test]
        public void OpenLoginScreen()
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            test = extent.CreateTest(m?.Name).Info("Test started");
            Assert.True(!_driver.Title.Contains("Login"));
            test.Log(Status.Pass, "Test Passed");

            Assert.IsTrue(false);
        }
    }
}