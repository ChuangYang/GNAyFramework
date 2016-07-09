using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Runtime.CompilerServices;
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
    public static class ThreadSafe
    {
        private static readonly ThreadLocal<int> _localSeed;
        private static readonly ThreadLocal<Random> _localRandom;

        static ThreadSafe()
        {
            _localSeed = new ThreadLocal<int>(() => (ThreadLocal.GetCreationTime().GetHashCode() ^ ThreadLocal.GetGuid().GetHashCode()), true);
            _localRandom = new ThreadLocal<Random>(() => new Random(GetSeed()), true);
        }

        /// <summary>
        /// Initialize the static instance.
        /// </summary>
        public static void Initialize()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetSeed()
        {
            return _localSeed.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Random GetRandom()
        {
            return _localRandom.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IList<int> GetSeedValues()
        {
            return _localSeed.Values;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool CheckSeedValuesNoDuplicate()
        {
            for (int i = ConstValue.StartIndex; i < (GetSeedValues().Count - ConstNumberValue.One); ++i)
            {
                for (int j = (i + ConstNumberValue.One); j < GetSeedValues().Count; ++j)
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
