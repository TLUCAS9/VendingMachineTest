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
    public class MenuItem
    {
        /// <summary>
        /// 
        /// </summary>
        public const decimal MAXIMUM_PRICE = 2.00m;

        private decimal price;
        private int itemId;
        private string name;

        /// <summary>
        /// 
        /// </summary>
        public MenuItem()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public int ItemId
        {
            get
            {
                return itemId;
            }

            set
            {
                if (value > 0)
                {
                    itemId = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    name = "Menu Item " + itemId;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                if (value > 0 && value <= MAXIMUM_PRICE)
                {
                    price = value;
                }
            }
        }
    }
}
