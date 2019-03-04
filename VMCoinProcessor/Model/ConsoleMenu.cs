using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMCoinProcessor
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsoleMenu : Menu
    {
        /// <summary>
        /// Menu items hard-coded to simulate vending machine 
        /// </summary>
        public override void LoadMenuItems()
        {
            MenuItemList.Add(new MenuItem { ItemId = 1, Name = "Coke", Price = 0.75m });
            MenuItemList.Add(new MenuItem { ItemId = 2, Name = "Sprite", Price = 0.75m });
            MenuItemList.Add(new MenuItem { ItemId = 3, Name = "Dr Pepper", Price = 0.75m });
            MenuItemList.Add(new MenuItem { ItemId = 4, Name = "Snickers Candy Bar", Price = 1.25m });
            MenuItemList.Add(new MenuItem { ItemId = 5, Name = "Hersheys Candy Bar", Price = 1.25m });
            MenuItemList.Add(new MenuItem { ItemId = 6, Name = "Doritos Chips", Price = 1.5m });
            MenuItemList.Add(new MenuItem { ItemId = 7, Name = "Ruffles Potato Chips", Price = 1.5m });
            MenuItemList.Add(new MenuItem { ItemId = 8, Name = "Chocolate Cookie", Price = 2.0m });
        }
    }
}
