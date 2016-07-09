using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

#region .NET Framework namespace.
using System;
using System.Threading.Tasks;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Alias.
using PortableLocal = GNAy.CSharp6.Portable.Utility.ThreadLocal;
using PortableSafe = GNAy.CSharp6.Portable.Utility.ThreadSafe;
#endregion

namespace GNAy.CSharp6.Portable.UnitTest.Utility
{
    /// <summary>
    /// <para>Don't use GNAy.CSharp6.Portable.Tests.Utility.</para>
    /// </summary>
    [TestClass]
    public class ThreadSafe
    {
        static ThreadSafe()
        {
            CSharp6.Portable.Tests.Sample.UnitTest.Initialize();
        }

        /// <summary>
        /// Initialize the static instance.
        /// </summary>
        public static void Initialize()
        { }

        /// <summary>
        /// 
        /// </summary>
        public ThreadSafe()
        { }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void CheckSeedValuesNoDuplicate()
        {
            const int mLoopTimes = 20;
            const int mParallelCount = 20;

            //arrange
            bool mActual1 = false;

            //act
            for (int i = 0; i < mLoopTimes; ++i)
            {
                Parallel.For(0, mParallelCount, j =>
                {
                    PortableSafe.GetRandom().Next();
                });
            }

            mActual1 = PortableSafe.CheckSeedValuesNoDuplicate();

            Console.WriteLine($"[{PortableLocal.GetCreationTimeValues().Count}][{string.Join(", ", PortableLocal.GetCreationTimeValues())}]");
            Console.WriteLine($"[{PortableLocal.GetGuidValues().Count}][{string.Join(", ", PortableLocal.GetGuidValues())}]");
            Console.WriteLine($"[{PortableSafe.GetSeedValues().Count}][{string.Join(", ", PortableSafe.GetSeedValues())}]");

            if (!mActual1)
            {
                for (int i = 0; i < (PortableSafe.GetSeedValues().Count - 1); ++i)
                {
                    for (int j = (i + 1); j < PortableSafe.GetSeedValues().Count; ++j)
                    {
                        if (j == i)
                        {
                            Console.WriteLine($"[{i}][{j}][{PortableSafe.GetSeedValues()[i]}]");
                        }
                    }
                }
            }

            //assert
            Assert.IsTrue(mActual1);
        }
        //[6]
        //[2016/7/9 上午 02:40:17, 2016/7/9 上午 02:40:17, 2016/7/9 上午 02:40:17, 2016/7/9 上午 02:40:17, 2016/7/9 上午 02:40:17, 2016/7/9 上午 02:40:17]
        //[6]
        //[64f4e001-0779-4030-92a2-e4c425f02ebd, 09fc2853-e15c-48b0-bd06-a7ee3bfcafed, 63abb948-465b-4b4c-8f65-1e4711f3a33f, 294565f1-6c49-49d4-8e78-c697b555b604, 8f8894fc-a583-420f-a4f8-91f14a1cb0c2, 0dfadde2-54c7-4b05-ad62-2efe59841ab8]
        //[6]
        //[-739808100, 466267166, 1872379435, -681123791, -278848991, 592927311]
    }
}
