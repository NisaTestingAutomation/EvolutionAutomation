using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Back_Office_Automation
{
    class LoginPageModel
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "btnLoginByUsername")]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.Name, Using = "overridelink")]
        public IWebElement OverrideLink { get; set; }

        public LoginPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
