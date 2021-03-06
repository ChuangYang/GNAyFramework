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
#if Development
using GNAy.CSharp6.Portable.Const.L0010_ConstString;
using GNAy.CSharp6.Portable.Const.L0010_ConstValue;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Const.Alias.L0011
#else
namespace GNAy.CSharp6.Portable.Const.Alias
#endif
{
    /// <summary>
    /// ConstValue
    /// </summary>
    public class CV : ConstValue
    {
    }

    /// <summary>
    /// ConstString
    /// </summary>
    public class CS : ConstString
    {
    }
}
