using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortal_Automation.Pages
{
    public class TimeMaterialPage
    {

        public void CreateTimeRecord(IWebDriver driver)
        {
            // Create a new Time/Material record



            // Click on the Create New Button 
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            Thread.Sleep(7000);

            // Select Time from dropdown


            IWebElement typeCodeMainDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            typeCodeMainDropdown.Click();


            IWebElement timeTypeCode = driver.FindElement(By.XPath("//ul[@id='TypeCode_listbox']/li[2]"));
            timeTypeCode.Click();



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

            //Check if a new Time/Material record has been created successfully
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            VerifyRecordCreated(driver);
        }

            // public
            public void VerifyRecordCreated(IWebDriver driver)
            {
                IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
                /*  if (newCode.Text == "March2024")
                  {
                    Console.WriteLine("New Time record has been created successfully");
                  }
                  else
                  {
                    Console.WriteLine("New Time record has not been created");
                  }*/

                Assert.That(newCode.Text == "March2024", "New Time record has not been created");
                Thread.Sleep(5000);

            }


            public void EditNewlyCreatedTMRecord(IWebDriver driver)
            {
                // TO EDIT THE ENTRY IN THE NEW RECORD

                // In the row of the  new record, select edit button
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();


                // clear the old value
                driver.FindElement(By.Id("Description")).Clear();

                // Select the item user wants to edit in the record...here user want to edit  description entry & edit the value
                IWebElement newDescription = driver.FindElement(By.Id("Description"));
                newDescription.SendKeys("Mar-Apr2024");


                //navigate to save button and click it

                IWebElement saveEdit = driver.FindElement(By.Id("SaveButton"));
                saveEdit.Click();

                Thread.Sleep(5000);

                //navigate to the last page and check whether the latest entry's price value has been editted or not
                IWebElement goToEditValue = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
                goToEditValue.Click();

                IWebElement edittedValue = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
                string valueText = edittedValue.Text;
                string wantedText = "Wanted Item Text";


                /* if (valueText == wantedText)
                 {
                     Console.WriteLine("Record has been editted succeddfully");
                 }
                 else
                 {
                     Console.WriteLine("Record has not been editted successfully");
                 }*/


                Assert.That(valueText == wantedText, "Record has not been editted successfully");

            }
            public void DeleteNewlyCreatedEmployeeRecord(IWebDriver driver)
            {
                // TO DELETE THE NEW RECORD FROM THE TABLE

                // In the new row navigate to the delete button and click on it
                IWebElement deleteItem = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteItem.Click();

                //Select "Ok" in the hover pop up
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();

                Thread.Sleep(5000);

                // Check whether the deleted entry no more exists in the table

                IWebElement deletedValue = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
                string itemText = deletedValue.Text;
                string expectedText = "Expected Item Text";

                /*if (itemText == expectedText)
                {
                    Console.WriteLine("Item has not been deleted, it is still there");
                }
                else
                {
                    Console.WriteLine("Record has been deleted successfully");
                }*/

                Assert.That(itemText == expectedText, "Record has been deleted successfully");


            }

            internal void EditNewlyCreatedEmployeeRecord(IWebDriver driver)
            {
                throw new NotImplementedException();
            }

            internal void CreateEmployeeRecord(IWebDriver driver)
            {
                throw new NotImplementedException();
            }
        }





    } 


