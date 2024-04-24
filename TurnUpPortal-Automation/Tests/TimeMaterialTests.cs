using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortal_Automation.Pages;
using TurnUpPortal_Automation.Utilities;
using OpenQA.Selenium.DevTools.V121.Autofill;
using System.Runtime.ConstrainedExecution;

namespace TurnUpPortal_Automation.Tests
{
    [TestFixture]
    public class TimeMaterialTests : CommonDriver
    {
        TimeMaterialPage tmPageObj = new TimeMaterialPage();
        [SetUp]
        public void SetUpTimeMaterial()
        {
             driver = new ChromeDriver();

            // Login Page Object initialization and definition

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver, "hari", "123123");

            // Home Page Object initialization and definition

            HomePage homePageObj = new HomePage();
            homePageObj.VerifyLoggedInUser(driver);
            homePageObj.NavigateToTimeMaterialPage(driver);

        }

        [Test, Order(1), Description("This test create a new Time/Material record with valid details")]
        public void TestCreateTimeMaterialRecord()
        {
           // TimeMaterialPage tmPageObj = new TimeMaterialPage();

            tmPageObj.CreateTimeRecord(driver);
            
        }

        [Test, Order(2), Description("This test edits a new Time/Material record with valid details")]
        public void TestEditTimeMaterialRecord()
        {
            TimeMaterialPage tmPageObj = new TimeMaterialPage();
            tmPageObj.EditNewlyCreatedTMRecord(driver);

        }

        [Test, Order(3), Description("This test deletes the last Time/Material record")]
        public void TestDeleteTimeMaterialRecord()
        {
            TimeMaterialPage tmPageObj = new TimeMaterialPage();
            tmPageObj.DeleteNewlyCreatedEmployeeRecord(driver);

        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();

        }





    }
}
