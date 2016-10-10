using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics;
using System.Diagnostics.Contracts;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#if Development
using GNAy.CSharp6.Portable.Utility.L0000_EMemberStatus;
using GNAy.CSharp6.Portable.Utility.L0020_CallerService;
using GNAy.CSharp6.Portable.Utility.L0020_StringHelper;
using GNAy.CSharp6.Portable.Utility.L0040_MemberInformation;
#else
using GNAy.CSharp6.Portable.Utility;
#endif
#endregion

#region Alias.
#if Development
using PortableThreadLocalMemberObserver = GNAy.CSharp6.Portable.Threading.L0050_ThreadLocalMemberObserver.ThreadLocalMemberObserver;
#else
using PortableThreadLocalMemberObserver = GNAy.CSharp6.Portable.Threading.ThreadLocalMemberObserver;
#endif
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Tests.Threading.L0051_ThreadLocalMemberObserver
#else
namespace GNAy.CSharp6.Portable.Tests.Threading
#endif
{
    /// <summary>
    /// <para>Don't use GNAy.CSharp6.Portable.Tests.Threading.</para>
    /// </summary>
    public class ThreadLocalMemberObserver
    {
        static ThreadLocalMemberObserver()
        {
#if Development
            CSharp6.Portable.Tests.Sample.L0000_UnitTest.UnitTest.Initialize();
#else
            CSharp6.Portable.Tests.Sample.UnitTest.Initialize();
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        public void SaveMemberInfo()
        {
            //arrange
            MemberInformation mArgument1 = null;
            MemberInformation mArgument2 = null;
            bool mActual1 = false;
            bool mActual2 = false;
            bool mActual3 = false;
            bool mActual4 = false;
            bool mActual5 = false;
            bool mActual6 = false;
            bool mActual7 = false;
            bool mActual8 = false;
            bool mActual9 = false;

            //act
            mArgument1 = PortableThreadLocalMemberObserver.SaveMemberInfo(EMemberStatus.IsRunning);
            mArgument2 = PortableThreadLocalMemberObserver.SaveMemberInfo(EMemberStatus.IsFinished);

            mActual1 = (mArgument2.GetCreationTime() >= mArgument1.GetCreationTime());
            mActual2 = ((mArgument2.Status == EMemberStatus.IsFinished) && (mArgument1.Status == EMemberStatus.IsRunning));
            mActual3 = (mArgument2.UniqueThreadID == mArgument1.UniqueThreadID);
            mActual4 = (mArgument2.UniqueMemberID == mArgument1.UniqueMemberID);
            mActual5 = ((mArgument2.Name == mArgument1.Name) && (mArgument2.Name == CallerService.GetThisMemberName()));
            mActual6 = ((mArgument2.FilePath == mArgument1.FilePath) && (mArgument2.FilePath == CallerService.GetThisFilePath()));
            mActual7 = (mArgument2.LineNumber > mArgument1.LineNumber);
            mActual8 = (mArgument2.Exception == mArgument1.Exception);
            mActual9 = (mArgument2.ExceptionStackTrace == mArgument1.ExceptionStackTrace);

            Debug.WriteLine(StringHelper.DefaultJoin(mArgument2.GetCreationTime().Ticks, mArgument1.GetCreationTime().Ticks, (mArgument2.GetCreationTime().Ticks - mArgument1.GetCreationTime().Ticks)));
            Debug.WriteLine(StringHelper.DefaultJoin(mArgument2.Status, mArgument1.Status));
            Debug.WriteLine(StringHelper.DefaultJoin(mArgument2.UniqueThreadID, mArgument2.UniqueMemberID));
            Debug.WriteLine(StringHelper.DefaultJoin(mArgument2.Name, mArgument2.FilePath));
            Debug.WriteLine(StringHelper.DefaultJoin(mArgument2.LineNumber, mArgument1.LineNumber, (mArgument2.LineNumber - mArgument1.LineNumber)));
            Debug.WriteLine(StringHelper.DefaultJoin(mArgument2.Exception, mArgument2.ExceptionStackTrace));

            //assert
            Contract.Assert(mActual1);
            Contract.Assert(mActual2);
            Contract.Assert(mActual3);
            Contract.Assert(mActual4);
            Contract.Assert(mActual5);
            Contract.Assert(mActual6);
            Contract.Assert(mActual7);
            Contract.Assert(mActual8);
            Contract.Assert(mActual9);
        }
    }
}
