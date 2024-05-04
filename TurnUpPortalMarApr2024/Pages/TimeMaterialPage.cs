using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortalMarApr2024.Pages
{
    public class TimeMaterialPage
    {

        public void CreateTimeRecord(IWebDriver driver, string code, string description )
        {
            // Create a new Time/Material record
            // Click on the Create New Button 
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();
            Thread.Sleep(7000);

            // Select Time from dropdown
            IWebElement typeCodeMainDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            typeCodeMainDropdown.Click();
            IWebElement timeTypeCode = driver.FindElement(By.XPath("//li[contains(text(),\"Time\")]"));
            timeTypeCode.Click();
            // "//ul[@id='TypeCode_listbox']/li[2]"

            // Enter Code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("March2024");

            // Enter Description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("March2024 Description");

            // Enter price per unit
            IWebElement priceTextBox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextBox.SendKeys("345.00");

            // Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(5000);

            ;
        }
        public void VerifyRecordCreated(IWebDriver driver, string code)
        
        
        {
            IWebElement lastpagebutton = driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            lastpagebutton.Click();
            string tmLastPage = driver.FindElement(By.XPath("//li/span")).Text;
            for (int i = 1; i <= tmLastPage.Length; i++)
            {
                int tmRows = driver.FindElements(By.XPath("//tbody/tr")).Count();
                for (int j = 1; j <= tmRows; j++)
                {
                    IWebElement codeValue = driver.FindElement(By.XPath("//tr[" + j + "]/td[1]"));
                    if (codeValue.Text == "March2024")
                    {
                        Console.WriteLine("Created Record was found");
                        TestContext.Out.WriteLine("Record created");
                        break;

                    };
                }
                driver.FindElement(By.XPath("//span[contains(text(),'Go to the next page')]")).Click();

           }
        }


        public void EditNewlyCreatedTMRecord(IWebDriver driver)


        {
            //Edit the newly created type code
            Thread.Sleep(5000);
            IWebElement lastpagebutton = driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            lastpagebutton.Click();
            string tmLastPage = driver.FindElement(By.XPath("//li/span")).Text;
            IWebElement firstPageButton = driver.FindElement(By.XPath("//span[contains(text(),'Go to the first')]"));
            firstPageButton.Click();
            for (int i = 1; i <= Int32.Parse(tmLastPage); i++)
            {
                int tmRows = driver.FindElements(By.XPath("//tbody/tr")).Count();
                for (int j = 1; j <= tmRows; j++)
                {
                    IWebElement codeValue = driver.FindElement(By.XPath("//tr[" + j + "]/td[1]"));
                    if (codeValue.Text == "March2024")
                    {
                        Console.WriteLine("Created Record was found");
                        driver.FindElement(By.XPath("//tbody/tr[" + j + "]/td[5]/a[1]")).Click(); Thread.Sleep(2000);
                        driver.FindElement(By.XPath("//input[@id='Description']")).Clear(); Thread.Sleep(1000);
                        driver.FindElement(By.XPath("//input[@id='Description']")).SendKeys("Mar-Apr2024");

                        driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]")).Click();
                        Thread.Sleep(1000);
                        break;




                    };

                }

                driver.FindElement(By.XPath("//span[contains(text(),'Go to the next page')]")).Click();

            }
        }

        public void VerifyEditedTimeRecord(IWebDriver driver)
        {
            Thread.Sleep(5000);
            IWebElement lastpagebutton = driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            lastpagebutton.Click();
            string tmLastPage = driver.FindElement(By.XPath("//li/span")).Text;
            IWebElement firstPageButton = driver.FindElement(By.XPath("//span[contains(text(),'Go to the first')]"));
            for (int i = 1; i <= tmLastPage.Length; i++)
            {
                int tmRows = driver.FindElements(By.XPath("//tbody/tr")).Count();
                for (int j = 1; j <= tmRows; j++)
                {
                    IWebElement codeValue = driver.FindElement(By.XPath("//tr[" + j + "]/td[1]"));
                    if (codeValue.Text == "March2024")
                    {
                        Console.WriteLine("Record is edited");

                        break;
                    };


                }
                driver.FindElement(By.XPath("//span[contains(text(),'Go to the next page')]")).Click();
            }
        }







        public void DeleteNewlyCreatedEmployeeRecord(IWebDriver driver, string code)
            

               {
                 IWebElement lastpageButton = driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
                  lastpageButton.Click();
                 Thread.Sleep(1000);
                 string tmLastPage = driver.FindElement(By.XPath("//li/span")).Text;
                 IWebElement firstPageButton = driver.FindElement(By.XPath("//span[contains(text(),'Go to the first')]"));
                  firstPageButton.Click();
                 Thread.Sleep(1000);
                 for (int i = 1; i <= Int32.Parse(tmLastPage); i++)
                 {
                   int tmRows = driver.FindElements(By.XPath("//tbody/tr")).Count();
                 for (int j = 1; j <= tmRows; j++)
                 {
                    IWebElement codeValue = driver.FindElement(By.XPath("//tr[" + j + "]/td[1]"));
                    if (codeValue.Text == "March2024")
                    {
                        Console.WriteLine("Record to be deleted is found");
                        driver.FindElement(By.XPath("//tbody/tr[" + j + "]/td[5]/a[2]")).Click(); Thread.Sleep(2000);
                        driver.SwitchTo().Alert().Accept();
                        break;
                    };


                }
                   driver.FindElement(By.XPath("//span[contains(text(),'Go to the next page')]")).Click();

            }
        }

        public void VerifyDeleteTimeRecord(IWebDriver driver)
        {
            IWebElement lastpageButton = driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            lastpageButton.Click();
            string tmLastPage = driver.FindElement(By.XPath("//li/span")).Text;
            IWebElement firstPageButton = driver.FindElement(By.XPath("//span[contains(text(),'Go to the first')]"));
            for (int i = 1; i <= tmLastPage.Length; i++)
            {
                int tmRows = driver.FindElements(By.XPath("//tbody/tr")).Count();
                for (int j = 1; j <= tmRows; j++)
                {
                    IWebElement codeValue = driver.FindElement(By.XPath("//tr[" + j + "]/td[1]"));
                    if (codeValue.Text == "March2024")
                    {
                        Console.WriteLine("Record not deleted");
                        break;
                    };


                }
                driver.FindElement(By.XPath("//span[contains(text(),'Go to the next page')]")).Click();
                Console.WriteLine("Record is deleted");
            }
        }

      /*  internal void EditNewlyCreatedEmployeeRecord(IWebDriver driver)
            {
                throw new NotImplementedException();
            }

            internal void CreateEmployeeRecord(IWebDriver driver)
            {
                throw new NotImplementedException();
            }

        internal void EditNewlyCreatedTMRecord(IWebDriver driver, string v)
        {
            throw new NotImplementedException();
        }

        internal void VerifyDeleteTimeRecord(IWebDriver driver, string v)
        {
            throw new NotImplementedException();
        }*/
    }





    } 


