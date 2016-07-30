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
namespace GNAy.CSharp6.Portable.UnitTest.Sample.L0001_Portable
#else
namespace GNAy.CSharp6.Portable.UnitTest.Sample
#endif
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class Portable
    {
#if Development
        private static CSharp6.Portable.Tests.Sample.L0000_UnitTest.UnitTest _unitTest;
#else
        private static CSharp6.Portable.Tests.Sample.UnitTest _unitTest;
#endif

        static Portable()
        {
#if Development
            _unitTest = new CSharp6.Portable.Tests.Sample.L0000_UnitTest.UnitTest();
#else
            _unitTest = new CSharp6.Portable.Tests.Sample.UnitTest();
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void NumberCalculating1()
        {
            _unitTest.NumberCalculating1();
        }
        
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void NumberCalculating2()
        {
            _unitTest.NumberCalculating2();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ValueEquals()
        {
            _unitTest.ValueEquals();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void StringEquals()
        {
            _unitTest.StringEquals();
        }
        
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ConstructorOrder()
        {
            _unitTest.ConstructorOrder();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ObjectEqualsNullException()
        {
            _unitTest.ObjectEqualsNullException();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ObjectEqualsNullPerformance()
        {
            _unitTest.ObjectEqualsNullPerformance();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ObjectToString()
        {
            _unitTest.ObjectToString();
        }
        
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ClassAndStructure()
        {
            _unitTest.ClassAndStructure();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DictionaryIgnoreCase()
        {
            _unitTest.DictionaryIgnoreCase();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DictionaryPerformance()
        {
            _unitTest.DictionaryPerformance();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DateTimeDefault()
        {
            _unitTest.DateTimeDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DateTimeKindTest()
        {
            _unitTest.DateTimeKindTest();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DateTimeTicks()
        {
            _unitTest.DateTimeTicks();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void WhileCount()
        {
            _unitTest.WhileCount();
        }
        
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void StringSequentialFormat()
        {
            _unitTest.StringSequentialFormat();
        }
    }
}
