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
using GNAy.CSharp6.Portable.Const.L0010_ConstString;
#else
using GNAy.CSharp6.Portable.Const;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Mathematics.L0020_Operator
#else
namespace GNAy.CSharp6.Portable.Mathematics
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public class Operator
    {
        /// <summary>
        /// (
        /// </summary>
        public const string OpenParenthesis = ConstString.OpenParenthesis;

        /// <summary>
        /// )
        /// </summary>
        public const string CloseParenthesis = ConstString.CloseParenthesis;

        /// <summary>
        /// +
        /// </summary>
        public const string Plus = "+";

        /// <summary>
        /// -
        /// </summary>
        public const string Minus = "-";

        /// <summary>
        /// *
        /// </summary>
        public const string Times = "*";

        /// <summary>
        /// /
        /// </summary>
        public const string Divided = "/";

        /// <summary>
        /// %
        /// </summary>
        public const string Modulo = "%";

        /// <summary>
        /// ^
        /// </summary>
        public const string Power = "^";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iTarget"></param>
        /// <returns></returns>
        public static bool CheckOrThrow(string iTarget)
        {
            switch (iTarget)
            {
                case OpenParenthesis:
                case CloseParenthesis:
                case Plus:
                case Minus:
                case Times:
                case Divided:
                case Modulo:
                case Power:
                    return true;

                default:
                    throw new ArgumentException($"[default:][{iTarget}]");
            }
        }
    }
}
