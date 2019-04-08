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
    public class AddDescrption
    {
        [Given(@"I clicked on the Description edit button on Profile page")]
        public void GivenIClickedOnTheDescriptionEditButtonOnProfilePage()
        {
            Driver.driver.FindElement(By.XPath("//a[text()='Profile']")).Click();
            Thread.Sleep(3000);
            //clicking descrption edit button
            Driver.driver.FindElement(By.XPath("//h3[text()='Description']//following::i[1]")).Click();
        }
        
        [When(@"I write the description and save iy")]
        public void WhenIWriteTheDescriptionAndSaveIy()
        {
            Driver.driver.FindElement(By.XPath("//textarea[@name='value']")).Clear();
            // entering description
            Thread.Sleep(2000);
            Driver.driver.FindElement(By.XPath("//textarea[@name='value']")).SendKeys("hi this is lavanya i have 2 years of experience as a test analyst");
            //clicking save button
            Driver.driver.FindElement(By.XPath("//textarea[@name='value']//following::button")).Click();

        }
        
        [Then(@"That Description should be displayed in Discrption tab")]
        public void ThenThatDescriptionShouldBeDisplayedInDiscrptionTab()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Description");

                Thread.Sleep(1000);
                string ExpectedValue = "hi this is lavanya i have 2 years of experience as a test analyst";
                string ActualValue = Driver.driver.FindElement(By.XPath("//textarea[@name='value']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added Description Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Description Added");
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
