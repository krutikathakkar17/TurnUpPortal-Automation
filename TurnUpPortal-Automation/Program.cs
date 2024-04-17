using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TurnUpPortal_Automation.Pages;
//Open Chrome Brows

public class Program
{
    private static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();

        // Login Page Object initialization and definition

        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginActions(driver, "hari", "123123");

        // Home Page Object initialization and definition

        HomePage homePageObj = new HomePage(); 
        homePageObj.VerifyLoggedInUser(driver);
        homePageObj.NavigateToTimeMaterialPage(driver);

        // TMPage Object initialization and definition

        TimeMaterialPage tmPageObj = new TimeMaterialPage();
        tmPageObj.CreateTimeRecord(driver);
        tmPageObj.EditNewlyCreatedTMRecord(driver);
        tmPageObj.DeleteNewlyCreatedTMRecord(driver);

    }
}