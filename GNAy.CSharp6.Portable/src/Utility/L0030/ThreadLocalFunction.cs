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
    public static class ThreadLocalFunction
    {
        private static readonly ConcurrentQueue<FunctionInformation> _functionInfoCollection;

        private static readonly ThreadLocal<FunctionInformation> _lastFunctionInfo;

        static ThreadLocalFunction()
        {
            _functionInfoCollection = new ConcurrentQueue<FunctionInformation>();

            _lastFunctionInfo = new ThreadLocal<FunctionInformation>(() =>
            {
                //FunctionInformation mFunctionInfo = new FunctionInformation(EFunctionStatus.IsRunning);

                //_functionInfoCollection.Enqueue(mFunctionInfo);

                //return mFunctionInfo;

                return null;
            }, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static FunctionInformation GetLastFunctionInfo()
        {
            return _lastFunctionInfo.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iStatus"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        public static void SaveFunctionInfo(EFunctionStatus iStatus, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            FunctionInformation mFunctionInfo = new FunctionInformation(iStatus, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            _lastFunctionInfo.Value = mFunctionInfo;
            _functionInfoCollection.Enqueue(mFunctionInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioException"></param>
        /// <param name="iExceptionStackTrace"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        public static void SaveFunctionInfo(Exception ioException, string iExceptionStackTrace, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            FunctionInformation mFunctionInfo = new FunctionInformation(ioException, iExceptionStackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            _lastFunctionInfo.Value = mFunctionInfo;
            _functionInfoCollection.Enqueue(mFunctionInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <param name="iExceptionStackTrace"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        public static void zSaveFunctionInfo(this Exception ioSource, string iExceptionStackTrace, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            SaveFunctionInfo(ioSource, iExceptionStackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
        }
    }
}
