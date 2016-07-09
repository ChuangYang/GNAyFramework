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

namespace GNAy.CSharp6.Portable.UnitTest.Sample
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class Portable
    {
        private static CSharp6.Portable.Tests.Sample.UnitTest _unitTest;

        static Portable()
        {
            _unitTest = new CSharp6.Portable.Tests.Sample.UnitTest();
        }

        /// <summary>
        /// Initialize the static instance.
        /// </summary>
        public static void Initialize()
        { }

        /// <summary>
        /// 
        /// </summary>
        public Portable()
        { }
        
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
        public void DateTimeDefault()
        {
            _unitTest.DateTimeDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DateTimeKind1()
        {
            _unitTest.DateTimeKind1();
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
