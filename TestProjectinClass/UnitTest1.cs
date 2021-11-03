using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Keys = OpenQA.Selenium.Keys;
using System.Threading;
using System.Linq;

namespace TestProjectinClass
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://newbookmodels.com/");
        }

        [Test]
        public void RegistrationTest()
        {
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class *='Navbar__signUp--12ZDV']"));
            buttonSignUp.Click();
            IWebElement buttonFirstName = driver.FindElement(By.CssSelector("[name = 'first_name']"));
            buttonFirstName.SendKeys("Naruto");
            IWebElement buttonLasttName = driver.FindElement(By.CssSelector("[name = 'last_name']"));
            buttonLasttName.SendKeys("Udzumaki");
            DateTime dataTime = new DateTime();
            dataTime = DateTime.Now;
            string nameOfUserAuthorization = dataTime.ToString();
            nameOfUserAuthorization = nameOfUserAuthorization.Replace(".", "");
            nameOfUserAuthorization = nameOfUserAuthorization.Replace(" ", "");
            nameOfUserAuthorization = nameOfUserAuthorization.Replace(":", "");
            nameOfUserAuthorization = "narutoSasuke" + nameOfUserAuthorization + "@gmail.com";
            IWebElement buttonEmail = driver.FindElement(By.CssSelector("[name='email']"));
            buttonEmail.SendKeys(nameOfUserAuthorization);
            IWebElement buttonPassword = driver.FindElement(By.CssSelector("[name='password']"));
            buttonPassword.SendKeys("Naruto_2345n");
            IWebElement buttonConfirmPassword = driver.FindElement(By.CssSelector("[name='password_confirm']"));
            buttonConfirmPassword.Clear();
            buttonConfirmPassword.SendKeys("Naruto_2345n");
            IWebElement buttonPhone = driver.FindElement(By.CssSelector("[name='phone_number']"));
            buttonPhone.SendKeys("2345234234");
            IWebElement buttonNext = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonNext.Click();
            IWebElement buttonCompanyName = driver.FindElement(By.CssSelector("[name='company_name']"));
            buttonCompanyName.SendKeys("Akatsuki");
            IWebElement buttonCompanyWedSite = driver.FindElement(By.CssSelector("[name='company_website']"));
            buttonCompanyWedSite.SendKeys("akatsuki.com");
            IWebElement buttonAdress = driver.FindElement(By.CssSelector("input[name=\"location\"]"));
            buttonAdress.SendKeys("11031 Mississippi Ave, Los Angeles, CA 90025, USA");
            Thread.Sleep(500);
            buttonAdress.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            buttonAdress.SendKeys(Keys.Enter);
            IWebElement industry = driver.FindElement(By.CssSelector("input[name=\"industry\"]"));
            industry.Click();
            IWebElement chosenIndustry = (IWebElement)driver.FindElements(By.ClassName("Select__option--1IbG6"))[1];
            chosenIndustry.Click();
            IWebElement finish = driver.FindElement(By.CssSelector("[type='submit']"));
            finish.Click();
            Assert.Pass();
        }

        [Test]
        public void LogInTest()
        {
            IWebElement logInButton = driver.FindElement(By.CssSelector("[class *=\"Navbar__navLink--3lL7S Navbar__navLinkSingle--3x6Lx Navbar__login--28b35\"]"));
            logInButton.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last()); 
            string title = driver.Title;
            IWebElement signInEmailButton = driver.FindElement(By.CssSelector("[class *= 'Input__input--_88SI Input__themeNewbook--1IRjd Input__fontRegular--2SStp']"));
            signInEmailButton.SendKeys("narutoSasuke02112021203621@gmail.com");
            IWebElement signInPasswordButton = driver.FindElement(By.CssSelector("[name = 'password']"));
            signInPasswordButton.SendKeys("Naruto_2345n");
            IWebElement signInLogInButton = driver.FindElement(By.CssSelector("[type='submit']"));
            signInLogInButton.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string titleR = driver.Title;
            IWebElement buttonCompanyName = driver.FindElement(By.CssSelector("[name='company_name']"));
            buttonCompanyName.SendKeys("Akatsuki");
            IWebElement buttonCompanyWedSite = driver.FindElement(By.CssSelector("[name='company_website']"));
            buttonCompanyWedSite.SendKeys("akatsuki.com");
            IWebElement buttonAdress = driver.FindElement(By.CssSelector("input[name=\"location\"]"));
            buttonAdress.SendKeys("11031 Mississippi Ave, Los Angeles, CA 90025, USA");
            Thread.Sleep(500);
            buttonAdress.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            buttonAdress.SendKeys(Keys.Enter);
            IWebElement industry = driver.FindElement(By.CssSelector("input[name=\"industry\"]"));
            industry.Click();
            IWebElement chosenIndustry = (IWebElement)driver.FindElements(By.ClassName("Select__option--1IbG6"))[1];
            chosenIndustry.Click();
            IWebElement finish = driver.FindElement(By.CssSelector("[type='submit']"));
            finish.Click();
            Assert.Pass();
        }

        [Test]
        public void LogOutTest()
        {
            IWebElement logInButton = driver.FindElement(By.CssSelector("[class *=\"Navbar__navLink--3lL7S Navbar__navLinkSingle--3x6Lx Navbar__login--28b35\"]"));
            logInButton.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string title = driver.Title;
            IWebElement signInEmailButton = driver.FindElement(By.CssSelector("[class *= 'Input__input--_88SI Input__themeNewbook--1IRjd Input__fontRegular--2SStp']"));
            signInEmailButton.SendKeys("narutoSasuke02112021203621@gmail.com");
            IWebElement signInPasswordButton = driver.FindElement(By.CssSelector("[name = 'password']"));
            signInPasswordButton.SendKeys("Naruto_2345n");
            IWebElement signInLogInButton = driver.FindElement(By.CssSelector("[type='submit']"));
            signInLogInButton.Click();
            IWebElement acountButton = driver.FindElement(By.CssSelector("[class *='AvatarClient__avatar--3TC7_']"));
            acountButton.Click();
            IWebElement logOutButton = driver.FindElement(By.CssSelector("[class *='link link_type_logout link_active']"));
            logOutButton.Click();
            Assert.Pass();
        }

        [Test]
        public void BrowseTalantedTest()
        {
            IWebElement browseButton = driver.FindElement(By.CssSelector("[class *='Navbar__navLink--3lL7S Navbar__navLinkSingle--3x6Lx']"));
            browseButton.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string title = driver.Title;
            IWebElement seePortfolioButton = (IWebElement)driver.FindElements(By.CssSelector("[class *='BrowseModel__action--3uPMB']"))[2];
            seePortfolioButton.Click();
            IWebElement signU = driver.FindElement(By.CssSelector("[class *='MainHeader__signup--fqm0x MainHeader__staticItem--2UY1x']"));
            signU.Click();
            IWebElement buttonFirstName = (IWebElement)driver.FindElement(By.CssSelector("[name = 'first_name']"));
            buttonFirstName.SendKeys("Naruto");
            IWebElement buttonLasttName = driver.FindElement(By.CssSelector("[name = 'last_name']"));
            buttonLasttName.SendKeys("Udzumaki");
            DateTime dataTime = new DateTime();
            dataTime = DateTime.Now;
            string nameOfUserAuthorization = dataTime.ToString();
            nameOfUserAuthorization = nameOfUserAuthorization.Replace(".", "");
            nameOfUserAuthorization = nameOfUserAuthorization.Replace(" ", "");
            nameOfUserAuthorization = nameOfUserAuthorization.Replace(":", "");
            nameOfUserAuthorization = "narutoSasuke" + nameOfUserAuthorization + "@gmail.com";
            IWebElement buttonEmail = driver.FindElement(By.CssSelector("[name='email']"));
            buttonEmail.SendKeys(nameOfUserAuthorization);
            IWebElement buttonPassword = driver.FindElement(By.CssSelector("[name='password']"));
            buttonPassword.SendKeys("Naruto_2345n");
            IWebElement buttonConfirmPassword = driver.FindElement(By.CssSelector("[name='password_confirm']"));
            buttonConfirmPassword.Clear();
            buttonConfirmPassword.SendKeys("Naruto_2345n");
            IWebElement buttonPhone = driver.FindElement(By.CssSelector("[name='phone_number']"));
            buttonPhone.SendKeys("2345234234");
            IWebElement buttonNext = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonNext.Click();
            IWebElement buttonCompanyName = driver.FindElement(By.CssSelector("[name='company_name']"));
            buttonCompanyName.SendKeys("Akatsuki");
            IWebElement buttonCompanyWedSite = driver.FindElement(By.CssSelector("[name='company_website']"));
            buttonCompanyWedSite.SendKeys("akatsuki.com");
            IWebElement buttonAdress = driver.FindElement(By.CssSelector("input[name=\"location\"]"));
            buttonAdress.SendKeys("11031 Mississippi Ave, Los Angeles, CA 90025, USA");
            Thread.Sleep(500);
            buttonAdress.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            buttonAdress.SendKeys(Keys.Enter);
            IWebElement industry = driver.FindElement(By.CssSelector("input[name=\"industry\"]"));
            industry.Click();
            IWebElement chosenIndustry = (IWebElement)driver.FindElements(By.ClassName("Select__option--1IbG6"))[1];
            chosenIndustry.Click();
            IWebElement finish = driver.FindElement(By.CssSelector("[type='submit']"));
            finish.Click();
            Assert.Pass();
        }

        [Test]
        public void AppleButtonLinkTest()
        {
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class *='Navbar__signUp--12ZDV']"));
            buttonSignUp.Click();
            IWebElement appleLinkKlick = driver.FindElement(By.CssSelector("[class *= 'SignupPageLayout__modelsLink--2zxUb']"));
            appleLinkKlick.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string title = driver.Title;
            Assert.Pass();
        }

        [Test]
        public void ViewModelsButtonTest()
        {
            IWebElement viewModelsButton = driver.FindElement(By.CssSelector("[class *= 'Hero__heroButtonLink--3AAFF']"));
            viewModelsButton.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string title = driver.Title;
            IWebElement seePortfolioButton = (IWebElement)driver.FindElements(By.CssSelector("[class *='BrowseModel__action--3uPMB']"))[4];
            seePortfolioButton.Click();
            Assert.Pass();
        }

        [Test]
        public void AddImageAvatar()
        {
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class *='Navbar__signUp--12ZDV']"));
            buttonSignUp.Click();
            IWebElement avatarImage= driver.FindElement(By.CssSelector("[class *='FileInput__container--DGYl- SignupAvatar__avatarFieldInner--Tu71w']"));
            avatarImage.Click();
            Assert.Pass();

        }

        [TearDown]
        public void After()
        {
            //driver.Quit();
        }
    }
}