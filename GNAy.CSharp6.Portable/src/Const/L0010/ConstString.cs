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
using GNAy.CSharp6.Portable.Const.L0000_ConstNumberString;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Const.L0010_ConstString
#else
namespace GNAy.CSharp6.Portable.Const
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public class ConstString
    {
        /// <summary>
        /// ' '
        /// </summary>
        public const char CharBlank = ' ';

        /// <summary>
        /// ""
        /// </summary>
        public const string Empty = "";

        /// <summary>
        /// " "
        /// </summary>
        public const string Blank = " ";

        /// <summary>
        /// "\r\n"
        /// </summary>
        public const string NewLine = "\r\n";

        /// <summary>
        /// "{"
        /// </summary>
        public const string OpenBrace = "{";

        /// <summary>
        /// "}"
        /// </summary>
        public const string CloseBrace = "}";

        /// <summary>
        /// "{"
        /// </summary>
        public const string FormatHead = OpenBrace;

        /// <summary>
        /// "}"
        /// </summary>
        public const string FormatTail = CloseBrace;

        /// <summary>
        /// "{0}"
        /// </summary>
        public const string FormatInitial = (FormatHead + ConstNumberString.Zero + FormatTail);

        /// <summary>
        /// "{S}"
        /// </summary>
        public const string FormatSequence = (FormatHead + "S" + FormatTail);
    }
}
