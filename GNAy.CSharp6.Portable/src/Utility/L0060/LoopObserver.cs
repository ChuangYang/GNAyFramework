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
using GNAy.CSharp6.Portable.Threading.L0030_ThreadLocalInformation;
using GNAy.CSharp6.Portable.Threading.L0050_ThreadLocalMemberObserver;
using GNAy.CSharp6.Portable.Utility.L0000_ELoopStatus;
using GNAy.CSharp6.Portable.Utility.L0000_LoopResult;
using GNAy.CSharp6.Portable.Utility.L0000_ObjectHelper;
using GNAy.CSharp6.Portable.Utility.L0040_LoopRecord;
#else
using GNAy.CSharp6.Portable.Const;
using GNAy.CSharp6.Portable.Threading;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0060_LoopObserver
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public class LoopObserver
    {
        #region WithoutRecord
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCondition"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        public static void SpinUntil(Func<LoopResult> iCondition, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            SpinWait.SpinUntil(() =>
            {
                try
                {
                    return iCondition();
                }
                catch (Exception mException)
                {
                    mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

                    return LoopResult.Continue;
                }
                finally
                { }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioArgument"></param>
        /// <param name="iCondition"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        public static void SpinUntil<T>(T ioArgument, Func<T, LoopResult> iCondition, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            SpinWait.SpinUntil(() =>
            {
                try
                {
                    return iCondition(ioArgument);
                }
                catch (Exception mException)
                {
                    mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

                    return LoopResult.Continue;
                }
                finally
                { }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCondition"></param>
        /// <param name="iMillisecondsTimeout"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static bool SpinUntil(Func<LoopResult> iCondition, int iMillisecondsTimeout, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            return SpinWait.SpinUntil(() =>
                {
                    try
                    {
                        return iCondition();
                    }
                    catch (Exception mException)
                    {
                        mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

                        return LoopResult.Continue;
                    }
                    finally
                    { }
                },
                iMillisecondsTimeout);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioArgument"></param>
        /// <param name="iCondition"></param>
        /// <param name="iMillisecondsTimeout"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static bool SpinUntil<T>(T ioArgument, Func<T, LoopResult> iCondition, int iMillisecondsTimeout, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            return SpinWait.SpinUntil(() =>
                {
                    try
                    {
                        return iCondition(ioArgument);
                    }
                    catch (Exception mException)
                    {
                        mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

                        return LoopResult.Continue;
                    }
                    finally
                    { }
                },
                iMillisecondsTimeout);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCondition"></param>
        /// <param name="iTimeout"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static bool SpinUntil(Func<LoopResult> iCondition, TimeSpan iTimeout, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            return SpinWait.SpinUntil(() =>
                {
                    try
                    {
                        return iCondition();
                    }
                    catch (Exception mException)
                    {
                        mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

                        return LoopResult.Continue;
                    }
                    finally
                    { }
                },
                iTimeout);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioArgument"></param>
        /// <param name="iCondition"></param>
        /// <param name="iTimeout"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static bool SpinUntil<T>(T ioArgument, Func<T, LoopResult> iCondition, TimeSpan iTimeout, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            return SpinWait.SpinUntil(() =>
                {
                    try
                    {
                        return iCondition(ioArgument);
                    }
                    catch (Exception mException)
                    {
                        mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

                        return LoopResult.Continue;
                    }
                    finally
                    { }
                },
                iTimeout);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCondition"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        public static void While(Func<LoopResult> iCondition, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            LoopResult mResult = LoopResult.Continue;

            while (mResult == LoopResult.Continue)
            {
                try
                {
                    mResult = iCondition();
                }
                catch (Exception mException)
                {
                    mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
                }
                finally
                { }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioArgument"></param>
        /// <param name="iCondition"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        public static void While<T>(T ioArgument, Func<T, LoopResult> iCondition, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            LoopResult mResult = LoopResult.Continue;

            while (mResult == LoopResult.Continue)
            {
                try
                {
                    mResult = iCondition(ioArgument);
                }
                catch (Exception mException)
                {
                    mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
                }
                finally
                { }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iFromInclusive"></param>
        /// <param name="iToExclusive"></param>
        /// <param name="iBody"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static ParallelLoopResult ParallelFor(int iFromInclusive, int iToExclusive, Action<int> iBody, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            return Parallel.For(iFromInclusive, iToExclusive, iIndex =>
                {
                    try
                    {
                        iBody(iIndex);
                    }
                    catch (Exception mException)
                    {
                        mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
                    }
                    finally
                    { }
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="ioCollection"></param>
        /// <param name="iBody"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static ParallelLoopResult ParallelForEach<TSource>(IEnumerable<TSource> ioCollection, Action<TSource> iBody, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            return Parallel.ForEach(ioCollection, ioSource =>
                {
                    try
                    {
                        iBody(ioSource);
                    }
                    catch (Exception mException)
                    {
                        mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
                    }
                    finally
                    { }
                });
        }
        #endregion

        #region WithRecord
        private static readonly ConcurrentDictionary<int, LoopRecord> _loopRecordCollection;

        static LoopObserver()
        {
            _loopRecordCollection = new ConcurrentDictionary<int, LoopRecord>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int Count()
        {
            return _loopRecordCollection.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ResetLocalRecord()
        {
            _loopRecordCollection[ThreadLocalInformation.GetUniqueID()] = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iUniqueThreadID"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static LoopRecord TryToGetRecord(int iUniqueThreadID, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            try
            {
                return _loopRecordCollection[iUniqueThreadID];
            }
            catch (Exception mException)
            {
                mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

                return null;
            }
            finally
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCondition"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        public static void SpinUntilAndRecord(Func<LoopResult> iCondition, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            LoopRecord mRecord = new LoopRecord();
            mRecord.Start();

            _loopRecordCollection[mRecord.UniqueThreadID] = mRecord;

            SpinWait.SpinUntil(() =>
            {
                try
                {
                    LoopResult mResult = iCondition();

                    if (mResult == LoopResult.Break)
                    {
                        mRecord.SetStatus(ELoopStatus.IsStopped);
                    }
                    else if (mRecord.GetStatus() == ELoopStatus.IsPausing)
                    {
                        mRecord.SetStatus(ELoopStatus.IsWaiting);

                        SpinUntil(() => (mRecord.GetStatus() != ELoopStatus.IsWaiting));
                    }

                    if (mRecord.GetStatus() == ELoopStatus.IsStopping)
                    {
                        mRecord.SetStatus(ELoopStatus.IsStopped);
                    }

                    return mResult;
                }
                catch (Exception mException)
                {
                    mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

                    return LoopResult.Continue;
                }
                finally
                { }
            });

            //mRecord.SetStatus(ELoopStatus.IsStopped);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioArgument"></param>
        /// <param name="iCondition"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        public static void SpinUntilAndRecord<T>(T ioArgument, Func<T, LoopResult> iCondition, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            LoopRecord mRecord = new LoopRecord();
            mRecord.Start();

            _loopRecordCollection[mRecord.UniqueThreadID] = mRecord;

            SpinWait.SpinUntil(() =>
            {
                try
                {
                    LoopResult mResult = iCondition(ioArgument);

                    if (mResult == LoopResult.Break)
                    {
                        mRecord.SetStatus(ELoopStatus.IsStopped);
                    }
                    else if (mRecord.GetStatus() == ELoopStatus.IsPausing)
                    {
                        mRecord.SetStatus(ELoopStatus.IsWaiting);

                        SpinUntil(() => (mRecord.GetStatus() != ELoopStatus.IsWaiting));
                    }

                    if (mRecord.GetStatus() == ELoopStatus.IsStopping)
                    {
                        mRecord.SetStatus(ELoopStatus.IsStopped);
                    }

                    return mResult;
                }
                catch (Exception mException)
                {
                    mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

                    return LoopResult.Continue;
                }
                finally
                { }
            });

            //mRecord.SetStatus(ELoopStatus.IsStopped);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCondition"></param>
        /// <param name="iMillisecondsTimeout"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static bool SpinUntilAndRecord(Func<LoopResult> iCondition, int iMillisecondsTimeout, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            LoopRecord mRecord = new LoopRecord();
            mRecord.Start();

            _loopRecordCollection[mRecord.UniqueThreadID] = mRecord;

            return SpinWait.SpinUntil(() =>
            {
                try
                {
                    LoopResult mResult = iCondition();

                    if (mResult == LoopResult.Break)
                    {
                        mRecord.SetStatus(ELoopStatus.IsStopped);
                    }
                    else if (mRecord.GetStatus() == ELoopStatus.IsPausing)
                    {
                        mRecord.SetStatus(ELoopStatus.IsWaiting);

                        SpinUntil(() => (mRecord.GetStatus() != ELoopStatus.IsWaiting));
                    }

                    if (mRecord.GetStatus() == ELoopStatus.IsStopping)
                    {
                        mRecord.SetStatus(ELoopStatus.IsStopped);
                    }

                    return mResult;
                }
                catch (Exception mException)
                {
                    mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

                    return LoopResult.Continue;
                }
                finally
                { }
            },
            iMillisecondsTimeout);

            //mRecord.SetStatus(ELoopStatus.IsStopped);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioArgument"></param>
        /// <param name="iCondition"></param>
        /// <param name="iMillisecondsTimeout"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static bool SpinUntilAndRecord<T>(T ioArgument, Func<T, LoopResult> iCondition, int iMillisecondsTimeout, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            LoopRecord mRecord = new LoopRecord();
            mRecord.Start();

            _loopRecordCollection[mRecord.UniqueThreadID] = mRecord;

            return SpinWait.SpinUntil(() =>
            {
                try
                {
                    LoopResult mResult = iCondition(ioArgument);

                    if (mResult == LoopResult.Break)
                    {
                        mRecord.SetStatus(ELoopStatus.IsStopped);
                    }
                    else if (mRecord.GetStatus() == ELoopStatus.IsPausing)
                    {
                        mRecord.SetStatus(ELoopStatus.IsWaiting);

                        SpinUntil(() => (mRecord.GetStatus() != ELoopStatus.IsWaiting));
                    }

                    if (mRecord.GetStatus() == ELoopStatus.IsStopping)
                    {
                        mRecord.SetStatus(ELoopStatus.IsStopped);
                    }

                    return mResult;
                }
                catch (Exception mException)
                {
                    mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

                    return LoopResult.Continue;
                }
                finally
                { }
            },
            iMillisecondsTimeout);

            //mRecord.SetStatus(ELoopStatus.IsStopped);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCondition"></param>
        /// <param name="iTimeout"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static bool SpinUntilAndRecord(Func<LoopResult> iCondition, TimeSpan iTimeout, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            LoopRecord mRecord = new LoopRecord();
            mRecord.Start();

            _loopRecordCollection[mRecord.UniqueThreadID] = mRecord;

            return SpinWait.SpinUntil(() =>
            {
                try
                {
                    LoopResult mResult = iCondition();

                    if (mResult == LoopResult.Break)
                    {
                        mRecord.SetStatus(ELoopStatus.IsStopped);
                    }
                    else if (mRecord.GetStatus() == ELoopStatus.IsPausing)
                    {
                        mRecord.SetStatus(ELoopStatus.IsWaiting);

                        SpinUntil(() => (mRecord.GetStatus() != ELoopStatus.IsWaiting));
                    }

                    if (mRecord.GetStatus() == ELoopStatus.IsStopping)
                    {
                        mRecord.SetStatus(ELoopStatus.IsStopped);
                    }

                    return mResult;
                }
                catch (Exception mException)
                {
                    mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

                    return LoopResult.Continue;
                }
                finally
                { }
            },
            iTimeout);

            //mRecord.SetStatus(ELoopStatus.IsStopped);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioArgument"></param>
        /// <param name="iCondition"></param>
        /// <param name="iTimeout"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static bool SpinUntilAndRecord<T>(T ioArgument, Func<T, LoopResult> iCondition, TimeSpan iTimeout, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            LoopRecord mRecord = new LoopRecord();
            mRecord.Start();

            _loopRecordCollection[mRecord.UniqueThreadID] = mRecord;

            return SpinWait.SpinUntil(() =>
            {
                try
                {
                    LoopResult mResult = iCondition(ioArgument);

                    if (mResult == LoopResult.Break)
                    {
                        mRecord.SetStatus(ELoopStatus.IsStopped);
                    }
                    else if (mRecord.GetStatus() == ELoopStatus.IsPausing)
                    {
                        mRecord.SetStatus(ELoopStatus.IsWaiting);

                        SpinUntil(() => (mRecord.GetStatus() != ELoopStatus.IsWaiting));
                    }

                    if (mRecord.GetStatus() == ELoopStatus.IsStopping)
                    {
                        mRecord.SetStatus(ELoopStatus.IsStopped);
                    }

                    return mResult;
                }
                catch (Exception mException)
                {
                    mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);

                    return LoopResult.Continue;
                }
                finally
                { }
            },
            iTimeout);

            //mRecord.SetStatus(ELoopStatus.IsStopped);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCondition"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        public static void WhileAndRecord(Func<LoopResult> iCondition, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            LoopResult mResult = LoopResult.Continue;

            LoopRecord mRecord = new LoopRecord();
            mRecord.Start();

            _loopRecordCollection[mRecord.UniqueThreadID] = mRecord;

            while (mResult == LoopResult.Continue)
            {
                try
                {
                    mResult = iCondition();

                    if (mResult == LoopResult.Break)
                    {
                        mRecord.SetStatus(ELoopStatus.IsStopped);
                    }
                    else if (mRecord.GetStatus() == ELoopStatus.IsPausing)
                    {
                        mRecord.SetStatus(ELoopStatus.IsWaiting);

                        while (mRecord.GetStatus() == ELoopStatus.IsWaiting) { }
                        //SpinUntil(() => (mRecord.GetStatus() != ELoopStatus.IsWaiting));
                    }

                    if (mRecord.GetStatus() == ELoopStatus.IsStopping)
                    {
                        mRecord.SetStatus(ELoopStatus.IsStopped);
                    }
                }
                catch (Exception mException)
                {
                    mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
                }
                finally
                { }
            }

            //mRecord.SetStatus(ELoopStatus.IsStopped);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioArgument"></param>
        /// <param name="iCondition"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        public static void WhileAndRecord<T>(T ioArgument, Func<T, LoopResult> iCondition, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            LoopResult mResult = LoopResult.Continue;

            LoopRecord mRecord = new LoopRecord();
            mRecord.Start();

            _loopRecordCollection[mRecord.UniqueThreadID] = mRecord;

            while (mResult == LoopResult.Continue)
            {
                try
                {
                    mResult = iCondition(ioArgument);

                    if (mResult == LoopResult.Break)
                    {
                        mRecord.SetStatus(ELoopStatus.IsStopped);
                    }
                    else if (mRecord.GetStatus() == ELoopStatus.IsPausing)
                    {
                        mRecord.SetStatus(ELoopStatus.IsWaiting);

                        while (mRecord.GetStatus() == ELoopStatus.IsWaiting) { }
                        //SpinUntil(() => (mRecord.GetStatus() != ELoopStatus.IsWaiting));
                    }

                    if (mRecord.GetStatus() == ELoopStatus.IsStopping)
                    {
                        mRecord.SetStatus(ELoopStatus.IsStopped);
                    }
                }
                catch (Exception mException)
                {
                    mException.zzSaveMemberInfo(mException.StackTrace, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
                }
                finally
                { }
            }

            //mRecord.SetStatus(ELoopStatus.IsStopped);
        }
        #endregion

        #region InBackground
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCondition"></param>
        /// <param name="iOptions"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static LoopRecord SpinUntilInBackground(Func<LoopResult> iCondition, TaskCreationOptions iOptions = TaskCreationOptions.None, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            int mUniqueThreadID = ThreadLocalInformation.GetUniqueID();
            LoopRecord mRecord = null;

            Task.Factory.StartNew(() =>
            {
                ThreadLocalInformation.Initialize();
                ResetLocalRecord();
                mUniqueThreadID = ThreadLocalInformation.GetUniqueID();

                SpinUntilAndRecord(iCondition, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
            },
            iOptions);

            SpinUntil(() =>
            {
                if (mUniqueThreadID == ThreadLocalInformation.GetUniqueID())
                {
                    return LoopResult.Continue;
                }
                else if ((mRecord = TryToGetRecord(mUniqueThreadID)).zzIsNull())
                {
                    return LoopResult.Continue;
                }

                return LoopResult.Break;
            },
            iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            return mRecord;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioArgument"></param>
        /// <param name="iCondition"></param>
        /// <param name="iOptions"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static LoopRecord SpinUntilInBackground<T>(T ioArgument, Func<T, LoopResult> iCondition, TaskCreationOptions iOptions = TaskCreationOptions.None, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            int mUniqueThreadID = ThreadLocalInformation.GetUniqueID();
            LoopRecord mRecord = null;

            Task.Factory.StartNew(() =>
            {
                ThreadLocalInformation.Initialize();
                ResetLocalRecord();
                mUniqueThreadID = ThreadLocalInformation.GetUniqueID();

                SpinUntilAndRecord(ioArgument, iCondition, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
            },
            iOptions);

            SpinUntil(() =>
            {
                if (mUniqueThreadID == ThreadLocalInformation.GetUniqueID())
                {
                    return LoopResult.Continue;
                }
                else if ((mRecord = TryToGetRecord(mUniqueThreadID)).zzIsNull())
                {
                    return LoopResult.Continue;
                }

                return LoopResult.Break;
            },
            iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            return mRecord;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCondition"></param>
        /// <param name="iMillisecondsTimeout"></param>
        /// <param name="iOptions"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static LoopRecord SpinUntilInBackground(Func<LoopResult> iCondition, int iMillisecondsTimeout, TaskCreationOptions iOptions = TaskCreationOptions.None, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            int mUniqueThreadID = ThreadLocalInformation.GetUniqueID();
            LoopRecord mRecord = null;

            Task.Factory.StartNew(() =>
            {
                ThreadLocalInformation.Initialize();
                ResetLocalRecord();
                mUniqueThreadID = ThreadLocalInformation.GetUniqueID();

                SpinUntilAndRecord(iCondition, iMillisecondsTimeout, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
            },
            iOptions);

            SpinUntil(() =>
            {
                if (mUniqueThreadID == ThreadLocalInformation.GetUniqueID())
                {
                    return LoopResult.Continue;
                }
                else if ((mRecord = TryToGetRecord(mUniqueThreadID)).zzIsNull())
                {
                    return LoopResult.Continue;
                }

                return LoopResult.Break;
            },
            iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            return mRecord;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioArgument"></param>
        /// <param name="iCondition"></param>
        /// <param name="iMillisecondsTimeout"></param>
        /// <param name="iOptions"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static LoopRecord SpinUntilInBackground<T>(T ioArgument, Func<T, LoopResult> iCondition, int iMillisecondsTimeout, TaskCreationOptions iOptions = TaskCreationOptions.None, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            int mUniqueThreadID = ThreadLocalInformation.GetUniqueID();
            LoopRecord mRecord = null;

            Task.Factory.StartNew(() =>
            {
                ThreadLocalInformation.Initialize();
                ResetLocalRecord();
                mUniqueThreadID = ThreadLocalInformation.GetUniqueID();

                SpinUntilAndRecord(ioArgument, iCondition, iMillisecondsTimeout, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
            },
            iOptions);

            SpinUntil(() =>
            {
                if (mUniqueThreadID == ThreadLocalInformation.GetUniqueID())
                {
                    return LoopResult.Continue;
                }
                else if ((mRecord = TryToGetRecord(mUniqueThreadID)).zzIsNull())
                {
                    return LoopResult.Continue;
                }

                return LoopResult.Break;
            },
            iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            return mRecord;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCondition"></param>
        /// <param name="iTimeout"></param>
        /// <param name="iOptions"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static LoopRecord SpinUntilInBackground(Func<LoopResult> iCondition, TimeSpan iTimeout, TaskCreationOptions iOptions = TaskCreationOptions.None, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            int mUniqueThreadID = ThreadLocalInformation.GetUniqueID();
            LoopRecord mRecord = null;

            Task.Factory.StartNew(() =>
            {
                ThreadLocalInformation.Initialize();
                ResetLocalRecord();
                mUniqueThreadID = ThreadLocalInformation.GetUniqueID();

                SpinUntilAndRecord(iCondition, iTimeout, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
            },
            iOptions);

            SpinUntil(() =>
            {
                if (mUniqueThreadID == ThreadLocalInformation.GetUniqueID())
                {
                    return LoopResult.Continue;
                }
                else if ((mRecord = TryToGetRecord(mUniqueThreadID)).zzIsNull())
                {
                    return LoopResult.Continue;
                }

                return LoopResult.Break;
            },
            iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            return mRecord;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioArgument"></param>
        /// <param name="iCondition"></param>
        /// <param name="iTimeout"></param>
        /// <param name="iOptions"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static LoopRecord SpinUntilInBackground<T>(T ioArgument, Func<T, LoopResult> iCondition, TimeSpan iTimeout, TaskCreationOptions iOptions = TaskCreationOptions.None, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            int mUniqueThreadID = ThreadLocalInformation.GetUniqueID();
            LoopRecord mRecord = null;

            Task.Factory.StartNew(() =>
            {
                ThreadLocalInformation.Initialize();
                ResetLocalRecord();
                mUniqueThreadID = ThreadLocalInformation.GetUniqueID();

                SpinUntilAndRecord(ioArgument, iCondition, iTimeout, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
            },
            iOptions);

            SpinUntil(() =>
            {
                if (mUniqueThreadID == ThreadLocalInformation.GetUniqueID())
                {
                    return LoopResult.Continue;
                }
                else if ((mRecord = TryToGetRecord(mUniqueThreadID)).zzIsNull())
                {
                    return LoopResult.Continue;
                }

                return LoopResult.Break;
            },
            iCallerMemberName, iCallerFilePath, iCallerLineNumber);

            return mRecord;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCondition"></param>
        /// <param name="iOptions"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static LoopRecord WhileInBackground(Func<LoopResult> iCondition, TaskCreationOptions iOptions = TaskCreationOptions.None, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            int mUniqueThreadID = ThreadLocalInformation.GetUniqueID();
            LoopRecord mRecord = null;

            Task.Factory.StartNew(() =>
            {
                ThreadLocalInformation.Initialize();
                ResetLocalRecord();
                mUniqueThreadID = ThreadLocalInformation.GetUniqueID();

                WhileAndRecord(iCondition, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
            },
            iOptions);

            while (true)
            {
                if (mUniqueThreadID == ThreadLocalInformation.GetUniqueID())
                {
                    continue;
                }
                else if ((mRecord = TryToGetRecord(mUniqueThreadID)).zzIsNull())
                {
                    continue;
                }

                break;
            }

            return mRecord;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioArgument"></param>
        /// <param name="iCondition"></param>
        /// <param name="iOptions"></param>
        /// <param name="iCallerMemberName"></param>
        /// <param name="iCallerFilePath"></param>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static LoopRecord WhileInBackground<T>(T ioArgument, Func<T, LoopResult> iCondition, TaskCreationOptions iOptions = TaskCreationOptions.None, [CallerMemberName] string iCallerMemberName = ConstString.Empty, [CallerFilePath] string iCallerFilePath = ConstString.Empty, [CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            int mUniqueThreadID = ThreadLocalInformation.GetUniqueID();
            LoopRecord mRecord = null;

            Task.Factory.StartNew(() =>
            {
                ThreadLocalInformation.Initialize();
                ResetLocalRecord();
                mUniqueThreadID = ThreadLocalInformation.GetUniqueID();

                WhileAndRecord(ioArgument, iCondition, iCallerMemberName, iCallerFilePath, iCallerLineNumber);
            },
            iOptions);

            while (true)
            {
                if (mUniqueThreadID == ThreadLocalInformation.GetUniqueID())
                {
                    continue;
                }
                else if ((mRecord = TryToGetRecord(mUniqueThreadID)).zzIsNull())
                {
                    continue;
                }

                break;
            }

            return mRecord;
        }
        #endregion
    }
}
