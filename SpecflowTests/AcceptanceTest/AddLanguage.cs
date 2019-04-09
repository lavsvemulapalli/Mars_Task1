using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature1Steps : Utils.Start
    {
        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);
       
            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//a[text()='Profile']")).Click();

            
        }
        
        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {

//adding english language

            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//div[text()='Add New']")).Click();
            //Add Language
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']")).SendKeys("English");
            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']")).Click();
            Thread.Sleep(2000);
            //Choose the language level
            Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']//following::option[4]")).Click();
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
            Thread.Sleep(5000);

//adding Telugu language

            Driver.driver.FindElement(By.XPath("//div[text()='Add New']")).Click();
            //Add Language
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']")).SendKeys("Telugu");
            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']")).Click();
            Thread.Sleep(2000);
            //Choose the language level
            Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']//following::option[3]")).Click();
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
            Thread.Sleep(5000);


 //adding Hindi language

            Driver.driver.FindElement(By.XPath("//div[text()='Add New']")).Click();
            //Add Language
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']")).SendKeys("Hindi");
            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']")).Click();
            Thread.Sleep(2000);
            //Choose the language level
            Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']//following::option[3]")).Click();
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
            Thread.Sleep(5000);

            // adding same language (English) with differnt language level

            /*Driver.driver.FindElement(By.XPath("//div[text()='Add New']")).Click();
            //Add Language
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']")).SendKeys("English");
            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']")).Click();
            Thread.Sleep(2000);
            //Choose the language level
            Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']//following::option[3]")).Click();
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
            //handling popup
            Assert.AreEqual("Duplicated data", Driver.driver.FindElement(By.CssSelector(".ns-box-inner")).Text);
            Driver.driver.FindElement(By.CssSelector(".ns-close")).Click();
            Driver.driver.FindElement(By.XPath("//input[@class='ui button' and @value='Cancel']")).Click();
            Thread.Sleep(5000);*/



            // adding same language (English) and same language level

            /*  //Click on Add New button
              Driver.driver.FindElement(By.XPath("//div[text()='Add New']")).Click();
              //Add Language
              Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']")).SendKeys("English");
              //Click on Language Level
              Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']")).Click();
              Thread.Sleep(2000);
              //Choose the language level
              Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']//following::option[4]")).Click();
              //Click on Add button
              Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
              //handling popup
              Assert.AreEqual("This language is already exist in your language list.", Driver.driver.FindElement(By.CssSelector(".ns-box-inner")).Text);
              Driver.driver.FindElement(By.CssSelector(".ns-close")).Click();
              Driver.driver.FindElement(By.XPath("//input[@class='ui button' and @value='Cancel']")).Click();
              Thread.Sleep(3000);  */



            //editing telugu language

            /* Driver.driver.FindElement(By.XPath("//td[text()='Fluent']//following::i[1]")).Click();
             Thread.Sleep(3000);
             Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']")).Click();
             Thread.Sleep(2000);
             //Choose the language level
             Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']//following::option[4]")).Click();
             Thread.Sleep(1000);
             //clicking update button
             Driver.driver.FindElement(By.XPath("//input[@value='Update']")).Click();
             Thread.Sleep(2000);
             //verification
             Assert.AreEqual("Telugu has been updated to your languages", Driver.driver.FindElement(By.CssSelector(".ns-box-inner")).Text);
             Thread.Sleep(5000);*/

            //deleting Hindhi language


            /* Driver.driver.FindElement(By.XPath("//td[text()='Hindi']//following::i[2]")).Click();
             Thread.Sleep(1000);
             //verification
             Assert.AreEqual("Hindi has been deleted from your languages", Driver.driver.FindElement(By.CssSelector(".ns-box-inner")).Text);
             Thread.Sleep(5000);*/





        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {


            Assert.IsTrue(Driver.driver.FindElement(By.XPath("//td[text()='English']")).Displayed);
            Assert.AreEqual("English", Driver.driver.FindElement(By.XPath("//td[text()='English']")).Text);
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "English";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='English']")).Text;
                Thread.Sleep(500);
                if(ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch(Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed",e.Message);
            }

             

        }
    }
}
