using System;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Evolution_Back_Office_Automation;
using System.Collections.Generic;
using System.Reflection;
using OpenQA.Selenium.Interactions;
using System.Linq;

namespace SeleniumTests
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private Shared shared;
        private Dictionary<string, string> config;
        string TestName;
        private NavigationPageModel navigation;
        private LoginPageModel loginPage;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            shared = new Shared();
            config = shared.GetConfig();
            baseURL = config["url"];
            verificationErrors = new StringBuilder();
            navigation = new NavigationPageModel(driver);
            loginPage = new LoginPageModel(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL + "/Index.aspx");
            loginPage.Username.SendKeys(config["username"]);
            loginPage.Password.SendKeys(config["password"]);
            loginPage.LoginButton.Click();
            Thread.Sleep(2000);
        }
        
        [TearDown]
        public void TeardownTest()
        {           

            try
            {
                
                shared.TakeScreenShot(driver, "End of test " + TestName + " " + DateTime.Now.ToString("ddMMyyyyHHmmss"));
                
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Console.Write(verificationErrors);
            Assert.AreEqual("", verificationErrors.ToString());
        }

        public void Logout()
        {
            navigation.Logout.Click();
            navigation.ConfirmPopup.Click();

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("Login" == driver.Title) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }

        [Test]
        [Description("Add, Edit and Delete a Basket")]
        public void TheAddEditDeleteBasketTest()
        {
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.LinkText("Nisa"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            navigation.Maintenance.Click();
            navigation.Baskets.Click();

            BasketPageModel basket = new BasketPageModel(driver);

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (basket.BasketFrame.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }

            driver.SwitchTo().Frame(basket.BasketFrame);
            Thread.Sleep(1000);
            basket.SearchBasketText.Click();
            basket.AddBasket.Click();
            Thread.Sleep(1000);
            basket.BasketDescription.Clear();
            basket.BasketDescription.SendKeys("Auto Basket");
            basket.SaveBasket.Click();

            Thread.Sleep(2000);

            basket.SearchBasketText.Clear();
            basket.SearchBasketText.SendKeys("auto basket");
            basket.SearchBasketButton.Click();
            Thread.Sleep(1000);
            basket.EditBasket.Click();
            Thread.Sleep(1000);
            basket.BasketDescription.Clear();
            basket.BasketDescription.SendKeys("Edited Auto Basket");
            Thread.Sleep(1000);
            basket.SaveBasket.Click();

            Thread.Sleep(2000);

            basket.ResetSearchButton.Click();
            Thread.Sleep(1000);
            basket.SearchBasketText.Clear();
            basket.SearchBasketText.SendKeys("Auto Basket");
            basket.SearchBasketButton.Click();
            Thread.Sleep(1000);
            basket.DeleteBasket.Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (navigation.ConfirmPopup.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            navigation.ConfirmPopup.Click();
            driver.SwitchTo().DefaultContent();

            navigation.Logout.Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (navigation.ConfirmPopup.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            navigation.ConfirmPopup.Click();

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (driver.Title == "Login") break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }

        [Test]        
        [Description("Add, Edit and Delete a Document")]
        public void TheAddEditDeleteDocumentTest()
        {
            DocumentPageModel document = new DocumentPageModel(driver);

            TestName = MethodBase.GetCurrentMethod().Name.Replace("The", "").Replace("Test", "");

            navigation.Configuration.Click();
            navigation.Documents.Click();

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (document.DocumentFrame.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Frame(document.DocumentFrame);
            document.AddButton.Click();
            document.Name.Clear();
            document.Name.SendKeys("Penguins");
            document.Image.Clear();
            document.Image.SendKeys("H:\\PMO\\Test Services\\Automation\\UploadFiles\\Penguins.jpg");
            document.SaveButton.Click();

            Thread.Sleep(2000);

            shared.TakeScreenShot(driver, "NewDocument" + DateTime.Now.ToString("ddMMyyyyHHmmss"));

            document.SearchText.Clear();
            document.SearchText.SendKeys("penguins");
            document.SearchButton.Click();

            document.EditButton.Click();
            document.Name.Clear();
            document.Name.SendKeys("3 Penguins");
            document.SaveButton.Click();
            
            Thread.Sleep(2000);

            shared.TakeScreenShot(driver, "EditedDocument" + DateTime.Now.ToString("ddMMyyyyHHmmss"));

            document.ResetSearch.Click();
            document.SearchText.Clear();
            document.SearchText.SendKeys("penguins");
            document.SearchButton.Click();
            
            document.DeleteButton.Click();
            navigation.ConfirmPopup.Click();

            shared.TakeScreenShot(driver, "DeletedDocument" + DateTime.Now.ToString("ddMMyyyyHHmmss"));

            driver.SwitchTo().DefaultContent();

            Logout();
        }

        [Test]
        [Description("Add, Edit and Delete a Fixed Event")]
        public void TheAddEditDeleteFixEventTest()
        {
            TestName = MethodBase.GetCurrentMethod().Name.Replace("The", "").Replace("Test", "");

            navigation.Configuration.Click();
            navigation.Events.Click();

            EventPageModel newEvent = new EventPageModel(driver);
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (newEvent.EventFrame.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Frame(newEvent.EventFrame);

            try
            {
                newEvent.AddEvent.Click();
            }
            catch (Exception) { }

            newEvent.EventName.Clear();
            newEvent.EventName.SendKeys("Auto Event");
            newEvent.EventDescription.Clear();
            newEvent.EventDescription.SendKeys("Auto Event Created By Selenium");
            newEvent.EventFrom.Clear();
            newEvent.EventFrom.SendKeys("01/01");
            newEvent.EventTo.Clear();
            newEvent.EventTo.SendKeys("01/02");
            newEvent.SaveEvent.Click();

            Thread.Sleep(2000);

            newEvent.SearchEventText.Clear();
            newEvent.SearchEventText.SendKeys("Auto Event");
            newEvent.SearchEventButton.Click();

            newEvent.EditEvent.Click();
            newEvent.EventName.Clear();
            newEvent.EventName.SendKeys("Edited Auto Event");
            newEvent.EventDescription.Clear();
            newEvent.EventDescription.SendKeys("Auto Event Created By Selenium, then edited");
            newEvent.EventFrom.Clear();
            newEvent.EventFrom.SendKeys("02/01");
            newEvent.EventTo.Clear();
            newEvent.EventTo.SendKeys("01/12");
            newEvent.SaveEvent.Click();            

            Thread.Sleep(2000);

            newEvent.ResetSearchEvent.Click();
            newEvent.SearchEventText.Clear();
            newEvent.SearchEventText.SendKeys("Edited Auto Event");
            newEvent.SearchEventButton.Click();
            
            newEvent.DeleteEvent.Click();
            navigation.ConfirmPopup.Click();
            driver.SwitchTo().DefaultContent();

            Logout();
        }

        [Test]
        [Description("Add, Edit and Delete a Non Fixed Event")]
        public void TheAddEditDeleteNonFixEventTest()
        {
            TestName = MethodBase.GetCurrentMethod().Name.Replace("The", "").Replace("Test", "");

            navigation.Configuration.Click();
            navigation.Events.Click();

            EventPageModel newEvent = new EventPageModel(driver);
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (newEvent.EventFrame.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Frame(newEvent.EventFrame);

            try
            {
                newEvent.AddEvent.Click();
            }
            catch (Exception) { }

            newEvent.EventName.Clear();
            newEvent.EventName.SendKeys("Auto Event");
            newEvent.EventDescription.Clear();
            newEvent.EventDescription.SendKeys("Auto Event Created By Selenium");
            newEvent.EventNonFix.Click();
            Thread.Sleep(1000);

            newEvent.EventNonFixFrom.SendKeys(DateTime.Now.AddDays(1).ToString("dd/MM/yyyy"));
            newEvent.EventNonFixTo.SendKeys(DateTime.Now.AddDays(30).ToString("dd/MM/yyyy"));
            newEvent.EventNonFixAddRow.Click();
            newEvent.EventNonFixFrom.SendKeys(DateTime.Now.AddDays(31).ToString("dd/MM/yyyy"));
            newEvent.EventNonFixTo.SendKeys(DateTime.Now.AddDays(60).ToString("dd/MM/yyyy"));
            newEvent.EventNonFixAddRow.Click();
            newEvent.EventNonFixFrom.SendKeys(DateTime.Now.AddDays(61).ToString("dd/MM/yyyy"));
            newEvent.EventNonFixTo.SendKeys(DateTime.Now.AddDays(90).ToString("dd/MM/yyyy"));
            newEvent.EventNonFixAddRow.Click();
            newEvent.SaveEvent.Click();            

            Thread.Sleep(2000);

            newEvent.SearchEventText.SendKeys("Auto Event");
            newEvent.SearchEventButton.Click();

            newEvent.EditEvent.Click();
            newEvent.EventName.Clear();
            newEvent.EventName.SendKeys("Edited Auto Event");
            newEvent.EventDescription.Clear();
            newEvent.EventDescription.SendKeys("Auto Event Created By Selenium, then edited");

            newEvent.EventNonFixDeleteRow.Click();
            navigation.ConfirmPopup.Click();

            newEvent.EventNonFixFrom.SendKeys(DateTime.Now.AddDays(91).ToString("dd/MM/yyyy"));
            newEvent.EventNonFixTo.SendKeys(DateTime.Now.AddDays(120).ToString("dd/MM/yyyy"));
            newEvent.EventNonFixAddRow.Click();
            newEvent.SaveEvent.Click();

            Thread.Sleep(2000);



            newEvent.ResetSearchEvent.Click();
            newEvent.SearchEventText.Clear();
            newEvent.SearchEventText.SendKeys("Edited Auto Event");
            newEvent.SearchEventButton.Click();

            newEvent.DeleteEvent.Click();
            navigation.ConfirmPopup.Click();
            driver.SwitchTo().DefaultContent();

            Logout();
        }

        [Test]
        [Description("Add, Edit and Delete an Age Rule Message")]
        public void TheAddEditDeleteMessageAgeRuleTest()
        {
            TestName = MethodBase.GetCurrentMethod().Name.Replace("The", "").Replace("Test", "");

            navigation.Configuration.Click();
            navigation.Messages.Click();

            MessagesPageModel message = new MessagesPageModel(driver);

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (message.MessageFrame.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Frame(message.MessageFrame);

            message.AddMessage.Click();
            message.MessageName.Clear();
            message.MessageName.SendKeys("Auto Age Rule");
            message.MessageDescription.Clear();
            message.MessageDescription.SendKeys("Age Rule created by Selenium");
            message.SaveMessage.Click();

            Thread.Sleep(2000);

            message.MessageSearchText.Clear();
            message.MessageSearchText.SendKeys("auto age rule");
            message.MessageSearchButton.Click();

            message.EditMessage.Click();
            message.MessageName.Clear();
            message.MessageName.SendKeys("Edited Auto Age Rule");
            message.MessageDescription.Clear();
            message.MessageDescription.SendKeys("Age Rule created by Selenium and edited by selenium");
            message.SaveMessage.Click();
            
            Thread.Sleep(2000);
            
            message.MessageSearchReset.Click();
            message.MessageSearchText.Clear();
            message.MessageSearchText.SendKeys("edited auto age rule");
            message.MessageSearchButton.Click();

            message.DeleteMessage.Click();
            navigation.ConfirmPopup.Click();
            driver.SwitchTo().DefaultContent();

            Logout();
        }

        [Test]
        [Description("Add, Edit and Delete an Age Procedure Message")]
        public void TheAddEditDeleteMessageAgeProcedureTest()
        {
            TestName = MethodBase.GetCurrentMethod().Name.Replace("The", "").Replace("Test", "");

            navigation.Configuration.Click();
            navigation.Messages.Click();

            MessagesPageModel message = new MessagesPageModel(driver);

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (message.MessageFrame.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Frame(message.MessageFrame);

            message.AddMessage.Click();
            message.MessageName.Clear();
            message.MessageName.SendKeys("Auto Age Procedure");
            message.MessageDescription.Clear();
            message.MessageDescription.SendKeys("Age Procedure created by Selenium");
            message.MessageProcedure.Click();
            message.SaveMessage.Click();
            
            Thread.Sleep(2000);

            message.MessageSearchText.Clear();
            message.MessageSearchText.SendKeys("auto age procedure");
            message.MessageSearchButton.Click();

            message.EditMessage.Click();
            message.MessageName.Clear();
            message.MessageName.SendKeys("Edited Auto Age Procedure");
            message.MessageDescription.Clear();
            message.MessageDescription.SendKeys("Age Procedure created by Selenium and edited by selenium");
            message.SaveMessage.Click();
            
            Thread.Sleep(2000);

            message.MessageSearchReset.Click();
            message.MessageSearchText.Clear();
            message.MessageSearchText.SendKeys("edited auto age procedure");

            message.MessageSearchButton.Click();

            message.DeleteMessage.Click();
            navigation.ConfirmPopup.Click();
            driver.SwitchTo().DefaultContent();

            Logout();
        }

        [Test]
        [Description("Add, Edit and Delete an Condition Rule Message")]
        public void TheAddEditDeleteMessageConditionRuleTest()
        {
            TestName = MethodBase.GetCurrentMethod().Name.Replace("The", "").Replace("Test", "");

            navigation.Configuration.Click();
            navigation.Messages.Click();

            MessagesPageModel message = new MessagesPageModel(driver);

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (message.MessageFrame.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Frame(message.MessageFrame);

            message.AddMessage.Click();
            message.MessageName.Clear();
            message.MessageName.SendKeys("Auto Condition Rule");
            message.MessageDescription.Clear();
            message.MessageDescription.SendKeys("Condition Rule created by Selenium");
            message.MessageAge.Click();
            message.MessageCondition.Click();
            message.SaveMessage.Click();

            Thread.Sleep(2000);

            message.MessageSearchText.Clear();
            message.MessageSearchText.SendKeys("auto Condition rule");
            message.MessageSearchButton.Click();

            message.EditMessage.Click();
            message.MessageName.Clear();
            message.MessageName.SendKeys("Edited Auto Condition Rule");
            message.MessageDescription.Clear();
            message.MessageDescription.SendKeys("Condition Rule created by Selenium and edited by selenium");
            message.SaveMessage.Click();

            Thread.Sleep(2000);

            message.MessageSearchReset.Click();
            message.MessageSearchText.Clear();
            message.MessageSearchText.SendKeys("edited auto Condition rule");
            message.MessageSearchButton.Click();

            message.DeleteMessage.Click();
            navigation.ConfirmPopup.Click();
            driver.SwitchTo().DefaultContent();

            Logout();
        }

        [Test]
        [Description("Add, Edit and Delete an Condition Procedure Message")]
        public void TheAddEditDeleteMessageConditionProcedureTest()
        {
            TestName = MethodBase.GetCurrentMethod().Name.Replace("The", "").Replace("Test", "");

            navigation.Configuration.Click();
            navigation.Messages.Click();

            MessagesPageModel message = new MessagesPageModel(driver);

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (message.MessageFrame.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Frame(message.MessageFrame);

            message.AddMessage.Click();
            message.MessageName.Clear();
            message.MessageName.SendKeys("Auto Cond Proc");
            message.MessageDescription.Clear();
            message.MessageDescription.SendKeys("Condition Procedure created by Selenium");
            message.MessageAge.Click();
            message.MessageCondition.Click();
            message.MessageProcedure.Click();
            message.SaveMessage.Click();

            Thread.Sleep(2000);

            message.MessageSearchText.SendKeys("auto Cond Proc");
            message.MessageSearchButton.Click();

            message.EditMessage.Click();
            message.MessageName.Clear();
            message.MessageName.SendKeys("Edited Auto Cond Proc");
            message.MessageDescription.Clear();
            message.MessageDescription.SendKeys("Condition Procedure created by Selenium and edited by selenium");
            message.SaveMessage.Click();

            Thread.Sleep(2000);

            message.MessageSearchReset.Click();
            message.MessageSearchText.Clear();
            message.MessageSearchText.SendKeys("edited auto Cond Proc");
            message.MessageSearchButton.Click();

            message.DeleteMessage.Click();
            navigation.ConfirmPopup.Click();
            driver.SwitchTo().DefaultContent();

            Logout();
        }

        [Test]
        [Description("Add, Edit and Delete an Age and Condition Rule Message")]
        public void TheAddEditDeleteMessageAgeConditionRuleTest()
        {
            TestName = MethodBase.GetCurrentMethod().Name.Replace("The", "").Replace("Test", "");

            navigation.Configuration.Click();
            navigation.Messages.Click();

            MessagesPageModel message = new MessagesPageModel(driver);

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (message.MessageFrame.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Frame(message.MessageFrame);
            message.AddMessage.Click();
            message.MessageName.Clear();
            message.MessageName.SendKeys("Auto AC Rule");
            message.MessageDescription.Clear();
            message.MessageDescription.SendKeys("Condition Procedure created by Selenium");            
            message.MessageCondition.Click();
            message.SaveMessage.Click();

            Thread.Sleep(2000);

            message.MessageSearchText.Clear();
            message.MessageSearchText.SendKeys("auto ac rule");
            message.MessageSearchButton.Click();

            message.EditMessage.Click();
            message.MessageName.Clear();
            message.MessageName.SendKeys("Edited Auto AC Rule");
            message.MessageDescription.Clear();
            message.MessageDescription.SendKeys("Age and Condition Rule created by Selenium and edited by Selenium");
            message.SaveMessage.Click();

            Thread.Sleep(2000);

            message.MessageSearchReset.Click();
            message.MessageSearchText.Clear();
            message.MessageSearchText.SendKeys("edited auto ac rule");
            message.MessageSearchButton.Click();
            message.DeleteMessage.Click();
            navigation.ConfirmPopup.Click();
            driver.SwitchTo().DefaultContent();

            Logout();
        }        

        [Test]
        [Description("Add, Edit and Delete an Age and Condition Procedure Message")]
        public void TheAddEditDeleteMessageAgeConditionProcedureTest()
        {
            TestName = MethodBase.GetCurrentMethod().Name.Replace("The", "").Replace("Test", "");

            navigation.Configuration.Click();
            navigation.Messages.Click();

            MessagesPageModel message = new MessagesPageModel(driver);

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (message.MessageFrame.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Frame(message.MessageFrame);
            message.AddMessage.Click();

            message.MessageName.SendKeys("Auto AC Proc");
            message.MessageDescription.SendKeys("Age and Condition Procedure created by Selenium");            
            message.MessageCondition.Click();
            message.MessageProcedure.Click();
            message.SaveMessage.Click();

            Thread.Sleep(2000);

            message.MessageSearchText.SendKeys("auto ac proc");
            message.MessageSearchButton.Click();

            message.EditMessage.Click();
            message.MessageName.Clear();
            message.MessageName.SendKeys("Edited Auto AC Proc");
            message.MessageDescription.Clear();
            message.MessageDescription.SendKeys("Age and Condition Procedure created by Selenium and edited by Selenium");
            message.SaveMessage.Click();

            Thread.Sleep(2000);

            message.MessageSearchReset.Click();
            message.MessageSearchText.Clear();
            message.MessageSearchText.SendKeys("edited auto ac proc");
            message.MessageSearchButton.Click();
            message.DeleteMessage.Click();
            navigation.ConfirmPopup.Click();
            driver.SwitchTo().DefaultContent();

            Logout();
        }

        [Test]
        [Description("Add, Edit and Delete a VAT Rate")]
        public void TheAddEditDeleteVATTest()
        {
            TestName = MethodBase.GetCurrentMethod().Name.Replace("The", "").Replace("Test", "");

            navigation.Configuration.Click();
            navigation.VATRates.Click();

            VATPageModel vat = new VATPageModel(driver);

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (vat.VATFrame.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Frame(vat.VATFrame);
            vat.AddVATRate.Click();
            vat.VATCode.Clear();
            vat.VATCode.SendKeys("A");
            vat.VATName.Clear();
            vat.VATName.SendKeys("Another VAT Rate");
            vat.VATRate.Clear();
            vat.VATRate.SendKeys("10");
            vat.VATFutureDate.SendKeys(DateTime.Now.AddDays(20).ToString("dd/MM/yyyy"));
            vat.VATFutureRate.Clear();
            vat.VATFutureRate.SendKeys("12");
            vat.VATFutureAdd.Click();
            vat.SaveVAT.Click();

            Thread.Sleep(2000);

            vat.VATSearchCode.Clear();
            vat.VATSearchCode.SendKeys("A");
            vat.VATSearchButton.Click();

            vat.EditVAT.Click();
            vat.VATCode.Clear();
            vat.VATCode.SendKeys("AN");
            vat.VATName.Clear();
            vat.VATName.SendKeys("Another Edited VAT Rate");
            vat.VATFutureDelete.Click(); //delete vat rate
            navigation.ConfirmPopup.Click();
            vat.VATFutureDate.Clear();
            vat.VATFutureDate.SendKeys(DateTime.Now.AddDays(25).ToString("dd/MM/yyyy"));
            vat.VATFutureRate.Clear();
            vat.VATFutureRate.SendKeys("12");
            vat.VATFutureAdd.Click();
            vat.SaveVAT.Click();

            Thread.Sleep(2000);

            vat.VATSearchReset.Click();
            vat.VATSearchCode.Clear();
            vat.VATSearchCode.SendKeys("A");
            vat.VATSearchButton.Click();

            Thread.Sleep(2000);

            vat.DeleteVAT.Click();
            navigation.ConfirmPopup.Click();
            driver.SwitchTo().DefaultContent();

            Logout();
        }

        //[Test]
        //[Description("Add, Edit and Delete an Age Trading Consent")]
        //public void TheAddEditDeleteAgeTradingConsentTest()
        //{
        //    TestName = MethodBase.GetCurrentMethod().Name.Replace("The", "").Replace("Test", "");
        //    driver.Navigate().GoToUrl(baseURL + "/Index.aspx");
        //    driver.FindElement(By.Id("UserName")).Clear();
        //    driver.FindElement(By.Id("UserName")).SendKeys("epositive");
        //    driver.FindElement(By.Id("Password")).Clear();
        //    driver.FindElement(By.Id("Password")).SendKeys("support@secure");
        //    driver.FindElement(By.Id("btnLoginByUsername")).Click();
        //    driver.FindElement(By.XPath("//div/ul/li[3]/a")).Click();
        //    driver.FindElement(By.XPath("//li[10]/a")).Click();
        //    for (int second = 0; ; second++)
        //    {
        //        if (second >= 60) Assert.Fail("timeout");
        //        try
        //        {
        //            if (IsElementPresent(By.Id("tab-24"))) break;
        //        }
        //        catch (Exception)
        //        { }
        //        Thread.Sleep(1000);
        //    }
        //    driver.SwitchTo().Frame(driver.FindElement(By.Id("tab-24")));
        //    driver.FindElement(By.Id("lnkAdd")).Click();
        //    driver.FindElement(By.Id("TrCoName")).Clear();
        //    driver.FindElement(By.Id("TrCoName")).SendKeys("Auto Age Consent");
        //    driver.FindElement(By.Id("TrCoAge")).Click();
        //    driver.FindElement(By.Id("TrCoCashierAge")).Clear();
        //    driver.FindElement(By.Id("TrCoCashierAge")).SendKeys("18");
        //    driver.FindElement(By.Id("TrCoCustomerAge")).Clear();
        //    driver.FindElement(By.Id("TrCoCustomerAge")).SendKeys("18");

        //    driver.FindElement(By.Id("btnAddNew")).Click();
        //    driver.FindElement(By.XPath("/html/body/div[6]/div[2]/div/table/tbody/tr[1]/td/div/div[2]/div[1]/div[2]/div/div/table/tbody/tr[2]/td[1]/div/input")).Click();
        //    driver.FindElement(By.Id("btnAddMessagestoGrid")).Click();      

        //    driver.FindElement(By.XPath("/html/body/form/div[6]/div[2]/div/div[1]/div/div/div/div[1]/table[1]/tbody/tr/td/table/tbody/tr[2]/td/div/div[2]/div[1]/div[2]/div/div/table/tbody/tr[2]/td[5]/div/input")).Click();
        //    int j = 2;
        //    while (IsElementPresent(By.XPath("/html/body/div[6]/div[2]/div/table/tbody/tr[1]/td/div/div[2]/div[1]/div[2]/div/div/table/tbody/tr[" + j.ToString() + "]/td[1]/div/input")))
        //    {
        //        driver.FindElement(By.XPath("/html/body/div[6]/div[2]/div/table/tbody/tr[1]/td/div/div[2]/div[1]/div[2]/div/div/table/tbody/tr[" + j.ToString() + "]/td[1]/div/input")).Click();
        //        j++;
        //    }  
        //    driver.FindElement(By.Id("btnAddMessagestoGrid")).Click();

        //    driver.FindElement(By.XPath("/html/body/form/div[6]/div[2]/div/div[1]/div/div/div/div[1]/table[1]/tbody/tr/td/table/tbody/tr[2]/td/div/div[2]/div[1]/div[2]/div/div/table/tbody/tr[2]/td[6]/div/input")).Click();

        //    Thread.Sleep(1000);
        //    int i = 2;
        //    do
        //    {
        //        driver.FindElement(By.XPath("/html/body/div[7]/div[2]/div/table/tbody/tr[1]/td/div/div[2]/div[1]/div[2]/div/div/table/tbody/tr[" + i.ToString() + "]/td[1]/div/input")).Click();
        //        i++;
        //    } while (IsElementPresent(By.XPath("/html/body/div[7]/div[2]/div/table/tbody/tr[1]/td/div/div[2]/div[1]/div[2]/div/div/table/tbody/tr[" + i.ToString() + "]/td[1]/div/input")));
        //    Thread.Sleep(1000);
        //    new Actions(driver).DragAndDropToOffset(driver.FindElement(By.Id("/html/body/div[7]/div[1]/span")), -50, -50).Build().Perform();
        //    shared.WaitForElementNotAppear(driver, "class=pq-grid-footer");
        //    //shared.WaitForElementAppear(driver, "id=btnAddReason");

        //    Thread.Sleep(2000);

        //    //IJavaScriptExecutor js = ((IJavaScriptExecutor)driver);

        //    driver.FindElement(By.Id("btnAddReason")).Click();

        //    //new Actions(driver).MoveToElement(driver.FindElement(By.Id("btnAddReason"))).Click().Perform();
            
        //    driver.FindElement(By.Id("lnkSave")).Click();

        //    Thread.Sleep(2000);

        //    driver.FindElement(By.Id("SearchText")).Clear();
        //    driver.FindElement(By.Id("SearchText")).SendKeys("Auto Age Consent");
        //    driver.FindElement(By.Id("btnSearch")).Click();
        //    driver.FindElement(By.Id("lnkEdit")).Click();
        //    driver.FindElement(By.Id("TrCoName")).Clear();
        //    driver.FindElement(By.Id("TrCoName")).SendKeys("Edited Auto Age Consent");
        //    driver.FindElement(By.Id("TrCoCashierAge")).Clear();
        //    driver.FindElement(By.Id("TrCoCashierAge")).SendKeys("16");
        //    driver.FindElement(By.Id("TrCoCustomerAge")).Clear();
        //    driver.FindElement(By.Id("TrCoCustomerAge")).SendKeys("21");
        //    driver.FindElement(By.Id("lnkSave")).Click();

        //    Thread.Sleep(2000);

        //    driver.FindElement(By.Id("btnCancel")).Click();

        //    Thread.Sleep(1000);

        //    driver.FindElement(By.Id("SearchText")).Click();
        //    driver.FindElement(By.Id("SearchText")).Clear();
        //    driver.FindElement(By.Id("SearchText")).SendKeys("Edited Auto Age Consent");
        //    driver.FindElement(By.Id("btnSearch")).Click();
        //    Thread.Sleep(1000);
        //    driver.FindElement(By.Id("lnkDelete")).Click();
        //    driver.FindElement(By.Name("Yes")).Click();
        //    driver.SwitchTo().DefaultContent();

        //    driver.FindElement(By.XPath("/html/body/form/div[3]/div[1]/div[1]/a[3]/i")).Click();
        //    driver.FindElement(By.Name("Yes")).Click();

        //    for (int second = 0; ; second++)
        //    {
        //        if (second >= 60) Assert.Fail("timeout");
        //        try
        //        {
        //            if ("Login" == driver.Title) break;
        //        }
        //        catch (Exception)
        //        { }
        //        Thread.Sleep(1000);
        //    }
        //}
        
        [Test]        
        [TestCase("Approval", Description="Add, Edit and Delete Reason - Approval")]
        [TestCase("Refusal", Description="Add, Edit and Delete Reason - Refusal")]
        [TestCase("Price Override", Description="Add, Edit and Delete Reason - Price Override")]
        [TestCase("Customer Returns", Description="Add, Edit and Delete Reason - Customer Returns")]
        [TestCase("Purchase Returns", Description="Add, Edit and Delete Reason - Purchase Returns")]
        [TestCase("Stock Adjustment / Wastage", Description="Add, Edit and Delete Reason - Stock Adjustment / Wastage")]
        [TestCase("Void Item / Sales", Description="Add, Edit and Delete Reason - Void Item / Sales")]
        [TestCase("Discount", Description="Add, Edit and Delete Reason - Discount")]
        [TestCase("Hold", Description="Add, Edit and Delete Reason - Hold")]
        [TestCase("Paid In", Description="Add, Edit and Delete Reason - Paid In")]
        [TestCase("Paid Out", Description="Add, Edit and Delete Reason - Paid Out")]
        [TestCase("Drawer", Description="Add, Edit and Delete Reason - Drawer")]
        [TestCase("Cash In/ Out", Description="Add, Edit and Delete Reason - Cash In/ Out")]
        [TestCase("Safe Drop", Description="Add, Edit and Delete Reason - Safe Drops")]           
        public void TheAddEditDeleteReasonsTest(string type)
        {

            navigation.Configuration.Click();
            navigation.Reasons.Click();

            // tab-18
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.Id("tab-18"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Frame(driver.FindElement(By.Id("tab-18")));
            driver.FindElement(By.Id("lnkAdd")).Click();
            new SelectElement(driver.FindElement(By.Id("REASActivity"))).SelectByText(type);
            driver.FindElement(By.Id("REASDesc")).Clear();
            driver.FindElement(By.Id("REASDesc")).SendKeys("Auto "+type);
            if (driver.FindElement(By.Id("SellRestrictionType")).Displayed)
            {
                new SelectElement(driver.FindElement(By.Id("SellRestrictionType"))).SelectByText("Age");
            }

            if (driver.FindElement(By.Id("rdoPlus")).Displayed)
            {
                driver.FindElement(By.Id("rdoPlus")).Click();
            }
            driver.FindElement(By.Id("lnkSave")).Click();

            Thread.Sleep(2000);

            driver.FindElement(By.Id("txtSearchReason")).Clear();
            driver.FindElement(By.Id("txtSearchReason")).SendKeys("Auto " + type.ToLower());
            driver.FindElement(By.Id("btnSearch")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("lnkEdit")).Click();
            driver.FindElement(By.Id("REASDesc")).Clear();
            driver.FindElement(By.Id("REASDesc")).SendKeys("Edited " + "Auto " + type);
            if (driver.FindElement(By.Id("SellRestrictionType")).Displayed)
            {
                new SelectElement(driver.FindElement(By.Id("SellRestrictionType"))).SelectByText("Conditional");
            }
            if (driver.FindElement(By.Id("rdoPlus")).Displayed)
            {
                driver.FindElement(By.Id("rdoMinus")).Click();
            }
            driver.FindElement(By.Id("lnkSave")).Click();
            driver.FindElement(By.Id("btnResetSearch")).Click();

            Thread.Sleep(1000);

            driver.FindElement(By.Id("txtSearchReason")).Clear();
            driver.FindElement(By.Id("txtSearchReason")).SendKeys("edited " + "auto " + type.ToLower());
            driver.FindElement(By.Id("btnSearch")).Click();

            Thread.Sleep(2000);

            driver.FindElement(By.Id("lnkDelete")).Click();
            driver.FindElement(By.Name("Yes")).Click();
            driver.SwitchTo().DefaultContent();

            Logout();
        }

        [Test]
        [TestCase("Engineer",Description="Add a new Engineer user and check that all correct menus are displayed")]
        [TestCase("Admin", Description = "Add a new Admin user and check that all correct menus are displayed")]
        [TestCase("Manager", Description = "Add a new Manager user and check that all correct menus are displayed")]        
        public void TheAddEditDeleteUserTest(string role)
        {

            navigation.Configuration.Click();
            navigation.Users.Click();

            UsersPageModel users = new UsersPageModel(driver);

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (users.UserFrame.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Frame(users.UserFrame);
            users.AddUser.Click();
            users.UserFirstName.Clear();
            users.UserFirstName.SendKeys("Automated");
            users.UserMiddleName.Clear();
            users.UserMiddleName.SendKeys("Selenium");
            users.UserLastName.Clear();
            users.UserLastName.SendKeys("User");

            new SelectElement(users.UserRoleID).SelectByText(role);
                        
            users.UserDateOfBirth.Click();
            new SelectElement(users.UserDateOfBirthMonth).SelectByText("Jan"); //DoB month
            new SelectElement(users.UserDateOfBirthYear).SelectByText("1980"); //DoB Year
            users.UserDateOfBirthFirstDay.Click(); //DoB 1st link
            users.UserAddress.Clear();
            users.UserAddress.SendKeys("123 Test Road");
            users.UserPostcode.Clear();
            users.UserPostcode.SendKeys("DN15 9YA");
            users.UserImage.SendKeys("H:\\PMO\\Test Services\\Automation\\UploadFiles\\Penguins.jpg");
            users.UserPhone1.Clear();
            users.UserPhone1.SendKeys("01111222222");
            users.UserPhone2.Clear();
            users.UserPhone2.SendKeys("077777888888");
            users.UserPhone3.Clear();
            users.UserPhone3.SendKeys("01111222223");
            users.UserEmail.Clear();
            users.UserEmail.SendKeys("testing@nisaretail.com");
            users.UserName.Clear();
            users.UserName.SendKeys("SeleniumUser");
            users.UserDisplayName.Clear();
            users.UserDisplayName.SendKeys("SeleniumUser");            
            users.UserPassword.Clear();
            users.UserPassword.SendKeys("123456a");
            users.UserConfirmPassword.Clear();
            users.UserConfirmPassword.SendKeys("123456a");
            users.SaveUser.Click();

            driver.SwitchTo().DefaultContent();
            Logout();

            loginPage.Username.SendKeys("SeleniumUser");
            loginPage.Password.SendKeys("123456a");
            loginPage.LoginButton.Click();            

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.LinkText("Nisa"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }

            MenuCheck(role);

            Thread.Sleep(1000);

            Logout();

            loginPage.Username.SendKeys("epositive");
            loginPage.Password.SendKeys("support@secure");
            loginPage.LoginButton.Click();

            navigation.Configuration.Click();
            navigation.Users.Click();

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (users.UserFrame.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Frame(users.UserFrame);

            users.SearchUserName.Clear();
            users.SearchUserName.SendKeys("SeleniumUser");
            users.SearchButton.Click();
            Thread.Sleep(1000);
            users.DeleteUser.Click();
            shared.WaitForElementAppear(driver, navigation.ConfirmPopup);
            navigation.ConfirmPopup.Click();
            driver.SwitchTo().DefaultContent();

            Logout();
        }

        [Test]
        [TestCase("NISAWAY-NISA Way", "wayproducts", Description ="Place and submit way order")]
        [TestCase("NISAFRZ-NISA Freeze", "freezeproducts", Description = "Place and submit freeze order")]
        [TestCase("NISACHL-NISA Chill","chillproducts", Description = "Place and submit chill order")]
        public void TheManualOrderingTest(string supp, string productList)
        {

            navigation.Replenishment.Click();
            navigation.Order.Click();

            NewManualOrderingPageModel newManualOrder = new NewManualOrderingPageModel(driver);
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (newManualOrder.NewOrderFrame.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }

            driver.SwitchTo().Frame(newManualOrder.NewOrderFrame);

            newManualOrder.AddOrder.Click();
            new Actions(driver).MoveToElement(newManualOrder.ManualOrder,5,5).Build().Perform();
            newManualOrder.ManualOrder.Click();
            Thread.Sleep(1000);

            ManualOrderingPageModel manualOrder = new ManualOrderingPageModel(driver);
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(manualOrder.OrderFrame);
            new SelectElement(manualOrder.SupplierID).SelectByText(supp);
            manualOrder.SaveOrder.Click();

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (manualOrder.QuickAddText.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }

            string[] products = config[productList].Split(',');

            foreach(string prod in products)
            {
                manualOrder.QuickAddText.Clear();
                manualOrder.QuickAddText.SendKeys(prod);
                manualOrder.QuickSearchItem.Click();
                Thread.Sleep(1000);
                manualOrder.QuickAddQuantity.SendKeys("3");
                manualOrder.QuickAddQuantity.SendKeys(Keys.Enter);
            }

            //manualOrder.SelectAllProducts.Click();
            //manualOrder.AddToBasket.Click();
            //Thread.Sleep(500);
            //new SelectElement(manualOrder.BasketDropdown).SelectByText("Default Basket");
            //manualOrder.AddBasket.Click();

            string handle = driver.CurrentWindowHandle;

            manualOrder.SendOrder.Click();

            driver.SwitchTo().DefaultContent();
            for (int second=0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (driver.WindowHandles.Count > 1) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            
            SendOrderWindow sendOrder = new SendOrderWindow(driver);

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (sendOrder.SubmitOrder.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }

            driver.Manage().Window.Maximize();

            Thread.Sleep(2000);

            sendOrder.SubmitOrder.Click();

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("Order Submitted" == driver.Title) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }

            driver.Close();

            driver.SwitchTo().Window(driver.WindowHandles.First());
            driver.SwitchTo().Frame(manualOrder.OrderFrame);
            Thread.Sleep(1000);

            navigation.ConfirmPopup.Click();
            driver.SwitchTo().DefaultContent();

            Logout();
        }

        [Test]
        [TestCase("NISAWAY-NISA Way", "wayproducts", Description = "Place and submit way order")]
        [TestCase("NISAFRZ-NISA Freeze", "freezeproducts", Description = "Place and submit freeze order")]
        [TestCase("NISACHL-NISA Chill", "chillproducts", Description = "Place and submit chill order")]
        public void TheManualOrderingAdvancedSearchTest(string supp, string productList)
        {

            navigation.Replenishment.Click();
            navigation.Order.Click();

            NewManualOrderingPageModel newManualOrder = new NewManualOrderingPageModel(driver);
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (newManualOrder.NewOrderFrame.Displayed) break;
                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000);
            }

            driver.SwitchTo().Frame(newManualOrder.NewOrderFrame);

            newManualOrder.AddOrder.Click();
            new Actions(driver).MoveToElement(newManualOrder.ManualOrder, 5, 5).Build().Perform();
            newManualOrder.ManualOrder.Click();
            Thread.Sleep(1000);

            ManualOrderingPageModel manualOrder = new ManualOrderingPageModel(driver);
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(manualOrder.OrderFrame);
            new SelectElement(manualOrder.SupplierID).SelectByText(supp);
            manualOrder.SaveOrder.Click();

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (manualOrder.QuickAddText.Displayed) break;
                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000);
            }

            string[] products = config[productList].Split(',');

            AdvancedSearchPageModel advancedSearch = new AdvancedSearchPageModel(driver);
            foreach (string prod in products)
            {
                manualOrder.AdvancedSearch.Click();
                for(int i = 0; ; i++)
                {
                    if (i >= 60) Assert.Fail("timeout");
                    try
                    {
                        if (advancedSearch.AdvancedSearchFrame.Displayed) break;
                    }
                    catch (Exception) { }
                    Thread.Sleep(1000);
                }
                driver.SwitchTo().Frame(advancedSearch.AdvancedSearchFrame);
                advancedSearch.ItemCode.SendKeys(prod);
                
                advancedSearch.SearchButton.Click();
                for (int i = 0; ; i++)
                {
                    if (i >= 60) Assert.Fail("timeout");
                    try
                    {
                        if (advancedSearch.SelectAll.Enabled) break;
                    }
                    catch (Exception) { }
                    Thread.Sleep(1000);
                }
                advancedSearch.SelectAll.Click();
                Thread.Sleep(500);
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame(manualOrder.OrderFrame);
                navigation.ConfirmPopup.Click();
                driver.SwitchTo().Frame(advancedSearch.AdvancedSearchFrame);
                Thread.Sleep(500);
                advancedSearch.OKButton.Click();
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame(manualOrder.OrderFrame);
                Thread.Sleep(500);
            }

            //manualOrder.SelectAllProducts.Click();
            //manualOrder.AddToBasket.Click();
            //Thread.Sleep(500);
            //new SelectElement(manualOrder.BasketDropdown).SelectByText("Default Basket");
            //manualOrder.AddBasket.Click();

            string handle = driver.CurrentWindowHandle;

            manualOrder.SendOrder.Click();

            driver.SwitchTo().DefaultContent();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (driver.WindowHandles.Count > 1) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            SendOrderWindow sendOrder = new SendOrderWindow(driver);

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (sendOrder.SubmitOrder.Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }

            driver.Manage().Window.Maximize();

            Thread.Sleep(2000);

            sendOrder.SubmitOrder.Click();

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("Order Submitted" == driver.Title) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }

            driver.Close();

            driver.SwitchTo().Window(driver.WindowHandles.First());
            driver.SwitchTo().Frame(manualOrder.OrderFrame);
            Thread.Sleep(1000);

            navigation.ConfirmPopup.Click();
            driver.SwitchTo().DefaultContent();

            Logout();
        }


        [Test]
        [TestCase("wayproducts", Description = "Place and submit way stock take")]
        [TestCase("freezeproducts", Description = "Place and submit freeze stock take")]
        [TestCase("chillproducts", Description = "Place and submit chill stock take")]
        public void TheStockTakeSubmitTest(string productList)
        {

            navigation.Replenishment.Click();
            navigation.StockTake.Click();

            Thread.Sleep(2000);

            StockTakePageModel stockTake = new StockTakePageModel(driver);

            for (int seconds=0; ; seconds++)
            {
                if(seconds>=60) Assert.Fail("timeout");
                try
                {
                    if (stockTake.StockTakeViewerFrame.Displayed) break;
                }
                catch (Exception) { }
            }

            driver.SwitchTo().Frame(stockTake.StockTakeViewerFrame);

            new Actions(driver).MoveToElement(stockTake.ResetStockTakeSearch).Build().Perform();

            stockTake.CreateStockTake.Click();

            driver.SwitchTo().DefaultContent();

            NewStockTakePageModel newStockTake = new NewStockTakePageModel(driver);

            for (int seconds = 0; ; seconds++)
            {
                if (seconds >= 60) Assert.Fail("timeout");
                try
                {
                    if (newStockTake.StockTakeFrame.Displayed) break;
                }
                catch (Exception) { }
            }

            driver.SwitchTo().Frame(newStockTake.StockTakeFrame);

            Thread.Sleep(2000);

            newStockTake.StockTakeComments.SendKeys("Automated Stock Take");

            string[] products = config[productList].Split(',');
            Random rand = new Random();
            foreach (string product in products)
            {
                newStockTake.QuickAddText.Clear();
                newStockTake.QuickAddText.SendKeys(product);
                newStockTake.QuickAddSearch.Click();
                for (int seconds = 0; ; seconds++)
                {
                    if (seconds >= 60) Assert.Fail("timeout");
                    try
                    {
                        if (newStockTake.QuickAddQuantity.Displayed) break;
                    }
                    catch (Exception) { }
                }
                newStockTake.QuickAddQuantity.SendKeys(rand.Next(1,11).ToString());
                newStockTake.QuickAddQuantity.SendKeys(Keys.Enter);
                for (int seconds = 0; ; seconds++)
                {
                    if (seconds >= 60) Assert.Fail("timeout");
                    try
                    {
                        if (!newStockTake.QuickAddQuantity.Displayed) break;
                    }
                    catch (Exception) { }
                }
            }

            newStockTake.SubmitStockTake.Click();
            Thread.Sleep(500);
            navigation.ConfirmPopup.Click();

            driver.SwitchTo().DefaultContent();

            for(int i = 0; ; i++)
            {
                if (i >= 60) Assert.Fail("timeout");
                try
                {
                    if (stockTake.StockTakeViewerFrame.Displayed) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }
            Logout();
        }

        [Test]
        [TestCase("NISAWAY-NISA Way", "wayproducts", Description = "Place and submit way delivery")]
        [TestCase("NISAFRZ-NISA Freeze", "freezeproducts", Description = "Place and submit freeze delivery")]
        [TestCase("NISACHL-NISA Chill", "chillproducts", Description = "Place and submit chill delivery")]
        public void TheDeliverySubmitTest(string supplier, string products)
        {
            navigation.Replenishment.Click();
            navigation.Delivery.Click();
            Thread.Sleep(2000);

            DeliveryPageModel delivery = new DeliveryPageModel(driver);
            for (int i = 0; ; i++)
            {
                if (i >= 60) Assert.Fail("timeout");
                try
                {
                    if (delivery.DeliveryFrame.Displayed) break;
                }
                catch (Exception) { }
            }

            driver.SwitchTo().Frame(delivery.DeliveryFrame);
            Thread.Sleep(1000);
            delivery.CreateDelivery.Click();
            driver.SwitchTo().DefaultContent();

            NewDeliveryPageModel newDelivery = new NewDeliveryPageModel(driver);
            for (int i = 0; ; i++)
            {
                if (i >= 60) Assert.Fail("timeout");
                try
                {
                    if (newDelivery.NewDeliveryFrame.Displayed) break;
                }
                catch (Exception) { }
            }

            driver.SwitchTo().Frame(newDelivery.NewDeliveryFrame);

            Random rand = new Random();

            newDelivery.SupplierID.SendKeys(supplier);
            newDelivery.DispatchNumber.SendKeys(rand.Next(100000, 999999).ToString());
            newDelivery.DeliveryDate.SendKeys(DateTime.Today.ToString("dd/MM/yyyy"));
            newDelivery.SaveDelivery.Click();
            Thread.Sleep(1000);

            string[] productList = config[products].Split(',');
            
            foreach (string prod in productList)
            {
                newDelivery.QuickAddProductText.Clear();
                newDelivery.QuickAddProductText.SendKeys(prod);
                newDelivery.QuickAddProductButton.Click();
                Thread.Sleep(500);
                newDelivery.QuickAddProductQuantity.SendKeys(rand.Next(1, 11).ToString());
                newDelivery.QuickAddProductQuantity.SendKeys(Keys.Enter);
                Thread.Sleep(1000);
            }

            newDelivery.SubmitDelivery.Click();

            driver.SwitchTo().DefaultContent();

            for (int i = 0; ; i++)
            {
                if (i >= 60) Assert.Fail("timeout");
                try
                {
                    if (delivery.DeliveryFrame.Displayed) break;
                }
                catch (Exception) { }
            }

            Logout();
        }

        [Test]
        [TestCase("NISAWAY-NISA Way", "wayproducts", Description = "Place and submit way delivery")]
        [TestCase("NISAFRZ-NISA Freeze", "freezeproducts", Description = "Place and submit freeze delivery")]
        [TestCase("NISACHL-NISA Chill", "chillproducts", Description = "Place and submit chill delivery")]
        public void TheDeliveryAdvancedSearchTest(string supplier, string products)
        { 
            navigation.Replenishment.Click();
            navigation.Delivery.Click();
            Thread.Sleep(2000);

            DeliveryPageModel delivery = new DeliveryPageModel(driver);
            for (int i = 0; ; i++)
            {
                if (i >= 60) Assert.Fail("timeout");
                try
                {
                    if (delivery.DeliveryFrame.Displayed) break;
                }
                catch (Exception) { }
            }

            driver.SwitchTo().Frame(delivery.DeliveryFrame);
            Thread.Sleep(1000);
            delivery.CreateDelivery.Click();
            driver.SwitchTo().DefaultContent();

            NewDeliveryPageModel newDelivery = new NewDeliveryPageModel(driver);
            for (int i = 0; ; i++)
            {
                if (i >= 60) Assert.Fail("timeout");
                try
                {
                    if (newDelivery.NewDeliveryFrame.Displayed) break;
                }
                catch (Exception) { }
            }

            driver.SwitchTo().Frame(newDelivery.NewDeliveryFrame);

            Random rand = new Random();

            newDelivery.SupplierID.SendKeys(supplier);
            newDelivery.DispatchNumber.SendKeys(rand.Next(100000, 999999).ToString());
            newDelivery.DeliveryDate.SendKeys(DateTime.Today.ToString("dd/MM/yyyy"));
            newDelivery.SaveDelivery.Click();
            Thread.Sleep(1000);

            string[] productList = config[products].Split(',');

            AdvancedSearchPageModel advancedSearch = new AdvancedSearchPageModel(driver);
            foreach (string prod in productList)
            {
                newDelivery.AdvancedSearch.Click();
                for (int i = 0; ; i++)
                {
                    if (i >= 60) Assert.Fail("timeout");
                    try
                    {
                        if (advancedSearch.AdvancedSearchFrame.Displayed) break;
                    }
                    catch (Exception) { }
                    Thread.Sleep(1000);
                }
                driver.SwitchTo().Frame(advancedSearch.AdvancedSearchFrame);
                advancedSearch.ItemCode.SendKeys(prod);

                advancedSearch.SearchButton.Click();
                for (int i = 0; ; i++)
                {
                    if (i >= 60) Assert.Fail("timeout");
                    try
                    {
                        if (advancedSearch.SelectAll.Enabled) break;
                    }
                    catch (Exception) { }
                    Thread.Sleep(1000);
                }
                advancedSearch.SelectAll.Click();
                Thread.Sleep(500);
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame(newDelivery.NewDeliveryFrame);
                navigation.ConfirmPopup.Click();
                driver.SwitchTo().Frame(advancedSearch.AdvancedSearchFrame);
                Thread.Sleep(500);
                shared.WaitForElementNotAppear(driver, driver.FindElement(By.ClassName("blockUI")));
                advancedSearch.OKButton.Click();
                
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame(newDelivery.NewDeliveryFrame);
                Thread.Sleep(500);
            }

            newDelivery.SubmitDelivery.Click();

            driver.SwitchTo().DefaultContent();

            for (int i = 0; ; i++)
            {
                if (i >= 60) Assert.Fail("timeout");
                try
                {
                    if (delivery.DeliveryFrame.Displayed) break;
                }
                catch (Exception) { }
            }

            Logout();
        }

        [Test]
        [TestCase("Way Stock Adjustment","wayproducts",Description ="Create and submit a way stock adjustment")]
        [TestCase("Freeze Stock Adjustment", "freezeproducts", Description = "Create and submit a freeze stock adjustment")]
        [TestCase("Chill Stock Adjustment", "chillproducts", Description = "Create and submit a chill stock adjustment")]
        public void TheAdvancedSearchStockAdjustmentTest(string comment, string products)
        {
            navigation.Replenishment.Click();
            navigation.StockAdjustment.Click();
            Thread.Sleep(2000);

            StockAdjustmentPageModel stockAdjust = new StockAdjustmentPageModel(driver);
            for (int i = 0; ; i++)
            {
                if (i >= 60) Assert.Fail("timeout");
                try
                {
                    if (stockAdjust.StockAdjustFrame.Displayed) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }

            driver.SwitchTo().Frame(stockAdjust.StockAdjustFrame);
            stockAdjust.NewStockAdjust.Click();
            driver.SwitchTo().DefaultContent();
            NewStockAdjustmentPageModel newSA = new NewStockAdjustmentPageModel(driver);
            for (int i = 0; ; i++)
            {
                if (i >= 60) Assert.Fail("timeout");
                try
                {
                    if (newSA.NewStockAdjustFrame.Displayed) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Frame(newSA.NewStockAdjustFrame);
            new SelectElement(newSA.NewStockAdjustReason).SelectByText("Damaged");
            newSA.NewStockAdjustComments.SendKeys("Automated " + comment);

            Thread.Sleep(2000);
            string[] productList = config[products].Split(',');
            AdvancedSearchPageModel advancedSearch = new AdvancedSearchPageModel(driver);
            Random rand = new Random();
            foreach (string prod in productList)
            {
                newSA.NewStockAdjustAdvancedSearch.Click();
                for (int i = 0; ; i++)
                {
                    if (i >= 60) Assert.Fail("timeout");
                    try
                    {
                        if (advancedSearch.AdvancedSearchFrame.Displayed) break;
                    }
                    catch (Exception) { }
                    Thread.Sleep(1000);
                }
                driver.SwitchTo().Frame(advancedSearch.AdvancedSearchFrame);
                advancedSearch.ItemCode.SendKeys(prod);

                advancedSearch.SearchButton.Click();
                for (int i = 0; ; i++)
                {
                    if (i >= 60) Assert.Fail("timeout");
                    try
                    {
                        if (advancedSearch.SelectAll.Enabled) break;
                    }
                    catch (Exception) { }
                    Thread.Sleep(1000);
                }

                new Actions(driver).DoubleClick(newSA.AdvancedSearchAdjustQuantityActivate).Build().Perform();
                newSA.AdvancedSearchAdjustQuantity.SendKeys(rand.Next(1, 11).ToString());
                newSA.AdvancedSearchAdjustQuantity.SendKeys(Keys.Enter);
                Thread.Sleep(1000);
                //shared.WaitForElementNotAppear(driver, driver.FindElement(By.ClassName("blockUI")));
                advancedSearch.OKButton.Click();
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame(newSA.NewStockAdjustFrame);
                Thread.Sleep(2000);
            }

            newSA.SaveStockAdjust.Click();
            driver.SwitchTo().DefaultContent();

            for (int i = 0; ; i++)
            {
                if (i >= 60) Assert.Fail("timeout");
                try
                {
                    if (stockAdjust.StockAdjustFrame.Displayed) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }
            Logout();
        }

        [Test]
        [TestCase("Way Stock Adjustment", "wayproducts", Description = "Create and submit a way stock adjustment")]
        [TestCase("Freeze Stock Adjustment", "freezeproducts", Description = "Create and submit a freeze stock adjustment")]
        [TestCase("Chill Stock Adjustment", "chillproducts", Description = "Create and submit a chill stock adjustment")]
        public void TheQuickAddStockAdjustmentTest(string comment, string products)
        {
            navigation.Replenishment.Click();
            navigation.StockAdjustment.Click();
            Thread.Sleep(2000);

            StockAdjustmentPageModel stockAdjust = new StockAdjustmentPageModel(driver);
            for (int i = 0; ; i++)
            {
                if (i >= 60) Assert.Fail("timeout");
                try
                {
                    if (stockAdjust.StockAdjustFrame.Displayed) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }

            driver.SwitchTo().Frame(stockAdjust.StockAdjustFrame);
            stockAdjust.NewStockAdjust.Click();
            driver.SwitchTo().DefaultContent();
            NewStockAdjustmentPageModel newSA = new NewStockAdjustmentPageModel(driver);
            for (int i = 0; ; i++)
            {
                if (i >= 60) Assert.Fail("timeout");
                try
                {
                    if (newSA.NewStockAdjustFrame.Displayed) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Frame(newSA.NewStockAdjustFrame);
            new SelectElement(newSA.NewStockAdjustReason).SelectByText("Damaged");
            newSA.NewStockAdjustComments.SendKeys("Automated " + comment);

            Thread.Sleep(2000);
            string[] productList = config[products].Split(',');
            Random rand = new Random();
            foreach (string prod in productList)
            {
                newSA.NewStockAdjustQuickAddTxt.SendKeys(prod);
                newSA.NewStockAdjustQuickAddButton.Click();
                for (int i = 0; ; i++)
                {
                    if (i >= 60) Assert.Fail("timeout");
                    try
                    {
                        if (newSA.NewStockAdjustQuickAddQty.Displayed) break;
                    }
                    catch (Exception) { }
                    Thread.Sleep(1000);
                }
                newSA.NewStockAdjustQuickAddQty.SendKeys(rand.Next(1, 11).ToString());
                newSA.NewStockAdjustQuickAddQty.SendKeys(Keys.Enter);
                //driver.SwitchTo().DefaultContent();

                //driver.SwitchTo().Frame(newSA.NewStockAdjustFrame);
                Thread.Sleep(3000);
            }
            newSA.SaveStockAdjust.Click();
            driver.SwitchTo().DefaultContent();
            for (int i = 0; ; i++)
            {
                if (i >= 60) Assert.Fail("timeout");
                try
                {
                    if (stockAdjust.StockAdjustFrame.Displayed) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }

            Logout();
        }

        [Test]
        public void TheAddEditDeleteItemGroupsTest()
        {
            navigation.Groups.Click();
            navigation.ItemGroups.Click();
            Thread.Sleep(2000);

            ItemGroupsPageModel itemGroups = new ItemGroupsPageModel(driver);

            for (int i=0; ; i++)
            {
                if (i >= 60) Assert.Fail("timeout");
                try
                {
                    if (itemGroups.ItemGroupFrame.Displayed) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Frame(itemGroups.ItemGroupFrame);
            itemGroups.AddItemGroup.Click();

            itemGroups.ItemGroupName.SendKeys("Auto Item Group");

            itemGroups.ItemGroupParent.Click();

            for (int i = 0; ; i++)
            {
                if (i >= 60) Assert.Fail("timeout");
                try
                {
                    if (itemGroups.ParentFrame.Displayed) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }
            driver.SwitchTo().Frame(itemGroups.ParentFrame);

            Thread.Sleep(1500);

            itemGroups.ItemGroupParentGrocery.Click();
            itemGroups.ItemGroupParentGrocery.Click();

            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame("tab-30");

            Thread.Sleep(1000);

            driver.FindElement(By.Name("Yes")).Click();

            Thread.Sleep(1000);

            new SelectElement(itemGroups.ItemGroupVAT).SelectByText("Standard");

            new SelectElement(itemGroups.ItemGroupUOM).SelectByText("Kilogram (kg)");

            itemGroups.SaveItemGroup.Click();

            Thread.Sleep(2000);

            itemGroups.SearchItemGroupText.SendKeys("Auto Item Group");

            itemGroups.SearchItemGroupButton.Click();

            Thread.Sleep(1000);

            itemGroups.EditItemGroup.Click();

            Thread.Sleep(1000);

            itemGroups.ItemGroupName.Clear();
            itemGroups.ItemGroupName.SendKeys("Edited Auto Item Group");

            itemGroups.SaveItemGroup.Click();

            Thread.Sleep(2000);

            itemGroups.ResetSearchItemGroupButton.Click();

            Thread.Sleep(1000);

            itemGroups.SearchItemGroupText.SendKeys("Auto Item Group");

            Thread.Sleep(1000);

            itemGroups.SearchItemGroupButton.Click();

            Thread.Sleep(2000);

            itemGroups.DeleteItemGroup.Click();

            navigation.ConfirmPopup.Click();

            driver.SwitchTo().DefaultContent();

            Logout();
        }

        [Test]
        public void TheTillSendTest()
        {
            navigation.Utilities.Click();
            navigation.TillSend.Click();
            Thread.Sleep(2000);

            TillSendPageModel tillSend = new TillSendPageModel(driver);

            for (int i = 0; ; i++) {
                if (i >= 60) Assert.Fail("timeout");
                try {
                    if (tillSend.TillSendFrame.Displayed) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }

            Thread.Sleep(1000);

            driver.SwitchTo().Frame(tillSend.TillSendFrame);

            tillSend.TillSendSelectAll.Click();

            tillSend.TillSendButton.Click();

            for (int i = 0; ; i++)
            {
                if (i >= 60) Assert.Fail("timeout");
                try
                {
                    if (tillSend.TillSendMessageLine1.Text.Contains("Send data started")) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }

            for (int i = 0; ; i++)
            {
                if (i >= 120) Assert.Fail("timeout");
                try
                {
                    if (tillSend.TillSendMessageLine2.Text.Contains("Data has been sent successfully")) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }

            for (int i = 0; ; i++)
            {
                if (i >= 120) Assert.Fail("timeout");
                try
                {
                    if (tillSend.TillSendMessageLine3.Text.Contains("Send files started")) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }

            for (int i = 0; ; i++)
            {
                if (i >= 120) Assert.Fail("timeout");
                try
                {
                    if (tillSend.TillSendMessageLine4.Text.Contains("Files has been sent successfully")) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }

            driver.SwitchTo().DefaultContent();
            Logout();
        }

        [Test]
        public void TheTillReceiveTest()
        {
            navigation.Utilities.Click();
            navigation.TillReceive.Click();
            Thread.Sleep(2000);

            TillReceivePageModel tillRec = new TillReceivePageModel(driver);

            for (int i = 0; ; i++)
            {
                if (i >= 60) Assert.Fail("timeout");
                try
                {
                    if (tillRec.TillRecFrame.Displayed) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }

            Thread.Sleep(1000);

            driver.SwitchTo().Frame(tillRec.TillRecFrame);

            tillRec.TillRecSelectAll.Click();

            tillRec.TillRecButton.Click();

            for (int i = 0; ; i++)
            {
                if (i >= 60) Assert.Fail("timeout");
                try
                {
                    if (tillRec.TillRecMessageLine1.Text.Contains("Receive data started")) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }

            for (int i = 0; ; i++)
            {
                if (i >= 120) Assert.Fail("timeout");
                try
                {
                    if (tillRec.TillRecMessageLine2.Text.Contains("Data has been received successfully")) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }

            for (int i = 0; ; i++)
            {
                if (i >= 120) Assert.Fail("timeout");
                try
                {
                    if (tillRec.TillRecMessageLine3.Text.Contains("Receive files started")) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }

            for (int i = 0; ; i++)
            {
                if (i >= 120) Assert.Fail("timeout");
                try
                {
                    if (tillRec.TillRecMessageLine4.Text.Contains("Files has been received successfully")) break;
                }
                catch (Exception) { }
                Thread.Sleep(1000);
            }

            driver.SwitchTo().DefaultContent();
            Logout();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }

        /// <summary>
        /// Checks for the correct menus to be displayed for a particular role
        /// </summary>
        /// <param name="role">String describing the role assigned to the user to check</param>
        private void MenuCheck(string role)
        {
            if (role.Equals("Engineer") || role.Equals("Admin"))
            {
                // Verify Admin Menu
                try
                {
                    Assert.IsTrue(navigation.SysAdmin.Displayed);
                }
                catch (AssertionException e)
                {
                    verificationErrors.Append(e.Message);
                }
            }         
            
            // Verify Setup Menu
            try
            {
                Assert.IsTrue(navigation.Setup.Displayed);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Verify Configuration Menu
            try
            {
                Assert.IsTrue(navigation.Configuration.Displayed);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Verify Groups Menu
            try
            {
                Assert.IsTrue(navigation.Groups.Displayed);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Verify Maintenance Menu
            try
            {
                Assert.IsTrue(navigation.Maintenance.Displayed);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Verify Replenishment Menu
            try
            {
                Assert.IsTrue(navigation.Replenishment.Displayed);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Verify Updates Menu
            try
            {
                Assert.IsTrue(navigation.Updates.Displayed);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Verify Reports Menu
            try
            {
                Assert.IsTrue(navigation.Reports.Displayed);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Verify Utilities Menu
            try
            {
                Assert.IsTrue(navigation.Utilities.Displayed);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }
    }
}
