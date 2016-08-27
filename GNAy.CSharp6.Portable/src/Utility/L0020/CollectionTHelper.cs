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
using GNAy.CSharp6.Portable.Utility.L0000_ObjectHelper;
#else
using GNAy.CSharp6.Portable.Const;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0020_CollectionTHelper
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public static class CollectionTHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static bool zzIsNullOrEmpty<T>(this ICollection<T> ioSource)
        {
            return (ioSource.zzIsNull() || (ioSource.Count == ConstValue.Empty));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static bool zzIsNotEmpty<T>(this ICollection<T> ioSource)
        {
            return !zzIsNullOrEmpty(ioSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static int zzGetLastIndex<T>(this ICollection<T> ioSource)
        {
            return (ioSource.Count - ConstNumberValue.One);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static bool zzIsReadOnly<T>(this ICollection<T> ioSource)
        {
            return ioSource.IsReadOnly;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="ioItem"></param>
        /// <returns></returns>
        public static bool zzTryAdd<T>(this ICollection<T> ioSource, T ioItem)
        {
            if (ioSource.IsReadOnly)
            {
                return false;
            }

            ioSource.Add(ioItem);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="ioItems"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzTryAdd<T>(this ICollection<T> ioSource, IEnumerable<T> ioItems)
        {
            if (ioSource.IsReadOnly)
            {
                yield break;
            }

            foreach (T mItem in ioItems)
            {
                yield return zzTryAdd(ioSource, mItem);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static bool zzTryClear<T>(this ICollection<T> ioSource)
        {
            if (ioSource.IsReadOnly)
            {
                return false;
            }

            ioSource.Clear();

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="ioItems"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzContains<T>(this ICollection<T> ioSource, IEnumerable<T> ioItems)
        {
            foreach (T mItem in ioItems)
            {
                yield return ioSource.Contains(mItem);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static T[] zzToArray<T>(this ICollection<T> ioSource)
        {
            T[] mCollection = new T[ioSource.Count];

            ioSource.CopyTo(mCollection, ConstValue.StartIndex);

            return mCollection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="iStartIndex"></param>
        /// <returns></returns>
        public static T[] zzToArray<T>(this ICollection<T> ioSource, int iStartIndex)
        {
            if (iStartIndex < ConstValue.StartIndex)
            {
                throw new ArgumentOutOfRangeException(iStartIndex.ToString());
            }
            else if (iStartIndex == ConstValue.StartIndex)
            {
                return zzToArray<T>(ioSource);
            }
            else if (iStartIndex >= ioSource.Count)
            {
                return new T[ConstValue.Empty];
            }

            T[] mCollection = new T[ioSource.Count - iStartIndex];
            int mIndex = ConstValue.NotFound;

            foreach (T mItem in ioSource)
            {
                if (++mIndex < iStartIndex)
                {
                    continue;
                }

                mCollection[mIndex - iStartIndex] = mItem;
            }

            return mCollection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="iStartIndex"></param>
        /// <param name="iCount"></param>
        /// <returns></returns>
        public static T[] zzToArray<T>(this ICollection<T> ioSource, int iStartIndex, int iCount)
        {
            if (iCount < ConstValue.StartIndex)
            {
                return zzToArray<T>(ioSource, iStartIndex);
            }
            else if (iStartIndex < ConstValue.StartIndex)
            {
                throw new ArgumentOutOfRangeException(iStartIndex.ToString());
            }
            else if (iStartIndex >= ioSource.Count)
            {
                return new T[ConstValue.Empty];
            }

            T[] mCollection = new T[ioSource.Count - iStartIndex];
            int mCount = ConstNumberValue.Zero;

            if (iStartIndex == ConstValue.StartIndex)
            {
                foreach (T mItem in ioSource)
                {
                    if (++mCount > iCount)
                    {
                        break;
                    }

                    mCollection[mCount - ConstNumberValue.One] = mItem;
                }
            }
            else
            {
                int mIndex = ConstValue.NotFound;

                foreach (T mItem in ioSource)
                {
                    if (++mIndex < iStartIndex)
                    {
                        continue;
                    }
                    else if (++mCount > iCount)
                    {
                        break;
                    }

                    mCollection[mIndex - iStartIndex] = mItem;
                }
            }

            return mCollection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="ioItem"></param>
        /// <returns></returns>
        public static bool zzTryRemove<T>(this ICollection<T> ioSource, T ioItem)
        {
            return (ioSource.IsReadOnly ? false : ioSource.Remove(ioItem));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="ioItems"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzTryRemove<T>(this ICollection<T> ioSource, IEnumerable<T> ioItems)
        {
            if (ioSource.IsReadOnly)
            {
                yield break;
            }

            foreach (T mItem in ioItems)
            {
                yield return zzTryRemove(ioSource, mItem);
            }
        }
    }
}
