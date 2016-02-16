using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumTests;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public Tests test;

        [TestInitialize]
        public void Startup()
        {
            test = new Tests();
            test.SetupTest();           
        }

        [TestCleanup]
        public void Cleanup()
        {
            test.TeardownTest(); 
        }

        [TestMethod]
        public void AddEditDeleteBasket()
        {
            test.TheAddEditDeleteBasketTest();
        }

        [TestMethod]
        public void AddEditDeleteDocument()
        {         
            test.TheAddEditDeleteDocumentTest();                                       
        }

        [TestMethod]
        public void AddEditDeleteFixEvent()
        {            
            test.TheAddEditDeleteFixEventTest();
        }

        [TestMethod]
        public void AddEditDeleteNonFixEvent()
        {
            test.TheAddEditDeleteNonFixEventTest();            
        }

        [TestMethod]
        public void AddEditDeleteMessageConditionProcedure()
        {
            test.TheAddEditDeleteMessageConditionProcedureTest();
        }        

        [TestMethod]
        public void ManualOrderingTestWay()
        {
            test.TheManualOrderingTest("NISAWAY-NISA Way", "wayproducts");
        }

        [TestMethod]
        public void ManualOrderingTestFreeze()
        {
            test.TheManualOrderingTest("NISAFRZ-NISA Freeze", "freezeproducts");
        }

        [TestMethod]
        public void ManualOrderingTestChill()
        {
            test.TheManualOrderingTest("NISACHL-NISA Chill", "chillproducts");
        }

        [TestMethod]
        public void StockTakeTestWay()
        {
            test.TheStockTakeSubmitTest("wayproducts");
        }

        [TestMethod]
        public void StockTakeTestFreeze()
        {
            test.TheStockTakeSubmitTest("freezeproducts");
        }

        [TestMethod]
        public void StockTakeTestChill()
        {
            test.TheStockTakeSubmitTest("chillproducts");
        }

        [TestMethod]
        public void DeliveryTestWay()
        {
            test.TheDeliverySubmitTest("NISAWAY-NISA Way", "wayproducts");
        }

        [TestMethod]
        public void DeliveryTestFreeze()
        {
            test.TheDeliverySubmitTest("NISAFRZ-NISA Freeze", "freezeproducts");
        }

        [TestMethod]
        public void DeliveryTestChill()
        {
            test.TheDeliverySubmitTest("NISACHL-NISA Chill", "chillproducts");
        }
                
        [TestMethod]
        public void AdvancedSearchOrderingWay() {
            test.TheManualOrderingAdvancedSearchTest("NISAWAY-NISA Way", "wayproducts");
        }

        [TestMethod]
        public void AdvancedSearchOrderingFreeze()
        {
            test.TheManualOrderingAdvancedSearchTest("NISAFRZ-NISA Freeze", "freezeproducts");
        }

        [TestMethod]
        public void AdvancedSearchOrderingChill()
        {
            test.TheManualOrderingAdvancedSearchTest("NISACHL-NISA Chill", "chillproducts");
        }

        [TestMethod]
        public void DeliveryAdvancedSearchTestWay()
        {
            test.TheDeliveryAdvancedSearchTest("NISAWAY-NISA Way", "wayproducts");
        }

        [TestMethod]
        public void DeliveryAdvancedSearchTestFreeze()
        {
            test.TheDeliveryAdvancedSearchTest("NISAFRZ-NISA Freeze", "freezeproducts");
        }

        [TestMethod]
        public void DeliveryAdvancedSearchTestChill()
        {
            test.TheDeliveryAdvancedSearchTest("NISACHL-NISA Chill", "chillproducts");
        }

        [TestMethod]
        public void StockAdjustQuickAddTestWay()
        {
            test.TheQuickAddStockAdjustmentTest("Way Stock Adjustment", "wayproducts");
        }

        [TestMethod]
        public void StockAdjustQuickAddTestFreeze()
        {
            test.TheQuickAddStockAdjustmentTest("Freeze Stock Adjustment", "freezeproducts");
        }

        [TestMethod]
        public void StockAdjustQuickAddTestChill()
        {
            test.TheQuickAddStockAdjustmentTest("Chill Stock Adjustment", "chillproducts");
        }

        [TestMethod]
        public void StockAdjustAdvancedSearchTestWay()
        {
            test.TheAdvancedSearchStockAdjustmentTest("Way Stock Adjustment", "wayproducts");
        }

        [TestMethod]
        public void StockAdjustAdvancedSearchTestFreeze()
        {
            test.TheAdvancedSearchStockAdjustmentTest("Freeze Stock Adjustment", "freezeproducts");
        }

        [TestMethod]
        public void StockAdjustAdvancedSearchTestChill()
        {
            test.TheAdvancedSearchStockAdjustmentTest("Chill Stock Adjustment", "chillproducts");
        }

        //[TestMethod]
        //public void AddEditDeleteReasons()
        //{
        //    test.TheAddEditDeleteReasonsTest();    
        //}
    }
}
