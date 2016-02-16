using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Back_Office_Automation
{
    class ItemGroupsPageModel
    {
        private IWebDriver driver { get; set; }

        public ItemGroupsPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.Id,Using ="tab-30")]
        public IWebElement ItemGroupFrame { get; set; }

        [FindsBy(How=How.Id,Using ="lnkAdd")]
        public IWebElement AddItemGroup { get; set; }
            
        [FindsBy(How=How.Id,Using ="ItGrParentArrow")]
        public IWebElement ItemGroupParent { get; set; }

        [FindsBy(How=How.Id,Using="iframeItemLookupwindow")]
        public IWebElement ParentFrame { get; set; }

        [FindsBy(How=How.XPath,Using= "/html/body/form/div/div[3]/ul/li[10]/a")]
        public IWebElement ItemGroupParentGrocery { get; set; }
                
        [FindsBy(How=How.Id,Using = "ItGrName")]
        public IWebElement ItemGroupName { get; set; }

        [FindsBy(How=How.Id, Using = "VATID")]
        public IWebElement ItemGroupVAT { get; set; }

        [FindsBy(How = How.Id, Using = "UOMID")]
        public IWebElement ItemGroupUOM { get; set; }

        [FindsBy(How = How.Id, Using = "lnkSave")]
        public IWebElement SaveItemGroup { get; set; }

        [FindsBy(How = How.Id, Using = "lnkEdit")]
        public IWebElement EditItemGroup { get; set; }

        [FindsBy(How = How.Id, Using = "SearchText")]
        public IWebElement SearchItemGroupText { get; set; }

        [FindsBy(How = How.Id, Using = "btnSearch")]
        public IWebElement SearchItemGroupButton { get; set; }

        [FindsBy(How = How.Id, Using = "btnCancel")]
        public IWebElement ResetSearchItemGroupButton { get; set; }

        [FindsBy(How = How.Id, Using = "lnkDelete")]
        public IWebElement DeleteItemGroup { get; set; }
    }
}
