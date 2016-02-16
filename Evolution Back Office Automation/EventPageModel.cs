using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Evolution_Back_Office_Automation
{
    class EventPageModel
    {
        private IWebDriver driver { get; set; }

        public EventPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.Id, Using ="tab-29")]
        public IWebElement EventFrame { get; set; }

        [FindsBy(How = How.Id, Using = "lnkAdd")]
        public IWebElement AddEvent { get; set; }

        [FindsBy(How = How.Id, Using = "lnkEdit")]
        public IWebElement EditEvent { get; set; }

        [FindsBy(How = How.Id, Using = "lnkSave")]
        public IWebElement SaveEvent { get; set; }

        [FindsBy(How=How.Id,Using= "lnkDelete")]
        public IWebElement DeleteEvent { get; set; }

        [FindsBy(How = How.Id, Using = "SearchText")]
        public IWebElement SearchEventText { get; set; }

        [FindsBy(How = How.Id, Using = "btnSearch")]
        public IWebElement SearchEventButton { get; set; }

        [FindsBy(How = How.Id, Using = "btnCancel")]
        public IWebElement ResetSearchEvent { get; set; }

        [FindsBy(How = How.Id, Using = "EvenName")]
        public IWebElement EventName { get; set; }

        [FindsBy(How = How.Id, Using = "EvenDescription")]
        public IWebElement EventDescription { get; set; }

        [FindsBy(How = How.Id, Using = "EvenFrom")]
        public IWebElement EventFrom { get; set; }

        [FindsBy(How = How.Id, Using = "EvenTo")]
        public IWebElement EventTo { get; set; }

        [FindsBy(How = How.Id, Using = "EvenTypeNonFix")]
        public IWebElement EventNonFix { get; set; }

        [FindsBy(How = How.Id, Using = "EvDeFromDate")]
        public IWebElement EventNonFixFrom { get; set; }

        [FindsBy(How = How.Id, Using = "EvDeToDate")]
        public IWebElement EventNonFixTo { get; set; }

        [FindsBy(How = How.Id, Using = "addRow")]
        public IWebElement EventNonFixAddRow { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[6]/div[2]/div/div[2]/div[2]/div/div[2]/div[1]/div[2]/div/div/table/tbody/tr[2]/td[3]/div/button[2]")]
        public IWebElement EventNonFixDeleteRow { get; set; }
    }
}
