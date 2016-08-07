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
#if Development
using GNAy.CSharp6.Portable.Const.L0000_ConstNumberValue;
using GNAy.CSharp6.Portable.Const.L0010_ConstString;
using GNAy.CSharp6.Portable.Utility.L0000_EMemberStatus;
using GNAy.CSharp6.Portable.Utility.L0000_ObjectHelper;
using GNAy.CSharp6.Portable.Utility.L0030_MemberInformation;
#else
using GNAy.CSharp6.Portable.Const;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0040_ThreadLocalMemberObserver
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public static class ThreadLocalMemberObserver
    {
        private static readonly ConcurrentQueue<MemberInformation> _memberInfoCollection;

        private static readonly ThreadLocal<MemberInformation> _lastMemberInfo;

        static ThreadLocalMemberObserver()
        {
            _memberInfoCollection = new ConcurrentQueue<MemberInformation>();

            _lastMemberInfo = new ThreadLocal<MemberInformation>(() =>
            {
                //MemberInformation mMemberInfo = new MemberInformation(EMemberStatus.IsRunning);

                //_memberInfoCollection.Enqueue(mMemberInfo);

                //return mMemberInfo;

                return null;
            }, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static MemberInformation GetLastMemberInfo()
        {
            return _lastMemberInfo.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static EMemberStatus GetLastMemberStatus()
        {
            return (GetLastMemberInfo().zIsNull() ? EMemberStatus.Unknown : GetLastMemberInfo().Status);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iStatus"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static MemberInformation SaveMemberInfo(EMemberStatus iStatus, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            MemberInformation mMemberInfo = new MemberInformation(iStatus, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            _lastMemberInfo.Value = mMemberInfo;
            _memberInfoCollection.Enqueue(mMemberInfo);

            return mMemberInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioException"></param>
        /// <param name="iExceptionStackTrace"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static MemberInformation SaveMemberInfo(Exception ioException, string iExceptionStackTrace, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            MemberInformation mMemberInfo = new MemberInformation(ioException, iExceptionStackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            _lastMemberInfo.Value = mMemberInfo;
            _memberInfoCollection.Enqueue(mMemberInfo);

            return mMemberInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <param name="iExceptionStackTrace"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static MemberInformation zSaveMemberInfo(this Exception ioSource, string iExceptionStackTrace, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            return SaveMemberInfo(ioSource, iExceptionStackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iTry"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static bool TryAndCatch(Action iTry, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            bool mResult = false;

            try
            {
                iTry();

                mResult = true;
            }
            catch (Exception mException)
            {
                SaveMemberInfo(mException, mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
            }
            finally
            { }

            return mResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iTry"></param>
        /// <param name="iCatch"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static bool TryAndCatch(Action iTry, Action<Exception, string> iCatch, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            bool mResult = false;

            try
            {
                iTry();

                mResult = true;
            }
            catch (Exception mException)
            {
                SaveMemberInfo(mException, mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

                iCatch(mException, mException.StackTrace);
            }
            finally
            { }

            return mResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iTry"></param>
        /// <param name="iCatch"></param>
        /// <param name="iFinally"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static bool TryAndCatch(Action iTry, Action<Exception, string> iCatch, Action iFinally, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            bool mResult = false;

            try
            {
                iTry();

                mResult = true;
            }
            catch (Exception mException)
            {
                SaveMemberInfo(mException, mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

                iCatch(mException, mException.StackTrace);
            }
            finally
            {
                if (!TryAndCatch(iFinally, iCatch, iCallerMemberName, iCallerFilePath, iCallerLineNumber))
                {
                    mResult = false;
                }
            }

            return mResult;
        }
    }
}
