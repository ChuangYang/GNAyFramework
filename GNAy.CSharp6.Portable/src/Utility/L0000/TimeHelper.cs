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

namespace GNAy.CSharp6.Portable.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class TimeHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static TimeSpan zGetUtcElapsedTime(this DateTime ioSource)
        {
            return (DateTime.UtcNow - ioSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static TimeSpan zGetLocalElapsedTime(this DateTime ioSource)
        {
            return (DateTime.Now - ioSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static TimeSpan zGetElapsedTime(this DateTime ioSource)
        {
            if (ioSource.Kind == DateTimeKind.Utc)
            {
                return zGetUtcElapsedTime(ioSource);
            }
            else if (ioSource.Kind == DateTimeKind.Local)
            {
                return zGetLocalElapsedTime(ioSource);
            }

            throw new ArgumentException("ioSource.Kind == DateTimeKind.Unspecified");
        }
    }
}
