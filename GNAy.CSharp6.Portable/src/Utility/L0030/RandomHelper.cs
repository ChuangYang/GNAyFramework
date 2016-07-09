using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Runtime.CompilerServices;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp6.Portable.Const;
#endregion

#region Alias.
#endregion

namespace GNAy.CSharp6.Portable.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class RandomHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public const int DefaultShufflingTimes = ConstNumberValue.Two;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="ioRandom"></param>
        /// <param name="iShufflingTimes"></param>
        /// <returns></returns>
        public static IList<T> zShuffleItems<T>(this IList<T> ioSource, Random ioRandom, int iShufflingTimes = DefaultShufflingTimes)
        {
            int mCount = ioSource.Count;

            if (mCount <= ConstNumberValue.One)
            {
                return ioSource;
            }
            else if (iShufflingTimes <= ConstNumberValue.Zero)
            {
                return ioSource;
            }

            int mHelfRight = ((int)Math.Ceiling(mCount / 2.0f) + ConstNumberValue.One);
            int mHelfLeft = ((int)Math.Floor(mCount / 2.0f) - ConstNumberValue.One);

            for (int i = ConstValue.StartIndex; i < mHelfRight; ++i)
            {
                int mRandomNumber = (ioRandom.Next(mHelfRight) + mHelfLeft);

                T mItem = ioSource[i];
                ioSource[i] = ioSource[mRandomNumber];
                ioSource[mRandomNumber] = mItem;
            }

            return ((--iShufflingTimes > ConstNumberValue.Zero) ? zShuffleItems(ioSource, ioRandom, iShufflingTimes) : ioSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="iShufflingTimes"></param>
        /// <returns></returns>
        public static IList<T> zShuffleItems<T>(this IList<T> ioSource, int iShufflingTimes = DefaultShufflingTimes)
        {
            return zShuffleItems(ioSource, ThreadSafe.GetRandom(), iShufflingTimes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="ioRandom"></param>
        /// <param name="iShufflingTimes"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static T[] zShuffleItems<T>(this T[] ioSource, Random ioRandom, int iShufflingTimes = DefaultShufflingTimes, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            ThreadLocal.SaveCaller(iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            return (T[])zShuffleItems((IList<T>)ioSource, ioRandom, iShufflingTimes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="iShufflingTimes"></param>
        /// <returns></returns>
        public static T[] zShuffleItems<T>(this T[] ioSource, int iShufflingTimes = DefaultShufflingTimes)
        {
            return zShuffleItems(ioSource, ThreadSafe.GetRandom(), iShufflingTimes);
        }

        /// <summary>
        /// Returns a non-negative random integer.
        /// </summary>
        /// <param name="ioSource"></param>
        /// <param name="iCount"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static int[] zDistinctInts(this Random ioSource, ushort iCount, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            ThreadLocal.SaveCaller(iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            int[] mResult = new int[iCount];

            mResult[ConstValue.StartIndex] = ioSource.Next();

            for (int i = (ConstValue.StartIndex + ConstNumberValue.One); i < iCount; ++i)
            {
                int mNext = ioSource.Next();

                if (mResult.Contains(mNext))
                {
                    --i;

                    continue;
                }

                mResult[i] = mNext;
            }

            return mResult;
        }

        /// <summary>
        /// Returns a non-negative random integer that is less than the specified maximum.
        /// </summary>
        /// <param name="ioSource"></param>
        /// <param name="iMaxValue"></param>
        /// <param name="iCount"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static int[] zDistinctInts(this Random ioSource, int iMaxValue, ushort iCount, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            ThreadLocal.SaveCaller(iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            int[] mResult = new int[iCount];

            mResult[ConstValue.StartIndex] = ioSource.Next(iMaxValue);

            for (int i = (ConstValue.StartIndex + ConstNumberValue.One); i < iCount; ++i)
            {
                int mNext = ioSource.Next(iMaxValue);

                if (mResult.Contains(mNext))
                {
                    --i;

                    continue;
                }

                mResult[i] = mNext;
            }

            return mResult;
        }

        /// <summary>
        /// Returns a random integer that is within a specified range.
        /// </summary>
        /// <param name="ioSource"></param>
        /// <param name="iMinValue"></param>
        /// <param name="iMaxValue"></param>
        /// <param name="iCount"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static int[] zDistinctInts(this Random ioSource, int iMinValue, int iMaxValue, ushort iCount, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            ThreadLocal.SaveCaller(iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            int[] mResult = new int[iCount];

            mResult[ConstValue.StartIndex] = ioSource.Next(iMinValue, iMaxValue);

            for (int i = (ConstValue.StartIndex + ConstNumberValue.One); i < iCount; ++i)
            {
                int mNext = ioSource.Next(iMinValue, iMaxValue);

                if (mResult.Contains(mNext))
                {
                    --i;

                    continue;
                }

                mResult[i] = mNext;
            }

            return mResult;
        }

        /// <summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        /// </summary>
        /// <param name="ioSource"></param>
        /// <param name="iCount"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static byte[] zDistinctBytes(this Random ioSource, ushort iCount, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            ThreadLocal.SaveCaller(iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            byte[] mResult = new byte[iCount];

            mResult[ConstValue.StartIndex] = (byte)ioSource.Next(byte.MaxValue + ConstNumberValue.One);

            for (int i = (ConstValue.StartIndex + ConstNumberValue.One); i < iCount; ++i)
            {
                byte mNext = (byte)ioSource.Next(byte.MaxValue + ConstNumberValue.One);

                if (mResult.Contains(mNext))
                {
                    --i;

                    continue;
                }

                mResult[i] = mNext;
            }

            return mResult;
        }

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
        /// </summary>
        /// <param name="ioSource"></param>
        /// <param name="iCount"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static double[] zDistinctDoubles(this Random ioSource, ushort iCount, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            ThreadLocal.SaveCaller(iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            double[] mResult = new double[iCount];

            mResult[ConstValue.StartIndex] = ioSource.Next();

            for (int i = (ConstValue.StartIndex + ConstNumberValue.One); i < iCount; ++i)
            {
                double mNext = ioSource.NextDouble();

                if (mResult.Contains(mNext))
                {
                    --i;

                    continue;
                }

                mResult[i] = mNext;
            }

            return mResult;
        }
    }
}
