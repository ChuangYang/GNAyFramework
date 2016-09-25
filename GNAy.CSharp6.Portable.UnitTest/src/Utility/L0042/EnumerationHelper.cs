using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

#region .NET Framework namespace.
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.UnitTest.Utility.L0042_EnumerationHelper
#else
namespace GNAy.CSharp6.Portable.UnitTest.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class EnumerationHelper
    {
#if Development
        private static CSharp6.Portable.Tests.Utility.L0041_EnumerationHelper.EnumerationHelper _enumerationHelper;
#else
        private static CSharp6.Portable.Tests.Utility.EnumerationHelper _enumerationHelper;
#endif

        static EnumerationHelper()
        {
#if Development
            _enumerationHelper = new CSharp6.Portable.Tests.Utility.L0041_EnumerationHelper.EnumerationHelper();
#else
            _enumerationHelper = new CSharp6.Portable.Tests.Utility.EnumerationHelper();
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GetEnumInfo()
        {
            _enumerationHelper.GetEnumInfo();
        }
        //[Constructor, Method, Field, Delegate][True][True][True][True][Constructor][Method][Field][Delegate]
        //0
        //0
        //[4448][4448][True][655][610][1.07377049180328]
        //0
        //0
        //[Constructor, Method, Field, Delegate][Constructor, Method, Field, Delegate][True][679][985645][1451.61266568483]
        //0
        //0
        //[False][False][True][624][99832][159.987179487179]
        //0
        //0
        //[Assembly,Module,Class,Struct,Enum,Constructor,Method,Property,Field,Event,Interface,Parameter,Delegate,ReturnValue,GenericParameter,All][True][713][817661][1146.78962131837]
        //0
        //0
        //[Assembly,Module,Class,Struct,Enum,Constructor,Method,Property,Field,Event,Interface,Parameter,Delegate,ReturnValue,GenericParameter,All][True][585][34834][59.5452991452991]
    }
}
