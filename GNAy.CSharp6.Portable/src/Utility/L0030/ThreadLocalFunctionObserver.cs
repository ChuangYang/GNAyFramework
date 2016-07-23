using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading;
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
    public static class ThreadLocalFunctionObserver
    {
        private static readonly ConcurrentQueue<FunctionInformation> _funcCollection;

        private static readonly ThreadLocal<FunctionInformation> _lastFunc;

        static ThreadLocalFunctionObserver()
        {
            _funcCollection = new ConcurrentQueue<FunctionInformation>();

            _lastFunc = new ThreadLocal<FunctionInformation>(() =>
            {
                //FunctionInformation mFunctionInfo = new FunctionInformation(EFunctionStatus.IsRunning);

                //_funcCollection.Enqueue(mFunctionInfo);

                //return mFunctionInfo;

                return null;
            }, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static FunctionInformation GetLastFuncInfo()
        {
            return _lastFunc.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static EFunctionStatus GetLastFuncStatus()
        {
            return (GetLastFuncInfo().zIsNull() ? EFunctionStatus.Unknown : GetLastFuncInfo().Status);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iStatus"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        public static void SaveFuncInfo(EFunctionStatus iStatus, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            FunctionInformation mFuncInfo = new FunctionInformation(iStatus, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            _lastFunc.Value = mFuncInfo;
            _funcCollection.Enqueue(mFuncInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioException"></param>
        /// <param name="iExceptionStackTrace"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        public static void SaveFuncInfo(Exception ioException, string iExceptionStackTrace, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            FunctionInformation mFuncInfo = new FunctionInformation(ioException, iExceptionStackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            _lastFunc.Value = mFuncInfo;
            _funcCollection.Enqueue(mFuncInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <param name="iExceptionStackTrace"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        public static void zSaveFuncInfo(this Exception ioSource, string iExceptionStackTrace, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            SaveFuncInfo(ioSource, iExceptionStackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
        }
    }
}
