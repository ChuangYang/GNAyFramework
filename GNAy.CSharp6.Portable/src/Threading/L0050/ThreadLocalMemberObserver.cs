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
using GNAy.CSharp6.Portable.Utility.L0040_MemberInformation;
#else
using GNAy.CSharp6.Portable.Const;
using GNAy.CSharp6.Portable.Utility;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Threading.L0050_ThreadLocalMemberObserver
#else
namespace GNAy.CSharp6.Portable.Threading
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

            //_lastMemberInfo = new ThreadLocal<MemberInformation>(() =>
            //{
            //    MemberInformation mMemberInfo = new MemberInformation(EMemberStatus.IsRunning);

            //    _memberInfoCollection.Enqueue(mMemberInfo);

            //    return mMemberInfo;
            //}, true);
            _lastMemberInfo = new ThreadLocal<MemberInformation>(() => null, true);
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
            return (GetLastMemberInfo().zzIsNull() ? EMemberStatus.Unknown : GetLastMemberInfo().Status);
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
        public static MemberInformation zzSaveMemberInfo(this Exception ioSource, string iExceptionStackTrace, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
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
        public static bool TryAndCatch(Action iTry, Action<MemberInformation> iCatch, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            bool mResult = false;

            try
            {
                iTry();

                mResult = true;
            }
            catch (Exception mException)
            {
                iCatch(SaveMemberInfo(mException, mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber));
            }
            finally
            { }

            return mResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iTry"></param>
        /// <param name="iFinally"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static bool TryAndCatch(Action iTry, Action iFinally, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
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
            {
                //if (!TryAndCatch(iFinally, iCallerMemberName, iCallerFilePath, iCallerLineNumber))
                //{
                //    mResult = false;
                //}
            }

            //For performance.
            try
            {
                iFinally();
            }
            catch (Exception mException)
            {
                SaveMemberInfo(mException, mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

                mResult = false;
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
        public static bool TryAndCatch(Action iTry, Action<MemberInformation> iCatch, Action iFinally, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            bool mResult = false;

            try
            {
                iTry();

                mResult = true;
            }
            catch (Exception mException)
            {
                iCatch(SaveMemberInfo(mException, mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber));
            }
            finally
            {
                //if (!TryAndCatch(iFinally, iCatch, iCallerMemberName, iCallerFilePath, iCallerLineNumber))
                //{
                //    mResult = false;
                //}
            }

            //For performance.
            try
            {
                iFinally();
            }
            catch (Exception mException)
            {
                iCatch(SaveMemberInfo(mException, mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber));

                mResult = false;
            }
            finally
            { }

            return mResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iConstruction"></param>
        /// <param name="iTry"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static bool TryUsing<T>(Func<T> iConstruction, Action<T> iTry, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero) where T : class, IDisposable
        {
            T mInstance = null;

            //if (!TryAndCatch(() => mInstance = iConstruction(), iCallerMemberName, iCallerFilePath, iCallerLineNumber))
            //{
            //    return false;
            //}

            //return TryAndCatch(() => iTry(mInstance), () => mInstance.Dispose(), iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            //For performance.
            bool mResult = false;

            try
            {
                mInstance = iConstruction();

                mResult = true;
            }
            catch (Exception mException)
            {
                SaveMemberInfo(mException, mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
            }
            finally
            { }

            if (!mResult)
            {
                return mResult;
            }

            try
            {
                iTry(mInstance);
            }
            catch (Exception mException)
            {
                SaveMemberInfo(mException, mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

                mResult = false;
            }
            finally
            { }

            try
            {
                mInstance.Dispose();
            }
            catch (Exception mException)
            {
                SaveMemberInfo(mException, mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

                mResult = false;
            }
            finally
            { }

            return mResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iConstruction"></param>
        /// <param name="iTry"></param>
        /// <param name="iCatch"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static bool TryUsing<T>(Func<T> iConstruction, Action<T> iTry, Action<T, MemberInformation> iCatch, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero) where T : class, IDisposable
        {
            T mInstance = null;

            //if (!TryAndCatch(() => mInstance = iConstruction(), (ioMemberInfo) => iCatch(mInstance, ioMemberInfo), iCallerMemberName, iCallerFilePath, iCallerLineNumber))
            //{
            //    return false;
            //}

            //return TryAndCatch(() => iTry(mInstance), (ioMemberInfo) => iCatch(mInstance, ioMemberInfo), () => mInstance.Dispose(), iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            //For performance.
            bool mResult = false;

            try
            {
                mInstance = iConstruction();

                mResult = true;
            }
            catch (Exception mException)
            {
                iCatch(mInstance, SaveMemberInfo(mException, mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber));
            }
            finally
            { }

            if (!mResult)
            {
                return mResult;
            }

            try
            {
                iTry(mInstance);
            }
            catch (Exception mException)
            {
                iCatch(mInstance, SaveMemberInfo(mException, mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber));

                mResult = false;
            }
            finally
            { }

            try
            {
                mInstance.Dispose();
            }
            catch (Exception mException)
            {
                iCatch(mInstance, SaveMemberInfo(mException, mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber));

                mResult = false;
            }
            finally
            { }

            return mResult;
        }
    }
}
