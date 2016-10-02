using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Runtime.CompilerServices;
using System.Threading;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#if Development
using GNAy.CSharp6.Portable.Const.L0000_ConstNumberValue;
using GNAy.CSharp6.Portable.Const.L0010_ConstString;
using GNAy.CSharp6.Portable.Threading.L0050_ThreadLocalMemberObserver;
using GNAy.CSharp6.Portable.Utility.L0000_LoopResult;
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
            LoopResult mLoopResult = LoopResult.Continue;

            while (mLoopResult == LoopResult.Continue)
            {
                try
                {
                    mLoopResult = iCondition();
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
            LoopResult mLoopResult = LoopResult.Continue;

            while (mLoopResult == LoopResult.Continue)
            {
                try
                {
                    mLoopResult = iCondition(ioArgument);
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
    }
}
