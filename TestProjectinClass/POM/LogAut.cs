using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestProjectinClass.POM
{
    class LogAut
    {
        private readonly IWebDriver _webDriver;
        private readonly By _accountButton = By.CssSelector("[class *='AvatarClient__avatar--3TC7_']");
        private readonly By _emailField = By.CssSelector("input[type=email]");
        private readonly By _password = By.CssSelector("input[type=password]");
        private readonly By _logInButton = By.CssSelector("button[class^=SignInForm__submitButton]");
        private readonly By _logOutButton = By.CssSelector("[class *='link link_type_logout link_active']");

        public LogAut(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public LogAut GoToHomePage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/explore");
            return this;
        }

        public LogAut ImputEmailField(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public LogAut ImputPasswordField(string password)
        {
            _webDriver.FindElement(_password).SendKeys(password);
            return this;
        }

        public void LogInButtonClick() =>
            _webDriver.FindElement(_logInButton).Click();

        public void ClickAccountButton() =>
            _webDriver.FindElement(_accountButton).Click();

        public void ClickLogAutButton() =>
            _webDriver.FindElement(_logOutButton).Click();
    }
}

