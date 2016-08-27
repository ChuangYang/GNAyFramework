using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#if Development
using GNAy.CSharp6.Portable.Const.L0000_ConstNumberValue;
using GNAy.CSharp6.Portable.Const.L0010_ConstValue;
using GNAy.CSharp6.Portable.Threading.L0040_ThreadSafeRandom;
#else
using GNAy.CSharp6.Portable.Const;
using GNAy.CSharp6.Portable.Threading;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0050_RandomHelper
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
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
        public static IList<T> zzShuffleItems<T>(this IList<T> ioSource, Random ioRandom, int iShufflingTimes = DefaultShufflingTimes)
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

            int mHelfRight = ((int)Math.Ceiling(mCount / (double)ConstNumberValue.Two) + ConstNumberValue.One);
            int mHelfLeft = ((int)Math.Floor(mCount / (double)ConstNumberValue.Two) - ConstNumberValue.One);

            for (int i = ConstValue.StartIndex; i < mHelfRight; ++i)
            {
                int mRandomNumber = (ioRandom.Next(mHelfRight) + mHelfLeft);

                T mItem = ioSource[i];
                ioSource[i] = ioSource[mRandomNumber];
                ioSource[mRandomNumber] = mItem;
            }

            return ((--iShufflingTimes > ConstNumberValue.Zero) ? zzShuffleItems(ioSource, ioRandom, iShufflingTimes) : ioSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="iShufflingTimes"></param>
        /// <returns></returns>
        public static IList<T> zzShuffleItems<T>(this IList<T> ioSource, int iShufflingTimes = DefaultShufflingTimes)
        {
            return zzShuffleItems(ioSource, ThreadSafeRandom.GetInstance(), iShufflingTimes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="ioRandom"></param>
        /// <param name="iShufflingTimes"></param>
        /// <returns></returns>
        public static T[] zzShuffleItems<T>(this T[] ioSource, Random ioRandom, int iShufflingTimes = DefaultShufflingTimes)
        {
            return (T[])zzShuffleItems((IList<T>)ioSource, ioRandom, iShufflingTimes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="iShufflingTimes"></param>
        /// <returns></returns>
        public static T[] zzShuffleItems<T>(this T[] ioSource, int iShufflingTimes = DefaultShufflingTimes)
        {
            return zzShuffleItems(ioSource, ThreadSafeRandom.GetInstance(), iShufflingTimes);
        }

        /// <summary>
        /// Returns a non-negative random integer.
        /// </summary>
        /// <param name="ioSource"></param>
        /// <param name="iCount"></param>
        /// <returns></returns>
        public static int[] zzDistinctInts(this Random ioSource, ushort iCount)
        {
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
        /// <returns></returns>
        public static int[] zzDistinctInts(this Random ioSource, int iMaxValue, ushort iCount)
        {
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
        /// <returns></returns>
        public static int[] zzDistinctInts(this Random ioSource, int iMinValue, int iMaxValue, ushort iCount)
        {
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
        /// <returns></returns>
        public static byte[] zzDistinctBytes(this Random ioSource, ushort iCount)
        {
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
        /// <returns></returns>
        public static double[] zzDistinctDoubles(this Random ioSource, ushort iCount)
        {
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
