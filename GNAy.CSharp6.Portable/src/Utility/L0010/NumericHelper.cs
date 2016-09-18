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
using GNAy.CSharp6.Portable.Const.L0000_ConstNumberValue;
#else
using GNAy.CSharp6.Portable.Const;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0010_NumericHelper
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public static class NumericHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static bool zzHasFlag(this sbyte iSource, sbyte iTarget)
        {
            return ((iSource & iTarget) == iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static bool zzHasFlag(this byte iSource, byte iTarget)
        {
            return ((iSource & iTarget) == iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static bool zzHasFlag(this short iSource, short iTarget)
        {
            return ((iSource & iTarget) == iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static bool zzHasFlag(this ushort iSource, ushort iTarget)
        {
            return ((iSource & iTarget) == iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static bool zzHasFlag(this int iSource, int iTarget)
        {
            return ((iSource & iTarget) == iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static bool zzHasFlag(this uint iSource, uint iTarget)
        {
            return ((iSource & iTarget) == iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static bool zzHasFlag(this long iSource, long iTarget)
        {
            return ((iSource & iTarget) == iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static bool zzHasFlag(this ulong iSource, ulong iTarget)
        {
            return ((iSource & iTarget) == iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static bool zzHasFlag(this char iSource, char iTarget)
        {
            return ((iSource & iTarget) == iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzHasFlags(this sbyte iSource, IEnumerable<sbyte> ioCollection)
        {
            foreach (sbyte mFlag in ioCollection)
            {
                yield return zzHasFlag(iSource, mFlag);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzHasFlags(this sbyte iSource, params sbyte[] ioCollection)
        {
            return zzHasFlags(iSource, (IEnumerable<sbyte>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzHasFlags(this byte iSource, IEnumerable<byte> ioCollection)
        {
            foreach (byte mFlag in ioCollection)
            {
                yield return zzHasFlag(iSource, mFlag);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzHasFlags(this byte iSource, params byte[] ioCollection)
        {
            return zzHasFlags(iSource, (IEnumerable<byte>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzHasFlags(this short iSource, IEnumerable<short> ioCollection)
        {
            foreach (short mFlag in ioCollection)
            {
                yield return zzHasFlag(iSource, mFlag);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzHasFlags(this short iSource, params short[] ioCollection)
        {
            return zzHasFlags(iSource, (IEnumerable<short>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzHasFlags(this ushort iSource, IEnumerable<ushort> ioCollection)
        {
            foreach (ushort mFlag in ioCollection)
            {
                yield return zzHasFlag(iSource, mFlag);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzHasFlags(this ushort iSource, params ushort[] ioCollection)
        {
            return zzHasFlags(iSource, (IEnumerable<ushort>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzHasFlags(this int iSource, IEnumerable<int> ioCollection)
        {
            foreach (int mFlag in ioCollection)
            {
                yield return zzHasFlag(iSource, mFlag);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzHasFlags(this int iSource, params int[] ioCollection)
        {
            return zzHasFlags(iSource, (IEnumerable<int>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzHasFlags(this uint iSource, IEnumerable<uint> ioCollection)
        {
            foreach (uint mFlag in ioCollection)
            {
                yield return zzHasFlag(iSource, mFlag);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzHasFlags(this uint iSource, params uint[] ioCollection)
        {
            return zzHasFlags(iSource, (IEnumerable<uint>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzHasFlags(this long iSource, IEnumerable<long> ioCollection)
        {
            foreach (long mFlag in ioCollection)
            {
                yield return zzHasFlag(iSource, mFlag);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzHasFlags(this long iSource, params long[] ioCollection)
        {
            return zzHasFlags(iSource, (IEnumerable<long>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzHasFlags(this ulong iSource, IEnumerable<ulong> ioCollection)
        {
            foreach (ulong mFlag in ioCollection)
            {
                yield return zzHasFlag(iSource, mFlag);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzHasFlags(this ulong iSource, params ulong[] ioCollection)
        {
            return zzHasFlags(iSource, (IEnumerable<ulong>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzHasFlags(this char iSource, IEnumerable<char> ioCollection)
        {
            foreach (char mFlag in ioCollection)
            {
                yield return zzHasFlag(iSource, mFlag);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static IEnumerable<bool> zzHasFlags(this char iSource, params char[] ioCollection)
        {
            return zzHasFlags(iSource, (IEnumerable<char>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static sbyte zzAddFlag(this sbyte iSource, sbyte iTarget)
        {
            return (sbyte)(iSource | iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static byte zzAddFlag(this byte iSource, byte iTarget)
        {
            return (byte)(iSource | iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static short zzAddFlag(this short iSource, short iTarget)
        {
            return (short)(iSource | iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static ushort zzAddFlag(this ushort iSource, ushort iTarget)
        {
            return (ushort)(iSource | iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static int zzAddFlag(this int iSource, int iTarget)
        {
            return (iSource | iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static uint zzAddFlag(this uint iSource, uint iTarget)
        {
            return (iSource | iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static char zzAddFlag(this char iSource, char iTarget)
        {
            return (char)(iSource | iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static sbyte zzAddFlags(this sbyte iSource, IEnumerable<sbyte> ioCollection)
        {
            foreach (sbyte mFlag in ioCollection)
            {
                iSource = zzAddFlag(iSource, mFlag);
            }

            return iSource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static sbyte zzAddFlags(this sbyte iSource, params sbyte[] ioCollection)
        {
            return zzAddFlags(iSource, (IEnumerable<sbyte>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static byte zzAddFlags(this byte iSource, IEnumerable<byte> ioCollection)
        {
            foreach (byte mFlag in ioCollection)
            {
                iSource = zzAddFlag(iSource, mFlag);
            }

            return iSource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static byte zzAddFlags(this byte iSource, params byte[] ioCollection)
        {
            return zzAddFlags(iSource, (IEnumerable<byte>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static short zzAddFlags(this short iSource, IEnumerable<short> ioCollection)
        {
            foreach (short mFlag in ioCollection)
            {
                iSource = zzAddFlag(iSource, mFlag);
            }

            return iSource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static short zzAddFlags(this short iSource, params short[] ioCollection)
        {
            return zzAddFlags(iSource, (IEnumerable<short>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static ushort zzAddFlags(this ushort iSource, IEnumerable<ushort> ioCollection)
        {
            foreach (ushort mFlag in ioCollection)
            {
                iSource = zzAddFlag(iSource, mFlag);
            }

            return iSource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static ushort zzAddFlags(this ushort iSource, params ushort[] ioCollection)
        {
            return zzAddFlags(iSource, (IEnumerable<ushort>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static int zzAddFlags(this int iSource, IEnumerable<int> ioCollection)
        {
            foreach (int mFlag in ioCollection)
            {
                iSource = zzAddFlag(iSource, mFlag);
            }

            return iSource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static int zzAddFlags(this int iSource, params int[] ioCollection)
        {
            return zzAddFlags(iSource, (IEnumerable<int>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static uint zzAddFlags(this uint iSource, IEnumerable<uint> ioCollection)
        {
            foreach (uint mFlag in ioCollection)
            {
                iSource = zzAddFlag(iSource, mFlag);
            }

            return iSource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static uint zzAddFlags(this uint iSource, params uint[] ioCollection)
        {
            return zzAddFlags(iSource, (IEnumerable<uint>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static char zzAddFlags(this char iSource, IEnumerable<char> ioCollection)
        {
            foreach (char mFlag in ioCollection)
            {
                iSource = zzAddFlag(iSource, mFlag);
            }

            return iSource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static char zzAddFlags(this char iSource, params char[] ioCollection)
        {
            return zzAddFlags(iSource, (IEnumerable<char>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static sbyte zzRemoveFlag(this sbyte iSource, sbyte iTarget)
        {
            return (sbyte)(iSource & ~iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static byte zzRemoveFlag(this byte iSource, byte iTarget)
        {
            return (byte)(iSource & ~iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static short zzRemoveFlag(this short iSource, short iTarget)
        {
            return (short)(iSource & ~iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static ushort zzRemoveFlag(this ushort iSource, ushort iTarget)
        {
            return (ushort)(iSource & ~iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static int zzRemoveFlag(this int iSource, int iTarget)
        {
            return (iSource & ~iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static uint zzRemoveFlag(this uint iSource, uint iTarget)
        {
            return (iSource & ~iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static char zzRemoveFlag(this char iSource, char iTarget)
        {
            return (char)(iSource & ~iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static sbyte zzRemoveFlags(this sbyte iSource, IEnumerable<sbyte> ioCollection)
        {
            foreach (sbyte mFlag in ioCollection)
            {
                iSource = zzRemoveFlag(iSource, mFlag);
            }

            return iSource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static sbyte zzRemoveFlags(this sbyte iSource, params sbyte[] ioCollection)
        {
            return zzRemoveFlags(iSource, (IEnumerable<sbyte>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static byte zzRemoveFlags(this byte iSource, IEnumerable<byte> ioCollection)
        {
            foreach (byte mFlag in ioCollection)
            {
                iSource = zzRemoveFlag(iSource, mFlag);
            }

            return iSource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static byte zzRemoveFlags(this byte iSource, params byte[] ioCollection)
        {
            return zzRemoveFlags(iSource, (IEnumerable<byte>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static short zzRemoveFlags(this short iSource, IEnumerable<short> ioCollection)
        {
            foreach (short mFlag in ioCollection)
            {
                iSource = zzRemoveFlag(iSource, mFlag);
            }

            return iSource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static short zzRemoveFlags(this short iSource, params short[] ioCollection)
        {
            return zzRemoveFlags(iSource, (IEnumerable<short>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static ushort zzRemoveFlags(this ushort iSource, IEnumerable<ushort> ioCollection)
        {
            foreach (ushort mFlag in ioCollection)
            {
                iSource = zzRemoveFlag(iSource, mFlag);
            }

            return iSource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static ushort zzRemoveFlags(this ushort iSource, params ushort[] ioCollection)
        {
            return zzRemoveFlags(iSource, (IEnumerable<ushort>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static int zzRemoveFlags(this int iSource, IEnumerable<int> ioCollection)
        {
            foreach (int mFlag in ioCollection)
            {
                iSource = zzRemoveFlag(iSource, mFlag);
            }

            return iSource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static int zzRemoveFlags(this int iSource, params int[] ioCollection)
        {
            return zzRemoveFlags(iSource, (IEnumerable<int>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static uint zzRemoveFlags(this uint iSource, IEnumerable<uint> ioCollection)
        {
            foreach (uint mFlag in ioCollection)
            {
                iSource = zzRemoveFlag(iSource, mFlag);
            }

            return iSource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static uint zzRemoveFlags(this uint iSource, params uint[] ioCollection)
        {
            return zzRemoveFlags(iSource, (IEnumerable<uint>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static char zzRemoveFlags(this char iSource, IEnumerable<char> ioCollection)
        {
            foreach (char mFlag in ioCollection)
            {
                iSource = zzRemoveFlag(iSource, mFlag);
            }

            return iSource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioCollection"></param>
        /// <returns></returns>
        public static char zzRemoveFlags(this char iSource, params char[] ioCollection)
        {
            return zzRemoveFlags(iSource, (IEnumerable<char>)ioCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioEnumType"></param>
        /// <returns></returns>
        public static Enum zzToEnum(this int iSource, Type ioEnumType)
        {
            return (Enum)Enum.ToObject(ioEnumType, iSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static Enum zzToEnum<TEnum>(this int iSource) where TEnum : struct, IComparable, IFormattable
        {
            return zzToEnum(iSource, typeof(TEnum));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <param name="ioEnumType"></param>
        /// <returns></returns>
        public static IEnumerable<Enum> zzToEnum(this IEnumerable<int> ioSource, Type ioEnumType)
        {
            //return Array.ConvertAll(ioSource, iItem => zzToEnum(iItem, ioEnumType));
            return ioSource.Select(iItem => zzToEnum(iItem, ioEnumType));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static IEnumerable<Enum> zzToEnum<TEnum>(this IEnumerable<int> ioSource) where TEnum : struct, IComparable, IFormattable
        {
            return zzToEnum(ioSource, typeof(TEnum));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsEven(this sbyte iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.Zero);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsOdd(this sbyte iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.One);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsEven(this byte iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.Zero);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsOdd(this byte iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.One);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsEven(this short iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.Zero);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsOdd(this short iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.One);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsEven(this ushort iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.Zero);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsOdd(this ushort iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.One);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsEven(this int iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.Zero);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsOdd(this int iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.One);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsEven(this uint iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.Zero);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsOdd(this uint iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.One);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsEven(this long iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.Zero);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsOdd(this long iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.One);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsEven(this ulong iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.Zero);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsOdd(this ulong iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.One);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsEven(this decimal iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.Zero);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsOdd(this decimal iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.One);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsEven(this char iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.Zero);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static bool extIsOdd(this char iSource)
        {
            return ((iSource % ConstNumberValue.Two) == ConstNumberValue.One);
        }
    }
}
