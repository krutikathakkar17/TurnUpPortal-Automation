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
        private readonly By administrationDropdownLocator = By.XPath("//body/div[3]/div[1]/div[1]/ul[1]/li[5]/a[1]");
        IWebElement administrationDropdown;
     

        private readonly By tmOptionLocator = By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a");
        IWebElement tmOption;
       

        private readonly By helloHariLinkLocator = By.XPath("//*[@id=\"logoutForm\"]/ul/li/a");
        IWebElement helloHariLink;


        public void NavigateToTimeMaterialPage(IWebDriver driver)
        {
            // Navigate to Time and Materials module (Click Administration button -> Select Time & Material option)
            IWebElement administrationDropdown = driver.FindElement(administrationDropdownLocator);
            administrationDropdown.Click();

            
            IWebElement tmOption = driver.FindElement(tmOptionLocator);
            tmOption.Click();

        }

        public void VerifyLoggedInUser(IWebDriver driver)
        {
            //Check if user has logged in successfully

            IWebElement helloHariLink = driver.FindElement(helloHariLinkLocator);

             if (helloHariLink.Text == "Hello hari!")
             {
             Console.WriteLine("User has logged in successfully");
              }
              else
             {
              Console.WriteLine("User hasn't been logged in.");
             }

        }
    }
}
