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
using GNAy.CSharp6.Portable.Const.L0000_ConstNumberValue;
using GNAy.CSharp6.Portable.Const.L0010_ConstValue;
using GNAy.CSharp6.Portable.Threading.L0030_ThreadLocalInformation;
using GNAy.CSharp6.Portable.Utility.L0010_TimeHelper;
using GNAy.CSharp6.Portable.Utility.L0020_CollectionTHelper;
using GNAy.CSharp6.Portable.Utility.L0020_StringHelper;
#else
using GNAy.CSharp6.Portable.Const;
using GNAy.CSharp6.Portable.Threading;
using GNAy.CSharp6.Portable.Utility;
#endif
#endregion

#region Alias.
#if Development
using PortableThreadSafeRandom = GNAy.CSharp6.Portable.Threading.L0040_ThreadSafeRandom.ThreadSafeRandom;
#else
using PortableThreadSafeRandom = GNAy.CSharp6.Portable.Threading.ThreadSafeRandom;
#endif
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Tests.Threading.L0041_ThreadSafeRandom
#else
namespace GNAy.CSharp6.Portable.Tests.Threading
#endif
{
    /// <summary>
    /// <para>Don't use GNAy.CSharp6.Portable.Tests.Threading.</para>
    /// </summary>
    public class ThreadSafeRandom
    {
        static ThreadSafeRandom()
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
        public void CheckSeedValuesNoDuplicate()
        {
            const int mLoopTimes = ConstNumberValue.Twenty;
            const int mParallelCount = ConstNumberValue.Twenty;

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

            Debug.WriteLine(StringHelper.DefaultJoin(ThreadLocalInformation.GetCreationTimeValues().Count, string.Join(", ", ThreadLocalInformation.GetCreationTimeValues())));
            Debug.WriteLine(StringHelper.DefaultJoin(ThreadLocalInformation.GetGuidValues().Count, string.Join(", ", ThreadLocalInformation.GetGuidValues())));
            Debug.WriteLine(StringHelper.DefaultJoin(ThreadLocalInformation.GetUniqueIDValues().Count, string.Join(", ", ThreadLocalInformation.GetUniqueIDValues())));

            if (!mActual1)
            {
                for (int i = ConstValue.StartIndex; i < ThreadLocalInformation.GetUniqueIDValues().zzGetLastIndex(); ++i)
                {
                    for (int j = (i + ConstNumberValue.One); j < ThreadLocalInformation.GetUniqueIDValues().Count; ++j)
                    {
                        if (j == i)
                        {
                            Debug.WriteLine(StringHelper.DefaultJoin(i, j, ThreadLocalInformation.GetUniqueIDValues()[i]));
                        }
                    }
                }
            }

            //assert
            Contract.Assert(mActual1);
        }

        /// <summary>
        /// 
        /// </summary>
        public void PrintTimeAndThreadAndValue()
        {
            const int mLoopTimes = ConstNumberValue.Five;
            const int mParallelCount = ConstNumberValue.Ten;

            //arrange
            bool mActual1 = false;

            //act
            CheckSeedValuesNoDuplicate();

            Parallel.For(ConstValue.StartIndex, mParallelCount, i =>
            {
                for (int j = ConstValue.StartIndex; j < mLoopTimes; ++j)
                {
                    Debug.WriteLine(StringHelper.DefaultJoin(TimeHelper.GetTimeNowByPreprocessor().Ticks, ThreadLocalInformation.GetCreationTime().Ticks, ThreadLocalInformation.GetUniqueID(), i, j, PortableThreadSafeRandom.GetInstance().Next()));
                }
            });

            mActual1 = PortableThreadSafeRandom.CheckSeedValuesNoDuplicate();

            Debug.WriteLine(StringHelper.DefaultJoin(ThreadLocalInformation.GetCreationTimeValues().Count, string.Join(", ", ThreadLocalInformation.GetCreationTimeValues())));
            Debug.WriteLine(StringHelper.DefaultJoin(ThreadLocalInformation.GetGuidValues().Count, string.Join(", ", ThreadLocalInformation.GetGuidValues())));
            Debug.WriteLine(StringHelper.DefaultJoin(ThreadLocalInformation.GetUniqueIDValues().Count, string.Join(", ", ThreadLocalInformation.GetUniqueIDValues())));

            if (!mActual1)
            {
                for (int i = ConstValue.StartIndex; i < ThreadLocalInformation.GetUniqueIDValues().zzGetLastIndex(); ++i)
                {
                    for (int j = (i + ConstNumberValue.One); j < ThreadLocalInformation.GetUniqueIDValues().Count; ++j)
                    {
                        if (j == i)
                        {
                            Debug.WriteLine(StringHelper.DefaultJoin(i, j, ThreadLocalInformation.GetUniqueIDValues()[i]));
                        }
                    }
                }
            }

            //assert
            Contract.Assert(mActual1);
        }
    }
}
