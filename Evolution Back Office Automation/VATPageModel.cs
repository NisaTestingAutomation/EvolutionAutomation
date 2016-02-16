using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Back_Office_Automation
{
    class VATPageModel
    {
        private IWebDriver driver { get; set; }

        public VATPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        [FindsBy(How=How.Id,Using ="tab-27")]
        public IWebElement VATFrame { get; set; }

        [FindsBy(How = How.Id, Using = "lnkAdd")]
        public IWebElement AddVATRate { get; set; }

        [FindsBy(How = How.Id, Using = "VATCode")]
        public IWebElement VATCode { get; set; }

        [FindsBy(How = How.Id, Using = "VATName")]
        public IWebElement VATName { get; set; }

        [FindsBy(How = How.Id, Using = "VATRate")]
        public IWebElement VATRate { get; set; }

        [FindsBy(How = How.Id, Using = "VatFUEffectiveDate")]
        public IWebElement VATFutureDate { get; set; }

        [FindsBy(How = How.Id, Using = "VatFUEffectiveRate")]
        public IWebElement VATFutureRate { get; set; }

        [FindsBy(How = How.Id, Using = "addRow")]
        public IWebElement VATFutureAdd { get; set; }

        [FindsBy(How = How.Id, Using = "lnkSave")]
        public IWebElement SaveVAT { get; set; }

        [FindsBy(How = How.Id, Using = "SearchVatCode")]
        public IWebElement VATSearchCode { get; set; }

        [FindsBy(How = How.Id, Using = "btnSearch")]
        public IWebElement VATSearchButton { get; set; }

        [FindsBy(How = How.Id, Using = "btnCancel")]
        public IWebElement VATSearchReset { get; set; }

        [FindsBy(How = How.Id, Using = "lnkEdit")]
        public IWebElement EditVAT { get; set; }

        [FindsBy(How = How.XPath, Using = "(//button[@type='button'])[9]")] //delete vat rate
        public IWebElement VATFutureDelete { get; set; }
        
        [FindsBy(How = How.Id, Using = "lnkDelete")]
        public IWebElement DeleteVAT { get; set; }
    }
}
