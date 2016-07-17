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
using GNAy.CSharp6.Portable.Const;
#endregion

#region Alias.
#endregion

namespace GNAy.CSharp6.Portable.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class CallerMember
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCallerMemberName"></param>
        /// <returns></returns>
        public static string GetThisFunctionName([CallerMemberName] string iCallerMemberName = ConstString.Empty)
        {
            return iCallerMemberName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCallerFilePath"></param>
        /// <returns></returns>
        public static string GetThisFilePath([CallerFilePath] string iCallerFilePath = ConstString.Empty)
        {
            return iCallerFilePath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCallerLineNumber"></param>
        /// <returns></returns>
        public static int GetThisLineNumber([CallerLineNumber] int iCallerLineNumber = ConstNumberValue.Zero)
        {
            return iCallerLineNumber;
        }
    }
}
