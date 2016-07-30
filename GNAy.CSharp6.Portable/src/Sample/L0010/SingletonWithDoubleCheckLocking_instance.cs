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
namespace GNAy.CSharp6.Portable.Sample.L0010_SingletonWithDoubleCheckLocking
#else
namespace GNAy.CSharp6.Portable.Sample
#endif
{
    /// <summary>
    /// 
    /// </summary>
    //[Serializable] //The singleton object may not be serialized, or it can be copied deeply.
    internal partial class SingletonWithDoubleCheckLocking
    {
        private SingletonWithDoubleCheckLocking() //If the constructor is protected, the singleton object can be inherited.
        {
            //
        }
    }
}
