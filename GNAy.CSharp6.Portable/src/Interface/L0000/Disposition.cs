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

namespace GNAy.CSharp6.Portable.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDisposition : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DateTime GetDispositionTime();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsDisposed();
    }
}
