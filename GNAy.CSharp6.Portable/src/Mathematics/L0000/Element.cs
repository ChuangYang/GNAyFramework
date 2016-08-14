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
namespace GNAy.CSharp6.Portable.Mathematics.L0000_Element
#else
namespace GNAy.CSharp6.Portable.Mathematics
#endif
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Element<T> where T : struct, IComparable, IComparable<T>, IEquatable<T>, IFormattable
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly bool IsOperator;

        /// <summary>
        /// 
        /// </summary>
        public bool IsValue
        {
            get { return !IsOperator; }
        }

        /// <summary>
        /// 
        /// </summary>
        public readonly string Operator;

        /// <summary>
        /// 
        /// </summary>
        public readonly T Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iOperator"></param>
        public Element(string iOperator)
        {
            if (string.IsNullOrWhiteSpace(iOperator))
            {
                throw new ArgumentException($"[string.IsNullOrWhiteSpace(iOperator)][{iOperator}]");
            }

            Operator = iOperator;
            Value = default(T);

            IsOperator = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iValue"></param>
        public Element(T iValue)
        {
            Operator = null;
            Value = iValue;

            IsOperator = false;
        }
    }
}
