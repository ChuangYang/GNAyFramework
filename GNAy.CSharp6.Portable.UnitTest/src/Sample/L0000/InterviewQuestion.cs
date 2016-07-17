using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

#region .NET Framework namespace.
using System;
using System.Text;
using System.Threading;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp6.Common.UnitTest.Sample
{
    [TestClass]
    public class InterviewQuestion
    {
        public partial class TestCalss1
        {
            protected static byte Value1 = byte.MaxValue;
            protected static sbyte Value2 = sbyte.MinValue;
        }

        public partial class TestCalss1
        {
            internal static byte GetValue1() { return Value1++; }
            internal static sbyte GetValue2() { return Value2--; }
        }

        private sealed class _testCalss2 : TestCalss1
        {
            public static new byte GetValue1() { return Value1; }
            public static new sbyte GetValue2() { return Value2; }
        }

        [TestMethod]
        public void NumberCalculating2()
        {
            byte mArgument1 = TestCalss1.GetValue1();
            sbyte mArgument2 = TestCalss1.GetValue2();
            byte mArgument3 = _testCalss2.GetValue1();
            sbyte mArgument4 = _testCalss2.GetValue2();

            Console.WriteLine(mArgument1);
            Console.WriteLine(mArgument2);
            Console.WriteLine(mArgument3);
            Console.WriteLine(mArgument4);
        }

        //Q1: What are the values of mArgument1, mArgument2, mArgument3, and mArgument4?
        //Q2: Why there are two classes named "TestCalss1"?
        //Q3: Why can we call "TestCalss1.GetValue1()" without new the class "TestCalss1"?
        //Q4: What is the meaning of "sealed class"?
        //Q5: What is the meaning in line 36?
        //Q6: What are the differences in public, protected, private, and internal?

        public class TestCalss3
        {
            public static string Value1 = "1";
            public string Value2 = string.Format("{0}{1}", Value1, "2");

            static TestCalss3() { Value1 = string.Format("{0}{1}", Value1, "3"); }
            public TestCalss3() { Value2 = string.Format("{0}{1}", Value1, "4"); }
        }

        public class TestCalss4 : TestCalss3
        {
            public static string Value3 = string.Format("{0}{1}", Value1, "5");
            public string Value4 = string.Format("{0}{1}", Value3, "6");

            static TestCalss4() { Value3 = string.Format("{0}{1}{2}", Value1, Value3, "7"); }
            public TestCalss4() { Value4 = string.Format("{0},{1},{2}", base.Value2, Value3, "8"); }
        }

        [TestMethod]
        public void ObjectValue1()
        {
            TestCalss4 mArgument1 = new TestCalss4();

            Console.WriteLine(mArgument1.Value4);
        }

        //Q7: What will be printed in line 84?

        [TestMethod]
        public void ObjectValue2()
        {
            string mArgument1 = "1";
            int mArgument2 = 2;
            bool mArgument3 = false;
            object mActual1 = null;
            string mActual2 = null;
            string mActual3 = null;
            bool mActual4 = false;
            bool mActual5 = true;

            mActual1 = (mArgument1 + mArgument2 + mArgument3);
            mActual2 = (mArgument1 + mArgument2.ToString() + mArgument3.ToString());
            mActual3 = string.Format("{0}{1}{2}", mArgument1, mArgument2, mArgument3);
            mActual4 = mActual1.Equals(mActual2);
            mActual5 = (mActual1 == (object)mActual3);
        }

        //Q8: What are the values of mActual1, mActual2, mActual3, mActual4, and mActual5?
        //Q9: What are the differences in line 101, line 102, and line 103?
        //Q10: What are the differences between line 104 and line 105?

        private struct _testStructure1
        {
            public char Value1;
            public char[] Value2;

            public override string ToString() { return string.Format("{0},{1}", Value1, Value2[0]); }
        }

        [TestMethod]
        public void ObjectValue3()
        {
            _testStructure1 mArgument1 = new _testStructure1() { Value1 = 'a', Value2 = new char[1] { 'a' } };
            _testStructure1 mArgument2 = mArgument1;
            
            mArgument2.Value1 = 'b';
            mArgument2.Value2[0] = 'b';

            Console.WriteLine(mArgument1.ToString());
            Console.WriteLine(mArgument2.ToString());
        }

        //Q11: What will be printed in line 129 and line 130?
        //Q12: _testStructure1 is private, why can we new it?

        [TestMethod]
        public void ObjectValue4()
        {
            Dictionary<string, byte> mArgument1 = new Dictionary<string, byte>(StringComparer.OrdinalIgnoreCase);
            
            mArgument1["a"] = byte.MaxValue;
            mArgument1["A"] = (byte)(mArgument1["a"] + 1);

            Console.WriteLine(mArgument1["a"]);
            Console.WriteLine(mArgument1["A"]);
        }

        //Q13: What will be printed in line 144 and line 145?
        //Q14: What are the differences in Array, List, and Dictionary?

        [TestMethod]
        public void ThreadAbort()
        {
            StringBuilder mArgument1 = new StringBuilder("1");
            
            try
            {
                try
                {
                    mArgument1.Append("2");
                    Thread.CurrentThread.Abort();
                    mArgument1.Append("3");
                }
                catch (Exception)
                {
                    mArgument1.Append("4");
                }
                finally
                {
                    mArgument1.Append("5");
                }
            }
            catch (ThreadAbortException)
            {
                Thread.ResetAbort();

                mArgument1.Append("6");
            }
            catch (Exception)
            {
                mArgument1.Append("7");
            }
            finally
            {
                mArgument1.Append("8");
            }

            mArgument1.Append("9");

            Console.WriteLine(mArgument1);
        }

        //Q15: What will be printed in line 192?

        //Q16: What is the meaning in line 19 and line 40?
    }
}
