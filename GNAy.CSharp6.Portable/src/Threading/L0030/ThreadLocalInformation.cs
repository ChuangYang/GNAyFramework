using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Threading;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#if Development
using GNAy.CSharp6.Portable.Base.L0020_LibraryInformation;
using GNAy.CSharp6.Portable.Utility.L0010_TimeHelper;
#else
using GNAy.CSharp6.Portable.Base;
using GNAy.CSharp6.Portable.Utility;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Threading.L0030_ThreadLocalInformation
#else
namespace GNAy.CSharp6.Portable.Threading
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public class ThreadLocalInformation
    {
        private static readonly ThreadLocal<DateTime> _creationTime;
        private static readonly ThreadLocal<Guid> _guid;
        private static readonly ThreadLocal<int> _uniqueID;

        static ThreadLocalInformation()
        {
            _creationTime = new ThreadLocal<DateTime>(() => TimeHelper.GetTimeNowByPreprocessor(), true);
            _guid = new ThreadLocal<Guid>(() => Guid.NewGuid(), true);
            _uniqueID = new ThreadLocal<int>(() => (LibraryInformation.UniqueID ^ _creationTime.Value.GetHashCode() ^ _guid.Value.GetHashCode()), true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DateTime GetCreationTime()
        {
            return _creationTime.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Guid GetGuid()
        {
            return _guid.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetUniqueID()
        {
            return _uniqueID.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static IList<DateTime> GetCreationTimeValues()
        {
            return _creationTime.Values;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static IList<Guid> GetGuidValues()
        {
            return _guid.Values;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static IList<int> GetUniqueIDValues()
        {
            return _uniqueID.Values;
        }
    }
}
