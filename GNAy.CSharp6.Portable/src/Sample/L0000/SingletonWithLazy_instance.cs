﻿using System;
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
    //[Serializable] //The singleton object may not be serialized, or it can be copied deeply.
    internal partial class SingletonWithLazy
    {
        private SingletonWithLazy() //If the constructor is protected, the singleton object can be inherited.
        {
            //
        }
    }
}
