using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace AppiumPractise.AppWebElements
{
    [TestFixture]
    public class AppInvoke
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
            IWebElement view = driver.FindElement(By.XPath("//android.widget.TextView[@content-desc='Views']"));
            view.Click();
        }
    }
}
