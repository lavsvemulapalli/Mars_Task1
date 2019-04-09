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
    public class DeleteingLanguageSteps
    {
        [Given(@"I click on the Language tab under Profile page")]
        public void GivenIClickOnTheLanguageTabUnderProfilePage()
        {
            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//a[text()='Profile']")).Click();

        }
        
        [When(@"I click on Delete option in language list")]
        public void WhenIClickOnDeleteOptionInLanguageList()
        {
            Driver.driver.FindElement(By.XPath("//td[text()='Hindi']//following::i[2]")).Click();
            Thread.Sleep(1000);
        }
        
        [Then(@"I check if language is deleted or not")]
        public void ThenICheckIfLanguageIsDeletedOrNot()
        {
            Assert.AreEqual("Hindi has been deleted from your languages", Driver.driver.FindElement(By.CssSelector(".ns-box-inner")).Text);
            Thread.Sleep(2000);
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "Hindi has been deleted from your languages";
                string ActualValue = Driver.driver.FindElement(By.CssSelector(".ns-box-inner")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, delted a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageDeleted");
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
