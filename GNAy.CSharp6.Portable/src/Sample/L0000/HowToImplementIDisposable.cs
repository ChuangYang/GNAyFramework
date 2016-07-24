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

namespace GNAy.CSharp6.Portable.Sample
{
    /// <summary>
    /// 
    /// </summary>
    internal class HowToImplementIDisposable : IDisposable
    {
        protected virtual void Dispose(bool iDisposeManagedResources) //i: The input parameter of the method.
        {
            if (iDisposeManagedResources)
            {
                //Do something.
            }

            //Free native resources.
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        ~HowToImplementIDisposable()
        {
            Dispose(false);
        }
    }
}
