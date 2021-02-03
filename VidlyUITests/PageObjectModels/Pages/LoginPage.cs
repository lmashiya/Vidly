using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VidlyUITests.PageObjectModels.Pages
{
    public class LoginPage
    {
        /// <summary>
        ///     A <see cref="IWebDriver"/> representing the web driver.
        /// </summary>
        private IWebDriver _driver;

        /// <summary>
        ///     Gets a <see cref="IWebElement"/> for user email text box.
        /// </summary>
        private readonly By _userEmail = By.Id("Email");

        /// <summary>
        ///     Gets a <see cref="IWebElement"/> for user password text box.
        /// </summary>
        private readonly By _userPassword = By.Id("Password");

        /// <summary>
        ///     Gets a <see cref="IWebElement"/> for the title for the login page.
        /// </summary>
        private readonly By _titleText = By.TagName("title");

        /// <summary>
        ///     Gets a <see cref="IWebElement"/> for the checkbox.
        /// </summary>
        private readonly By _rememberMeCheckBox = By.Id("RememberMe");

        /// <summary>
        ///     Gets a <see cref="IWebElement"/> for the register new user link.
        /// </summary>
        private readonly By _registerNewUserLink = By.LinkText("Register as a new user");

        /// <summary>
        ///     Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        /// <param name="driver">
        ///     A <see cref="IWebDriver"/> representing the driver.
        /// </param>
        public LoginPage(IWebDriver driver)
        {
            _driver = new ChromeDriver();
        }

        /// <summary>
        ///     Sets user email in text box. 
        /// </summary>
        /// <param name="userEmail">
        ///     A <see cref="string"/> representing the user's email address.
        /// </param>
        public void SetUserEmail(string userEmail)
        {
            _driver.FindElement(_userEmail).SendKeys(userEmail);
        }

        /// <summary>
        ///     Sets user password in text box. 
        /// </summary>
        /// <param name="password">
        ///     A <see cref="string"/> representing the user's email address.
        /// </param>
        public void SetUserPassword(string password)
        {
            _driver.FindElement(_userPassword).SendKeys(password);
        }

        /// <summary>
        ///     Click on login button.
        /// </summary>
        public void ClickLoginButton()
        {
            _driver.FindElement(_userPassword).Submit();
        }

        /// <summary>
        ///     Gets the page title.
        /// </summary>
        /// <returns>
        ///     A <see cref="string"/> representing the title of the page.
        /// </returns>
        public string GetPageTitle()
        {
            return _driver.FindElement(_titleText).Text;
        }

        /// <summary>
        ///     
        /// </summary>
        public void SetRememberMeCheckBox()
        {
            var checkbox = _driver.FindElement(_rememberMeCheckBox);
            if (!checkbox.Selected)
            {
                checkbox.Click();
            }
        }

        public void ClickRegisterNewUser()
        {
            _driver.FindElement(_registerNewUserLink).Click();
        }

        /// <summary>
        /// Logs in to the application.
        /// </summary>
        /// <param name="userName">
        ///     An <see cref="string"/> representing the user's email.
        /// </param>
        /// <param name="password">
        ///     A <see cref="string"/> representing the user's password.
        /// </param>
        public void Login(string userName, string password)
        {
            SetUserEmail(userName);
            SetUserPassword(password);
            ClickLoginButton();
        }
    }
}
