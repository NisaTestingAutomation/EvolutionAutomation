using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace Evolution_Back_Office_Automation
{
    class StockTakePageModel
    {
        private IWebDriver driver { get; set; }

        public StockTakePageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.Id,Using ="tab-139")]
        public IWebElement StockTakeViewerFrame { get; set; }

        [FindsBy(How = How.Id, Using = "btncreate")]
        public IWebElement CreateStockTake { get; set; }

        [FindsBy(How=How.Id, Using = "btnCancel")]
        public IWebElement ResetStockTakeSearch { get; set; }
    }

    class NewStockTakePageModel
    {
        private IWebDriver driver { get; set; }

        public NewStockTakePageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[3]/div[2]/iframe[2]")]
        public IWebElement StockTakeFrame { get; set; }

        [FindsBy(How = How.Id, Using = "StTaComments")]
        public IWebElement StockTakeComments { get; set; }

        [FindsBy(How = How.Id, Using = "EAN")]
        public IWebElement QuickAddText { get; set; }

        [FindsBy(How = How.Id, Using = "btnQuickEANSearch")]
        public IWebElement QuickAddSearch { get; set; }

        [FindsBy(How = How.Id, Using = "txtQuickAddQty_1")]
        public IWebElement QuickAddQuantity { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveStock")]
        public IWebElement SubmitStockTake { get; set; }

        [FindsBy(How = How.Id, Using = "btnPartialSaveStock")]
        public IWebElement SaveStockTake { get; set; }
    }

    class StockAdjustmentPageModel {
        private IWebDriver driver { get; set; }

        public StockAdjustmentPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.Id, Using = "tab-36")]
        public IWebElement StockAdjustFrame { get; set; }

        [FindsBy(How=How.Id, Using = "btncreate")]
        public IWebElement NewStockAdjust { get; set; }
    }

    class NewStockAdjustmentPageModel {
        private IWebDriver driver { get; set; }

        public NewStockAdjustmentPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.XPath,Using = "/html/body/form/div[3]/div[2]/iframe[2]")]
        public IWebElement NewStockAdjustFrame { get; set; }

        [FindsBy(How=How.Id, Using ="StAdComments")]
        public IWebElement NewStockAdjustComments { get; set; } 

        [FindsBy(How=How.Id, Using ="ReasID")]
        public IWebElement NewStockAdjustReason { get; set; }

        [FindsBy(How=How.Id, Using = "EAN")]
        public IWebElement NewStockAdjustQuickAddTxt { get; set; }

        [FindsBy(How=How.Id, Using = "btnProductSarch")]
        public IWebElement NewStockAdjustQuickAddButton { get; set; }

        [FindsBy(How=How.Id, Using = "txtQuickAddQty_1")]
        public IWebElement NewStockAdjustQuickAddQty { get; set; }

        [FindsBy(How=How.Id, Using ="btnDetailSearch")]
        public IWebElement NewStockAdjustAdvancedSearch { get; set; }

        [FindsBy(How=How.Id, Using ="btnSaveStock")]
        public IWebElement SaveStockAdjust { get; set; }

        [FindsBy(How=How.XPath, Using = "/html/body/form/div[3]/div[4]/div/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div/table/tbody/tr[2]/td[14]/div")]
        public IWebElement AdvancedSearchAdjustQuantityActivate { get; set; }

        [FindsBy(How=How.Id, Using = "txt_undefined_undefined")]
        public IWebElement AdvancedSearchAdjustQuantity { get; set; }
    }
}
