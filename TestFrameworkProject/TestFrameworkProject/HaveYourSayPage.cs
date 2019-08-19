using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFrameworkProject
{
    class HaveYourSayPage
    {
        private IWebDriver _driver;
        [FindsBy(How = How.XPath, Using = "//div/textarea[@placeholder='What questions would you like us to investigate?']")]
        private IWebElement _textArea;
        [FindsBy(How = How.XPath, Using = "//div/label/input[@placeholder='Name']")]
        private IWebElement _nameField;
        [FindsBy(How = How.XPath, Using = "//div/label/input[@placeholder='Email address']")]
        private IWebElement _emailAdressField;
        [FindsBy(How = How.XPath, Using = "//div/label/input[@placeholder='Age']")]
        private IWebElement _ageField;
        [FindsBy(How = How.XPath, Using = "//div/label/input[@placeholder='Postcode']")]
        private IWebElement _postalCodeField;
        [FindsBy(How = How.XPath, Using = "//div/p[text()=\"Please don't publish my name\"]")]
        private IWebElement _dontPublishName;
        [FindsBy(How = How.XPath, Using = "//div[@class='button-container']/button[text()='Submit']")]
        private IWebElement _submitButton;
        [FindsBy(How = How.XPath, Using = "//div[@class='input-error-message'][text()='Name can\'t be blank']")]
        private IWebElement _errorMessageFillYourName;
        [FindsBy(How = How.XPath, Using = "//div[@class='input-error-message'][text()='Email address can\'t be blank']")]
        private IWebElement _errorMessageFillYourEmail;

        public HaveYourSayPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            _driver.Manage().Window.Maximize();

        }
        
        public void MakeScreenshot()
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)_driver;
            screenshot.GetScreenshot().SaveAsFile("screen", ScreenshotImageFormat.Png);
        }

        public void Fillform(Dictionary<string, string> val, bool submit, string generatedText)
        {
            _textArea.Click();
            _textArea.SendKeys(generatedText);

            foreach(string key in val.Keys)
            {
                if (key.Equals("name"))
                {
                   _nameField.Click();
                   _nameField.SendKeys(val["name"]);
                }
                if (key.Equals("age"))
                {
                    _ageField.Click();
                    _ageField.SendKeys(val["age"]);
                }
                if (key.Equals("postalCode"))
                {
                    _postalCodeField.Click();
                    _postalCodeField.SendKeys(val["postalCode"]);
                }
                if (key.Equals("email"))
                {
                    _emailAdressField.Click();
                    _emailAdressField.SendKeys(val["email"]);
                }
            }

            if (submit == false)
            {
                MakeScreenshot();
            }
            else
            {
                _submitButton.Click();
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                Assert.AreEqual( "Name can\'t be blank", _errorMessageFillYourEmail);
            }
        }
    }
}
