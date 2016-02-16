using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Back_Office_Automation
{
    class ManualOrderingPageModel
    {
        private IWebDriver driver { get; set; }

        public ManualOrderingPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[3]/div[2]/iframe[2]")]
        public IWebElement OrderFrame { get; set; }

        [FindsBy(How=How.Id,Using ="SuppID")]
        public IWebElement SupplierID { get; set; }

        [FindsBy(How = How.Id, Using = "btnSave")]
        public IWebElement SaveOrder { get; set; }

        [FindsBy(How=How.Id,Using = "txtQuickAddText")]
        public IWebElement QuickAddText { get; set; }

        [FindsBy(How = How.Id, Using = "btnSearchItem")]
        public IWebElement QuickSearchItem { get; set; }

        [FindsBy(How = How.Id, Using = "txtQuickAddQty_0")]
        public IWebElement QuickAddQuantity { get; set; }

        [FindsBy(How=How.Id,Using ="btnAdvanceSearch")]
        public IWebElement AdvancedSearch { get; set; }

        [FindsBy(How = How.Id, Using = "btnAddAllColumn")]
        public IWebElement SelectAllProducts { get; set; }

        [FindsBy(How = How.Id, Using = "btnAddToBasket")]
        public IWebElement AddToBasket { get; set; }

        [FindsBy(How = How.Id, Using = "BasketID")]
        public IWebElement BasketDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "btnAddBasket")]
        public IWebElement AddBasket { get; set; }

        [FindsBy(How = How.Id, Using = "btnSend")]
        public IWebElement SendOrder { get; set; }
    }

    class NewManualOrderingPageModel
    {
        private IWebDriver driver { get; set; }

        public NewManualOrderingPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id,Using ="tab-32")]
        public IWebElement NewOrderFrame { get; set; }

        [FindsBy(How = How.XPath,Using ="(//input[@type='button'])[18]")]
        public IWebElement AddOrder { get; set; }

        [FindsBy(How=How.Id,Using ="btnManualOrder")]
        public IWebElement ManualOrder { get; set; }
    }

    class SendOrderWindow
    {
        private IWebDriver driver { get; set; }

        public SendOrderWindow(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_OrderEntrySummary1_SubmitOrderTab")]
        public IWebElement SubmitOrder { get; set; }       
    }

    class AdvancedSearchPageModel
    {
        private IWebDriver driver { get; set; }

        public AdvancedSearchPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.Id,Using = "iframeProductSearchPopup")]
        public IWebElement AdvancedSearchFrame { get; set; }

        [FindsBy(How=How.Id,Using = "btnSearch")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How=How.Id,Using ="btnCancel")]
        public IWebElement ResetButton { get; set; }

        [FindsBy(How=How.Id,Using = "txtItemSearchAll")]
        public IWebElement SearchText { get; set; }

        [FindsBy(How=How.Id,Using = "SelectSearchValue_InnerEAN")]
        public IWebElement InnerEAN { get; set; }

        [FindsBy(How = How.Id, Using = "SelectSearchValue_OuterEAN")]
        public IWebElement OuterEAN { get; set; }

        [FindsBy(How = How.Id, Using = "SelectSearch_ItemDesc")]
        public IWebElement ItemName { get; set; }

        [FindsBy(How = How.Id, Using = "SelectSearchValue_ItemCode")]
        public IWebElement ItemCode { get; set; }

        [FindsBy(How = How.Id, Using = "SelectSearchValue_SuppCode")]
        public IWebElement SupplierCode { get; set; }

        [FindsBy(How = How.Id, Using = "chk_selectAll_divPLOFItemSearch")]
        public IWebElement SelectAll { get; set; }

        [FindsBy(How = How.Id, Using = "btnItemOk")]
        public IWebElement OKButton { get; set; }
    }
}
