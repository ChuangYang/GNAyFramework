using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

#region .NET Framework namespace.
using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Alias.
#endregion

namespace GNAy.CSharp6.Portable.UnitTest.Sample
{
    /// <summary>
    /// All the test methods in this class must be stand along.
    /// </summary>
    [TestClass]
    public class UnitTestSample
    {
        static UnitTestSample()
        { }

        /// <summary>
        /// Initialize the static instance.
        /// </summary>
        public static void Initialize()
        { }

        /// <summary>
        /// 
        /// </summary>
        public UnitTestSample()
        { }

        //[TestMethod]
        //public void TestMethodSample()
        //{
        //    //arrange

        //    //act

        //    //assert
        //}


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void NumberCalculating1()
        {
            //arrange
            int mArgument1 = int.MinValue;
            int mArgument2 = int.MaxValue;
            int mActual1 = 0;
            int mActual2 = 0;

            //act
            mActual1 = mArgument1--;
            mActual2 = mArgument2++;

            //assert
            Assert.IsTrue(mArgument1 == int.MaxValue);
            Assert.IsTrue(mArgument2 == int.MinValue);
            Assert.IsTrue(mActual1 == int.MinValue);
            Assert.IsTrue(mActual2 == int.MaxValue);
        }


        /// <summary>
        /// 
        /// </summary>
        internal partial class NumberCalculatingTest1
        {
            /// <summary>
            /// 
            /// </summary>
            protected static int Value1 = int.MinValue;

            /// <summary>
            /// 
            /// </summary>
            protected static int Value2 = int.MaxValue;
        }

        internal partial class NumberCalculatingTest1
        {
            public static int GetValue1()
            {
                return Value1--;
            }

            public static int GetValue2()
            {
                return Value2++;
            }
        }

        private sealed class _numberCalculatingTest2 : NumberCalculatingTest1
        {
            public static new int GetValue1()
            {
                return Value1;
            }

            public static new int GetValue2()
            {
                return Value2;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void NumberCalculating2()
        {
            //arrange
            int mArgument1 = NumberCalculatingTest1.GetValue1();
            int mArgument2 = NumberCalculatingTest1.GetValue2();
            int mArgument3 = _numberCalculatingTest2.GetValue1();
            int mArgument4 = _numberCalculatingTest2.GetValue2();
            bool mActual1 = false;
            bool mActual2 = false;
            bool mActual3 = false;
            bool mActual4 = false;

            //act
            mActual1 = (mArgument1 == int.MinValue);
            mActual2 = (mArgument2 == int.MaxValue);
            mActual3 = (mArgument3 == int.MaxValue);
            mActual4 = (mArgument4 == int.MinValue);

            //assert
            Assert.IsTrue(mActual1);
            Assert.IsTrue(mActual2);
            Assert.IsTrue(mActual3);
            Assert.IsTrue(mActual4);
        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ValueEquals()
        {
            //arrange
            const int mArgument1 = (1000 * 10000);
            Stopwatch mArgument2 = new Stopwatch();
            int mArgument3 = 0;
            long mActual1 = 0;
            long mActual2 = 0;
            bool mActual3 = true;
            bool mActual4 = true;

            //act
            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mActual3 = (mArgument3 == mArgument1);
            }
            mArgument2.Stop();
            mActual1 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[{mActual1}][{mArgument1 / mActual1}]");

            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mActual4 = mArgument3.Equals(mArgument1);
            }
            mArgument2.Stop();
            mActual2 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[{mActual2}][{mArgument1 / mActual2}]");

            //assert
            Assert.IsFalse(mActual3);
            Assert.IsFalse(mActual4);
        }
        //0
        //[8886]
        //[1125]
        //0
        //[9398]
        //[1064]


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void StringEquals()
        {
            //arrange
            const int mArgument1 = (1000 * 10000);
            Stopwatch mArgument2 = new Stopwatch();
            string mArgument3 = string.Empty;
            string mArgument4 = string.Empty;
            long mActual1 = 0;
            long mActual2 = 0;
            bool mActual3 = false;
            bool mActual4 = false;

            //act
            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mActual3 = (mArgument3 == mArgument4);
            }
            mArgument2.Stop();
            mActual1 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[{mActual1}][{mArgument1 / mActual1}]");

            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mActual4 = mArgument3.Equals(mArgument4);
            }
            mArgument2.Stop();
            mActual2 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[{mActual2}][{mArgument1 / mActual2}]");

