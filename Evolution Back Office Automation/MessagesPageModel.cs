using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Back_Office_Automation
{
    class MessagesPageModel
    {
        private IWebDriver driver { get; set; }

        public MessagesPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "tab-11")]
        public IWebElement MessageFrame { get; set; }

        [FindsBy(How = How.Id, Using = "lnkAdd")]
        public IWebElement AddMessage { get; set; }

        [FindsBy(How = How.Id, Using = "MESSName")]
        public IWebElement MessageName { get; set; }
        
        [FindsBy(How = How.Id, Using = "MESSDesc")]
        public IWebElement MessageDescription { get; set; }

        [FindsBy(How = How.Id, Using = "MESSCondition")]
        public IWebElement MessageCondition { get; set; }

        [FindsBy(How = How.Id, Using = "MESSAge")]
        public IWebElement MessageAge { get; set; }

        [FindsBy(How = How.Id, Using = "rdoP")]
        public IWebElement MessageProcedure { get; set; }

        [FindsBy(How = How.Id, Using = "lnkSave")]
        public IWebElement SaveMessage { get; set; }

        [FindsBy(How = How.Id, Using = "txtSearchMessage")]
        public IWebElement MessageSearchText { get; set; }

        [FindsBy(How = How.Id, Using = "btnSearch")]
        public IWebElement MessageSearchButton { get; set; }

        [FindsBy(How = How.Id, Using = "lnkEdit")]
        public IWebElement EditMessage { get; set; }

        [FindsBy(How = How.Id, Using = "btnResetSearch")]
        public IWebElement MessageSearchReset { get; set; }

        [FindsBy(How = How.Id, Using = "lnkDelete")]
        public IWebElement DeleteMessage { get; set; }

    }
}
