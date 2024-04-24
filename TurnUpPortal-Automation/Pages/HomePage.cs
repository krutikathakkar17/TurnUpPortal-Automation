using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace TurnUpPortal_Automation.Pages
{
    public class HomePage
    {
        private readonly By administrationDropdownLocator = By.XPath("/html/body/div[3]/div[1]/div[1]/ul[1]/li[5]/a ");
        IWebElement administrationDropdown;


        private readonly By TimeMaterialLocator = By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a");
        IWebElement tmOption;


        private readonly By helloHariLinkLocator = By.XPath("//*[@id=\"logoutForm\"]/ul/li/a");
        IWebElement helloHariLink;


        private readonly By EmployeeLocator = By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a");
        IWebElement EmployeeOption;


        public void NavigateToTimeMaterialPage(IWebDriver driver)
        {
            try
            {
                // Navigate to Time and Materials module (Click Administration button -> Select Time & Material option)
                IWebElement administrationDropdown = driver.FindElement(administrationDropdownLocator);
                administrationDropdown.Click();


                IWebElement tmOption = driver.FindElement(TimeMaterialLocator);
                tmOption.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("TurnUp portal page did not displayed" + ex.Message);
            }

        }

        public void NavigateToEmployeePage(IWebDriver driver)
        {
            try
            {
                // Navigate to Employee module (Click Administration button -> Select Employee option)
                IWebElement administrationDropdown = driver.FindElement(administrationDropdownLocator);
                administrationDropdown.Click();

                IWebElement EmployeeOption = driver.FindElement(EmployeeLocator);
                EmployeeOption.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("TurnUp portal page did not displayed" + ex.Message);
            }

        }

        public void VerifyLoggedInUser(IWebDriver driver)
        {
            //Check if user has logged in successfully

            try
            {
                IWebElement helloHariLink = driver.FindElement(helloHariLinkLocator);

                /*if (helloHariLink.Text == "Hello hari!")
                {
                Console.WriteLine("User has logged in successfully");
                 }
                 else
                {
                 Console.WriteLine("User hasn't been logged in.");
                }*/

                Assert.That(helloHariLink.Text == "Hello hari!", "User hasn't been logged in.");
            }
            catch (Exception ex)
            { 
             Assert.Fail("User hasn't logged in" + ex.Message);

            }
        }
    }
}
