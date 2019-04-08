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
    public class AddEducation
    {
        [Given(@"I clicked on the Education tab under Profile page")]
        public void GivenIClickedOnTheEducationTabUnderProfilePage()
        {
            //clicking on Education tab

            Driver.driver.FindElement(By.XPath("//a[text()='Education']")).Click();
        }
        
        [When(@"I add a new Education details")]
        public void WhenIAddANewEducationDetails()
        {

//adding first education detais

            //clicking on add new tab
            Driver.driver.FindElement(By.XPath("//th[text()='Graduation Year']//following::div[1]")).Click();
            //entering college or uni name
            Driver.driver.FindElement(By.XPath("//input[@placeholder='College/University Name']")).SendKeys("JNTU");
            //selecting college of country
            Driver.driver.FindElement(By.XPath("//select[@name='country']")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.XPath("//option[text()='India']")).Click();
            //Selecting course title
            Driver.driver.FindElement(By.XPath("//select[@name='title']")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.XPath("//option[text()='B.Tech']")).Click();
            //entering degree
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Degree']")).SendKeys("Under Graduation");
            //selecting year of graduation
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Degree']")).Click();
            Thread.Sleep(2000);
            Driver.driver.FindElement(By.XPath("//option[text()='2010']")).Click();
            Thread.Sleep(1000);
            //clicking on add button
            Driver.driver.FindElement(By.XPath("//div[@class='sixteen wide field']/input[1]")).Click();
            Thread.Sleep(2000);

 // adding second education details           

            //clicking on add new tab 2nd time
            Driver.driver.FindElement(By.XPath("//th[text()='Graduation Year']//following::div[1]")).Click();
            //entering college or uni name
            Driver.driver.FindElement(By.XPath("//input[@placeholder='College/University Name']")).SendKeys("USQ/UUNZ");
            //selecting college of country
            Driver.driver.FindElement(By.XPath("//select[@name='country']")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.XPath("//option[text()='New Zealand']")).Click();
            //Selecting course title
            Driver.driver.FindElement(By.XPath("//select[@name='title']")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.XPath("//option[text()='M.A']")).Click();
            //entering degree
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Degree']")).SendKeys("Post Graduation");
            //selecting year of graduation
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Degree']")).Click();
            Thread.Sleep(2000);
            Driver.driver.FindElement(By.XPath("//option[text()='2017']")).Click();
            Thread.Sleep(1000);
            //clicking on add button
            Driver.driver.FindElement(By.XPath("//div[@class='sixteen wide field']/input[1]")).Click();
            Thread.Sleep(2000);
        }
        
        [Then(@"that Education Details should be displayed on my listings")]
        public void ThenThatEducationDetailsShouldBeDisplayedOnMyListings()
        {
            Assert.IsTrue(Driver.driver.FindElement(By.XPath("//td[text()='JNTU']")).Displayed);
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Education");

                Thread.Sleep(1000);
                string ExpectedValue = "JNTU";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='JNTU']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added Education details Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Education Details Added");
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
