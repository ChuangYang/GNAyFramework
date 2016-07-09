using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Collections.Concurrent;
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
    public static class ThreadLocal
    {
        private static readonly ThreadLocal<DateTime> _localCreationTime;
        private static readonly ThreadLocal<Guid> _localGuid;

        private static readonly ThreadLocal<ConcurrentQueue<DateTime>> _localCallerTime;
        private static readonly ThreadLocal<ConcurrentQueue<string>> _localCallerMemberName;
        private static readonly ThreadLocal<ConcurrentQueue<string>> _localCallerFilePath;
        private static readonly ThreadLocal<ConcurrentQueue<int>> _localCallerLineNumber;

        private static readonly ThreadLocal<ConcurrentQueue<DateTime>> _localExceptionTime;
        private static readonly ThreadLocal<ConcurrentQueue<Exception>> _localException;
        private static readonly ThreadLocal<ConcurrentQueue<string>> _localExceptionStackTrace;

        static ThreadLocal()
        {
            _localCreationTime = new ThreadLocal<DateTime>(() => DateTime.UtcNow, true);
            _localGuid = new ThreadLocal<Guid>(() => Guid.NewGuid(), true);

            _localCallerTime = new ThreadLocal<ConcurrentQueue<DateTime>>(() => new ConcurrentQueue<DateTime>(), true);
            _localCallerMemberName = new ThreadLocal<ConcurrentQueue<string>>(() => new ConcurrentQueue<string>(), true);
            _localCallerFilePath = new ThreadLocal<ConcurrentQueue<string>>(() => new ConcurrentQueue<string>(), true);
            _localCallerLineNumber = new ThreadLocal<ConcurrentQueue<int>>(() => new ConcurrentQueue<int>(), true);

            _localExceptionTime = new ThreadLocal<ConcurrentQueue<DateTime>>(() => new ConcurrentQueue<DateTime>(), true);
            _localException = new ThreadLocal<ConcurrentQueue<Exception>>(() => new ConcurrentQueue<Exception>(), true);
            _localExceptionStackTrace = new ThreadLocal<ConcurrentQueue<string>>(() => new ConcurrentQueue<string>(), true);
        }

        /// <summary>
        /// Initialize the static instance.
        /// </summary>
        public static void Initialize()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        public static void SaveCaller(string iCallerMemberName, string iCallerFilePath, int iCallerLineNumber)
        {
            _localCallerTime.Value.Enqueue(DateTime.UtcNow);
            _localCallerMemberName.Value.Enqueue(iCallerMemberName);
            _localCallerFilePath.Value.Enqueue(iCallerFilePath);
            _localCallerLineNumber.Value.Enqueue(iCallerLineNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <param name="iExceptionStackTrace"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        public static void zSave(this Exception ioSource, string iExceptionStackTrace, string iCallerMemberName, string iCallerFilePath, int iCallerLineNumber)
        {
            DateTime TimeNow = DateTime.UtcNow;

            _localCallerTime.Value.Enqueue(TimeNow);
            _localCallerMemberName.Value.Enqueue(iCallerMemberName);
            _localCallerFilePath.Value.Enqueue(iCallerFilePath);
            _localCallerLineNumber.Value.Enqueue(iCallerLineNumber);

            _localExceptionTime.Value.Enqueue(TimeNow);
            _localException.Value.Enqueue(ioSource);
            _localExceptionStackTrace.Value.Enqueue(iExceptionStackTrace);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DateTime GetCreationTime()
        {
            return _localCreationTime.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Guid GetGuid()
        {
            return _localGuid.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IList<DateTime> GetCreationTimeValues()
        {
            return _localCreationTime.Values;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IList<Guid> GetGuidValues()
        {
            return _localGuid.Values;
        }
    }
}
