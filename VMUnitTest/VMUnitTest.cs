using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VMCoinProcessor;

namespace VMUnitTest
{
    [TestClass]
    public class VMUnitTest
    {
        [TestMethod]
        public void TestMenuPriceItem()
        {
            MenuItem testGoodPriceItem = new MenuItem { ItemId = 1, Name = "Snickers Candy Bar", Price = 1.5m };
            Assert.AreNotEqual(testGoodPriceItem.Price, 0);

            MenuItem testBadPriceItem = new MenuItem { ItemId = 1, Name = "Pretzel Snack", Price = 3.5m };
            Assert.AreEqual(testBadPriceItem.Price, 0);
        }
        
        [TestMethod]
        public void TestMenuItemId()
        {
            MenuItem testGoodIdItem = new MenuItem { ItemId = 1, Name = "Candy Bar", Price = 2.5m };
            Assert.AreNotEqual(testGoodIdItem.ItemId, 0);

            MenuItem testBadIdItem = new MenuItem { ItemId = -1, Name = "Hostess Twinkie", Price = 1.5m };
            Assert.AreEqual(testBadIdItem.ItemId, 0);
        }

        [TestMethod]
        public void TestMenuItemName()
        {
            MenuItem testGoodName = new MenuItem { ItemId = 1, Name = "Mounds Chocolate Bar", Price = 2.5m };
            Assert.AreNotEqual(testGoodName.Name, "Menu Item " + testGoodName.ItemId);

            MenuItem testBadName = new MenuItem { ItemId = 2, Name = "", Price = 0.5m };
            Assert.AreEqual(testBadName.Name, "Menu Item " + testBadName.ItemId);
        }

        [TestMethod]
        public void TestConsoleMenu()
        {
            FactoryCreatorConsole createConsole = new FactoryCreatorConsole();
            VMTestConsole vmTestConsole = (VMTestConsole)createConsole.FactoryMethod();
            Menu testConsoleMenu = vmTestConsole.LoadMenuItems();
            Assert.AreNotEqual(testConsoleMenu.MenuItemList.Count, 0);
        }

        [TestMethod]
        public void TestLoadCoints()
        {
            FactoryCreatorConsole createConsole = new FactoryCreatorConsole();
            VMTestConsole vmTestConsole = (VMTestConsole)createConsole.FactoryMethod();
            Dictionary<string, int> dictAvailableCoins = vmTestConsole.LoadCoins();
            Assert.AreNotEqual(dictAvailableCoins.Count, 0);
        }
    }
}
