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
namespace GNAy.CSharp6.Portable.Utility.L0000_ObjectHelper
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public static class ObjectHelper
    {
        /// <summary>
        /// <para>Equals may be overridden.</para>
        /// <para>Structure may be nullable or be boxed like an object class.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static bool zzIsNotNull<T>(this T ioSource)
        {
            return (ioSource is T);
        }

        /// <summary>
        /// <para>Equals may be overridden.</para>
        /// <para>Structure may be nullable or be boxed like an object class.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static bool zzIsNull<T>(this T ioSource)
        {
            return !zzIsNotNull(ioSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="ioTargetHashCode"></param>
        public static void zzGetHashCode<T>(this T ioSource, ref int ioTargetHashCode)
        {
            ioTargetHashCode ^= ioSource.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="iTargetHashCode"></param>
        /// <returns></returns>
        public static int zzGetHashCode<T>(this T ioSource, int iTargetHashCode)
        {
            return (iTargetHashCode ^ ioSource.GetHashCode());
        }
    }
}
