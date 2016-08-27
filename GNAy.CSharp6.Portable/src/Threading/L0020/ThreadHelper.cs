using System;
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
#if Development
using GNAy.CSharp6.Portable.Utility.L0000_CommonEvent;
using GNAy.CSharp6.Portable.Utility.L0010_TimeHelper;
#else
using GNAy.CSharp6.Portable.Utility;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Threading.L0020_ThreadHelper
#else
namespace GNAy.CSharp6.Portable.Threading
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public class ThreadHelper
    {
        /// <summary>
        /// 0.0001 millisecond.
        /// </summary>
        public static void MinSleep()
        {
            SpinWait.SpinUntil(CommonEvent.ReturnFalse, TimeHelper.MinTimeUnit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iMillisecondsTimeout"></param>
        public static void Sleep(int iMillisecondsTimeout)
        {
            SpinWait.SpinUntil(CommonEvent.ReturnFalse, iMillisecondsTimeout);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iTimeout"></param>
        public static void Sleep(TimeSpan iTimeout)
        {
            SpinWait.SpinUntil(CommonEvent.ReturnFalse, iTimeout);
        }
    }
}
