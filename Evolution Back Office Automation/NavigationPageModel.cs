using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Evolution_Back_Office_Automation
{
    class NavigationPageModel
    {
        private IWebDriver driver { get; set; }

        public NavigationPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.PartialLinkText, Using = "Sys Admin")]
        public IWebElement SysAdmin { get; set; }

        //Setup Menu
        [FindsBy(How = How.PartialLinkText, Using = "Setup")]
        public IWebElement Setup { get; set; }

        //Setup Sublinks
        [FindsBy(How = How.PartialLinkText, Using = "BOS Parameters")]
        public IWebElement BOSParameters { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Devices")]
        public IWebElement Devices { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "HHU")]
        public IWebElement HHU { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Locations")]
        public IWebElement Locations { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Vending")]
        public IWebElement Vending { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Store")]
        public IWebElement Store { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Till(s)")]
        public IWebElement Tills { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Till Parameters")]
        public IWebElement TillParameters { get; set; }

        //Configuration Menu
        [FindsBy(How = How.PartialLinkText, Using = "Configuration")]
        public IWebElement Configuration { get; set; }

        //Configuration Sublinks
        [FindsBy(How = How.PartialLinkText, Using = "Documents")]
        public IWebElement Documents { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Event")]
        public IWebElement Events { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Messages")]
        public IWebElement Messages { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Till Designer")]
        public IWebElement TillDesigner { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "PLU Designer")]
        public IWebElement PLUDesigner { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Tobacco Designer")]
        public IWebElement TobaccoDesigner { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Reasons")]
        public IWebElement Reasons { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Roles and Rights")]
        public IWebElement RolesAndRights { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Tenders")]
        public IWebElement Tenders { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Trading Consent")]
        public IWebElement TradingConsent { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Unit Measures")]
        public IWebElement UnitMeasures { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Users")]
        public IWebElement Users { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "VAT Rates")]
        public IWebElement VATRates { get; set; }

        //Groups Menu
        [FindsBy(How = How.PartialLinkText, Using = "Groups")]
        public IWebElement Groups { get; set; }

        //Groups Sublinks
        [FindsBy(How = How.PartialLinkText, Using = "Item Groups")]
        public IWebElement ItemGroups { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Item Group Mapping")]
        public IWebElement ItemGroupMapping { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Paid Out Groups")]
        public IWebElement PaidOutGroups { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Promotion Groups")]
        public IWebElement PromotionGroups { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Supplier Group")]
        public IWebElement SupplierGroup { get; set; }

        //Maintenance Menu
        [FindsBy(How = How.PartialLinkText, Using = "Maintenance")]
        public IWebElement Maintenance { get; set; }

        //Maintenance Sublinks
        [FindsBy(How = How.PartialLinkText, Using = "Promotion (Single Price)")]
        public IWebElement PromotionSinglePrice { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Promotion (Deal)")]
        public IWebElement PromotionDeal { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Baskets")]
        public IWebElement Baskets { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Customers")]
        public IWebElement Customers { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Global Product Changes")]
        public IWebElement GlobalProductChanges { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Items")]
        public IWebElement Items { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Paid Out Reasons")]
        public IWebElement PaidOutReasons { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Suppliers")]
        public IWebElement Suppliers { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Work Bench")]
        public IWebElement WorkBench { get; set; }

        //Replenishment Menu
        [FindsBy(How = How.PartialLinkText, Using = "Replenishment")]
        public IWebElement Replenishment { get; set; }

        //Replenishment Sublinks
        [FindsBy(How = How.PartialLinkText, Using = "Delivery")]
        public IWebElement Delivery { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Order")]
        public IWebElement Order { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Purchase Return")]
        public IWebElement PurchaseReturn { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Stock Adjustment")]
        public IWebElement StockAdjustment { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Stock Take")]
        public IWebElement StockTake { get; set; }

        //Updates Menu
        [FindsBy(How = How.PartialLinkText, Using = "Updates")]
        public IWebElement Updates { get; set; }

        //Updates Sublinks
        [FindsBy(How = How.PartialLinkText, Using = "Currency Exchange")]
        public IWebElement CurrencyExchange { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Nisa PLOF")]
        public IWebElement NisaPLOF { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Print Label")]
        public IWebElement PrintLabel { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Supplier PLOF")]
        public IWebElement SupplierPLOF { get; set; }

        //Reports Menu
        [FindsBy(How = How.PartialLinkText, Using = "Reports")]
        public IWebElement Reports { get; set; }

        //Reports Sublinks
        [FindsBy(How = How.PartialLinkText, Using = "Explorer")]
        public IWebElement Explorer { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Item Pricing Report")]
        public IWebElement ItemPricingReport { get; set; }

        //Utilities Menu
        [FindsBy(How = How.PartialLinkText, Using = "Utilities")]
        public IWebElement Utilities { get; set; }

        //Utilities Sublinks
        [FindsBy(How = How.PartialLinkText, Using = "Backup")]
        public IWebElement Backup { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Promotion Download")]
        public IWebElement PromotionDownload { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Till Receive")]
        public IWebElement TillReceive { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Till Send")]
        public IWebElement TillSend { get; set; }

        //Other
        [FindsBy(How = How.PartialLinkText, Using = "Logout")]
        public IWebElement Logout { get; set; }

        [FindsBy(How=How.Name,Using ="Yes")]
        public IWebElement ConfirmPopup { get; set; }
    }
}
