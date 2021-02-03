using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;


namespace VidlyUITests.BaseClass
{
    public class TestBase
    {
        public ExtentReports extent;
        public ExtentTest test;

        [OneTimeSetUp]
        public void StartReporting()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

            string actualPath = pth?.Substring(0, pth.LastIndexOf("bin"));

            string projectPath = new Uri(actualPath).LocalPath;

            extent = new ExtentReports();

            //Append the html report file to current project path

            string reportPath = projectPath + "TestReports\\TestRunReport.html";
            //var path = @"C:\Users\User\source\repos\Vidly\VidlyUITests\TestReports\";
            //report = new ExtentReports();
            
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent.AttachReporter(htmlReporter);
        }

        [TearDown]
        public void AfterClass()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == TestStatus.Failed)
            {
                test.Log(Status.Fail, status + errorMessage);
            }
        }

        [OneTimeTearDown]

        public void EndReport()

        {
            extent.Flush();
        }
    }
}
