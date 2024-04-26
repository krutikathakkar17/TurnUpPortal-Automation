using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TurnUpPortal_Automation.Pages;
using TurnUpPortal_Automation.Utilities;

namespace TurnUpPortal_Automation.Tests
{
    public class EmployeeTests : CommonDriver
    {
        EmployeePage employeePageObj = new EmployeePage();



        public void SetUp()
        {
            driver = new ChromeDriver();

            // Login Page Object initialization and definition

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver, "hari", "123123");

            // Home Page Object initialization and definition

            HomePage homePageObj = new HomePage();
            homePageObj.VerifyLoggedInUser(driver);
            homePageObj.NavigateToEmployeePage(driver);
        }

            [Test, Order(1), Description("This test create a new Employee record with valid details")]
            public  void TestCreateEmployeeRecord()
            {
                employeePageObj.CreateEmployeeRecord(driver);

            }

            [Test, Order(2), Description("This test edits a new Employee record with valid details")]
            public void TestEditEmployeeRecord()
            {
                employeePageObj.EditEmployeeRecord(driver);

            }

            [Test, Order(3), Description("This test deletes the last Employee record")]
            public void TestDeleteEmployeeRecord()
            {
                employeePageObj.DeleteEmployeeRecord(driver);


            }

            /*[TearDown]
            public void CloseTestRun()
            {
                //driver.Quit();*/

            }









            
        }
     