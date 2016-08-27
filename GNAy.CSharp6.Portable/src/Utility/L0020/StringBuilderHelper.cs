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
using GNAy.CSharp6.Portable.Const.L0000_ConstNumberValue;
using GNAy.CSharp6.Portable.Const.L0010_ConstValue;
using GNAy.CSharp6.Portable.Utility.L0000_ObjectHelper;
#else
using GNAy.CSharp6.Portable.Const;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0020_StringBuilderHelper
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringBuilderHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static bool zzIsNullOrEmpty(this StringBuilder ioSource)
        {
            return (ioSource.zzIsNull() || (ioSource.Length == ConstValue.Empty));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static bool zzIsNotEmpty(this StringBuilder ioSource)
        {
            return !zzIsNullOrEmpty(ioSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static int zzGetLastIndex(this StringBuilder ioSource)
        {
            return (ioSource.Length - ConstNumberValue.One);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static char zzGetFirstChar(this StringBuilder ioSource)
        {
            return ioSource[ConstValue.StartIndex];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static char zzGetLastChar(this StringBuilder ioSource)
        {
            return ioSource[zzGetLastIndex(ioSource)];
        }
    }
}
