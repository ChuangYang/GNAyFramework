using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using System.Threading;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Tests.Sample.L0000_UnitTest
#else
namespace GNAy.CSharp6.Portable.Tests.Sample
#endif
{
    /// <summary>
    /// <para>All the test methods in this class must be stand along.</para>
    /// <para>Don't use CSharp6.Portable.Tests.Sample.</para>
    /// </summary>
    public class UnitTest
    {
        static UnitTest()
        {
            Contract.ContractFailed += contractFailedEvent;
        }

        /// <summary>
        /// Initialize the static instance.
        /// </summary>
        public static void Initialize()
        { }

        private static void contractFailedEvent(object sender, ContractFailedEventArgs e)
        {
            e.SetUnwind();
            throw new Exception(e.Message);
        }

        //public void TestMethodSample()
        //{
        //    //arrange

        //    //act

        //    //assert
        //}


        /// <summary>
        /// 
        /// </summary>
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
            Contract.Assert(mArgument1 == int.MaxValue);
            Contract.Assert(mArgument2 == int.MinValue);
            Contract.Assert(mActual1 == int.MinValue);
            Contract.Assert(mActual2 == int.MaxValue);
        }

        
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
            Contract.Assert(mActual1);
            Contract.Assert(mActual2);
            Contract.Assert(mActual3);
            Contract.Assert(mActual4);
        }


        /// <summary>
        /// 
        /// </summary>
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
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mActual3 = (mArgument3 == mArgument1);
            }
            mArgument2.Stop();
            mActual1 = mArgument2.ElapsedTicks;
            Debug.WriteLine($"[{mActual1}][{mArgument1 / mActual1}]");

            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mActual4 = mArgument3.Equals(mArgument1);
            }
            mArgument2.Stop();
            mActual2 = mArgument2.ElapsedTicks;
            Debug.WriteLine($"[{mActual2}][{mArgument1 / mActual2}]");

            //assert
            Contract.Assert(!mActual3);
            Contract.Assert(!mActual4);
        }


        /// <summary>
        /// 
        /// </summary>
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
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mActual3 = (mArgument3 == mArgument4);
            }
            mArgument2.Stop();
            mActual1 = mArgument2.ElapsedTicks;
            Debug.WriteLine($"[{mActual1}][{mArgument1 / mActual1}]");

            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mActual4 = mArgument3.Equals(mArgument4);
            }
            mArgument2.Stop();
            mActual2 = mArgument2.ElapsedTicks;
            Debug.WriteLine($"[{mActual2}][{mArgument1 / mActual2}]");

            //assert
            Contract.Assert(mActual3);
            Contract.Assert(mActual4);
        }


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
        public void ConstructorOrder()
        {
            //arrange
            ConstructorOrderTest2 mArgument1 = new ConstructorOrderTest2();
            bool mActual1 = false;

            //act
            mActual1 = (mArgument1.Value4 == "1341313578");

            //assert
            Contract.Assert(mActual1);
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
            Contract.Assert(!mActual1);
            Contract.Assert(!mActual2);
            Contract.Assert(mActual3);
            Contract.Assert(mActual4);
            Contract.Assert(!mActual5);
            Contract.Assert(mActual6);
        }


        /// <summary>
        /// 
        /// </summary>
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
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mActual1 = (mArgument3 == null);
            }
            mArgument2.Stop();
            mActual4 = mArgument2.ElapsedTicks;
            Debug.WriteLine($"[operator ==][{mActual1}][{mActual4}][{mArgument1 / mActual4}]");

            //object.ReferenceEquals
            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mActual2 = object.ReferenceEquals(mArgument3, null);
            }
            mArgument2.Stop();
            mActual5 = mArgument2.ElapsedTicks;
            Debug.WriteLine($"[object.ReferenceEquals][{mActual2}][{mActual5}][{mArgument1 / mActual5}]");

            //isNull
            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mActual3 = isNull(mArgument3);
            }
            mArgument2.Stop();
            mActual6 = mArgument2.ElapsedTicks;
            Debug.WriteLine($"[isNull][{mActual3}][{mActual6}][{mArgument1 / mActual6}]");

            //assert
            Contract.Assert(mActual1);
            Contract.Assert(mActual2);
            Contract.Assert(mActual3);
        }


        /// <summary>
        /// 
        /// </summary>
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

            Debug.WriteLine($"[{mActual1}][{mActual2}][{mActual3}][{mActual4}][{mActual5}][{mActual6}]");

            //assert
            Contract.Assert(mActual2 == "12True");
            Contract.Assert(mActual3 == "12True");
            Contract.Assert(mActual4);
            Contract.Assert(mActual5);
            Contract.Assert(!mActual6);
        }


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
        public void ClassAndStructure()
        {
            //arrange
            _classAndStructureTest mArgument1 = new _classAndStructureTest() { Value1 = 'a', Value2 = new char[1] { 'a' } };
            _classAndStructureTest mArgument2 = mArgument1;

            //act
            mArgument2.Value1 = 'b';
            mArgument2.Value2[0] = 'b';

            //assert
            Contract.Assert(mArgument1.ToString() == "ab");
            Contract.Assert(mArgument2.ToString() == "bb");
        }


        /// <summary>
        /// 
        /// </summary>
        public void DictionaryIgnoreCase()
        {
            //arrange
            Dictionary<string, byte> mArgument1 = new Dictionary<string, byte>(StringComparer.OrdinalIgnoreCase);

            //act
            mArgument1["a"] = byte.MinValue;
            mArgument1["A"] = (byte)(mArgument1["a"] - 1);

            //assert
            Contract.Assert(mArgument1["a"] == byte.MaxValue);
            Contract.Assert(mArgument1["A"] == byte.MaxValue);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DictionaryPerformance()
        {
            //arrange
            const int mArgument1 = (10 * 10000);
            Stopwatch mArgument2 = new Stopwatch();
            Dictionary<int, string> mArgument3 = new Dictionary<int, string>();
            Dictionary<int, string> mArgument4 = new Dictionary<int, string>(mArgument1);
            string[] mArgument5 = new string[mArgument1];
            string mArgument6 = string.Empty;
            long mActual1 = 0;
            long mActual2 = 0;
            long mActual3 = 0;
            long mActual4 = 0;
            long mActual5 = 0;
            long mActual6 = 0;
            bool mActual7 = false;
            bool mActual8 = false;
            bool mActual9 = false;

            //act
            //Dictionary without capacity.
            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mArgument3[i] = i.ToString();
            }
            mArgument2.Stop();
            mActual1 = mArgument2.ElapsedTicks;

            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mArgument6 = mArgument3[i];
            }
            mArgument2.Stop();
            mActual2 = mArgument2.ElapsedTicks;

            Debug.WriteLine($"[{mActual1}][{mActual2}]");

            //Dictionary with capacity.
            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mArgument4[i] = i.ToString();
            }
            mArgument2.Stop();
            mActual3 = mArgument2.ElapsedTicks;

            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mArgument6 = mArgument4[i];
            }
            mArgument2.Stop();
            mActual4 = mArgument2.ElapsedTicks;

            Debug.WriteLine($"[{mActual3}][{mActual4}]");

            //HashTable
            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mArgument5[i] = i.ToString();
            }
            mArgument2.Stop();
            mActual5 = mArgument2.ElapsedTicks;

            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = 0; i < mArgument1; ++i)
            {
                mArgument6 = mArgument5[i];
            }
            mArgument2.Stop();
            mActual6 = mArgument2.ElapsedTicks;

            Debug.WriteLine($"[{mActual5}][{mActual6}]");

            mActual7 = ((mActual2 < mActual1) && (mActual4 < mActual3) && (mActual6 < mActual5));
            mActual8 = ((mActual5 < mActual1) && (mActual3 < mActual1));
            mActual9 = ((mActual6 < mActual4) && (mActual6 < mActual2));
            
            Debug.WriteLine("((mActual2 < mActual1) && (mActual4 < mActual3) && (mActual6 < mActual5))");
            Debug.WriteLine("((mActual5 < mActual1) && (mActual3 < mActual1))");
            Debug.WriteLine("((mActual6 < mActual4) && (mActual6 < mActual2))");

            //assert
            Contract.Assert(mActual7);
            Contract.Assert(mActual8);
            Contract.Assert(mActual9);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DateTimeDefault()
        {
            //arrange
            DateTime mArgument1 = DateTime.MinValue;
            DateTime mArgument2 = default(DateTime);
            bool mActual1 = false;

            //act
            mActual1 = (mArgument1 == mArgument2);

            Debug.WriteLine(mArgument1);

            //assert
            Contract.Assert(mActual1);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DateTimeKindTest()
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

            Debug.WriteLine($"[{mArgument1}][{mArgument2}][{mArgument3}][{mArgument4}]");

            mArgument1 = mArgument1.ToUniversalTime();
            mArgument2 = mArgument2.ToUniversalTime();
            mArgument3 = mArgument3.ToUniversalTime();
            mArgument4 = mArgument4.ToLocalTime();

            mActual3 = ((mArgument1 == mArgument2) && (mArgument1 == mArgument3) && (mArgument1 == mArgument4));

            Debug.WriteLine($"[{mArgument1}][{mArgument2}][{mArgument3}][{mArgument4}]");

            //assert
            Contract.Assert(mActual1);
            Contract.Assert(mActual2);
            Contract.Assert(!mActual3);
        }


        /// <summary>
        /// 
        /// </summary>
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

            Debug.WriteLine(mArgument2);
            Debug.WriteLine($"[{mArgument1}][{mArgument3}][{mArgument3 - mArgument1}]");

            //assert
            Contract.Assert(mActual1);
            Contract.Assert(mActual2);
        }


        /// <summary>
        /// 
        /// </summary>
        public void WhileCount()
        {
            //arrange
            DateTime mArgument1 = default(DateTime);
            int mArgument2 = 0;
            int mArgument3 = 0;
            int mArgument4 = 0;
            bool mActual1 = false;

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

            mActual1 = ((mArgument3 > mArgument2) && (mArgument2 > mArgument4) && (mArgument4 > 0));

            Debug.WriteLine($"[{mArgument2}][{mArgument4}][{mArgument2 - mArgument4}][{mArgument2 / mArgument4}]");
            Debug.WriteLine($"[{mArgument3}][{mArgument4}][{mArgument3 - mArgument4}][{mArgument3 / mArgument4}]");
            Debug.WriteLine("((mArgument3 > mArgument2) && (mArgument2 > mArgument4) && (mArgument4 > 0))");

            //assert
            Contract.Assert(mActual1);
        }


        /// <summary>
        /// 
        /// </summary>
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
                Debug.WriteLine($"[{ioMatch.Value}][{ioMatch.Index}][{ioMatch.Length}]");

                return ioMatch.Value.Replace(
                    ioMatch.Value.Substring(ioMatch.Value.IndexOf(mTarget, StringComparison.OrdinalIgnoreCase), mTarget.Length),
                    string.Format(mNewValue, mArgument2++)
                    );
            });
            mActual1 = ((mArgument1 == "SSS{0}SSS") && (mArgument2 == 1));
            Debug.WriteLine($"[{mArgument1}][{mArgument2}]");

            Debug.WriteLine(string.Empty);
            mArgument2 = 0;
            mArgument1 = Regex.Replace("SSS{S", mPattern, ioMatch =>
            {
                Debug.WriteLine($"[{ioMatch.Value}][{ioMatch.Index}][{ioMatch.Length}]");

                return ioMatch.Value.Replace(
                    ioMatch.Value.Substring(ioMatch.Value.IndexOf(mTarget, StringComparison.OrdinalIgnoreCase), mTarget.Length),
                    string.Format(mNewValue, mArgument2++)
                    );
            });
            mActual2 = ((mArgument1 == "SSS{S") && (mArgument2 == 0));
            Debug.WriteLine($"[{mArgument1}][{mArgument2}]");

            Debug.WriteLine(string.Empty);
            mArgument2 = 0;
            mArgument1 = Regex.Replace("SS}S{S", mPattern, ioMatch =>
            {
                Debug.WriteLine($"[{ioMatch.Value}][{ioMatch.Index}][{ioMatch.Length}]");

                return ioMatch.Value.Replace(
                    ioMatch.Value.Substring(ioMatch.Value.IndexOf(mTarget, StringComparison.OrdinalIgnoreCase), mTarget.Length),
                    string.Format(mNewValue, mArgument2++)
                    );
            });
            mActual3 = ((mArgument1 == "SS}S{S") && (mArgument2 == 0));
            Debug.WriteLine($"[{mArgument1}][{mArgument2}]");

            Debug.WriteLine(string.Empty);
            mArgument2 = 0;
            mArgument1 = Regex.Replace("SSS{{S}}SSS", mPattern, ioMatch =>
            {
                Debug.WriteLine($"[{ioMatch.Value}][{ioMatch.Index}][{ioMatch.Length}]");

                return ioMatch.Value.Replace(
                    ioMatch.Value.Substring(ioMatch.Value.IndexOf(mTarget, StringComparison.OrdinalIgnoreCase), mTarget.Length),
                    string.Format(mNewValue, mArgument2++)
                    );
            });
            mActual4 = ((mArgument1 == "SSS{{0}}SSS") && (mArgument2 == 1));
            Debug.WriteLine($"[{mArgument1}][{mArgument2}]");

            Debug.WriteLine(string.Empty);
            mArgument2 = 0;
            mArgument1 = Regex.Replace("SSS{S:####}SSS", mPattern, ioMatch =>
            {
                Debug.WriteLine($"[{ioMatch.Value}][{ioMatch.Index}][{ioMatch.Length}]");

                return ioMatch.Value.Replace(
                    ioMatch.Value.Substring(ioMatch.Value.IndexOf(mTarget, StringComparison.OrdinalIgnoreCase), mTarget.Length),
                    string.Format(mNewValue, mArgument2++)
                    );
            });
            mActual5 = ((mArgument1 == "SSS{0:####}SSS") && (mArgument2 == 1));
            Debug.WriteLine($"[{mArgument1}][{mArgument2}]");

            Debug.WriteLine(string.Empty);
            mArgument2 = 0;
            mArgument1 = Regex.Replace("SS{{s}}SS{Sa}SS{S:####}SS", mPattern, ioMatch =>
            {
                Debug.WriteLine($"[{ioMatch.Value}][{ioMatch.Index}][{ioMatch.Length}]");

                return ioMatch.Value.Replace(
                    ioMatch.Value.Substring(ioMatch.Value.IndexOf(mTarget, StringComparison.OrdinalIgnoreCase), mTarget.Length),
                    string.Format(mNewValue, mArgument2++)
                    );
            });
            mActual6 = ((mArgument1 == "SS{{0}}SS{Sa}SS{1:####}SS") && (mArgument2 == 2));
            Debug.WriteLine($"[{mArgument1}][{mArgument2}]");

            //assert
            Contract.Assert(mActual1);
            Contract.Assert(mActual2);
            Contract.Assert(mActual3);
            Contract.Assert(mActual4);
            Contract.Assert(mActual5);
            Contract.Assert(mActual6);
        }
    }
}
