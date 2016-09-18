using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Collections.Concurrent;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#if Development
using GNAy.CSharp6.Portable.Const.L0000_ConstNumberValue;
using GNAy.CSharp6.Portable.Const.L0010_ConstValue;
using GNAy.CSharp6.Portable.Utility.L0010_NumericHelper;
using GNAy.CSharp6.Portable.Utility.L0030_EnumerationInformation;
#else
using GNAy.CSharp6.Portable.Const;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0040_EnumerationHelper
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumerationHelper
    {
        private static readonly ConcurrentDictionary<Enum, EnumerationInformation> _enumerationCollection;

        static EnumerationHelper()
        {
            _enumerationCollection = new ConcurrentDictionary<Enum, EnumerationInformation>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int Count()
        {
            return _enumerationCollection.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool zzContains(this Enum iSource)
        {
            return _enumerationCollection.ContainsKey(iSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<EnumerationInformation> Watch()
        {
            foreach (EnumerationInformation mItem in _enumerationCollection.Values)
            {
                yield return mItem;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        public static void CacheInfo(Enum iSource)
        {
            Enum[] mRawCollection = Enum.GetValues(iSource.GetType()).Cast<Enum>().ToArray();

            if (_enumerationCollection.ContainsKey(mRawCollection[ConstValue.StartIndex]))
            {
                return;
            }

            EnumerationInformation mFirstInfo = new EnumerationInformation(ConstValue.StartIndex, mRawCollection);
            _enumerationCollection[mFirstInfo.Source] = mFirstInfo;

            for (int i = (ConstValue.StartIndex + ConstNumberValue.One); i < mRawCollection.Length; ++i)
            {
                _enumerationCollection[mRawCollection[i]] = new EnumerationInformation(mRawCollection[i], (int)(object)mRawCollection[i], mRawCollection[i].ToString(), mFirstInfo.IsDefined, i, mRawCollection, mFirstInfo.ValueCollection, mFirstInfo.NameCollection);
            }

            if (_enumerationCollection.ContainsKey(iSource))
            {
                return;
            }

            _enumerationCollection[iSource] = new EnumerationInformation(iSource, (int)(object)iSource, iSource.ToString(), false, ConstValue.NotFound, mRawCollection, mFirstInfo.ValueCollection, mFirstInfo.NameCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        public static void zzCacheInfo(this Enum iSource)
        {
            CacheInfo(iSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static EnumerationInformation GetInfo(Enum iSource)
        {
            try
            {
                return _enumerationCollection[iSource];
            }
            catch //(Exception mException)
            {
                CacheInfo(iSource);

                return _enumerationCollection[iSource];
            }
            finally
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static EnumerationInformation zzGetInfo(this Enum iSource)
        {
            return GetInfo(iSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iFlagCollection"></param>
        /// <returns></returns>
        public static IEnumerable<EnumerationInformation> ForeachFlagInfo(Enum iFlagCollection)
        {
            int mValue = (int)(object)iFlagCollection;
            EnumerationInformation mInfo = GetInfo(iFlagCollection);

            for (int i = ConstValue.StartIndex; i < mInfo.ValueCollection.Length; ++i)
            {
                if (mValue.zzHasFlag(mInfo.ValueCollection[i]))
                {
                    yield return _enumerationCollection[mInfo.RawCollection[i]];
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iFlagCollection"></param>
        /// <returns></returns>
        public static IEnumerable<EnumerationInformation> zzForeachFlagInfo(this Enum iFlagCollection)
        {
            return ForeachFlagInfo(iFlagCollection);
        }
    }
}
