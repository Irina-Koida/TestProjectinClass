using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestProjectinClass.POM
{
    class GreetingHomePage
    {
        private readonly IWebDriver _webDriver;
        private readonly By _welconeInAccount = By.CssSelector("[class='WelcomePage__welcomeBackSection--1fVmu'] [class='Section__title--1wSQt']");

        public GreetingHomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string CheckATryLogIn =>
            _webDriver.FindElement(_welconeInAccount).Text;
    }
}