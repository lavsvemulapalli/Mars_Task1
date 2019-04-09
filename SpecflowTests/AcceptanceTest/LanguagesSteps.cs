using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class LanguagesSteps
    {
        [Given(@"I click on the Language tab in profile")]
        public void GivenIClickOnTheLanguageTabInProfile()
        {
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.XPath("//a[text()='Profile']")).Click();
        }
        
        [When(@"I addded a new language ""(.*)""")]
        public void WhenIAdddedANewLanguage(string Languages)
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//div[text()='Add New']")).Click();
            //Add Language
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']")).SendKeys(Languages);
            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']")).Click();
            Thread.Sleep(2000);
            //Choose the language level
            Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']//following::option[4]")).Click();
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
            Thread.Sleep(5000);
        }
        
        [Then(@"that language should be displayed on my listing")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListing()
        {
            
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
               // string ExpectedValue = "English";
                //string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='English']")).Text;
                Thread.Sleep(500);

                var lang = new List<String> { "Hindi", "English", "Telugu" };
                foreach (String l in lang)
                {
                    if (l == "Hindi")
                    {
                        string ExpectedValue = "Hindi";
                        string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='Hindi']")).Text;
                        if (ExpectedValue == ActualValue)
                        {
                            CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                        }
                        else
                            CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                    }

                    if (l == "English")
                    {
                        string ExpectedValue = "English";
                        string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='English']")).Text;
                        if (ExpectedValue == ActualValue)
                        {
                            CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                        }
                        else
                            CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                    }

                    if (l == "Telugu")
                    {
                        string ExpectedValue = "Telugu";
                        string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='Telugu']")).Text;
                        if (ExpectedValue == ActualValue)
                        {
                            CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                        }
                        else
                            CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                    }

                }

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}
