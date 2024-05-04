using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TurnUpPortalMarApr2024.Pages;
using TurnUpPortalMarApr2024.Utilities;

namespace TurnUpPortalMarApr2024.StepDefinitions
{
    [Binding]
    public class TMTestsStepDefinitions : CommonDriver
    {

        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        // TimeMaterialPage timeMaterialPageObj = new TimeMaterialPage();
        TimeMaterialPage tmPageObj = new TimeMaterialPage();

        [Given(@"user logs into Turn Up Portal")]
        public void GivenUserLogsIntoTurnUpPortal()
        {
            //  open chrome browser
            
            driver = new ChromeDriver();
            Thread.Sleep(1000);

            // Login page object initialization and definition

            loginPageObj.LoginActions(driver, "hari", "123123");
        }

        [Given(@"user navigates to TM Page")]
        public void GivenUserNavigatesToTMPage()
        {
            homePageObj.NavigateToTimeMaterialPage(driver);
        }

        [When(@"user creates a new TM record")]
        public void WhenUserCreatesANewTMRecord()
        {

            tmPageObj.CreateTimeRecord(driver, "March2024", "March2024 Description");
        }


        [Then(@"verify TM record is created")]
        public void ThenVerifyTMRecordIsCreated()
        {
            tmPageObj.VerifyRecordCreated(driver, "March2024");

        }

       


        [When(@"user edits an existing record")]
        public void WhenUserEditsAnExistingRecord()
        {

            tmPageObj.EditNewlyCreatedTMRecord(driver);
        }


        
         [Then(@"verify TM record is edited")]
         public void ThenVerifyTMRecordIsEdited()
         {

          tmPageObj.VerifyEditedTimeRecord(driver);

         }

        [When(@"user deletes an existing record")]
        public void WhenUserDeletesAnExistingRecord()
        {

            tmPageObj.DeleteNewlyCreatedEmployeeRecord(driver, "March2024");
        }



          [Then(@"verify TM record is deleted")]
           public void ThenVerifyTMRecordIsdeleted()
           {

             tmPageObj.VerifyDeleteTimeRecord(driver);
            }
    }
}
