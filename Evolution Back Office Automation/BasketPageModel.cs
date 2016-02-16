using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Back_Office_Automation
{
    class BasketPageModel
    {
        private IWebDriver driver { get; set; }

        public BasketPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.Id,Using ="tab-5")]
        public IWebElement BasketFrame { get; set; }

        [FindsBy(How=How.Id,Using ="SearchText")]
        public IWebElement SearchBasketText { get; set; }

        [FindsBy(How=How.Id,Using = "btnSearch")]
        public IWebElement SearchBasketButton { get; set; }

        [FindsBy(How=How.Id,Using ="btnCancel")]
        public IWebElement ResetSearchButton { get; set; }

        [FindsBy(How=How.Id,Using ="lnkAdd")]
        public IWebElement AddBasket { get; set; }

        [FindsBy(How=How.Id,Using ="lnkSave")]
        public IWebElement SaveBasket { get; set; }

        [FindsBy(How=How.Id,Using ="lnkEdit")]
        public IWebElement EditBasket { get; set; }

        [FindsBy(How=How.Id,Using ="lnkDelete")]
        public IWebElement DeleteBasket { get; set; }

        [FindsBy(How=How.Id,Using ="BaskDesc")]
        public IWebElement BasketDescription { get; set; }
    }
}
