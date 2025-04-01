using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace Appium_BrowserStack.AppWebElements
{
    [TestFixture]
    public class Invoke
    {
        public AndroidDriver driver;

        [OneTimeSetUp]
        public void setup()
        {
            string browserStackUrl = "https://vaishnavim_NnFb2f:gEkpSRqftqsipyyFTyB1@hub-cloud.browserstack.com/wd/hub";

            var appId = "<bs://5c07a8540777d20458d7360d4bb85074b6fcbc0b>"; // App ID after uploading your APK

            var driverOptions = new AppiumOptions()
            {
                PlatformName = "Android",
                DeviceName = "Samsung Galaxy S20",  // Replace with a valid BrowserStack device
                PlatformVersion = "10.0",          // Replace with the desired platform version
                AutomationName = AutomationName.AndroidUIAutomator2,
                App = appId,                       // The App ID from BrowserStack
            };

            // Add BrowserStack-specific capabilities using AddAdditionalAppiumOption
            driverOptions.AddAdditionalAppiumOption("browserstack.username", Environment.GetEnvironmentVariable("vaishnavim_NnFb2f"));
            driverOptions.AddAdditionalAppiumOption("browserstack.accessKey", Environment.GetEnvironmentVariable("gEkpSRqftqsipyyFTyB1"));
            driverOptions.AddAdditionalAppiumOption("name", "Appium Test on BrowserStack"); // Test name
            driverOptions.AddAdditionalAppiumOption("build", "Appium Test Build 1"); // Build name

            driver = new AndroidDriver(new Uri(browserStackUrl), driverOptions, TimeSpan.FromSeconds(180));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Dispose();
        }

        [Test]
        public void AppInvoketest()
        {

            //2 execution code(git actiosn reuslt)
            //IWebElement view = driver.FindElement(By.XPath("//android.widget.TextView[@content-desc='Views']"));
            //view.Click();

            //3rd execution code 
            //IWebElement view = driver.FindElement(By.XPath("//ndroid.widget.TextView[@content-desc='Views']"));
            //view.Click();

            //4th execution code 
            try
            {
                IWebElement view = driver.FindElement(By.XPath("//ndroid.widget.TextView[@content-desc='Views']"));
                view.Click();
            }
            catch (NoSuchElementException ex)
            {
                // Log the exception to ensure it is captured in the BrowserStack logs
                Console.WriteLine("Element not found: " + ex.Message);
                Assert.Fail("Test failed due to: " + ex.Message);  // Explicitly fail the test
            }
            catch (Exception ex)
            {
                // Catch any other exceptions
                Console.WriteLine("Error: " + ex.Message);
                Assert.Fail("Test failed due to: " + ex.Message);  // Explicitly fail the test
            }



        }
    }
}
