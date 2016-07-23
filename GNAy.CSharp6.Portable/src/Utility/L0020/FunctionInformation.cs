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
    public class FunctionInformation
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly DateTime TagTime;

        /// <summary>
        /// 
        /// </summary>
        public readonly EFunctionStatus Status;

        /// <summary>
        /// 
        /// </summary>
        public readonly int UniqueThreadNumber;

        /// <summary>
        /// 
        /// </summary>
        public readonly int UniqueFuncNumber;

        /// <summary>
        /// 
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// 
        /// </summary>
        public readonly string FilePath;

        /// <summary>
        /// 
        /// </summary>
        public readonly int LineNumber;

        /// <summary>
        /// 
        /// </summary>
        public readonly Exception Exception;

        /// <summary>
        /// 
        /// </summary>
        public readonly string ExceptionStackTrace;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iStatus"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        public FunctionInformation(EFunctionStatus iStatus, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            if (iStatus == EFunctionStatus.Unknown)
            {
                throw new ArgumentException("iStatus == EFunctionStatus.Unknown");
            }
            else if (iStatus == EFunctionStatus.HasException)
            {
                throw new ArgumentException("iStatus == EFunctionStatus.HasException");
            }

            TagTime = DateTime.UtcNow;

            Status = iStatus;

            Name = iCallerMemberName;
            FilePath = iCallerFilePath;
            LineNumber = iCallerLineNumber;

            UniqueFuncNumber = (ThreadUniqueNumber.GetNumber() ^ Name.GetHashCode() ^ FilePath.GetHashCode());

            Exception = null;
            ExceptionStackTrace = ConstString.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioException"></param>
        /// <param name="iExceptionStackTrace"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        public FunctionInformation(Exception ioException, string iExceptionStackTrace, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            TagTime = DateTime.UtcNow;

            Status = EFunctionStatus.HasException;

            Name = iCallerMemberName;
            FilePath = iCallerFilePath;
            LineNumber = iCallerLineNumber;

            UniqueThreadNumber = ThreadUniqueNumber.GetNumber();
            UniqueFuncNumber = (UniqueThreadNumber ^ Name.GetHashCode() ^ FilePath.GetHashCode());

            Exception = ioException;
            ExceptionStackTrace = iExceptionStackTrace;
        }
    }
}
