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

namespace GNAy.CSharp6.Portable.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class GlobalData
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime CreationTime;

        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid Guid;

        /// <summary>
        /// 
        /// </summary>
        public static readonly int UniqueNumber;

        static GlobalData()
        {
            CreationTime = DateTime.UtcNow;
            Guid = Guid.NewGuid();
            UniqueNumber = (CreationTime.GetHashCode() ^ Guid.GetHashCode());
        }
    }
}
