using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Threading;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#if Development
using GNAy.CSharp6.Portable.Const.L0000_ConstNumberValue;
using GNAy.CSharp6.Portable.Const.L0010_ConstValue;
using GNAy.CSharp6.Portable.Utility.L0020_ThreadLocalInformation;
#else
using GNAy.CSharp6.Portable.Const;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0030_ThreadSafeRandom
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public static class ThreadSafeRandom
    {
        private static readonly ThreadLocal<Random> _localRandom;

        static ThreadSafeRandom()
        {
            _localRandom = new ThreadLocal<Random>(() => new Random(ThreadLocalInformation.GetUniqueID()), true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Random GetInstance()
        {
            return _localRandom.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool CheckSeedValuesNoDuplicate()
        {
            for (int i = ConstValue.StartIndex; i < (ThreadLocalInformation.GetUniqueIDValues().Count - ConstNumberValue.One); ++i)
            {
                for (int j = (i + ConstNumberValue.One); j < ThreadLocalInformation.GetUniqueIDValues().Count; ++j)
                {
                    if (j == i)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
