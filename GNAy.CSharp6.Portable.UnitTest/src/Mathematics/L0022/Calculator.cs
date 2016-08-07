using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

#region .NET Framework namespace.
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.UnitTest.Mathematics.L0022_Calculator
#else
namespace GNAy.CSharp6.Portable.UnitTest.Mathematics
#endif
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class Calculator
    {
#if Development
        private static CSharp6.Portable.Tests.Mathematics.L0021_Mathematics.Calculator _calculator;
#else
        private static CSharp6.Portable.Tests.Mathematics.Calculator _calculator;
#endif

        static Calculator()
        {
#if Development
            _calculator = new Tests.Mathematics.L0021_Mathematics.Calculator();
#else
            _calculator = new Tests.Mathematics.Calculator();
#endif
        }
        
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ParseInfix()
        {
            _calculator.ParseInfix();
        }
    }
}
