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
#if Development
using GNAy.CSharp6.Portable.Const.L0000_ConstNumberValue;
using GNAy.CSharp6.Portable.Const.L0010_ConstString;
using GNAy.CSharp6.Portable.Utility.L0000_EMemberStatus;
using GNAy.CSharp6.Portable.Utility.L0000_TimeHelper;
using GNAy.CSharp6.Portable.Utility.L0020_ThreadLocalInformation;
#else
using GNAy.CSharp6.Portable.Const;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0030_MemberInformation
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public class MemberInformation
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly DateTime CreationTime;

        /// <summary>
        /// 
        /// </summary>
        public readonly EMemberStatus Status;

        /// <summary>
        /// 
        /// </summary>
        public readonly int UniqueThreadID;

        /// <summary>
        /// 
        /// </summary>
        public readonly int UniqueMemberID;

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
        public MemberInformation(EMemberStatus iStatus, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            if (iStatus == EMemberStatus.Unknown)
            {
                throw new ArgumentException("iStatus == EMemberStatus.Unknown");
            }
            else if (iStatus == EMemberStatus.HasException)
            {
                throw new ArgumentException("iStatus == EMemberStatus.HasException");
            }

            CreationTime = TimeHelper.GetTimeNowByPreprocessor();

            Status = iStatus;

            Name = iCallerMemberName;
            FilePath = iCallerFilePath;
            LineNumber = iCallerLineNumber;

            UniqueThreadID = ThreadLocalInformation.GetUniqueID();
            UniqueMemberID = (UniqueThreadID ^ Name.GetHashCode() ^ FilePath.GetHashCode());

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
        public MemberInformation(Exception ioException, string iExceptionStackTrace, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            CreationTime = TimeHelper.GetTimeNowByPreprocessor();

            Status = EMemberStatus.HasException;

            Name = iCallerMemberName;
            FilePath = iCallerFilePath;
            LineNumber = iCallerLineNumber;

            UniqueThreadID = ThreadLocalInformation.GetUniqueID();
            UniqueMemberID = (UniqueThreadID ^ Name.GetHashCode() ^ FilePath.GetHashCode());

            Exception = ioException;
            ExceptionStackTrace = iExceptionStackTrace;
        }
    }
}
