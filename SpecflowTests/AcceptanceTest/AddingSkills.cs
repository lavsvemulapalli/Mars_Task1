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
    public class AddingSkills
    {
        [Given(@"I clicked on the Skills tab under Profile page")]
        public void GivenIClickedOnTheSkillsTabUnderProfilePage()
        {
            //click on skills tab
            Driver.driver.FindElement(By.XPath("//a[text()='Skills']")).Click();
        }
        
        [When(@"I add a new Skills")]
        public void WhenIAddANewSkills()
        {
            
//adding manual Testing

            //Click on Add New button first time
            Driver.driver.FindElement(By.XPath("//div[@class='ui teal button']")).Click();
            //Add skills
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']")).SendKeys("Manual Testing");
            //Click on skills Level
            Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']")).Click();
            Thread.Sleep(2000);
            //Choose the skills level
            Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']//following::option[3]")).Click();
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
            Thread.Sleep(3000);

//adding Automation Testing

            //Click on Add New button secondtime time
            Driver.driver.FindElement(By.XPath("//div[@class='ui teal button']")).Click();
            //Add skills
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']")).SendKeys("Automation Testing");
            //Click on skills Level
            Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']")).Click();
            Thread.Sleep(2000);
            //Choose the skills level
            Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']//following::option[3]")).Click();
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
            Thread.Sleep(3000);
            
// adding API Testing

            //Click on Add New button third time
            Driver.driver.FindElement(By.XPath("//div[@class='ui teal button']")).Click();
            //Add skills
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']")).SendKeys("API Testing");
            //Click on skills Level
            Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']")).Click();
            Thread.Sleep(2000);
            //Choose the skills level
            Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']//following::option[2]")).Click();
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
            Thread.Sleep(3000);

//adding Perfomance Testing


            //Click on Add New button fourth time
            Driver.driver.FindElement(By.XPath("//div[@class='ui teal button']")).Click();
            //Add skills
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']")).SendKeys("Perfomance Testing");
            //Click on skills Level
            Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']")).Click();
            Thread.Sleep(2000);
            //Choose the skills level
            Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']//following::option[1]")).Click();
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
            Thread.Sleep(2000);

        }

        [Then(@"that Skills should be displayed on my listings")]
        public void ThenThatSkillsShouldBeDisplayedOnMyListings()
        {
            Assert.IsTrue(Driver.driver.FindElement(By.XPath("//td[text()='Automation Testing']")).Displayed);

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "Automation Testing";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='Automation Testing']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillAdded");
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
