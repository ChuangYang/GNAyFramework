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
using GNAy.CSharp6.Portable.Const.L0010_ConstValue;
using GNAy.CSharp6.Portable.Utility.L0020_CollectionTHelper;
#else
using GNAy.CSharp6.Portable.Const;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0030_ListTHelper
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public static class ListTHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static T zzGetFirstItem<T>(this List<T> ioSource)
        {
            return ioSource[ConstValue.StartIndex];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static T zzGetLastItem<T>(this List<T> ioSource)
        {
            return ioSource[ioSource.zzGetLastIndex()];
        }
    }
}
