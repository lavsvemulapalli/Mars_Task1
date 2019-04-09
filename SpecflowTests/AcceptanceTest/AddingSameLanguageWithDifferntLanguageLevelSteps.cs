using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class AddingSameLanguageWithDifferntLanguageLevelSteps
    {
        [Given(@"I click on the Language tab under Profile")]
        public void GivenIClickOnTheLanguageTabUnderProfile()
        {
            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//a[text()='Profile']")).Click();

        }
        
        [Given(@"I have enter same language and with differnt language level")]
        public void GivenIHaveEnterSameLanguageAndWithDifferntLanguageLevel()
        {
            Driver.driver.FindElement(By.XPath("//div[text()='Add New']")).Click();
            //Add Language
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']")).SendKeys("English");
            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']")).Click();
            Thread.Sleep(2000);
            //Choose the language level
            Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']//following::option[3]")).Click();
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }
        
        [Then(@"check if user is able to add the same language or not")]
        public void ThenCheckIfUserIsAbleToAddTheSameLanguageOrNot()
        {
            //handling popup
            Assert.AreEqual("Duplicated data", Driver.driver.FindElement(By.CssSelector(".ns-box-inner")).Text);
            Driver.driver.FindElement(By.CssSelector(".ns-close")).Click();
            Driver.driver.FindElement(By.XPath("//input[@class='ui button' and @value='Cancel']")).Click();
            Thread.Sleep(5000);
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("adding same language (English) with differnt language level");

                Thread.Sleep(1000);
                string ExpectedValue = "Duplicated data";
                string ActualValue = Driver.driver.FindElement(By.CssSelector(".ns-box-inner")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, not adding same language (English) with differnt language level");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SameLanguagewithdifferentlevel");
                    
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }






        }
    }
}
