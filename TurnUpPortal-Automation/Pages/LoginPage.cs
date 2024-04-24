

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortal_Automation.Pages
{
    public class LoginPage
    {
        private readonly By userNameTextboxLocator = By.Id("UserName");
        IWebElement usernameTextbox;

        private readonly By passwordTextboxLocator = By.Id("Password");
        IWebElement passwordTextbox;


        private readonly By loginButtonLocator = By.XPath("//*[@id='loginForm']/form/div[3]/input[1]");
        IWebElement loginButton;


        public void LoginActions(IWebDriver driver, string username, string password)
        {
            driver.Manage().Window.Maximize();

            Thread.Sleep(7000);

            //Launch turnup Portal and navigates to login page
            string baseURL = "http://horse.industryconnect.io/Account/Login";
            driver.Navigate().GoToUrl(baseURL);
           // driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login");


            //Identify username textbox and enter valid username 
            // IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            // usernameTextbox.SendKeys("hari");

            usernameTextbox = driver.FindElement(userNameTextboxLocator);
            usernameTextbox.SendKeys(username);


            //Identify password textbox and enter valid password 

          //  IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
           // passwordTextbox.SendKeys("123123");

            passwordTextbox = driver.FindElement(passwordTextboxLocator);
            passwordTextbox.SendKeys(password);

            //Identify login button and click on the button and click on the button

            loginButton = driver.FindElement(loginButtonLocator);
            loginButton.Click();

         // IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
          // loginButton.Click();

        }
    }
}
