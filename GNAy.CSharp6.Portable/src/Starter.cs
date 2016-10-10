using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#if Development
using GNAy.CSharp6.Portable.Base.L0020_LibraryInformation;
using GNAy.CSharp6.Portable.Threading.L0030_ThreadLocalInformation;
using GNAy.CSharp6.Portable.Threading.L0050_ThreadLocalMemberObserver;
using GNAy.CSharp6.Portable.Utility.L0000_LoopResult;
using GNAy.CSharp6.Portable.Utility.L0000_ObjectHelper;
using GNAy.CSharp6.Portable.Utility.L0040_LoopRecord;
using GNAy.CSharp6.Portable.Utility.L0040_MemberInformation;
using GNAy.CSharp6.Portable.Utility.L0060_LoopObserver;
#else
using GNAy.CSharp6.Portable.Base;
using GNAy.CSharp6.Portable.Threading;
using GNAy.CSharp6.Portable.Utility;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.L9990_Starter
#else
namespace GNAy.CSharp6.Portable
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public static class Starter
    {
        private static LoopRecord _loopRecord;

        static Starter()
        {
            _loopRecord = null;
        }

        private static LoopResult memberInfoHandler()
        {
            MemberInformation mMemberInfo = null;

            while (ThreadLocalMemberObserver.MemberInfoCollection.TryDequeue(out mMemberInfo))
            {
                try
                {
                    ThreadLocalMemberObserver.MemberInfoHandler(mMemberInfo);
                }
                catch //(Exception mException)
                { }
                finally
                { }
            }

            return LoopResult.Continue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iMemberInfoHandler"></param>
        /// <param name="iBeforeEnqueueMemberInfo"></param>
        /// <param name="iTaskException"></param>
        public static void Register(Func<MemberInformation, bool> iMemberInfoHandler, Func<MemberInformation, bool> iBeforeEnqueueMemberInfo = null, EventHandler<UnobservedTaskExceptionEventArgs> iTaskException = null)
        {
            LibraryInformation.Initialize();
            ThreadLocalInformation.Initialize();

            if (_loopRecord.zzIsNotNull())
            {
                _loopRecord.Stop();

                //TODO: Wait.
            }

            if (iMemberInfoHandler.zzIsNull())
            {
                throw new ArgumentNullException(nameof(iMemberInfoHandler), "iMemberInfoHandler.zzIsNull()");
            }
            ThreadLocalMemberObserver.MemberInfoHandler = iMemberInfoHandler;

            if (iBeforeEnqueueMemberInfo.zzIsNotNull())
            {
                ThreadLocalMemberObserver.BeforeEnqueueMemberInfo = iBeforeEnqueueMemberInfo;
            }

            TaskScheduler.UnobservedTaskException += (iTaskException.zzIsNull() ? ThreadLocalMemberObserver.UnobservedTaskException : iTaskException);

            _loopRecord = LoopObserver.SpinUntilInBackground(memberInfoHandler, TaskCreationOptions.LongRunning);

            //TODO: Test self.
        }
    }
}
