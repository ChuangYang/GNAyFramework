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
#if Development
using GNAy.CSharp6.Portable.Const.L0000_ConstNumberString;
using GNAy.CSharp6.Portable.Const.L0000_ConstNumberValue;
using GNAy.CSharp6.Portable.Const.L0000_PreprocessorDirective;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Const.Alias.L0001
#else
namespace GNAy.CSharp6.Portable.Const.Alias
#endif
{
    /// <summary>
    /// ConstNumberValue
    /// </summary>
    public class CNV : ConstNumberValue
    {
    }

    /// <summary>
    /// ConstNumberString
    /// </summary>
    public class CNS : ConstNumberString
    {
    }

    /// <summary>
    /// <para>PreprocessorDirective</para>
    /// <para>ConditionalAttribute.ConditionString</para>
    /// </summary>
    public class PD : PreprocessorDirective
    {
    }
}
