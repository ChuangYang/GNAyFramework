using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Runtime.InteropServices;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Alias.
#if Development
using GNAy.CSharp6.Portable.Utility.L0020_BaseEnumerationInformation;
#endif
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0030_EnumerationInformation
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// BaseEnumerationInformation&lt;int&gt;
    /// </summary>
    [ComVisible(false)]
    public class EnumerationInformation : BaseEnumerationInformation<int>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iValue"></param>
        /// <param name="iName"></param>
        /// <param name="iIsDefined"></param>
        /// <param name="iPosition"></param>
        /// <param name="ioRawCollection"></param>
        /// <param name="ioValueCollection"></param>
        /// <param name="ioNameCollection"></param>
        public EnumerationInformation(Enum iSource, int iValue, string iName, bool iIsDefined, int iPosition, Enum[] ioRawCollection, int[] ioValueCollection, string[] ioNameCollection) :
            base(iSource, iValue, iName, iIsDefined, iPosition, ioRawCollection, ioValueCollection, ioNameCollection)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iPosition"></param>
        /// <param name="ioRawCollection"></param>
        public EnumerationInformation(int iPosition, Enum[] ioRawCollection) :
            base(iPosition, ioRawCollection)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        public EnumerationInformation(Enum iSource) :
            base(iSource)
        { }
    }
}