            //assert
            Assert.IsTrue(mActual3);
            Assert.IsTrue(mActual4);
        }
        //0
        //[45113]
        //[221]
        //0
        //[53843]
        //[185]


        /// <summary>
        /// 
        /// </summary>
        public class ConstructorOrderTest1
        {
            /// <summary>
            /// 
            /// </summary>
            public const string One = "1";

            /// <summary>
            /// 
            /// </summary>
            public const string Two = "2";

            /// <summary>
            /// 
            /// </summary>
            public static readonly string Value1 = One;

            /// <summary>
            /// 
            /// </summary>
            public readonly string Value2 = (Value1 + Two); //132

            static ConstructorOrderTest1()
            {
                Value1 = (Value1 + "3"); //13
            }

            /// <summary>
            /// 
            /// </summary>
            public ConstructorOrderTest1()
            {
                Value2 = (Value1 + "4"); //134
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class ConstructorOrderTest2 : ConstructorOrderTest1
        {
            /// <summary>
            /// 
            /// </summary>
            public static string Value3 = $"{Value1}5"; //135

            /// <summary>
            /// 
            /// </summary>
            public string Value4 = $"{Value3}6"; //1313576

            static ConstructorOrderTest2()
            {
                Value3 = $"{Value1}{Value3}7"; //131357
            }

            /// <summary>
            /// 
            /// </summary>
            public ConstructorOrderTest2()
            {
                Value4 = $"{Value2}{Value3}8"; //1341313578
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ConstructorOrder()
        {
            //arrange
            ConstructorOrderTest2 mArgument1 = new ConstructorOrderTest2();
            bool mActual1 = false;

            //act
            mActual1 = (mArgument1.Value4 == "1341313578");

            //assert
            Assert.IsTrue(mActual1);
        }


        /// <summary>
        /// 
        /// </summary>
        private class _objectEqualsNullExceptionTest
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="ioLeft"></param>
            /// <param name="ioRight"></param>
            /// <returns></returns>
            public static bool operator ==(_objectEqualsNullExceptionTest ioLeft, _objectEqualsNullExceptionTest ioRight)
            {
                if (object.ReferenceEquals(ioRight, null))
                {
                    throw new NotSupportedException("Object equals null exception test.");
                }

                return object.ReferenceEquals(ioLeft, ioRight);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="ioLeft"></param>
            /// <param name="ioRight"></param>
            /// <returns></returns>
            public static bool operator !=(_objectEqualsNullExceptionTest ioLeft, _objectEqualsNullExceptionTest ioRight)
            {
                return !(ioLeft == ioRight);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="ioTarget"></param>
            /// <returns></returns>
            public override bool Equals(object ioTarget)
            {
                return (this == (ioTarget as _objectEqualsNullExceptionTest));
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        private bool isNull<T>(T ioTarget)
        {
            return !(ioTarget is T);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ObjectEqualsNullException()
        {
            //arrange
            _objectEqualsNullExceptionTest mArgument1 = null;
            StringBuilder mArgument2 = new StringBuilder();
            bool mActual1 = false;
            bool mActual2 = false;
            bool mActual3 = true;
            bool mActual4 = true;
            bool mActual5 = true;
            bool mActual6 = false;

            //act
            try
            {
                mArgument2.Append("A1");
                mActual1 = (mArgument1 == null);
                mArgument2.Append("A2");
            }
            catch (Exception mException)
            {
                mArgument2.Append("A3");
                mArgument2.Append(mException.Message);
            }
            finally
            {
                mArgument2.Append("A4");
            }
            mArgument2.Append(Environment.NewLine);

            try
            {
                mArgument2.Append("B1");
                mActual2 = mArgument1.Equals(null);
                mArgument2.Append("B2");
            }
            catch (Exception mException)
            {
                mArgument2.Append("B3");
                mArgument2.Append(mException.Message);
            }
            finally
            {
                mArgument2.Append("B4");
            }
            mArgument2.Append(Environment.NewLine);

            mArgument1 = new _objectEqualsNullExceptionTest();

            try
            {
                mArgument2.Append("C1");
                mActual3 = (mArgument1 == null);
                mArgument2.Append("C2");
            }
            catch (Exception mException)
            {
                mArgument2.Append("C3");
                mArgument2.Append(mException.Message);
            }
            finally
            {
                mArgument2.Append("C4");
            }
            mArgument2.Append(Environment.NewLine);

            try
            {
                mArgument2.Append("D1");
                mActual4 = mArgument1.Equals(null);
                mArgument2.Append("D2");
            }
            catch (Exception mException)
            {
                mArgument2.Append("D3");
                mArgument2.Append(mException.Message);
            }
            finally
            {
                mArgument2.Append("D4");
            }
            mArgument2.Append(Environment.NewLine);

            try
            {
                mArgument2.Append("E1");
                mActual5 = isNull(mArgument1);
                mArgument2.Append("E2");
            }
            catch (Exception mException)
            {
                mArgument2.Append("E3");
                mArgument2.Append(mException.Message);
            }
            finally
            {
                mArgument2.Append("E4");
            }

            mActual6 = (mArgument2.ToString() ==
@"A1A3Object equals null exception test.A4
B1B3並未將物件參考設定為物件的執行個體。B4
C1C3Object equals null exception test.C4
D1D3Object equals null exception test.D4
E1E2E4");

            //assert
            Assert.IsFalse(mActual1);
            Assert.IsFalse(mActual2);
            Assert.IsTrue(mActual3);
            Assert.IsTrue(mActual4);
            Assert.IsFalse(mActual5);
            Assert.IsTrue(mActual6);
        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ObjectEqualsNullPerformance()
        {
            //arrange
            const int mArgument1 = (1000 * 10000);
            Stopwatch mArgument2 = new Stopwatch();
            object mArgument3 = null;
            bool mActual1 = false;
            bool mActual2 = false;
            bool mActual3 = false;
            long mActual4 = 0;
            long mActual5 = 0;
            long mActual6 = 0;

            //act
            //operator ==
            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mActual1 = (mArgument3 == null);
            }
            mArgument2.Stop();
            mActual4 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[operator ==][{mActual1}][{mActual4}][{mArgument1 / mActual4}]");

            //object.ReferenceEquals
            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mActual2 = object.ReferenceEquals(mArgument3, null);
            }
            mArgument2.Stop();
            mActual5 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[object.ReferenceEquals][{mActual2}][{mActual5}][{mArgument1 / mActual5}]");

            //isNull
            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mActual3 = isNull(mArgument3);
            }
            mArgument2.Stop();
            mActual6 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[isNull][{mActual3}][{mActual6}][{mArgument1 / mActual6}]");

            //assert
            Assert.IsTrue(mActual1);
            Assert.IsTrue(mActual2);
            Assert.IsTrue(mActual3);
        }
        //0
        //[operator ==]
        //[True]
        //[13535]
        //[738]
        //0
        //[object.ReferenceEquals][True]
        //[13009]
        //[768]
        //0
        //[isNull]
        //[True]
        //[13217]
        //[756]


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ObjectToString()
        {
            //arrange
            string mArgument1 = "1";
            int mArgument2 = 2;
            bool mArgument3 = true;
            object mActual1 = null;
            string mActual2 = null;
            string mActual3 = string.Empty;
            bool mActual4 = false;
            bool mActual5 = false;
            bool mActual6 = true;

            //act
            mActual1 = (mArgument1 + mArgument2 + mArgument3);
            mActual2 = (mArgument1 + mArgument2.ToString() + mArgument3.ToString());
            mActual3 = $"{mArgument1}{mArgument2}{mArgument3}";
            mActual4 = mActual1.Equals(mActual2);
            mActual5 = ((string)mActual1 == mActual2);
            mActual6 = (mActual1 == (object)mActual2);

            Console.WriteLine($"[{mActual1}][{mActual2}][{mActual3}][{mActual4}][{mActual5}][{mActual6}]");

            //assert
            Assert.IsTrue(mActual2 == "12True");
            Assert.IsTrue(mActual3 == "12True");
            Assert.IsTrue(mActual4);
            Assert.IsTrue(mActual5);
            Assert.IsFalse(mActual6);
        }
        //[12True]
        //[12True]
        //[12True]
        //[True]
        //[True]
        //[False]


        private struct _classAndStructureTest
        {
            public char Value1;
            public char[] Value2;

            public override string ToString()
            {
                return $"{Value1}{Value2[0]}";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ClassAndStructure()
        {
            //arrange
            _classAndStructureTest mArgument1 = new _classAndStructureTest() { Value1 = 'a', Value2 = new char[1] { 'a' } };
            _classAndStructureTest mArgument2 = mArgument1;

            //act
            mArgument2.Value1 = 'b';
            mArgument2.Value2[0] = 'b';

            //assert
            Assert.IsTrue(mArgument1.ToString() == "ab");
            Assert.IsTrue(mArgument2.ToString() == "bb");
        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DictionaryIgnoreCase()
        {
            //arrange
            Dictionary<string, byte> mArgument1 = new Dictionary<string, byte>(StringComparer.OrdinalIgnoreCase);

            //act
            mArgument1["a"] = byte.MinValue;
            mArgument1["A"] = (byte)(mArgument1["a"] - 1);

            //assert
            Assert.IsTrue(mArgument1["a"] == byte.MaxValue);
            Assert.IsTrue(mArgument1["A"] == byte.MaxValue);
        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DateTimeDefault()
        {
            //arrange
            DateTime mArgument1 = DateTime.MinValue;
            DateTime mArgument2 = default(DateTime);
            bool mActual1 = false;

            //act
            mActual1 = (mArgument1 == mArgument2);

            Console.WriteLine(mArgument1);

            //assert
            Assert.IsTrue(mActual1);
        }
        //01/01/0001 00:00:00


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DateTimeKind1()
        {
            //arrange
            DateTime mArgument1 = DateTime.Now;
            DateTime mArgument2 = new DateTime(mArgument1.Ticks, DateTimeKind.Local);
            DateTime mArgument3 = new DateTime(mArgument1.Ticks, DateTimeKind.Unspecified);
            DateTime mArgument4 = new DateTime(mArgument1.Ticks, DateTimeKind.Utc);
            bool mActual1 = false;
            bool mActual2 = false;
            bool mActual3 = true;

            //act
            mActual1 = ((mArgument1 == mArgument2) && (mArgument1 == mArgument3) && (mArgument1 == mArgument4));
            mActual2 = (mArgument1.Kind == DateTimeKind.Local);

            Console.WriteLine($"[{mArgument1}][{mArgument2}][{mArgument3}][{mArgument4}]");

            mArgument1 = mArgument1.ToUniversalTime();
            mArgument2 = mArgument2.ToUniversalTime();
            mArgument3 = mArgument3.ToUniversalTime();
            mArgument4 = mArgument4.ToLocalTime();

            mActual3 = ((mArgument1 == mArgument2) && (mArgument1 == mArgument3) && (mArgument1 == mArgument4));

            Console.WriteLine($"[{mArgument1}][{mArgument2}][{mArgument3}][{mArgument4}]");

            //assert
            Assert.IsTrue(mActual1);
            Assert.IsTrue(mActual2);
            Assert.IsFalse(mActual3);
        }
        //[2016/6/6 下午 04:04:19]
        //[2016/6/6 下午 04:04:19]
        //[2016/6/6 下午 04:04:19]
        //[2016/6/6 下午 04:04:19]
        //[2016/6/6 上午 08:04:19]
        //[2016/6/6 上午 08:04:19]
        //[2016/6/6 上午 08:04:19]
        //[2016/6/7 上午 12:04:19]


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DateTimeTicks()
        {
            //arrange
            long mArgument1 = 0;
            int mArgument2 = 0;
            long mArgument3 = 0;
            bool mActual1 = false;
            bool mActual2 = false;

            //act
            mArgument1 = DateTime.UtcNow.Ticks;
            while (mArgument1 == DateTime.UtcNow.Ticks)
            {
                mArgument2++;
            }
            mArgument3 = DateTime.UtcNow.Ticks;

            mActual1 = (mArgument2 > 0);
            mActual2 = ((mArgument3 - mArgument1) > 0);

            Console.WriteLine(mArgument2);
            Console.WriteLine($"[{mArgument1}][{mArgument3}][{mArgument3 - mArgument1}]");

            //assert
            Assert.IsTrue(mActual1);
            Assert.IsTrue(mActual2);
        }
        //60034
        //[636007970598508972]
        //[636007970598518986]
        //[10014]


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [ContractVerification(false)]
        public void WhileCount()
        {
            //arrange
            DateTime mArgument1 = default(DateTime);
            int mArgument2 = 0;
            int mArgument3 = 0;
            int mArgument4 = 0;
            bool mActual1 = false;
            bool mActual2 = false;
            bool mActual3 = false;
            bool mActual4 = false;

            //act
            mArgument1 = DateTime.UtcNow;
            while ((DateTime.UtcNow - mArgument1).Milliseconds <= 1)
            {
                mArgument2++;
            }

            mArgument1 = DateTime.UtcNow.AddMilliseconds(1);
            while (DateTime.UtcNow <= mArgument1)
            {
                mArgument3++;
            }

            SpinWait.SpinUntil(() =>
            {
                mArgument4++;
                return false;
            },
            1);

            mActual1 = (mArgument2 > 0);
            mActual2 = (mArgument3 > 0);
            mActual3 = (mArgument4 > 0);
            mActual4 = ((mArgument3 > mArgument2) && (mArgument2 > mArgument4));

            Console.WriteLine($"[{mArgument2}][{mArgument4}][{mArgument2 - mArgument4}][{mArgument2 / mArgument4}]");
            Console.WriteLine($"[{mArgument3}][{mArgument4}][{mArgument3 - mArgument4}][{mArgument3 / mArgument4}]");
            Console.WriteLine("((mArgument3 > mArgument2) && (mArgument2 > mArgument4))");

            //assert
            Assert.IsTrue(mActual1);
            Assert.IsTrue(mActual2);
            Assert.IsTrue(mActual3);
            Assert.IsTrue(mActual4);
        }
        //[83161]
        //[70]
        //[83091]
        //[1188]
        //[121599]
        //[70]
        //[121529]
        //[1737]
        //((mArgument3 > mArgument2) && (mArgument2 > mArgument4))


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ThreadAbort()
        {
            //arrange
            StringBuilder mArgument1 = new StringBuilder("1");

            //act
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
                mArgument1.Append("6");
                Thread.ResetAbort();
                mArgument1.Append("7");
            }
            catch (Exception)
            {
                mArgument1.Append("8");
            }
            finally
            {
                mArgument1.Append("9");
            }

            //assert
            Assert.IsTrue(mArgument1.ToString() == "1245679");
        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void StringSequentialFormat()
        {
            const string mPattern = @"\{{1,}[S|s](\}|:[^\}]*\})";
            const string mTarget = "{s";
            const string mNewValue = "{{{0}";

            //arrange
            string mArgument1 = string.Empty;
            int mArgument2 = 0;
            bool mActual1 = false;
            bool mActual2 = false;
            bool mActual3 = false;
            bool mActual4 = false;
            bool mActual5 = false;
            bool mActual6 = false;

            //act
            mArgument2 = 0;
            mArgument1 = Regex.Replace("SSS{S}SSS", mPattern, ioMatch =>
            {
                Console.WriteLine($"[{ioMatch.Value}][{ioMatch.Index}][{ioMatch.Length}]");

                return ioMatch.Value.Replace(
                    ioMatch.Value.Substring(ioMatch.Value.IndexOf(mTarget, StringComparison.OrdinalIgnoreCase), mTarget.Length),
                    string.Format(mNewValue, mArgument2++)
                    );
            });
            mActual1 = ((mArgument1 == "SSS{0}SSS") && (mArgument2 == 1));
            Console.WriteLine($"[{mArgument1}][{mArgument2}]");

            Console.WriteLine(string.Empty);
            mArgument2 = 0;
            mArgument1 = Regex.Replace("SSS{S", mPattern, ioMatch =>
            {
                Console.WriteLine($"[{ioMatch.Value}][{ioMatch.Index}][{ioMatch.Length}]");

                return ioMatch.Value.Replace(
                    ioMatch.Value.Substring(ioMatch.Value.IndexOf(mTarget, StringComparison.OrdinalIgnoreCase), mTarget.Length),
                    string.Format(mNewValue, mArgument2++)
                    );
            });
            mActual2 = ((mArgument1 == "SSS{S") && (mArgument2 == 0));
            Console.WriteLine($"[{mArgument1}][{mArgument2}]");

            Console.WriteLine(string.Empty);
            mArgument2 = 0;
            mArgument1 = Regex.Replace("SS}S{S", mPattern, ioMatch =>
            {
                Console.WriteLine($"[{ioMatch.Value}][{ioMatch.Index}][{ioMatch.Length}]");

                return ioMatch.Value.Replace(
                    ioMatch.Value.Substring(ioMatch.Value.IndexOf(mTarget, StringComparison.OrdinalIgnoreCase), mTarget.Length),
                    string.Format(mNewValue, mArgument2++)
                    );
            });
            mActual3 = ((mArgument1 == "SS}S{S") && (mArgument2 == 0));
            Console.WriteLine($"[{mArgument1}][{mArgument2}]");

            Console.WriteLine(string.Empty);
            mArgument2 = 0;
            mArgument1 = Regex.Replace("SSS{{S}}SSS", mPattern, ioMatch =>
            {
                Console.WriteLine($"[{ioMatch.Value}][{ioMatch.Index}][{ioMatch.Length}]");

                return ioMatch.Value.Replace(
                    ioMatch.Value.Substring(ioMatch.Value.IndexOf(mTarget, StringComparison.OrdinalIgnoreCase), mTarget.Length),
                    string.Format(mNewValue, mArgument2++)
                    );
            });
            mActual4 = ((mArgument1 == "SSS{{0}}SSS") && (mArgument2 == 1));
            Console.WriteLine($"[{mArgument1}][{mArgument2}]");

            Console.WriteLine(string.Empty);
            mArgument2 = 0;
            mArgument1 = Regex.Replace("SSS{S:####}SSS", mPattern, ioMatch =>
            {
                Console.WriteLine($"[{ioMatch.Value}][{ioMatch.Index}][{ioMatch.Length}]");

                return ioMatch.Value.Replace(
                    ioMatch.Value.Substring(ioMatch.Value.IndexOf(mTarget, StringComparison.OrdinalIgnoreCase), mTarget.Length),
                    string.Format(mNewValue, mArgument2++)
                    );
            });
            mActual5 = ((mArgument1 == "SSS{0:####}SSS") && (mArgument2 == 1));
            Console.WriteLine($"[{mArgument1}][{mArgument2}]");

            Console.WriteLine(string.Empty);
            mArgument2 = 0;
            mArgument1 = Regex.Replace("SS{{s}}SS{Sa}SS{S:####}SS", mPattern, ioMatch =>
            {
                Console.WriteLine($"[{ioMatch.Value}][{ioMatch.Index}][{ioMatch.Length}]");

                return ioMatch.Value.Replace(
                    ioMatch.Value.Substring(ioMatch.Value.IndexOf(mTarget, StringComparison.OrdinalIgnoreCase), mTarget.Length),
                    string.Format(mNewValue, mArgument2++)
                    );
            });
            mActual6 = ((mArgument1 == "SS{{0}}SS{Sa}SS{1:####}SS") && (mArgument2 == 2));
            Console.WriteLine($"[{mArgument1}][{mArgument2}]");

            //assert
            Assert.IsTrue(mActual1);
            Assert.IsTrue(mActual2);
            Assert.IsTrue(mActual3);
            Assert.IsTrue(mActual4);
            Assert.IsTrue(mActual5);
            Assert.IsTrue(mActual6);
        }
        //[{S}][3]
        //    [3]
        //    [SSS{0}
        //SSS][1]

        //[SSS{S]
        //[0]

        //[SS}S{S][0]

        //[{{S}][3]
        //[4]
        //[SSS{{0}}SSS][1]

        //[{S:####}][3][8]
        //[SSS{0:####}SSS][1]

        //[{{s}][2]
        //[4]
        //[{S:####}][15][8]
        //[SS{{0}}SS{Sa}SS{1:####}SS][2]


        /// <summary>
        /// 
        /// </summary>
        /// <param name="iInput"></param>
        /// <returns></returns>
        public int NumberIncrease1(int iInput)
        {
            return ++iInput;
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DelegatePerformance_Instance()
        {
            //arrange
            const int mArgument1 = (100 * 10000);
            Stopwatch mArgument2 = new Stopwatch();
            Func<int, int> mArgument3 = NumberIncrease1;
            MethodInfo mArgument4 = GetType().GetMethod("NumberIncrease1", (BindingFlags.Instance | BindingFlags.Public));

            ParameterExpression mArgument5 = Expression.Parameter(mArgument4.GetParameters()[0].ParameterType, mArgument4.GetParameters()[0].Name);
            MethodCallExpression mArgument6 = Expression.Call(Expression.Constant(this), mArgument4, mArgument5);

            ParameterExpression[] mArgument7 = { Expression.Parameter(typeof(int)), Expression.Parameter(typeof(int)) };
            Func<int, int, int> mArgument8 = Expression.Lambda<Func<int, int, int>>(Expression.Add(mArgument7[0], mArgument7[1]), mArgument7).Compile();

            //act
            //Normal function call.
            int mArgument19 = 0;
            long mActual1 = 0;
            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mArgument19 = NumberIncrease1(mArgument19);
            }
            mArgument2.Stop();
            mActual1 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[Normal function call][{mArgument19}][{mActual1}][{mArgument1 / mActual1}]");

            //Normal delegate.
            int mArgument10 = 0;
            long mActual2 = 0;
            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mArgument10 = mArgument3(mArgument10);
            }
            mArgument2.Stop();
            mActual2 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[Normal delegate][{mArgument10}][{mActual2}][{mArgument1 / mActual2}]");

            //Delegate.CreateDelegate
            int mArgument11 = 0;
            long mActual3 = 0;
            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument3 = (Func<int, int>)Delegate.CreateDelegate(typeof(Func<int, int>), this, mArgument4.Name, true);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mArgument11 = mArgument3(mArgument11);
            }
            mArgument2.Stop();
            mActual3 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[Delegate.CreateDelegate][{mArgument11}][{mActual3}][{mArgument1 / mActual3}]");

            //Expression.Call
            int mArgument12 = 0;
            long mActual4 = 0;
            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument3 = Expression.Lambda<Func<int, int>>(mArgument6, mArgument5).Compile();
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mArgument12 = mArgument3(mArgument12);
            }
            mArgument2.Stop();
            mActual4 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[Expression.Call][{mArgument12}][{mActual4}][{mArgument1 / mActual4}]");

            //Expression.Add
            int mArgument13 = 0;
            long mActual5 = 0;
            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mArgument13 = mArgument8(mArgument13, 1);
            }
            mArgument2.Stop();
            mActual5 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[Expression.Add][{mArgument13}][{mActual5}][{mArgument1 / mActual5}]");

            //Expression.Increment
            int mArgument16 = 0;
            long mActual6 = 0;
            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument3 = Expression.Lambda<Func<int, int>>(Expression.Increment(mArgument7[0]), mArgument7[0]).Compile();
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mArgument16 = mArgument3(mArgument16);
            }
            mArgument2.Stop();
            mActual6 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[Expression.Increment][{mArgument16}][{mActual6}][{mArgument1 / mActual6}]");

            bool mActual7 = ((mArgument19 == mArgument10) && (mArgument10 == mArgument11) && (mArgument11 == mArgument12) && (mArgument12 == mArgument13) && (mArgument13 == mArgument16) && (mArgument16 == mArgument1));
            bool mActual8 = ((mActual3 < mActual2) && (mActual2 < mActual4) && (mActual5 < mActual4) && (mActual6 < mActual4) && (mActual1 < mActual4));

            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            Console.WriteLine("((mActual3 < mActual2) && (mActual2 < mActual4) && (mActual5 < mActual4) && (mActual6 < mActual4) && (mActual1 < mActual4))");

            //assert
            Assert.IsTrue(mActual7);
            Assert.IsTrue(mActual8);
        }
        //0
        //[Normal function call]
        //        [1000000]
        //        [5159]
        //        [193]
        //0
        //[Normal delegate][1000000]
        //        [5992]
        //        [166]
        //0
        //[Delegate.CreateDelegate]
        //        [1000000]
        //        [4499]
        //        [222]
        //0
        //[Expression.Call]
        //        [1000000]
        //        [32592]
        //        [30]
        //0
        //[Expression.Add]
        //        [1000000]
        //        [8781]
        //        [113]
        //0
        //[Expression.Increment]
        //        [1000000]
        //        [5411]
        //        [184]
        //0
        //((mActual3<mActual2) && (mActual2<mActual4) && (mActual5<mActual4) && (mActual6<mActual4) && (mActual1<mActual4))


        /// <summary>
        /// 
        /// </summary>
        /// <param name="iInput"></param>
        /// <returns></returns>
        public static int NumberIncrease2(int iInput)
        {
            return ++iInput;
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DelegatePerformance_Static()
        {
            //arrange
            const int mArgument1 = (100 * 10000);
            Stopwatch mArgument2 = new Stopwatch();
            Func<int, int> mArgument3 = NumberIncrease2;
            MethodInfo mArgument4 = GetType().GetMethod("NumberIncrease2", (BindingFlags.Static | BindingFlags.Public));

            ParameterExpression mArgument5 = Expression.Parameter(mArgument4.GetParameters()[0].ParameterType, mArgument4.GetParameters()[0].Name);
            MethodCallExpression mArgument6 = Expression.Call(null, mArgument4, mArgument5);

            //act
            //Normal function call.
            int mArgument7 = 0;
            long mActual1 = 0;
            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mArgument7 = NumberIncrease1(mArgument7);
            }
            mArgument2.Stop();
            mActual1 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[Normal function call][{mArgument7}][{mActual1}][{mArgument1 / mActual1}]");

            //Normal delegate.
            int mArgument8 = 0;
            long mActual2 = 0;
            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mArgument8 = mArgument3(mArgument8);
            }
            mArgument2.Stop();
            mActual2 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[Normal delegate: 1][{mArgument8}][{mActual2}][{mArgument1 / mActual2}]");

            //Delegate.CreateDelegate
            int mArgument9 = 0;
            long mActual3 = 0;
            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument3 = (Func<int, int>)Delegate.CreateDelegate(typeof(Func<int, int>), mArgument4, true);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mArgument9 = mArgument3(mArgument9);
            }
            mArgument2.Stop();
            mActual3 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[Delegate.CreateDelegate: 1][{mArgument9}][{mActual3}][{mArgument1 / mActual3}]");

            //Normal delegate.
            int mArgument10 = 0;
            long mActual4 = 0;
            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument3 = NumberIncrease2;
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mArgument10 = mArgument3(mArgument10);
            }
            mArgument2.Stop();
            mActual4 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[Normal delegate: 2][{mArgument10}][{mActual4}][{mArgument1 / mActual4}]");

            //Delegate.CreateDelegate
            int mArgument11 = 0;
            long mActual5 = 0;
            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument3 = (Func<int, int>)Delegate.CreateDelegate(typeof(Func<int, int>), mArgument4, true);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mArgument11 = mArgument3(mArgument11);
            }
            mArgument2.Stop();
            mActual5 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[Delegate.CreateDelegate: 2][{mArgument11}][{mActual5}][{mArgument1 / mActual5}]");

            //Expression.Call
            int mArgument12 = 0;
            long mActual6 = 0;
            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            mArgument3 = Expression.Lambda<Func<int, int>>(mArgument6, mArgument5).Compile();
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mArgument12 = mArgument3(mArgument12);
            }
            mArgument2.Stop();
            mActual6 = mArgument2.ElapsedTicks;
            Console.WriteLine($"[Expression.Call][{mArgument12}][{mActual6}][{mArgument1 / mActual6}]");

            bool mActual7 = ((mArgument7 == mArgument8) && (mArgument8 == mArgument9) && (mArgument9 == mArgument10) && (mArgument10 == mArgument11) && (mArgument11 == mArgument12) && (mArgument12 == mArgument1));
            bool mActual8 = ((mActual1 < mActual3) && (mActual3 < mActual2) && (mActual2 < mActual6) && (mActual1 < mActual5) && (mActual5 < mActual4) && (mActual4 < mActual6));

            mArgument2.Reset();
            Console.WriteLine(mArgument2.ElapsedTicks);
            Console.WriteLine("((mActual1 < mActual3) && (mActual3 < mActual2) && (mActual2 < mActual6) && (mActual1 < mActual5) && (mActual5 < mActual4) && (mActual4 < mActual6))");

            //assert
            Assert.IsTrue(mActual7);
            Assert.IsTrue(mActual8);
        }
        //0
        //[Normal function call]
        //        [1000000]
        //        [3516]
        //        [284]
        //0
        //[Normal delegate: 1][1000000]
        //        [8131]
        //        [122]
        //0
        //[Delegate.CreateDelegate: 1]
        //        [1000000]
        //        [7210]
        //        [138]
        //0
        //[Normal delegate: 2][1000000]
        //        [10136]
        //        [98]
        //0
        //[Delegate.CreateDelegate: 2]
        //        [1000000]
        //        [9028]
        //        [110]
        //0
        //[Expression.Call]
        //        [1000000]
        //        [36759]
        //        [27]
        //0
        //((mActual1<mActual3) && (mActual3<mActual2) && (mActual2<mActual6) && (mActual1<mActual5) && (mActual5<mActual4) && (mActual4<mActual6))
    }
}
