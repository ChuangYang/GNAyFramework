﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Threading;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0000_TimeHelper
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public static class TimeHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public const string DefaultSQLTimeFormat = "yyyy-MM-dd HH:mm:ss.fffffff";

        /// <summary>
        /// Utc or Local.
        /// </summary>
        public static readonly DateTimeKind KindByPreprocessor;

        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime TimeMin;

        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime TimeMax;

        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime TimeDefault;

        /// <summary>
        /// 0.0001 millisecond.
        /// </summary>
        public static readonly TimeSpan MinTimeUnit;

        /// <summary>
        /// -1 millisecond.
        /// </summary>
        public static readonly TimeSpan InfiniteTimeSpan;

        static TimeHelper()
        {
#if LocalTime
            KindByPreprocessor = DateTimeKind.Local;
#else
            KindByPreprocessor = DateTimeKind.Utc;
#endif

            TimeMin = new DateTime(DateTime.MinValue.Ticks, KindByPreprocessor);
            TimeMax = new DateTime(DateTime.MaxValue.Ticks, KindByPreprocessor);
            TimeDefault = TimeMin;

            MinTimeUnit = new TimeSpan(1);
            InfiniteTimeSpan = Timeout.InfiniteTimeSpan;
        }

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
        public static TimeSpan zGetElapsedTimeByKind(this DateTime ioSource)
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

#if LocalTime
        /// <summary>
        /// LocalTime
        /// </summary>
        /// <returns></returns>
        public static DateTime GetTimeNowByPreprocessor()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// LocalTime
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static TimeSpan zGetElapsedTimeByPreprocessor(this DateTime ioSource)
        {
            return (DateTime.Now - ioSource);
        }
#else
        /// <summary>
        /// UTCTTime
        /// </summary>
        /// <returns></returns>
        public static DateTime GetTimeNowByPreprocessor()
        {
            return DateTime.UtcNow;
        }

        /// <summary>
        /// UTCTTime
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static TimeSpan zGetElapsedTimeByPreprocessor(this DateTime ioSource)
        {
            return (DateTime.UtcNow - ioSource);
        }
#endif

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iFormat"></param>
        /// <returns></returns>
        public static string zToSQLFormat(this DateTime iSource, string iFormat = DefaultSQLTimeFormat)
        {
            return iSource.ToString(iFormat);
        }
    }
}
