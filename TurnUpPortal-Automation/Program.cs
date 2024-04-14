using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
//Open Chrome Brows

IWebDriver driver = new ChromeDriver();
driver.Manage().Window.Maximize();


//Launch turnup Portal and navigates to login page
driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login");
//Identify username textbox and enter valid username 
IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
usernameTextbox.SendKeys("hari");


//Identify password textbox and enter valid password 

IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
passwordTextbox.SendKeys("123123");

//Identify login button and click on the button and click on the button

IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
loginButton.Click();
//Check if user has logged in successfully

IWebElement helloHariLink = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
if (helloHariLink.Text == "Hello hari!")
{
    Console.WriteLine("User has logged in successfully");
}
else
{
    Console.WriteLine("User hasn't been logged in.");
}


// Create a new Time/Material record

// Navigate to Time and Materials module (Click Administration button -> Select Time & Material option)
IWebElement administrationDropdown = driver.FindElement(By.XPath("//body/div[3]/div[1]/div[1]/ul[1]/li[5]/a[1]"));
administrationDropdown.Click();
IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
tmOption.Click();

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

IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
if (newCode.Text == "March2024")
{
    Console.WriteLine("New Time record has been created successfully");
}
else
{
    Console.WriteLine("New Time record has not been created");
}

Thread.Sleep(5000);

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


if (valueText == wantedText)
{
    Console.WriteLine("Record has been editted succeddfully");
}
else
{
    Console.WriteLine("Record has not been editted successfully");
}

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

if (itemText == expectedText)
{
    Console.WriteLine("Item has not been deleted, it is still there");
}
else
{
    Console.WriteLine("Record has been deleted successfully");
}