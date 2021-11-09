using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectinClass.POD
{
    static public class HelpForTests
    {
        public static string EmailUser()
        {
            string now = DateTime.Now.ToString("ddMMyyyyhhmmss");
            string email = now + "@test.com";
            return email = "narutoSasuke" + now + "@gmail.com";
        }

        public static string RegistrationPassword()
        {
            string password = "Naruto_2345n";
            return password; 
        }

        public static string RegistrationConfirmPassword()
        {
            string password = "Naruto_2345n";
            return password;
        }

        public static string PhoneNumber()
        {
            string phoneNumber = "2345234234";
            return phoneNumber;
        }

        public static string FirstName()
        {
            string firstName = "Naruto";
            return firstName;
        }

        public static string LastName()
        {
            string lastName = "Udzumaki";
            return lastName;
        }

        public static string CompanyName()
        {
            string companyName = "Akatsuki";
            return companyName;
        }

        public static string CompanySite()
        {
            string companySite = "akatsuki.com";
            return companySite;
        }

        public static string CompanyAddress()
        {
            string companySite = "11031 Mississippi Ave, Los Angeles, CA 90025, USA";
            return companySite;
        }
    }
}