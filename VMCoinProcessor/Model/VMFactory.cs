using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMCoinProcessor
{
    /// <summary>
    /// This is a prototype application, so the factory is only creating a console application.
    /// In a production application, there could be other factories created, such as for database output, 
    /// or output to an RestFul API, or file. 
    /// </summary>
    public abstract class VMCoinProcessorFactCreator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IVMProcess FactoryMethod();
    }

    /// <summary>
    /// 
    /// </summary>
    public class FactoryCreatorConsole : VMCoinProcessorFactCreator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IVMProcess FactoryMethod()
        {
            return new VMTestConsole();
        }
    }

    
}
