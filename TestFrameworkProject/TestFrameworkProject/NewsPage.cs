using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFrameworkProject
{
    class NewsPage
    {
        private IWebDriver _driver;
        [FindsBy(How = How.XPath, Using = "(//*[@data-entityid='container-top-stories#1']//h3)[1]")]
        private IWebElement _mainTitle;
        [FindsBy(How = How.XPath, Using = "//li[@class='nw-c-promo-meta'][2]/a")]
        private IWebElement _mainTitleCategory;
        [FindsBy(How = How.XPath, Using = "//*[@id='orb-search-q']")]
        private IWebElement _searchInput;
        [FindsBy(How = How.XPath, Using = "//span[@class='nw-c-nav__wide-morebutton-separator']/button/span[text()='More']")]
        private IWebElement _newsSectionMore;
        [FindsBy(How = How.XPath, Using = "//span[text()='Have Your Say']")]
        private IWebElement _haveYourSay;
        [FindsBy(How = How.XPath, Using = "//*[@id='topos-component']/div[4]/div/div[1]/div/div[1]/div/div[2]/div[1]")]
        private IWebElement _doYouHaveAQuestion;

        public NewsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(10)));
        }
        public void GoToHaveYourSayPage()
        {
            _newsSectionMore.Click();
            _haveYourSay.Click();
            _doYouHaveAQuestion.Click();
        }
        public void VerifyMainArticleTitle(string hardMainTitle)
        {
            Assert.AreEqual(hardMainTitle, _mainTitle.Text);
        }
        public void VerifySecondaryArticlesTitles(List<string> hardTitlesList)
        {
            foreach (string elem in hardTitlesList)
            {
                _driver.FindElement(By.XPath($"//h3[text()=\"{elem}\"]"));
            }
        }
        public void SubmitInput()
        {
            _searchInput.SendKeys(_mainTitleCategory.Text);
            _searchInput.SendKeys(Keys.Return);
        }
    }
}
