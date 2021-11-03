using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Linq;
using TestProjectinClass.POD;
using NUnit.Framework;

namespace TestProjectinClass
{
    public class UITests
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Dispose();
        }

        [Test]
        public void Test()
        {
            var signInPage = new SignUp(_webDriver);
            signInPage.GoToSignInPage()
                .ImputEmailField("wrongEmail@gmail.com")
                .ImputPasswordField("wrongPassword123")
                .LogInButtonClick();
            var actualResultMessage = signInPage.GetErrorMessage();

            Assert.AreEqual(expected: "Please enter a correct email and password.", actualResultMessage);
        }

        [TearDown]
        public void After()
        {
            //_webDriver.Quit();
        }
    }
}