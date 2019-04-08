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
    public class AddCertification
    {
        [Given(@"I clicked on the Certification tab under Profile page")]
        public void GivenIClickedOnTheCertificationTabUnderProfilePage()
        {
            //click on certification tab
            Driver.driver.FindElement(By.XPath("//a[text()='Certifications']")).Click();
        }
        
        [When(@"I add a new Certification details")]
        public void WhenIAddANewCertificationDetails()
        {
            //click on add new tab
            Driver.driver.FindElement(By.XPath("//th[text()='Year']//following::div[1]")).Click();
            //entering certification name
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']")).SendKeys("ISTQB");
            //entering certification from
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Certified From (e.g. Adobe)']")).SendKeys("ISTQB/ANZTB");
            //selecting year of certification
            Driver.driver.FindElement(By.XPath("//select[@name='certificationYear']")).Click();
            Thread.Sleep(2000);
            Driver.driver.FindElement(By.XPath("//select[@name='certificationYear']//following::option[2]")).Click();
            Thread.Sleep(2000);
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();

            Thread.Sleep(3000);
        }
        
        [Then(@"that Certification Details should be displayed on my listings")]
        public void ThenThatCertificationDetailsShouldBeDisplayedOnMyListings()
        {
            Assert.IsTrue(Driver.driver.FindElement(By.XPath("//td[text()='ISTQB']")).Displayed);
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Certificate");

                Thread.Sleep(1000);
                string ExpectedValue = "ISTQB";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='ISTQB']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Certificate Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Certificate Added");
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
