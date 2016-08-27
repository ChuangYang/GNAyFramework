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
#else
using GNAy.CSharp6.Portable.Const;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0020_StringHelper
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static bool zzIsNotEmpty(this string ioSource)
        {
            return !string.IsNullOrEmpty(ioSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static bool zzIsNotWhiteSpace(this string ioSource)
        {
            return !string.IsNullOrWhiteSpace(ioSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static int zzGetLastIndex(this string ioSource)
        {
            return (ioSource.Length - ConstNumberValue.One);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static char zzGetFirstChar(this string ioSource)
        {
            return ioSource[ConstValue.StartIndex];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static char zzGetLastChar(this string ioSource)
        {
            return ioSource[zzGetLastIndex(ioSource)];
        }
    }
}
