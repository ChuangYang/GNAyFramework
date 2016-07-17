using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

#region .NET Framework namespace.
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Alias.
#endregion

namespace GNAy.CSharp6.Portable.UnitTest.ThreadSafeRandom
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class Portable
    {
        private static CSharp6.Portable.Tests.Utility.ThreadSafeRandom _threadSafeRandom;

        static Portable()
        {
            _threadSafeRandom = new CSharp6.Portable.Tests.Utility.ThreadSafeRandom();
        }

        /// <summary>
        /// 
        /// </summary>
        public Portable()
        { }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void CheckSeedValuesNoDuplicate()
        {
            _threadSafeRandom.CheckSeedValuesNoDuplicate();
        }
        //[5]
        //[2016/7/17 上午 08:30:43, 2016/7/17 上午 08:30:43, 2016/7/17 上午 08:30:43, 2016/7/17 上午 08:30:43, 2016/7/17 上午 08:30:43]
        //[5]
        //[788d4858-8e6a-4706-b627-3847bf5190f9, 3397436a-c2ce-4a36-b42a-c1930d9fbe0d, 75323f38-c6e3-4d50-a395-d97d51e6b553, 3454e4c3-6199-4022-a08a-713b6b5a3ae6, 32512493-2d1f-4784-a243-a888912c5c78]
        //[5]
        //[73513684, -86000606, -1604860088, -297070220, 2110314012]
    }
}
