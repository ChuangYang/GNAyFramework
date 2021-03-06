﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

#region .NET Framework namespace.
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.UnitTest.Threading.L0052_ThreadLocalMemberObserver
#else
namespace GNAy.CSharp6.Portable.UnitTest.Threading
#endif
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class ThreadLocalMemberObserver
    {
#if Development
        private static CSharp6.Portable.Tests.Threading.L0051_ThreadLocalMemberObserver.ThreadLocalMemberObserver _threadLocalMemberObserver;
#else
        private static CSharp6.Portable.Tests.Threading.ThreadLocalMemberObserver _threadLocalMemberObserver;
#endif

        static ThreadLocalMemberObserver()
        {
#if Development
            _threadLocalMemberObserver = new CSharp6.Portable.Tests.Threading.L0051_ThreadLocalMemberObserver.ThreadLocalMemberObserver();
#else
            _threadLocalMemberObserver = new CSharp6.Portable.Tests.Threading.ThreadLocalMemberObserver();
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void SaevMemebrInfo()
        {
            _threadLocalMemberObserver.SaveMemberInfo();
        }
        //[636061522767354369][636061522767344342][10027]
        //[IsFinished][IsRunning]
        //[-42819511][1870254681]
        //[SaveMemberInfo][C:\GNAy Framework\GNAy.CSharp6.Portable\tests\Threading\ThreadLocalMemberObserver.cs]
        //[73][72][1]
        //[][]
    }
}
