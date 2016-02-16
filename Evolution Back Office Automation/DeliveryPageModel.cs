using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Back_Office_Automation
{
    class DeliveryPageModel
    {
        private IWebDriver driver { get; set; }

        public DeliveryPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.Id,Using ="tab-109")]
        public IWebElement DeliveryFrame { get; set; }

        [FindsBy(How=How.Id,Using ="lnkCreate")]
        public IWebElement CreateDelivery { get; set; }
    }

    class NewDeliveryPageModel
    {
        private IWebDriver driver { get; set; }

        public NewDeliveryPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[3]/div[2]/iframe[2]")]
        public IWebElement NewDeliveryFrame { get; set; }

        [FindsBy(How=How.Id,Using ="PurcSuppID")]
        public IWebElement SupplierID { get; set; }

        [FindsBy(How = How.Id, Using = "CreatPurcDispatchNo")]
        public IWebElement DispatchNumber { get; set; }

        [FindsBy(How = How.Id, Using = "PurcDeliveryDateCrt")]
        public IWebElement DeliveryDate { get; set; }

        [FindsBy(How=How.Id,Using ="btnSaveDelivery")]
        public IWebElement SaveDelivery { get; set; }

        [FindsBy(How = How.Id, Using = "PurcComments")]
        public IWebElement DeliveryComments { get; set; }

        [FindsBy(How = How.Id, Using = "txtQuickAddText")]
        public IWebElement QuickAddProductText { get; set; }

        [FindsBy(How = How.Id, Using = "btnnewadd")]
        public IWebElement QuickAddProductButton { get; set; }

        [FindsBy(How = How.Id, Using = "txtQuickAddQty_0")]
        public IWebElement QuickAddProductQuantity { get; set; }

        [FindsBy(How = How.Id, Using = "btnSubmit")]
        public IWebElement SubmitDelivery { get; set; }

        [FindsBy(How = How.Id, Using = "btnDetailSearch")]
        public IWebElement AdvancedSearch { get; set; }
    }
}
