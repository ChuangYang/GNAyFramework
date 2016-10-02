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
namespace GNAy.CSharp6.Portable.Utility.L0000_LoopResult
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// bool
    /// </summary>
    public struct LoopResult
    {
        /// <summary>
        /// false
        /// </summary>
        public const bool Continue = false;

        /// <summary>
        /// true
        /// </summary>
        public const bool Break = true;

        private bool _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iValue"></param>
        public static implicit operator LoopResult(bool iValue)
        {
            LoopResult mResult;
            mResult._value = iValue;

            //return new LoopResult { _value = iValue };
            return mResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iValue"></param>
        public static implicit operator bool(LoopResult iValue)
        {
            return iValue._value;
        }

        /// <summary>
        /// false
        /// </summary>
        /// <returns></returns>
        public static bool ReturnToContinue()
        {
            return Continue;
        }

        /// <summary>
        /// true
        /// </summary>
        /// <returns></returns>
        public static bool ReturnToBreak()
        {
            return Break;
        }
    }
}
