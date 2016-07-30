using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Runtime.CompilerServices;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#if Development
using GNAy.CSharp6.Portable.Const.L0000_ConstNumberValue;
using GNAy.CSharp6.Portable.Const.L0010_ConstString;
#else
using GNAy.CSharp6.Portable.Const;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0030_CallerService
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public static class CallerService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iName"></param>
        /// <returns></returns>
        public static string GetThisMemberName([CallerMemberName] string iName = ConstString.Empty)
        {
            return iName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iPath"></param>
        /// <returns></returns>
        public static string GetThisFilePath([CallerFilePath] string iPath = ConstString.Empty)
        {
            return iPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        public static int GetThisLineNumber([CallerLineNumber] int iNumber = ConstNumberValue.Zero)
        {
            return iNumber;
        }
    }
}
