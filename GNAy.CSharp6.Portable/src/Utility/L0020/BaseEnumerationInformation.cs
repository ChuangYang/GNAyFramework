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
#if Development
using GNAy.CSharp6.Portable.Const.L0010_ConstValue;
#else
using GNAy.CSharp6.Portable.Const;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0020_BaseEnumerationInformation
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseEnumerationInformation<T> where T : struct, IComparable, IComparable<T>, IEquatable<T>, IFormattable
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly Enum Source;

        /// <summary>
        /// 
        /// </summary>
        public readonly T Value;

        /// <summary>
        /// 
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// 
        /// </summary>
        public readonly bool IsDefined;

        ///// <summary>
        ///// 
        ///// </summary>
        //public readonly bool IsFlag;

        /// <summary>
        /// 
        /// </summary>
        public readonly int Position;

        /// <summary>
        /// 
        /// </summary>
        public readonly Enum[] RawCollection;

        /// <summary>
        /// 
        /// </summary>
        public readonly T[] ValueCollection;

        /// <summary>
        /// 
        /// </summary>
        public readonly string[] NameCollection;

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
        public BaseEnumerationInformation(Enum iSource, T iValue, string iName, bool iIsDefined, int iPosition, Enum[] ioRawCollection, T[] ioValueCollection, string[] ioNameCollection)
        {
            Source = iSource;
            Value = iValue;
            Name = iName;

            IsDefined = iIsDefined;
            Position = iPosition;

            RawCollection = ioRawCollection;
            ValueCollection = ioValueCollection;
            NameCollection = ioNameCollection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iPosition"></param>
        /// <param name="ioRawCollection"></param>
        public BaseEnumerationInformation(int iPosition, Enum[] ioRawCollection)
        {
            Position = iPosition;

            Source = ioRawCollection[iPosition];
            Value = (T)(object)Source;
            Name = Source.ToString();

            IsDefined = Enum.IsDefined(Source.GetType(), Source);

            RawCollection = ioRawCollection;
            ValueCollection = ioRawCollection.Cast<T>().ToArray();
            NameCollection = Enum.GetNames(Source.GetType());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        public BaseEnumerationInformation(Enum iSource)
        {
            Source = iSource;
            Value = (T)(object)iSource;
            Name = iSource.ToString();

            IsDefined = Enum.IsDefined(iSource.GetType(), iSource);
            Position = ConstValue.NotFound;

            RawCollection = Enum.GetValues(iSource.GetType()).Cast<Enum>().ToArray();
            ValueCollection = Enum.GetValues(iSource.GetType()).Cast<T>().ToArray();
            NameCollection = Enum.GetNames(iSource.GetType());

            if (IsDefined)
            {
                for (int i = ConstValue.StartIndex; i < RawCollection.Length; ++i)
                {
                    if (RawCollection[i] == iSource)
                    {
                        Position = i;
                        break;
                    }
                }
            }
        }
    }
}
