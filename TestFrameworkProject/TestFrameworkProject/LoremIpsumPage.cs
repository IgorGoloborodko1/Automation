using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFrameworkProject
{
    class LoremIpsumPage
    {
        private IWebDriver _driver;
        [FindsBy(How = How.XPath, Using = "//label[@for='bytes']")]
        private IWebElement _bytesRadio;
        [FindsBy(How = How.XPath, Using = "//*[@id='amount']")]
        private IWebElement _amountField;
        [FindsBy(How = How.XPath, Using = "//*[@id='generate']")]
        private IWebElement _submitButton;
        [FindsBy(How = How.XPath, Using = "//*[@id='lipsum']/p")]
        private IWebElement _generatedOutput;

        public LoremIpsumPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string GenerateText(int numOfChars)
        {
            string strNumOfChars = (numOfChars * 2).ToString();
            _driver.Navigate().GoToUrl("https://www.lipsum.com/");
            _driver.Manage().Window.Maximize();
            _bytesRadio.Click();
            _amountField.Click();
            _amountField.Clear();
            _amountField.SendKeys(strNumOfChars);
            _submitButton.Click();
            string newStr = _generatedOutput.Text;
            return newStr;
        }
    }
}
