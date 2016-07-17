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
#endregion

#region Alias.
#endregion

namespace GNAy.CSharp6.Portable.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class ThreadUniqueNumber
    {
        private static readonly ThreadLocal<DateTime> _creationTime;
        private static readonly ThreadLocal<Guid> _guid;
        private static readonly ThreadLocal<int> _uniqueNumber;

        static ThreadUniqueNumber()
        {
            _creationTime = new ThreadLocal<DateTime>(() => DateTime.UtcNow, true);
            _guid = new ThreadLocal<Guid>(() => Guid.NewGuid(), true);
            _uniqueNumber = new ThreadLocal<int>(() => (GlobalData.UniqueNumber ^ _creationTime.Value.GetHashCode() ^ _guid.Value.GetHashCode()), true);
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
        public static int GetNumber()
        {
            return _uniqueNumber.Value;
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
        internal static IList<int> GetNumberValues()
        {
            return _uniqueNumber.Values;
        }
    }
}
