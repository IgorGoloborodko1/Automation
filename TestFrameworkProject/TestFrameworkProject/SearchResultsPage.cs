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
    class SearchResultsPage
    {
        private IWebDriver _driver;
        [FindsBy(How = How.XPath, Using = "//h1[@itemprop='headline'][1]/a")]
        private IWebElement _searchResultPgFirstHeader;
        public SearchResultsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void CompareSearchResultHeader(string hardText)
        {
            Assert.AreEqual(hardText, _searchResultPgFirstHeader.Text);
        }
    }
}
