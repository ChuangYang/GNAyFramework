using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics.Contracts;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Alias.
#if Development
using PortableCalculator = GNAy.CSharp6.Portable.Mathematics.L0020_Calculator.Calculator;
#else
using PortableCalculator = GNAy.CSharp6.Portable.Mathematics.Calculator;
#endif
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Tests.Mathematics.L0021_Mathematics
#else
namespace GNAy.CSharp6.Portable.Tests.Mathematics
#endif
{
    /// <summary>
    /// <para>Don't use GNAy.CSharp6.Portable.Tests.Mathematics.</para>
    /// </summary>
    public class Calculator
    {
        static Calculator()
        {
#if Development
            CSharp6.Portable.Tests.Sample.L0000_UnitTest.UnitTest.Initialize();
#else
            CSharp6.Portable.Tests.Sample.UnitTest.Initialize();
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        public void ParseInfix()
        {
            //arrange
            bool mActual1 = true;
            bool mActual2 = true;
            bool mActual3 = true;
            bool mActual4 = true;
            bool mActual5 = true;
            bool mActual6 = true;
            bool mActual7 = true;

            //act
            //Group 1
            try
            {
                PortableCalculator.ParseInfix(null);
                mActual1 = false;
            }
            catch //(Exception mException)
            { }
            finally
            { }

            try
            {
                PortableCalculator.ParseInfix(string.Empty);
                mActual1 = false;
            }
            catch //(Exception mException)
            { }
            finally
            { }

            try
            {
                PortableCalculator.ParseInfix("   ");
                mActual1 = false;
            }
            catch //(Exception mException)
            { }
            finally
            { }

            try
            {
                PortableCalculator.ParseInfix("\t\r\n");
                mActual1 = false;
            }
            catch //(Exception mException)
            { }
            finally
            { }

            try
            {
                PortableCalculator.ParseInfix("A");
                mActual1 = false;
            }
            catch //(Exception mException)
            { }
            finally
            { }

            try
            {
                PortableCalculator.ParseInfix("+");
                mActual1 = false;
            }
            catch //(Exception mException)
            { }
            finally
            { }

            //Group 2
            if (PortableCalculator.ParseInfix("0") != 0)
            {
                mActual2 = false;
            }

            if (PortableCalculator.ParseInfix("0") != 0)
            {
                mActual2 = false;
            }

            if (PortableCalculator.ParseInfix("0.0") != 0)
            {
                mActual2 = false;
            }

            if (PortableCalculator.ParseInfix("\t0 .\r0") != 0)
            {
                mActual2 = false;
            }

            if (PortableCalculator.ParseInfix("1") != 1)
            {
                mActual2 = false;
            }

            if (PortableCalculator.ParseInfix("1.2") != 1.2m)
            {
                mActual2 = false;
            }

            if (PortableCalculator.ParseInfix("\t1 .\r2") != 1.2m)
            {
                mActual2 = false;
            }

            if (PortableCalculator.ParseInfix("-1") != -1)
            {
                mActual2 = false;
            }

            if (PortableCalculator.ParseInfix("-1.2") != -1.2m)
            {
                mActual2 = false;
            }

            if (PortableCalculator.ParseInfix("\n-\t1 .\r2") != -1.2m)
            {
                mActual2 = false;
            }

            //Group 3
            if (PortableCalculator.ParseInfix("0+1") != 1)
            {
                mActual3 = false;
            }

            if (PortableCalculator.ParseInfix("0+1+2") != 3)
            {
                mActual3 = false;
            }

            if (PortableCalculator.ParseInfix("0+(1+2)") != 3)
            {
                mActual3 = false;
            }

            if (PortableCalculator.ParseInfix("0-1") != -1)
            {
                mActual3 = false;
            }

            if (PortableCalculator.ParseInfix("0-1+2") != 1)
            {
                mActual3 = false;
            }

            if (PortableCalculator.ParseInfix("0-(1+2)") != -3)
            {
                mActual3 = false;
            }

            //Group 4
            if (PortableCalculator.ParseInfix("3+(1+2)+(3+(1+2))+(3+(1+2)+(3+(1+2)))") != 24)
            {
                mActual4 = false;
            }

            if (PortableCalculator.ParseInfix("3+ (1+\r2)+( 3+(1 +2))\t+(3\t\r\n+(1+ 2)+ (3 +(1+2) )\r\n)") != 24)
            {
                mActual4 = false;
            }

            if (PortableCalculator.ParseInfix("-3+(1-2)+(3+(1+2))-(3-(1+2)+(3-(1-2)))") != -2)
            {
                mActual4 = false;
            }

            if (PortableCalculator.ParseInfix("  - 3+(1-\t\r2)+(3 +(1+2))-(3- (1\r\n+2)+(3 -(1\r\t-2))) ") != -2)
            {
                mActual4 = false;
            }

            //Group 5
            if (PortableCalculator.ParseInfix("33+(1+20)+(93+(1+2))+(53+(12+2)+(37+(51+2)))") != 307)
            {
                mActual5 = false;
            }

            if (PortableCalculator.ParseInfix("33+ (1+2\r0)+(9 3+(1 +2))\t+(5\t\r\n3+(12+ 2)+ (3 7+(51+2) )\r\n)") != 307)
            {
                mActual5 = false;
            }

            if (PortableCalculator.ParseInfix("-33+(1-22)+(3+(19+28))-(34-(1+22)+(3-(11-2)))") != -9)
            {
                mActual5 = false;
            }

            if (PortableCalculator.ParseInfix("  -3 3+(1-2\t\r2)+(3 +(19+2\t8))-(34- (1+2\r\n2)+(3 -(1\r1\t-2))) ") != -9)
            {
                mActual5 = false;
            }

            //Group 6
            if (PortableCalculator.ParseInfix("33+(1+2.0)+(119.3+(1+2))+(5.3987+(1.2+2)+(37+(5112.333+2)))") != 5318.2317m)
            {
                mActual6 = false;
            }

            if (PortableCalculator.ParseInfix("33+ (1+2.\r0)+(119 .3+(1 +2))\t+(5.39\t\r\n87+(1.2+ 2)+ (3 7+(51\r\n12.3 33+2) )\r\n)") != 5318.2317m)
            {
                mActual6 = false;
            }

            if (PortableCalculator.ParseInfix("-33+(1-2.2)+(3+19.28)-(34-(1567+22)+(3-(1.91-2)))") != 1539.99m)
            {
                mActual6 = false;
            }

            if (PortableCalculator.ParseInfix("  -3 3+(1-2\t.\r2)+(3 +(19.2\t8))-(34- (1567+2\r\n2)+(3 -(1.\r91\t-2))) ") != 1539.99m)
            {
                mActual6 = false;
            }

            //Group 7
            if (PortableCalculator.ParseInfix("33+(1+2.0)/(119.3%(1*2))*(5.3987%(1.2+2)/(37+(5112.333+2)))") != 33.000984972836530481901107330m)
            {
                mActual7 = false;
            }

            if (PortableCalculator.ParseInfix("33+ (1+2.\r0)\r/\n(119 .3%(1 *2))\t*(5.39\t\r\n87% \t(1.2+ 2)/ (3 7+(51\r\n12.3 33+2) )\r\n)") != 33.000984972836530481901107330m)
            {
                mActual7 = false;
            }

            if (PortableCalculator.ParseInfix("-33/(1%2.2)+(3/19.28)-(34-(1567%22)/(3-(1.91*2)))") != -72.941959315858718753162635361m)
            {
                mActual7 = false;
            }

            if (PortableCalculator.ParseInfix(" ( -3 3)/(1%2\t.\r2)+(3 /((19.2\t8)))-(34- ((1567) %(2\r\n2))/(3 -(1.\r91\t*2))) ") != -72.941959315858718753162635361m)
            {
                mActual7 = false;
            }

            //assert
            Contract.Assert(mActual1);
            Contract.Assert(mActual2);
            Contract.Assert(mActual3);
            Contract.Assert(mActual4);
            Contract.Assert(mActual5);
            Contract.Assert(mActual6);
            Contract.Assert(mActual7);
        }
    }
}
