using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestProjectinClass.POM
{
    class SignIn
    {
        private readonly IWebDriver _webDriver;

        public SignIn(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SignIn GoToSignInPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            return this;
        }
    }
}
