using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Back_Office_Automation
{
    class TillSendPageModel
    {
        private IWebDriver driver { get; set; }

        public TillSendPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "tab-135")]
        public IWebElement TillSendFrame { get; set; }

        [FindsBy(How=How.Id,Using = "btnReceive")]
        public IWebElement TillSendButton { get; set; }

        [FindsBy(How=How.XPath, Using = "/html/body/form/div[7]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/span[2]/table/tbody/tr[2]/td[2]/div/input")]
        public IWebElement TillSendSelectAll { get; set; }

        [FindsBy(How=How.XPath, Using = "/html/body/form/div[7]/div[2]/div[2]/div[2]/div[2]/div[1]/div[2]/div/div/table/tbody/tr[2]/td[9]/div/font[1]")]
        public IWebElement TillSendMessageLine1 { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[7]/div[2]/div[2]/div[2]/div[2]/div[1]/div[2]/div/div/table/tbody/tr[2]/td[9]/div/font[2]")]
        public IWebElement TillSendMessageLine2 { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[7]/div[2]/div[2]/div[2]/div[2]/div[1]/div[2]/div/div/table/tbody/tr[2]/td[9]/div/font[3]")]
        public IWebElement TillSendMessageLine3 { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[7]/div[2]/div[2]/div[2]/div[2]/div[1]/div[2]/div/div/table/tbody/tr[2]/td[9]/div/font[4]")]
        public IWebElement TillSendMessageLine4 { get; set; }
    }

    class TillReceivePageModel
    {
        private IWebDriver driver { get; set; }

        public TillReceivePageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "tab-134")]
        public IWebElement TillRecFrame { get; set; }

        [FindsBy(How = How.Id, Using = "btnReceive")]
        public IWebElement TillRecButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[7]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/span[2]/table/tbody/tr[2]/td[2]/div/input")]
        public IWebElement TillRecSelectAll { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[7]/div[2]/div[2]/div[2]/div[2]/div[1]/div[2]/div/div/table/tbody/tr[2]/td[7]/div/font[1]")]
        public IWebElement TillRecMessageLine1 { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[7]/div[2]/div[2]/div[2]/div[2]/div[1]/div[2]/div/div/table/tbody/tr[2]/td[7]/div/font[2]")]
        public IWebElement TillRecMessageLine2 { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[7]/div[2]/div[2]/div[2]/div[2]/div[1]/div[2]/div/div/table/tbody/tr[2]/td[7]/div/font[3]")]
        public IWebElement TillRecMessageLine3 { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[7]/div[2]/div[2]/div[2]/div[2]/div[1]/div[2]/div/div/table/tbody/tr[2]/td[7]/div/font[4]")]
        public IWebElement TillRecMessageLine4 { get; set; }
    }
}
