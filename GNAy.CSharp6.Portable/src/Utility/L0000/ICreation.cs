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
namespace GNAy.CSharp6.Portable.Utility.L0000_ICreation
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICreation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DateTime GetCreationTime();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsCreated();
    }
}
