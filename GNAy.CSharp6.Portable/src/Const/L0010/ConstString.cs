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

namespace GNAy.CSharp6.Portable.Const
{
    /// <summary>
    /// ConstString
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
