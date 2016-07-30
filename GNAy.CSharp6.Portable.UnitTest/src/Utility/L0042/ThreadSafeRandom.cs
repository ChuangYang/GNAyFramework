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
namespace GNAy.CSharp6.Portable.UnitTest.Utility.L0042_ThreadSafeRandom
#else
namespace GNAy.CSharp6.Portable.UnitTest.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class ThreadSafeRandom
    {
#if Development
        private static CSharp6.Portable.Tests.Utility.L0041_ThreadSafeRandom.ThreadSafeRandom _threadSafeRandom;
#else
        private static CSharp6.Portable.Tests.Utility.ThreadSafeRandom _threadSafeRandom;
#endif

        static ThreadSafeRandom()
        {
#if Development
            _threadSafeRandom = new CSharp6.Portable.Tests.Utility.L0041_ThreadSafeRandom.ThreadSafeRandom();
#else
            _threadSafeRandom = new CSharp6.Portable.Tests.Utility.ThreadSafeRandom();
#endif
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //[TestMethod]
        //public void CheckSeedValuesNoDuplicate()
        //{
        //    _threadSafeRandom.CheckSeedValuesNoDuplicate();
        //}
        //[5][2016/7/23 上午 08:32:04, 2016/7/23 上午 08:32:04, 2016/7/23 上午 08:32:04, 2016/7/23 上午 08:32:04, 2016/7/23 上午 08:32:04]
        //[5][c13cb7bc-8eae-4c40-b4c9-7143aa698212, 4af0d526-7bac-4333-9278-d2815b424d86, 91d0fb14-b781-447c-9f8b-bf0008bdbd99, 1d2d2d43-b1f6-42a7-9865-386da8ed8b41, 95c956aa-4bd3-4d7c-a5d5-8290bd7c1860]
        //[5][1435533017, -2007100508, -229426490, -2495854, 924367276]


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void PrintTimeAndThreadAndValue()
        {
            _threadSafeRandom.PrintTimeAndThreadAndValue();
        }
        //[5][2016/7/23 上午 08:32:04, 2016/7/23 上午 08:32:04, 2016/7/23 上午 08:32:04, 2016/7/23 上午 08:32:04, 2016/7/23 上午 08:32:04]
        //[5][c13cb7bc-8eae-4c40-b4c9-7143aa698212, 4af0d526-7bac-4333-9278-d2815b424d86, 91d0fb14-b781-447c-9f8b-bf0008bdbd99, 1d2d2d43-b1f6-42a7-9865-386da8ed8b41, 95c956aa-4bd3-4d7c-a5d5-8290bd7c1860]
        //[5][1435533017, -2007100508, -229426490, -2495854, 924367276]
        //[636048595242797475][636048595242762369][924367276][0][0][2074081543]
        //[636048595242802484][636048595242762369][924367276][0][1][1537133215]
        //[636048595242802484][636048595242762369][924367276][0][2][631153217]
        //[636048595242802484][636048595242762369][924367276][0][3][1430674927]
        //[636048595242802484][636048595242762369][924367276][0][4][96168403]
        //[636048595242802484][636048595242762369][924367276][1][0][1905406456]
        //[636048595242802484][636048595242762369][924367276][1][1][208753131]
        //[636048595242802484][636048595242762369][924367276][1][2][1886593193]
        //[636048595242802484][636048595242762369][924367276][1][3][1098894078]
        //[636048595242802484][636048595242762369][924367276][1][4][1246628214]
        //[636048595242802484][636048595242762369][924367276][3][0][548935410]
        //[636048595242802484][636048595242772396][-2495854][2][0][1820447616]
        //[636048595242807498][636048595242772396][-2495854][2][1][1589155348]
        //[636048595242807498][636048595242772396][-2495854][2][2][2040613259]
        //[636048595242807498][636048595242772396][-2495854][2][3][1493724577]
        //[636048595242807498][636048595242772396][-2495854][2][4][1922609316]
        //[636048595242807498][636048595242772396][-2495854][4][0][14881987]
        //[636048595242807498][636048595242772396][-2495854][4][1][1000042549]
        //[636048595242807498][636048595242772396][-2495854][4][2][1716150810]
        //[636048595242807498][636048595242772396][-2495854][4][3][377440052]
        //[636048595242807498][636048595242772396][-2495854][4][4][272711383]
        //[636048595242807498][636048595242772396][-2495854][5][0][1585216890]
        //[636048595242812511][636048595242772396][-2495854][5][1][231288225]
        //[636048595242812511][636048595242772396][-2495854][5][2][1426603156]
        //[636048595242812511][636048595242772396][-2495854][5][3][1209254929]
        //[636048595242812511][636048595242772396][-2495854][5][4][16030153]
        //[636048595242812511][636048595242772396][-2495854][6][0][1565564084]
        //[636048595242812511][636048595242772396][-2495854][6][1][1708908928]
        //[636048595242812511][636048595242772396][-2495854][6][2][878812584]
        //[636048595242812511][636048595242772396][-2495854][6][3][363264064]
        //[636048595242812511][636048595242772396][-2495854][6][4][603897385]
        //[636048595242812511][636048595242772396][-2495854][7][0][914788345]
        //[636048595242812511][636048595242772396][-2495854][7][1][1767418921]
        //[636048595242812511][636048595242772396][-2495854][7][2][736426230]
        //[636048595242812511][636048595242772396][-2495854][7][3][1400033206]
        //[636048595242812511][636048595242772396][-2495854][7][4][892672751]
        //[636048595242812511][636048595242772396][-2495854][8][0][1627686940]
        //[636048595242812511][636048595242772396][-2495854][8][1][1486620209]
        //[636048595242812511][636048595242772396][-2495854][8][2][1841972582]
        //[636048595242812511][636048595242772396][-2495854][8][3][79493025]
        //[636048595242812511][636048595242772396][-2495854][8][4][1997799954]
        //[636048595242812511][636048595242772396][-2495854][9][0][910382664]
        //[636048595242812511][636048595242772396][-2495854][9][1][15699969]
        //[636048595242812511][636048595242772396][-2495854][9][2][1298163785]
        //[636048595242812511][636048595242772396][-2495854][9][3][1088883396]
        //[636048595242812511][636048595242772396][-2495854][9][4][268680855]
        //[636048595242807498][636048595242762369][924367276][3][1][309925370]
        //[636048595242837642][636048595242762369][924367276][3][2][1252314470]
        //[636048595242837642][636048595242762369][924367276][3][3][196494776]
        //[636048595242837642][636048595242762369][924367276][3][4][1655839869]
        //[5][2016/7/23 上午 08:32:04, 2016/7/23 上午 08:32:04, 2016/7/23 上午 08:32:04, 2016/7/23 上午 08:32:04, 2016/7/23 上午 08:32:04]
        //[5][c13cb7bc-8eae-4c40-b4c9-7143aa698212, 4af0d526-7bac-4333-9278-d2815b424d86, 91d0fb14-b781-447c-9f8b-bf0008bdbd99, 1d2d2d43-b1f6-42a7-9865-386da8ed8b41, 95c956aa-4bd3-4d7c-a5d5-8290bd7c1860]
        //[5][1435533017, -2007100508, -229426490, -2495854, 924367276]
    }
}
