using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0000_EMemberStatus
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public enum EMemberStatus
    {
        /// <summary>
        /// 0
        /// </summary>
        Unknown,

        /// <summary>
        /// 1
        /// </summary>
        IsRunning,

        /// <summary>
        /// 2
        /// </summary>
        IsFinished,

        /// <summary>
        /// 3
        /// </summary>
        HasException,
    }
}
