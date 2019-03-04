using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VMCoinProcessor
{
    /// <summary>
    /// Class assumes that the unit of coin is cents
    /// </summary>
    public static class CoinEnums
    {
        /// <summary>
        /// 
        /// </summary>
        public enum Denomination
        {
            /// <summary>
            /// 
            /// </summary>
            [Description("1c")]
            OneCents = 0,
            /// <summary>
            /// 
            /// </summary>
            [Description("5c")]
            FiveCents = 1,
            /// <summary>
            /// 
            /// </summary>
            [Description("10c")]
            TenCents = 2,
            /// <summary>
            /// 
            /// </summary>
            [Description("25c")]
            TwentyFiveCents = 3
        }
    }
}
