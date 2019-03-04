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
    public class VMTestConsole : IVMProcess
    {
        /// <summary>
        /// Class specific to console output
        /// </summary>
        public VMTestConsole()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, int> LoadCoins()
        {
            Dictionary<string, int> dictAvailableCoins = new Dictionary<string, int>();
            foreach (var item in Enum.GetValues(typeof(CoinEnums.Denomination)))
            {
                string denominationDesc = item.ToString();
                if (denominationDesc == "OneCents")
                {
                    dictAvailableCoins.Add(denominationDesc, 100);
                }
                else if (denominationDesc == "FiveCents")
                {
                    dictAvailableCoins.Add(denominationDesc, 50);
                }
                else if (denominationDesc == "TenCents")
                {
                    dictAvailableCoins.Add(denominationDesc, 50);
                }
                else if (denominationDesc == "TwentyFiveCents")
                {
                    dictAvailableCoins.Add(denominationDesc, 50);
                }
            }

            return dictAvailableCoins;
        }

        /// <summary>
        /// 
        /// </summary>
        public Menu LoadMenuItems()
        {
            Menu consoleMenu = new ConsoleMenu();
            consoleMenu.LoadMenuItems();
            return consoleMenu;
        }

        private decimal GetAmountDue(Dictionary<string, int> denominationResults)
        {
            decimal amountDue = 0;
            foreach (KeyValuePair<string, int> resultItem in denominationResults)
            {
                switch (resultItem.Key)
                {
                    case "OneCents":
                        {
                            amountDue += (decimal)resultItem.Value / 100m;
                            break;
                        }
                    case "FiveCents":
                        {
                            amountDue += (decimal)(resultItem.Value * 5) / 100m;
                            break;
                        }
                    case "TenCents":
                        {
                            amountDue += (decimal)(resultItem.Value * 10) / 100m;
                            break;
                        }
                    case "TwentyFiveCents":
                        {
                            amountDue += (decimal)(resultItem.Value * 25) / 100m;
                            break;
                        }
                    default:
                        {
                            throw new Exception("Exception occurred in method GetAmountDue. Denomination key not found. ");
                        }
                }
            }

            return amountDue;
        }

        private decimal GetMoneyEntered(Dictionary<string, int> denominationChoices)
        {
            decimal amountEntered = 0;
            foreach (KeyValuePair<string, int> choice in denominationChoices)
            {
                switch (choice.Key)
                {
                    case "OneCents":
                        {
                            amountEntered += (decimal)choice.Value / 100m;
                            break;
                        }
                    case "FiveCents":
                        {
                            amountEntered += (decimal)(choice.Value * 5) / 100m;
                            break;
                        }
                    case "TenCents":
                        {
                            amountEntered += (decimal)(choice.Value * 10) /  100m;
                            break;
                        }
                    case "TwentyFiveCents":
                        {
                            amountEntered += (decimal)(choice.Value * 25) / 100m;
                            break;
                        }
                    default: 
                        {
                            throw new Exception("Exception occurred in method GetMoneyEntered. Denomination key not found. "); 
                        }
                }
            }

            return amountEntered;
        }

        private bool GetCoinsAvailable(Dictionary<string, int> dictAvailableCoins, decimal amountDue)
        {
            //Check each denomination for available coins
            bool foundAvailableCoins = true;
            decimal totalAmount = 0;
            foreach (KeyValuePair<string, int> denominationItem in dictAvailableCoins)
            {
                switch (denominationItem.Key)
                {
                    case "OneCents":
                        {
                            totalAmount += (decimal)denominationItem.Value / 100m;
                            break;
                        }
                    case "FiveCents":
                        {
                            totalAmount += (decimal)(denominationItem.Value * 5) / 100m;
                            break;
                        }
                    case "TenCents":
                        {
                            totalAmount += (decimal)(denominationItem.Value * 10) / 100m;
                            break;
                        }
                    case "TwentyFiveCents":
                        {
                            totalAmount += (decimal)(denominationItem.Value * 25) / 100m;
                            break;
                        }
                    default:
                        {
                            throw new Exception("Exception occurred in method GetCoinsAvailable. Denomination key not found. ");
                        }
                }

            }
             
            if (totalAmount < amountDue)
            {
                foundAvailableCoins = false;
            }

            return foundAvailableCoins;
        }

        private void AddUserCoinsEntered(Dictionary<string, int> dictAvailableCoins, Dictionary<string, int> denominationChoices)
        {
            //Add the coin denominations entered by the user to the total available coins for each denomination
            foreach (KeyValuePair<string, int> denominationItem in denominationChoices)
            {
                dictAvailableCoins[denominationItem.Key] += denominationItem.Value;
             }

            }
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, int> CalculateChange(Dictionary<string, int> dictAvailableCoins, Dictionary<string, int> denominationChoices, decimal itemPrice, out decimal amountDue, out decimal amountEntered)
        {
            amountDue = 0;
            amountEntered = 0;
            Dictionary<string, int> dictResult = new Dictionary<string, int>();
            foreach (var item in Enum.GetValues(typeof(CoinEnums.Denomination)))
            {
                dictResult.Add(item.ToString(), 0);
            }

            decimal enteredMoney = GetMoneyEntered(denominationChoices);
            amountEntered = enteredMoney;
            decimal changeBack = 0;
            if (enteredMoney > 0)
            {
                changeBack = enteredMoney - itemPrice;
            }
           
            //If user didn't enter enough coins for the item price, then return change to user. 
            if (changeBack < 0)
            {
                changeBack = enteredMoney;
            }

            //Add the coin denominations entered by the user to the total available coins for each denomination
            AddUserCoinsEntered(dictAvailableCoins, denominationChoices);

            //If not enough coins are available to give user change, then return change to user 
            if (!(GetCoinsAvailable(dictAvailableCoins, changeBack)))
            {
                changeBack = enteredMoney;
            }

            while (changeBack > 0)
            {
                if (changeBack >= 0.25m && dictAvailableCoins["TwentyFiveCents"] > 1)
                {
                    dictResult["TwentyFiveCents"] += 1;
                    dictAvailableCoins["TwentyFiveCents"] += -1;
                    changeBack -= 0.25m;
                }
                else if (changeBack >= 0.10m && dictAvailableCoins["TenCents"] > 1)
                {
                    dictResult["TenCents"] += 1;
                    dictAvailableCoins["TenCents"] += -1;
                    changeBack -= 0.10m;
                }
                else if (changeBack >= 0.05m && dictAvailableCoins["FiveCents"] > 1)
                {
                    dictResult["FiveCents"] += 1;
                    dictAvailableCoins["FiveCents"] += -1;
                    changeBack -= 0.05m;
                }
                else if (changeBack >= 0.01m && dictAvailableCoins["OneCents"] > 1)
                {
                    dictResult["OneCents"] += 1;
                    dictAvailableCoins["OneCents"] += -1;
                    changeBack -= 0.01m;
                }
            }
     
            amountDue = GetAmountDue(dictResult);
            return dictResult;
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="denominationResults"></param>
        /// <param name="itemPrice"></param>
        /// <param name="amountDue"></param>
        /// <param name="amountEntered"></param>
        /// <param name="selectQuit"></param>
        public void DisplayChange(Dictionary<string, int> denominationResults, decimal itemPrice, decimal amountDue, decimal amountEntered, bool selectQuit)
        {
            if (!selectQuit)
            {
                Console.WriteLine("Thank you for using Virtual Machine Test Simulator. Item Price is: {0:C2}. Amount entered: {1:C2}. Your change due is: {2:C2}", itemPrice, amountEntered,  amountDue);

                if (amountEntered < itemPrice)
                {
                    Console.WriteLine("Please check entered amount. Selection price is greater than amount entered.");
                }
                else if (amountEntered == amountDue)
                {
                    Console.WriteLine("Virtual Machine Test Simulator is out of coin change for your selection.");
                }

                foreach (KeyValuePair<string, int> result in denominationResults)
                {
                    Console.WriteLine(result.Value + " X " + result.Key);
                }
            }
            else
            {
                Console.WriteLine("Simulation ended. Thank you for using Virtual Machine Test Simulator.");
            }
        }

        private bool ValidMenuItem(string menuChoice, ref int itemSelect, int itemCount)
        {
            bool isValid = true;

            if  (!(int.TryParse(menuChoice, out itemSelect) && 
                itemSelect <= itemCount &&
                itemSelect > 0))
            {
                isValid = false;
            }

            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, int> DisplayMenuItems(Menu consoleMenu, out decimal itemPrice, out bool selectQuit)
        {
            itemPrice = 0;

            //Keep track of whether or not the user has decided to quit the simulation. 
            selectQuit = false;

            Dictionary<string, int> dictDenominationAmounts = new Dictionary<string, int>();

            while (true)
            {
                Console.WriteLine("\n");
                Console.WriteLine("=== Welcome to Virtual Machine Test Simulator ===");
                foreach (MenuItem item in consoleMenu.MenuItemList)
                {
                    Console.WriteLine("=== Item {0}) {1} {2:C2} ===", item.ItemId, item.Name, item.Price);
                }
                Console.WriteLine("===== Press Q or q to Quit =====");

                Console.WriteLine("Enter requested menu item number:");
                
                string menuChoice = Console.ReadLine();
                if (menuChoice != "Q" && menuChoice != "q")
                {
                    int itemSelect = 0;
                    if (ValidMenuItem(menuChoice, ref itemSelect, consoleMenu.MenuItemList.Count))
                    {
                        itemPrice = consoleMenu.MenuItemList[itemSelect - 1].Price;
                        foreach (var item in Enum.GetValues(typeof(CoinEnums.Denomination)))
                        {
                            Console.WriteLine("Enter number of " + item + " or press Q or q to Quit:");
                            string amountChoice = Console.ReadLine();
                            if (amountChoice != "Q" && amountChoice != "q")
                            {
                                int denominationAmount = 0;
                                if (int.TryParse(amountChoice, out denominationAmount))
                                {
                                    if (!dictDenominationAmounts.ContainsKey(item.ToString()))
                                    {
                                        dictDenominationAmounts.Add(item.ToString(), denominationAmount);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid denomination choice selection. Please try again.");
                                }
                            }
                            else
                            {
                                selectQuit = true;
                                break;
                            }

                        }

                        break;

                    }
                    else
                    {
                        Console.WriteLine("Invalid item selection. Please try again.");
                    }
                }
                else
                {
                    selectQuit = true;
                    break;
                }
            }

            return dictDenominationAmounts;
        }
       
    }
}
