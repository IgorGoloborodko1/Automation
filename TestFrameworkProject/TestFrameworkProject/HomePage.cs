using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFrameworkProject
{
    class HomePage
    {
        private IWebDriver _driver;
        [FindsBy(How = How.XPath, Using = "//li[@class='orb-nav-newsdotcom']/a")]
        private IWebElement _news;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            _driver.Manage().Window.Maximize();
        }
        public void Navi()
        {
            _driver.Navigate().GoToUrl("https://www.bbc.com/");
            _news.Click();
        }
    }
}
