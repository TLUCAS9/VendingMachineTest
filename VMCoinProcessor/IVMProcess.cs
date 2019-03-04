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
    public interface IVMProcess
    {
        /// <summary>
        /// 
        /// </summary>
        Dictionary<string, int> LoadCoins();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Menu LoadMenuItems();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dictAvailableCoins"></param>
        /// <param name="denomicationChoices"></param>
        /// <param name="itemPrice"></param>
        /// <param name="amountDue"></param>
        /// <param name="amountEntered"></param>
        /// <returns></returns>
        Dictionary<string, int> CalculateChange(Dictionary<string, int> dictAvailableCoins, Dictionary<string, int> denomicationChoices, decimal itemPrice, out decimal amountDue, out decimal amountEntered);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="denominationResults"></param>
        /// <param name="itemPrice"></param>
        /// <param name="amountDue"></param>
        /// <param name="amountEntered"></param>
        /// <param name="selectQuit"></param>
        void DisplayChange(Dictionary<string, int> denominationResults, decimal itemPrice, decimal amountDue, decimal amountEntered, bool selectQuit);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuItems"></param>
        /// <param name="itemPrice"></param>
        /// <param name="selectQuit"></param>
        /// <returns></returns>
        Dictionary<string, int> DisplayMenuItems(Menu menuItems, out decimal itemPrice, out bool selectQuit);
    }
}
