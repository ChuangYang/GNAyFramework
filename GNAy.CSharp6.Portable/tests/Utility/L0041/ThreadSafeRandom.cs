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
using GNAy.CSharp6.Portable.Const;
using GNAy.CSharp6.Portable.Utility;
#endregion

#region Alias.
using PortableThreadSafeRandom = GNAy.CSharp6.Portable.Utility.ThreadSafeRandom;
#endregion

namespace GNAy.CSharp6.Portable.Tests.Utility
{
    /// <summary>
    /// <para>Don't use GNAy.CSharp6.Portable.Tests.Utility.</para>
    /// </summary>
    public class ThreadSafeRandom
    {
        static ThreadSafeRandom()
        {
            CSharp6.Portable.Tests.Sample.UnitTest.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        public ThreadSafeRandom()
        { }

        /// <summary>
        /// 
        /// </summary>
        public void CheckSeedValuesNoDuplicate()
        {
            const int mLoopTimes = 20;
            const int mParallelCount = 20;

            //arrange
            bool mActual1 = false;

            //act
            for (int i = ConstValue.StartIndex; i < mLoopTimes; ++i)
            {
                Parallel.For(ConstValue.StartIndex, mParallelCount, j =>
                {
                    PortableThreadSafeRandom.GetInstance().Next();
                });
            }

            mActual1 = PortableThreadSafeRandom.CheckSeedValuesNoDuplicate();

            Debug.WriteLine($"[{ThreadUniqueNumber.GetCreationTimeValues().Count}][{string.Join(", ", ThreadUniqueNumber.GetCreationTimeValues())}]");
            Debug.WriteLine($"[{ThreadUniqueNumber.GetGuidValues().Count}][{string.Join(", ", ThreadUniqueNumber.GetGuidValues())}]");
            Debug.WriteLine($"[{ThreadUniqueNumber.GetNumberValues().Count}][{string.Join(", ", ThreadUniqueNumber.GetNumberValues())}]");

            if (!mActual1)
            {
                for (int i = ConstValue.StartIndex; i < (ThreadUniqueNumber.GetNumberValues().Count - ConstNumberValue.One); ++i)
                {
                    for (int j = (i + ConstNumberValue.One); j < ThreadUniqueNumber.GetNumberValues().Count; ++j)
                    {
                        if (j == i)
                        {
                            Debug.WriteLine($"[{i}][{j}][{ThreadUniqueNumber.GetNumberValues()[i]}]");
                        }
                    }
                }
            }

            //assert
            Contract.Assert(mActual1);
        }
    }
}
