using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestProjectinClass.POM
{
    class AccountSettings
    {
        private readonly IWebDriver _webDriver;
        private readonly By _accountButton = By.CssSelector("[class *='AvatarClient__avatar--3TC7_']");

        private readonly By _passwordType = By.CssSelector("input[type=password]");

        private readonly By _infoEditGeneral = By.CssSelector("[class='ng-untouched ng-pristine ng-valid'] [class='edit-switcher__icon_type_edit']");
        private readonly By _editIndustry = By.XPath("//common-border/div[1]/div/nb-account-info-general-information/form/div[2]/div/nb-paragraph[4]");

        private readonly By _editGeneralInfoEmail = By.CssSelector("nb-account-info-email-address [class='edit-switcher__icon_type_edit']");
        private readonly By _editGeneralInfoPassword = By.CssSelector("nb-account-info-password [class='edit-switcher__icon_type_edit']");
        private readonly By _editGeneralInfoPhone = By.CssSelector("nb-account-info-phone [class='edit-switcher__icon_type_edit']");
        private readonly By _editGeneralInfoFirstName = By.CssSelector("input[placeholder='Enter First Name']");
        private readonly By _editGeneralInfoLastName = By.CssSelector("input[placeholder='Enter Last Name']");
        private readonly By _editGeneralInfoLocation = By.CssSelector("input[placeholder='Enter Company Location']");
        private readonly By _editGeneralInfoIndustry = By.CssSelector("input[placeholder='Enter Industry']");
        private readonly By _saveGeneralInfoEdition = By.CssSelector("[type=\"submit\"]");

        private readonly By _primaryAccountHolderName = By.XPath("/html/body/nb-app/ng-component/nb-internal-layout/" +
            "common-layout/section/div/ng-component/nb-account-info-edit/common-border" +
            "/div[1]/div/nb-account-info-general-information/form/div[2]/div/nb-paragraph[2]/div"); //By.CssSelector("[@class=\'paragraph_type_gray\'][2]");
        //private readonly By _companyLocation = By.XPath("/html/body/nb-app/ng-component/nb-internal-layout/common-layout/" +
        //    "section/div/ng-component/nb-account-info-edit/common-border" +
        //    "/div[1]/div/nb-account-info-general-information/form/div[2]/div/nb-paragraph[3]/div");

        private readonly By _greetingHomePage = By.CssSelector("[class='HeaderLine__logo--104lH ']");

        public AccountSettings(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void ClickAccountButton() =>
            _webDriver.FindElement(_accountButton).Click();

        public AccountSettings ImputPasswordType()
        {
            _webDriver.FindElement(_passwordType).SendKeys("HarryPotter - thedeath2");
            return this;
        }

        public AccountSettings EditGeneralInfo()
        {
            _webDriver.FindElement(_infoEditGeneral).Click();
            return this;
        }

        public AccountSettings EditGeneralInfoFirstName(string firstName)
        {
            _webDriver.FindElement(_editGeneralInfoFirstName).Clear();
            _webDriver.FindElement(_editGeneralInfoFirstName).SendKeys(firstName);
            return this;
        }

        public void GoToGreetingHomeHage()
        {
            _webDriver.FindElement(_greetingHomePage).Click();
        }

        public AccountSettings EditGeneralInfoLastName(string lastName)
        {
            _webDriver.FindElement(_editGeneralInfoLastName).Clear();
            _webDriver.FindElement(_editGeneralInfoLastName).SendKeys(lastName);
            return this;
        }

        public AccountSettings EditGeneralInfoIndustry(string industry)
        {
            _webDriver.FindElement(_editGeneralInfoIndustry).Clear();
            _webDriver.FindElement(_editGeneralInfoIndustry).SendKeys(industry);
            return this;
        }

        public string EditIndustry()
        {
            return _webDriver.FindElement(_editIndustry).Text;
        }

        public AccountSettings EditGeneralInfoCompanyAddress(string address)
        {
            _webDriver.FindElement(_editGeneralInfoLocation).Click();
            _webDriver.FindElement(_editGeneralInfoLocation).SendKeys(Keys.Control + "a");
            _webDriver.FindElement(_editGeneralInfoLocation).SendKeys(Keys.Delete);
            _webDriver.FindElement(_editGeneralInfoLocation).Clear();
            Thread.Sleep(1500);
            _webDriver.FindElement(_editGeneralInfoLocation).SendKeys(address);
            Thread.Sleep(1500);
            _webDriver.FindElement(_editGeneralInfoLocation).SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            _webDriver.FindElement(_editGeneralInfoLocation).SendKeys(Keys.Enter);
            return this;
        }

        public string EditInfoLocation()
        {
            return _webDriver.FindElement(_editGeneralInfoLocation).Text;
        }

        public AccountSettings EditGeneralInfoEmail()
        {
            _webDriver.FindElement(_editGeneralInfoEmail).Click();
            return this;
        }

        public AccountSettings EditGeneralInfoPassword()
        {
            _webDriver.FindElement(_editGeneralInfoPassword).Click();
            return this;
        }

        public AccountSettings EditGeneralInfoPhone(string phone)
        {
            _webDriver.FindElement(_editGeneralInfoPhone).Click();
            _webDriver.FindElement(_editGeneralInfoPhone).Clear();
            _webDriver.FindElement(_editGeneralInfoPhone).SendKeys(phone);
            return this;
        }

        public AccountSettings SaveGeneralInfoEdition()
        {
            _webDriver.FindElement(_saveGeneralInfoEdition).Click();
            return this;
        }

        public string GetPrimaryAccountName() => _webDriver.FindElement(_primaryAccountHolderName).Text;

        //public string CompanyLocation() => _webDriver.FindElement(_companyLocation).Text;
    }
}
