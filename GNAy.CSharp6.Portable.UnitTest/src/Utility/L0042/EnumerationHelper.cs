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
        //[4448][4448][True][605][570][1.06140350877193]
        //0
        //0
        //[Constructor, Method, Field, Delegate][Constructor, Method, Field, Delegate][True][604][910906][1508.12251655629]
        //0
        //0
        //[False][False][True][606][95720][157.953795379538]
        //0
        //0
        //[Assembly,Module,Class,Struct,Enum,Constructor,Method,Property,Field,Event,Interface,Parameter,Delegate,ReturnValue,GenericParameter,All][True][606][873017][1440.62211221122]
        //0
        //0
        //[Assembly,Module,Class,Struct,Enum,Constructor,Method,Property,Field,Event,Interface,Parameter,Delegate,ReturnValue,GenericParameter,All][True][585][35612][60.8752136752137]
    }
}
