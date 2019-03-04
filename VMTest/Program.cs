using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMCoinProcessor;

namespace VirtualMachineTest
{
    class Program
    {
        /// <summary>
        /// This is a prototype appplication, so there is an assumption that currency types are not defined for this simulation. 
        /// In a production application, multiple currency types would be defined and supported. 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static int Main(string[] args)
        {
            try
            {
                FactoryCreatorConsole createConsole = new FactoryCreatorConsole();
                VMTestConsole vmTestConsole = (VMTestConsole)createConsole.FactoryMethod();
                VMTestRunner vmTestRunner = new VMTestRunner();
                vmTestRunner.RunSimulator(vmTestConsole);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred. Error message: " + ex.Message + "\nInnerException: " + ex.InnerException + "\nStackTrace: " + ex.StackTrace);
                return -1;
            }
    
            return 0;
        }
    }
}
