using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Back_Office_Automation
{
    class DocumentPageModel
    {
        private IWebDriver driver { get; set; }

        public DocumentPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id,Using ="tab-9")]
        public IWebElement DocumentFrame { get; set; }

        //Search
        [FindsBy(How=How.Id, Using ="SearchText")]
        public IWebElement SearchText { get; set; }

        [FindsBy(How=How.Id,Using ="btnSearch")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How=How.Id,Using ="btnCancel")]
        public IWebElement ResetSearch { get; set; }

        //Add, Edit, Save and Delete buttons
        [FindsBy(How=How.Id,Using = "lnkAdd")]
        public IWebElement AddButton { get; set; }

        [FindsBy(How = How.Id, Using = "lnkEdit")]
        public IWebElement EditButton { get; set; }

        [FindsBy(How = How.Id, Using = "lnkDelete")]
        public IWebElement DeleteButton { get; set; }

        [FindsBy(How = How.Id, Using = "lnkSave")]
        public IWebElement SaveButton { get; set; }

        //Main Panel
        [FindsBy(How = How.Id, Using ="DocuName")]
        public IWebElement Name { get; set; }

        [FindsBy(How = How.Id, Using ="Image")]
        public IWebElement Image { get; set; }
    }
}
