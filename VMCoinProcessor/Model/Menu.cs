using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMCoinProcessor
{
    /// <summary>
    /// Assumption that the abstract class will provide the menu item list structure for the simulation
    /// </summary>
    public abstract class Menu
    {
        /// <summary>
        /// 
        /// </summary>
        public List<MenuItem> MenuItemList { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Menu()
        {
            MenuItemList = new List<MenuItem>();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void LoadMenuItems()
        {
        }
     }
}
