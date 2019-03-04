using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VMCoinProcessor;

namespace VMCoinProcessor
{
    /// <summary>
    /// 
    /// </summary>
    public class VMTestRunner
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="processor"></param>
        /// 
        public virtual void RunSimulator(IVMProcess processor)
        {
            Dictionary<string, int> dictAvailableCoins = processor.LoadCoins();
            Menu simulatorMenu = processor.LoadMenuItems();
            decimal itemPrice = 0;
            bool selectQuit = false;
            while (!selectQuit)
            {
                Dictionary<string, int> denominationChoices = processor.DisplayMenuItems(simulatorMenu, out itemPrice, out selectQuit);
                decimal amountDue = 0;
                decimal amountEntered = 0;
                Dictionary<string, int> dictResults = processor.CalculateChange(dictAvailableCoins, denominationChoices, itemPrice, out amountDue, out amountEntered);
                processor.DisplayChange(dictResults, itemPrice, amountDue, amountEntered, selectQuit);
            }
        }
    }
}
