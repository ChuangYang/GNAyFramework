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
using GNAy.CSharp6.Portable.Const;
#endregion

#region Alias.
#endregion

namespace GNAy.CSharp6.Portable.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class ThreadSafeRandom
    {
        private static readonly ThreadLocal<Random> _localRandom;

        static ThreadSafeRandom()
        {
            _localRandom = new ThreadLocal<Random>(() => new Random(ThreadUniqueNumber.GetNumber()), true);
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
            for (int i = ConstValue.StartIndex; i < (ThreadUniqueNumber.GetNumberValues().Count - ConstNumberValue.One); ++i)
            {
                for (int j = (i + ConstNumberValue.One); j < ThreadUniqueNumber.GetNumberValues().Count; ++j)
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
