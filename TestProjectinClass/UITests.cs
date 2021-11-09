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

        [Test]
        public void LoginWithEmptyEmail()
        {
            var signInPage = new SignUp(_webDriver);
            signInPage.GoToSignInPage()
                .ImputEmailField("")
                .ImputPasswordField(HelpForTests.PasswordLogIn())
                .LogInButtonClick();
            var actualResultMessage = signInPage.GetErrorMessageAboutEmail();
            Assert.AreEqual(expected: "Required", actualResultMessage);
        }

        [TestCase("")]
        public void LoginWithEmptyPassword()
        {
            var signInPage = new SignUp(_webDriver);
            signInPage.GoToSignInPage()
                .ImputEmailField(HelpForTests.EmailLogIn())
                .ImputPasswordField("")
                .LogInButtonClick();
            var actualResultMessage = signInPage.GetErrorMessageAboutPassword();
            Assert.AreEqual(expected: "Required", actualResultMessage);
        }

        [TestCase("", "")]
        public void LoginWithEmptyPasswordAndEmail(string email, string password)
        {
            var signInPage = new SignUp(_webDriver);
            signInPage.GoToSignInPage()
                .ImputEmailField(email)
                .ImputPasswordField(password)
                .LogInButtonClick();
            var actualResultMessage = signInPage.GetErrorMessageAboutPassword() + signInPage.GetErrorMessageAboutEmail();
            Assert.AreEqual(expected: "RequiredRequired", actualResultMessage);
        }

        [Test]
        public void LoginWithValidLogginAndPass()
        {
            var signInPage = new SignUp(_webDriver);
            var home = new GreetingHomePage(_webDriver);
            signInPage.GoToSignInPage()
                .ImputEmailField(HelpForTests.EmailLogIn())
                .ImputPasswordField(HelpForTests.PasswordLogIn())
                .LogInButtonClick();
            var actualResultMessage = home.CheckATryLogIn;
            Assert.AreEqual(expected: "Welcome back Naruto! How can we help?", actualResultMessage);
        }

        [Test]
        public void ErrorSubmitTest()
        {
            var signInPage = new SignUp(_webDriver);
            signInPage.GoToSignInPage()
                .ImputEmailField("wrongEmail@gmail.com")
                .ImputPasswordField("wrongPassword123")
                .LogInButtonClick();
            var actualResultMessage = signInPage.GetErrorMessage();

            Assert.AreEqual(expected: "Please enter a correct email and password.", actualResultMessage);
        }

        [Test]
        public void RegistrationWitfValidData()
        {
            var registrationPage = new Registration(_webDriver);
            var home = new GreetingHomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(HelpForTests.FirstName())
                .InputLastName(HelpForTests.LastName())
                .InputEmail(HelpForTests.EmailUser())
                .InputPassword(HelpForTests.RegistrationPassword())
                .InputConfirmPassword(HelpForTests.RegistrationConfirmPassword())
                .InputPhoneNumber(HelpForTests.PhoneNumber())
                .ClickNextButton();

            registrationPage.InputCompanyName(HelpForTests.CompanyName())
                .InputCompanyWebSite(HelpForTests.CompanySite())
                .InputCompanyAddress(HelpForTests.CompanyAddress())
                .InputCompanyIndustry(5)
                .ClickOnFinishRegistration();

            Assert.AreEqual(expected: $"Welcome {HelpForTests.FirstName()}! How can we help?", home.CheckATryLogIn);
        }

        public void RegistrationWithInValidEmail()
        {
            var registrationPage = new Registration(_webDriver);
            var homePage = new GreetingHomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(HelpForTests.FirstName())
                .InputLastName(HelpForTests.LastName())
                .InputEmail("name")
                .InputPassword(HelpForTests.RegistrationPassword())
                .InputConfirmPassword(HelpForTests.RegistrationConfirmPassword())
                .InputPhoneNumber(HelpForTests.PhoneNumber())
                .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutEmail();

            Assert.AreEqual(expected: "Invalid Email", actualResultat);
        }

        [TestCase("3344556678qe_d", "3344556678qe_d")]
        public void RegistrationWithInValidPasswordUppercase(string password, string confirmPassword)
        {
            var registrationPage = new Registration(_webDriver);
            var homePage = new GreetingHomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(HelpForTests.FirstName())
                .InputLastName(HelpForTests.LastName())
                .InputEmail(HelpForTests.EmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(HelpForTests.PhoneNumber())
                .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutPassword() + " " + registrationPage.errorTextAboutPasswordUpperCase();

            Assert.AreEqual(expected: "Invalid password format At least one capital letter", actualResultat);
        }

        [TestCase("2233445567QE_D", "2233445567QE_D")]
        public void RegistrationWithInValidPasswordLowercase(string password, string confirmPassword)
        {
            var registrationPage = new Registration(_webDriver);
            var homePage = new GreetingHomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(HelpForTests.FirstName())
                .InputLastName(HelpForTests.LastName())
                .InputEmail(HelpForTests.EmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(HelpForTests.PhoneNumber())
                .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutPassword() + " " + registrationPage.errorTextAboutPasswordLowerCase();

            Assert.AreEqual(expected: "Invalid password format At least one lowercase letter", actualResultat);
        }

        [TestCase("Se_d", "Se_d")]
        [TestCase("88888333344455566677712345678Se_d", "88888333344455566677712345678Se_d")]
        public void RegistrationWithInValidPasswordLenght(string password, string confirmPassword)
        {
            var registrationPage = new Registration(_webDriver);
            var homePage = new GreetingHomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(HelpForTests.FirstName())
                .InputLastName(HelpForTests.LastName())
                .InputEmail(HelpForTests.EmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(HelpForTests.PhoneNumber())
                .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutPassword() + " " + registrationPage.errorTextAboutPasswordLenght();

            Assert.AreEqual(expected: "Invalid password format From 8 to 25 characters", actualResultat);
        }

        [TestCase("1234567890Ded", "1234567890Ded")]
        public void RegistrationWithInValidPasswordSymbol(string password, string confirmPassword)
        {
            var registrationPage = new Registration(_webDriver);
            var homePage = new GreetingHomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(HelpForTests.FirstName())
                .InputLastName(HelpForTests.LastName())
                .InputEmail(HelpForTests.EmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(HelpForTests.PhoneNumber())
                .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutPassword() + " " + registrationPage.errorTextAboutPasswordMarks();

            Assert.AreEqual(expected: "Invalid password format At least one special character such as an exclamation mark", actualResultat);
        }

        [TestCase("qwsddqqwQ_ed", "qwsddqqwQ_ed")]
        public void RegistrationWithInValidPasswordNumber(string password, string confirmPassword)
        {
            var registrationPage = new Registration(_webDriver);
            var homePage = new GreetingHomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(HelpForTests.FirstName())
                .InputLastName(HelpForTests.LastName())
                .InputEmail(HelpForTests.EmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(HelpForTests.PhoneNumber())
                .ClickNextButton(); ;
            var actualResultat = registrationPage.errorTextAboutPassword() + " " + registrationPage.errorTextAboutPasswordNumbers();

            Assert.AreEqual(expected: "Invalid password format At least one number", actualResultat);
        }

        [TestCase("1234567890De_d", "1234567890D_d")]
        public void RegistrationWithInValidPasswordMath(string password, string confirmPassword)
        {
            var registrationPage = new Registration(_webDriver);
            var homePage = new GreetingHomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(HelpForTests.FirstName())
                .InputLastName(HelpForTests.LastName())
                .InputEmail(HelpForTests.EmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(HelpForTests.PhoneNumber())
                .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutPasswordMatch();

            Assert.AreEqual(expected: "Passwords match", actualResultat);
        }

        [TestCase("143123")]
        public void RegistrationWithInValidPhone(string phone)
        {
            var registrationPage = new Registration(_webDriver);
            var homePage = new GreetingHomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(HelpForTests.FirstName())
                .InputLastName(HelpForTests.LastName())
                .InputEmail(HelpForTests.EmailUser())
                .InputPassword(HelpForTests.RegistrationPassword())
                .InputConfirmPassword(HelpForTests.RegistrationConfirmPassword())
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutPhone();

            Assert.AreEqual(expected: "Invalid phone format", actualResultat);
        }

        [TestCase("")]
        public void RegistrationWithEmptyFirstName(string firstName)
        {
            var registrationPage = new Registration(_webDriver);
            var homePage = new GreetingHomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(HelpForTests.LastName())
                .InputEmail(HelpForTests.EmailUser())
                .InputPassword(HelpForTests.RegistrationPassword())
                .InputConfirmPassword(HelpForTests.RegistrationConfirmPassword())
                .InputPhoneNumber(HelpForTests.PhoneNumber())
                .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutFirstName();

            Assert.AreEqual(expected: "Required", actualResultat);
        }

        public void RegistrationWithEmptyLastName()
        {
            var registrationPage = new Registration(_webDriver);
            var homePage = new GreetingHomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputLastName(HelpForTests.FirstName())
                .InputLastName("")
                .InputEmail(HelpForTests.EmailUser())
                .InputPassword(HelpForTests.RegistrationPassword())
                .InputConfirmPassword(HelpForTests.RegistrationConfirmPassword())
                .InputPhoneNumber(HelpForTests.PhoneNumber())
                .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutLastName();

            Assert.AreEqual(expected: "Required", actualResultat);
        }

        public void RegistrationWithEmptyMail()
        {
            var registrationPage = new Registration(_webDriver);
            var homePage = new GreetingHomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
               .InputFirstName(HelpForTests.FirstName())
               .InputLastName(HelpForTests.LastName())
               .InputEmail("")
               .InputPassword(HelpForTests.RegistrationPassword())
               .InputConfirmPassword(HelpForTests.RegistrationConfirmPassword())
               .InputPhoneNumber(HelpForTests.PhoneNumber())
               .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutEmail();

            Assert.AreEqual(expected: "Required", actualResultat);
        }

        [TestCase("")]
        public void RegistrationWithEmptyPasword(string password)
        {
            var registrationPage = new Registration(_webDriver);
            var homePage = new GreetingHomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(HelpForTests.FirstName())
               .InputLastName(HelpForTests.LastName())
               .InputEmail(HelpForTests.EmailUser())
               .InputPassword("")
               .InputConfirmPassword(HelpForTests.RegistrationConfirmPassword())
               .InputPhoneNumber(HelpForTests.PhoneNumber())
               .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutPassword();

            Assert.AreEqual(expected: "Invalid password format", actualResultat);
        }

        [TestCase("")]
        public void RegistrationWithEmptyConfirmPassword(string confirmPassword)
        {
            var registrationPage = new Registration(_webDriver);
            var homePage = new GreetingHomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
               .InputFirstName(HelpForTests.FirstName())
               .InputLastName(HelpForTests.LastName())
               .InputEmail(HelpForTests.EmailUser())
               .InputPassword(HelpForTests.RegistrationPassword())
               .InputConfirmPassword("")
               .InputPhoneNumber(HelpForTests.PhoneNumber())
               .ClickNextButton(); ;
            var actualResultat = registrationPage.errorTextAboutConfitmPassword();

            Assert.AreEqual(expected: "Passwords must match", actualResultat);
        }

        [TestCase("")]
        public void RegistrationWithEmptyPhone(string phone)
        {
            var registrationPage = new Registration(_webDriver);
            var homePage = new GreetingHomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
               .InputFirstName(HelpForTests.FirstName())
               .InputLastName(HelpForTests.LastName())
               .InputEmail(HelpForTests.EmailUser())
               .InputPassword(HelpForTests.RegistrationPassword())
               .InputConfirmPassword(HelpForTests.RegistrationConfirmPassword())
               .InputPhoneNumber(phone)
               .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutPhone();

            Assert.AreEqual(expected: "Invalid phone format", actualResultat);
        }

        [TestCase("", 1)]
        public void RegistrationWitfInEmptyCompanyName(string companyName, int count)
        {
            var registrationPage = new Registration(_webDriver);
            var home = new GreetingHomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
            .InputFirstName(HelpForTests.FirstName())
            .InputLastName(HelpForTests.LastName())
            .InputEmail(HelpForTests.EmailUser())
            .InputPassword(HelpForTests.RegistrationPassword())
            .InputConfirmPassword(HelpForTests.RegistrationConfirmPassword())
            .InputPhoneNumber(HelpForTests.PhoneNumber())
            .ClickNextButton();

            registrationPage.InputCompanyName(companyName)
            .InputCompanyWebSite(HelpForTests.CompanySite())
            .InputCompanyAddress(HelpForTests.CompanyAddress())
            .InputCompanyIndustry(count)
            .ClickOnFinishRegistration();
            var actualResultat = registrationPage.errorTextAboutCompanyName();

            Assert.AreEqual(expected: "Required", actualResultat);
        }

        [TestCase( "", 2)]
        public void RegistrationWitfInEmptyCompanyWebSite(string companyWebSite, int count)
        {
            var registrationPage = new Registration(_webDriver);
            var homePage = new GreetingHomePage(_webDriver);
             registrationPage.GoToRegistrationPages()
            .InputFirstName(HelpForTests.FirstName())
            .InputLastName(HelpForTests.LastName())
            .InputEmail(HelpForTests.EmailUser())
            .InputPassword(HelpForTests.RegistrationPassword())
            .InputConfirmPassword(HelpForTests.RegistrationConfirmPassword())
            .InputPhoneNumber(HelpForTests.PhoneNumber())
            .ClickNextButton();

             registrationPage.InputCompanyName(HelpForTests.CompanyName())
            .InputCompanyWebSite(companyWebSite)
            .InputCompanyAddress(HelpForTests.CompanyAddress())
            .InputCompanyIndustry(count)
            .ClickOnFinishRegistration();
            var actualResultat = registrationPage.errorTextAboutCompanyWebSite();

            Assert.AreEqual(expected: "Required", actualResultat);
        }

        [TestCase(2)]
        public void RegistrationWitfInEmptyAddress( int count)
        {
            var registrationPage = new Registration(_webDriver);
            var homePage = new GreetingHomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
              .InputFirstName(HelpForTests.FirstName())
              .InputLastName(HelpForTests.LastName())
              .InputEmail(HelpForTests.EmailUser())
              .InputPassword(HelpForTests.RegistrationPassword())
              .InputConfirmPassword(HelpForTests.RegistrationConfirmPassword())
              .InputPhoneNumber(HelpForTests.PhoneNumber())
              .ClickNextButton();

            registrationPage.InputCompanyName(HelpForTests.CompanyName())
           .InputCompanyWebSite(HelpForTests.CompanySite())
           .InputCompanyAddress("")
           .InputCompanyIndustry(count)
           .ClickOnFinishRegistration();
            var actualResultat = registrationPage.errorTextAboutAddress();

            Assert.AreEqual(expected: "Please choose a location from the suggested addresses. This field doesn’t accept custom addresses, or “#” symbols.", actualResultat);
        }


        [TestCase( 2)]
        public void RegistrationWitfInValidAddress( int count)
        {
            var registrationPage = new Registration(_webDriver);
            var homePage = new GreetingHomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
             .InputFirstName(HelpForTests.FirstName())
             .InputLastName(HelpForTests.LastName())
             .InputEmail(HelpForTests.EmailUser())
             .InputPassword(HelpForTests.RegistrationPassword())
             .InputConfirmPassword(HelpForTests.RegistrationConfirmPassword())
             .InputPhoneNumber(HelpForTests.PhoneNumber())
             .ClickNextButton();

            registrationPage.InputCompanyName(HelpForTests.CompanyName())
           .InputCompanyWebSite(HelpForTests.CompanySite())
           .InputCompanyAddress("57675 tyfdj ## jdfjviiefjddh")
           .InputCompanyIndustry(count)
           .ClickOnFinishRegistration();
            var actualResultat = registrationPage.errorTextAboutAddress();

            Assert.AreEqual(expected: "Please choose a location from the suggested addresses. This field doesn’t accept custom addresses, or “#” symbols.", actualResultat);
        }

        //[TearDown]
        //public void TearDown()
        //{
        //    _webDriver.Dispose();
        //}
    }
}
