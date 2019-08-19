using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace TestFrameworkProject
{
    [TestClass]
    public class UnitTest1
    {
        #region
        private IWebDriver _driver;
        private HomePage _homePage;
        private NewsPage _newsPage;
        private LoremIpsumPage _loremIpsumPage;
        private HaveYourSayPage _haveYourSayPage;
        private SearchResultsPage _searchResultsPage;
        private Dictionary<string, string> _values = new Dictionary<string, string>();
        private Dictionary<string, string> _valuesMissingName = new Dictionary<string, string>();
        private Dictionary<string, string> _valuesMissingEmail = new Dictionary<string, string>();
        [TestInitialize]
        public void TestInitialize()
        {
            _driver = new ChromeDriver();
            _homePage = new HomePage(_driver);
            _newsPage = new NewsPage(_driver);
            _loremIpsumPage = new LoremIpsumPage(_driver);
            _haveYourSayPage = new HaveYourSayPage(_driver);
            _searchResultsPage = new SearchResultsPage(_driver);
            _values.Add("name", "Igor");
            _values.Add("email", "igor.goloborodko19@gmail.com");
            _values.Add("postalCode", "02099");
            _values.Add("age", "16");
            _valuesMissingName.Add("email", "ig@ukr.net");
            _valuesMissingName.Add("age", "88");
            _valuesMissingName.Add("postalCode", "12222");
            _valuesMissingEmail.Add("name", "Igor");
            _valuesMissingEmail.Add("postalCode", "02099");
            _valuesMissingEmail.Add("age", "16");
        }
        #endregion
        [TestMethod]
        public void VerifyNewsMainTitle()
        {
            _homePage.Navi();
            _newsPage.VerifyMainArticleTitle("Detained Iran oil tanker sets sail from Gibraltar");
        }
        [TestMethod]
        public void VerifyNewSecondaryArticles()
        {
            _homePage.Navi();
            List<string> hardTitles = new List<string>
            {
                "Prince Andrew 'appalled' by Epstein's sex abuse claims",
                "Afghan groom has 'lost hope' after wedding blast",
                "Russian's 1969 message in a bottle found in Alaska",
                "The paradise island that wants to ditch plastic"
            };
            _newsPage.VerifySecondaryArticlesTitles(hardTitles);
        }
        [TestMethod]
        public void VerifySearchResult()
        {
            _homePage.Navi();
            _newsPage.SubmitInput();
            _searchResultsPage.CompareSearchResultHeader("Europe");
        }
        [TestMethod]
        public void FillFullFormAndScreenshot()
        {
            string loremText = _loremIpsumPage.GenerateText(140);
            _homePage.Navi();
            _newsPage.GoToHaveYourSayPage();
            _haveYourSayPage.Fillform(_values, false, loremText);
        }
        [TestMethod]
        public void SubmitQuestionWithoutName()
        {
            string loremText = _loremIpsumPage.GenerateText(122);
            _homePage.Navi();
            _newsPage.GoToHaveYourSayPage();
            _haveYourSayPage.Fillform(_valuesMissingName, true, loremText);
            _haveYourSayPage.VerifyMissingNameError();
        }
        [TestMethod]
        public void SubmitQuestionWithoutEmail()
        {
            string loremText = _loremIpsumPage.GenerateText(122);
            _homePage.Navi();
            _newsPage.GoToHaveYourSayPage();
            _haveYourSayPage.Fillform(_valuesMissingEmail, true, loremText);
            _haveYourSayPage.VerifyMissingEmailError();
        }
        [TestMethod]
        public void ExceedTextAreaLimit()
        {
            string loremText = _loremIpsumPage.GenerateText(200);
            _homePage.Navi();
            _newsPage.GoToHaveYourSayPage();
            _haveYourSayPage.Fillform(_values, false, loremText);
        }
    }
}
