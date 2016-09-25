using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Text.RegularExpressions;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#if Development
using GNAy.CSharp6.Portable.Const.L0000_ConstNumberValue;
using GNAy.CSharp6.Portable.Const.L0010_ConstString;
using GNAy.CSharp6.Portable.Const.L0010_ConstValue;
#else
using GNAy.CSharp6.Portable.Const;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0020_StringHelper
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static bool zzIsNotEmpty(this string ioSource)
        {
            return !string.IsNullOrEmpty(ioSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static bool zzIsNotWhiteSpace(this string ioSource)
        {
            return !string.IsNullOrWhiteSpace(ioSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static bool zzEqualsWithIgnoreCase(this string iSource, string iTarget)
        {
            //if (object.ReferenceEquals(iSource, iTarget))
            //{
            //    return true;
            //}
            //else if (iSource == null)
            //{
            //    return (iTarget == null);
            //}
            //else if (iTarget == null)
            //{
            //    return false;
            //}

            //return iTarget.Equals(iSource, StringComparison.OrdinalIgnoreCase);

            return (object.ReferenceEquals(iSource, iTarget) ? true :
                ((iSource == null) ? (iTarget == null) :
                ((iTarget == null) ? false :
                iTarget.Equals(iSource, StringComparison.OrdinalIgnoreCase))));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static bool zzNotEqualsWithIgnoreCase(this string iSource, string iTarget)
        {
            return !zzEqualsWithIgnoreCase(iSource, iTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioTargetHashCode"></param>
        public static void zzGetHashCodeWithIgnoreCase(this string iSource, ref int ioTargetHashCode)
        {
            ioTargetHashCode ^= iSource.ToUpper().GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTargetHashCode"></param>
        /// <returns></returns>
        public static int zzGetHashCodeWithIgnoreCase(this string iSource, int iTargetHashCode)
        {
            return (iTargetHashCode ^ iSource.ToUpper().GetHashCode());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static Guid zzToGUID(this string iSource)
        {
            return new Guid(iSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioEscapes"></param>
        /// <param name="iReplacement"></param>
        /// <returns></returns>
        public static string zzToValidString(this string iSource, Regex ioEscapes, string iReplacement)
        {
            return ioEscapes.Replace(iSource, iReplacement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iInvalidChars"></param>
        /// <param name="iReplacement"></param>
        /// <returns></returns>
        public static string zzToValidString(this string iSource, string iInvalidChars, string iReplacement)
        {
            return zzToValidString(iSource, new Regex(string.Format(ConstString.DefaultJoinFormat, Regex.Escape(iInvalidChars))), iReplacement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="ioInvalidChars"></param>
        /// <param name="iReplacement"></param>
        /// <returns></returns>
        public static string zzToValidString(this string iSource, IEnumerable<char> ioInvalidChars, string iReplacement)
        {
            return zzToValidString(iSource, new string((ioInvalidChars is char[]) ? (ioInvalidChars as char[]) : ioInvalidChars.ToArray()), iReplacement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static int zzGetLastIndex(this string ioSource)
        {
            return (ioSource.Length - ConstNumberValue.One);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static char zzGetFirstChar(this string ioSource)
        {
            return ioSource[ConstValue.StartIndex];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static char zzGetLastChar(this string ioSource)
        {
            return ioSource[zzGetLastIndex(ioSource)];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static bool zzContains(this string iSource, string iTarget)
        {
            return (iSource.IndexOf(iTarget) >= ConstValue.StartIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <param name="iStringComparison"></param>
        /// <returns></returns>
        public static bool zzContains(this string iSource, string iTarget, StringComparison iStringComparison)
        {
            return (iSource.IndexOf(iTarget, iStringComparison) >= ConstValue.StartIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <param name="iStringComparison"></param>
        /// <returns></returns>
        public static bool zzContainsWithIgnoreCase(this string iSource, string iTarget, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return zzContains(iSource, iTarget, iStringComparison);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <param name="iStartIndex"></param>
        /// <returns></returns>
        public static bool zzContains(this string iSource, string iTarget, int iStartIndex)
        {
            return (iSource.IndexOf(iTarget, iStartIndex) >= ConstValue.StartIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <param name="iStartIndex"></param>
        /// <param name="iStringComparison"></param>
        /// <returns></returns>
        public static bool zzContains(this string iSource, string iTarget, int iStartIndex, StringComparison iStringComparison)
        {
            return (iSource.IndexOf(iTarget, iStartIndex, iStringComparison) >= ConstValue.StartIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <param name="iStartIndex"></param>
        /// <param name="iStringComparison"></param>
        /// <returns></returns>
        public static bool zzContainsWithIgnoreCase(this string iSource, string iTarget, int iStartIndex, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return zzContains(iSource, iTarget, iStartIndex, iStringComparison);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <param name="iStartIndex"></param>
        /// <param name="iCount"></param>
        /// <returns></returns>
        public static bool zzContains(this string iSource, string iTarget, int iStartIndex, int iCount)
        {
            return (iSource.IndexOf(iTarget, iStartIndex, iCount) >= ConstValue.StartIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <param name="iStartIndex"></param>
        /// <param name="iCount"></param>
        /// <param name="iStringComparison"></param>
        /// <returns></returns>
        public static bool zzContains(this string iSource, string iTarget, int iStartIndex, int iCount, StringComparison iStringComparison)
        {
            return (iSource.IndexOf(iTarget, iStartIndex, iCount, iStringComparison) >= ConstValue.StartIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iTarget"></param>
        /// <param name="iStartIndex"></param>
        /// <param name="iCount"></param>
        /// <param name="iStringComparison"></param>
        /// <returns></returns>
        public static bool zzContainsWithIgnoreCase(this string iSource, string iTarget, int iStartIndex, int iCount, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return zzContains(iSource, iTarget, iStartIndex, iCount, iStringComparison);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioValues"></param>
        /// <returns></returns>
        public static string DefaultJoin(params string[] ioValues)
        {
            return string.Format(ConstString.DefaultJoinFormat, string.Join(ConstString.DefaultSeparator, ioValues));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioValues"></param>
        /// <returns></returns>
        public static string DefaultJoin(params object[] ioValues)
        {
            return string.Format(ConstString.DefaultJoinFormat, string.Join(ConstString.DefaultSeparator, ioValues));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iKeyword"></param>
        /// <returns></returns>
        public static int zzIndexOfTail(this string iSource, string iKeyword)
        {
            int mIndex = iSource.IndexOf(iKeyword);

            return ((mIndex < ConstValue.StartIndex) ? mIndex : (mIndex + iKeyword.Length));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iKeyword"></param>
        /// <param name="iStringComparison"></param>
        /// <returns></returns>
        public static int zzIndexOfTail(this string iSource, string iKeyword, StringComparison iStringComparison)
        {
            int mIndex = iSource.IndexOf(iKeyword, iStringComparison);

            return ((mIndex < ConstValue.StartIndex) ? mIndex : (mIndex + iKeyword.Length));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iKeyword"></param>
        /// <param name="iStringComparison"></param>
        /// <returns></returns>
        public static int zzIndexOfTailWithIgnoreCase(this string iSource, string iKeyword, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return zzIndexOfTail(iSource, iKeyword, iStringComparison);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iKeyword"></param>
        /// <returns></returns>
        public static int zzLastIndexOfTail(this string iSource, string iKeyword)
        {
            int mIndex = iSource.LastIndexOf(iKeyword);

            return ((mIndex < ConstValue.StartIndex) ? mIndex : (mIndex + iKeyword.Length));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iKeyword"></param>
        /// <param name="iStringComparison"></param>
        /// <returns></returns>
        public static int zzLastIndexOfTail(this string iSource, string iKeyword, StringComparison iStringComparison)
        {
            int mIndex = iSource.LastIndexOf(iKeyword, iStringComparison);

            return ((mIndex < ConstValue.StartIndex) ? mIndex : (mIndex + iKeyword.Length));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iKeyword"></param>
        /// <param name="iStringComparison"></param>
        /// <returns></returns>
        public static int zzLastIndexOfTailWithIgnoreCase(this string iSource, string iKeyword, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return zzLastIndexOfTail(iSource, iKeyword, iStringComparison);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iStart"></param>
        /// <param name="iSearchStartFromHead"></param>
        /// <param name="iEnd"></param>
        /// <param name="iSearchEndFromHead"></param>
        /// <returns></returns>
        public static string zzSubstring(this string iSource, string iStart, bool iSearchStartFromHead, string iEnd, bool iSearchEndFromHead)
        {
            int mStartIndex = ConstValue.NotFound;

            if ((mStartIndex = (iSearchStartFromHead ? zzIndexOfTail(iSource, iStart) : zzLastIndexOfTail(iSource, iStart))) < ConstValue.StartIndex)
            {
                return ConstString.Empty;
            }

            string mStart = iSource.Substring(mStartIndex);
            int mEndIndex = (iSearchEndFromHead ? mStart.IndexOf(iEnd) : mStart.LastIndexOf(iEnd));

            return ((mEndIndex < ConstValue.StartIndex) ? mStart : mStart.Substring(ConstValue.StartIndex, mEndIndex));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iStart"></param>
        /// <param name="iSearchStartFromHead"></param>
        /// <param name="iEnd"></param>
        /// <param name="iSearchEndFromHead"></param>
        /// <param name="iStringComparison"></param>
        /// <returns></returns>
        public static string zzSubstring(this string iSource, string iStart, bool iSearchStartFromHead, string iEnd, bool iSearchEndFromHead, StringComparison iStringComparison)
        {
            int mStartIndex = ConstValue.NotFound;

            if ((mStartIndex = (iSearchStartFromHead ? zzIndexOfTail(iSource, iStart, iStringComparison) : zzLastIndexOfTail(iSource, iStart, iStringComparison))) < ConstValue.StartIndex)
            {
                return ConstString.Empty;
            }

            string mStart = iSource.Substring(mStartIndex);
            int mEndIndex = (iSearchEndFromHead ? mStart.IndexOf(iEnd, iStringComparison) : mStart.LastIndexOf(iEnd, iStringComparison));

            return ((mEndIndex < ConstValue.StartIndex) ? mStart : mStart.Substring(ConstValue.StartIndex, mEndIndex));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iStart"></param>
        /// <param name="iSearchStartFromHead"></param>
        /// <param name="iEnd"></param>
        /// <param name="iSearchEndFromHead"></param>
        /// <param name="iStringComparison"></param>
        /// <returns></returns>
        public static string zzSubstringWithIgnoreCase(this string iSource, string iStart, bool iSearchStartFromHead, string iEnd, bool iSearchEndFromHead, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return zzSubstring(iSource, iStart, iSearchStartFromHead, iEnd, iSearchEndFromHead, iStringComparison);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iStart"></param>
        /// <param name="iEnd"></param>
        /// <returns></returns>
        public static string zzFirstSubstring(this string iSource, string iStart, string iEnd)
        {
            return zzSubstring(iSource, iStart, true, iEnd, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iStart"></param>
        /// <param name="iEnd"></param>
        /// <param name="iStringComparison"></param>
        /// <returns></returns>
        public static string zzFirstSubstring(this string iSource, string iStart, string iEnd, StringComparison iStringComparison)
        {
            return zzSubstring(iSource, iStart, true, iEnd, true, iStringComparison);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iStart"></param>
        /// <param name="iEnd"></param>
        /// <param name="iStringComparison"></param>
        /// <returns></returns>
        public static string zzFirstSubstringWithIgnoreCase(this string iSource, string iStart, string iEnd, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return zzSubstring(iSource, iStart, true, iEnd, true, iStringComparison);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iStart"></param>
        /// <param name="iEnd"></param>
        /// <returns></returns>
        public static string zzLastSubstring(this string iSource, string iStart, string iEnd)
        {
            return zzSubstring(iSource, iStart, false, iEnd, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iStart"></param>
        /// <param name="iEnd"></param>
        /// <param name="iStringComparison"></param>
        /// <returns></returns>
        public static string zzLastSubstring(this string iSource, string iStart, string iEnd, StringComparison iStringComparison)
        {
            return zzSubstring(iSource, iStart, false, iEnd, false, iStringComparison);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iStart"></param>
        /// <param name="iEnd"></param>
        /// <param name="iStringComparison"></param>
        /// <returns></returns>
        public static string zzLastSubstringWithIgnoreCase(this string iSource, string iStart, string iEnd, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return zzSubstring(iSource, iStart, false, iEnd, false, iStringComparison);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns></returns>
        public static string zzGetSequentialFormat(this string iSource)
        {
            const string mPattern = @"\{{1,}[S|s](\}|:[^\}]*\})";
            const int mTargetLength = ConstNumberValue.Two;
            const string mNewValue = "{{{0}";

            int mIndex = ConstValue.StartIndex;

            return Regex.Replace(iSource, mPattern, ioMatch =>
                ioMatch.Value.Replace(
                    ioMatch.Value.Substring(ioMatch.Value.IndexOf(ConstString.FormatSequence, StringComparison.OrdinalIgnoreCase), mTargetLength),
                    string.Format(mNewValue, mIndex++)
                    )
                );
        }
    }
}
