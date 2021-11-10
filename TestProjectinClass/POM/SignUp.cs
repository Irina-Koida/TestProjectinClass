using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestProjectinClass.POM
{
    class SignUp
    {
        private readonly IWebDriver _webDriver;

        private readonly By _emailField = By.CssSelector("input[type=email]");
        private readonly By _password = By.CssSelector("input[type=password]");
        private readonly By _loginButton = By.CssSelector("button[class^=SignInForm__submitButton]");
        private readonly By _errorMessage = By.XPath("//*[contains(@class, 'SignInForm__submitButton')]/../../" +
            "div[contains(@class, 'PageFormLayout__errors--3dFcq')]/div/div");
        private readonly By _errorMessageByEmail = By.XPath("//input[@name = 'email']/../div[@class='FormErrorText__error---nzyq']");
        private readonly By _errorMessageByPassword = By.XPath("//input[@name = 'password']/../div[@class='FormErrorText__error---nzyq']/div");

        public SignUp(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SignUp GoToSignInPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            return this;
        }

        public SignUp ImputEmailField(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public SignUp ImputPasswordField(string password)
        {
            _webDriver.FindElement(_password).SendKeys(password);
            return this;
        }

        public void LogInButtonClick() =>
            _webDriver.FindElement(_loginButton).Click(); //красиво записали

        public string GetErrorMessage() =>
            _webDriver.FindElement(_errorMessage).Text;

        public string GetErrorMessageAboutEmail() =>
            _webDriver.FindElement(_errorMessageByEmail).Text;

        public string GetErrorMessageAboutPassword() =>
            _webDriver.FindElement(_errorMessageByPassword).Text;

    }
}

