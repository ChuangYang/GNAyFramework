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
using GNAy.CSharp6.Portable.Const.L0010_ConstString;
using GNAy.CSharp6.Portable.Const.L0010_ConstValue;
#else
using GNAy.CSharp6.Portable.Const;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Mathematics.L0020_Calculator
#else
namespace GNAy.CSharp6.Portable.Mathematics
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// +
        /// </summary>
        public const string Operator_Plus = "+";

        /// <summary>
        /// -
        /// </summary>
        public const string Operator_Minus = "-";

        /// <summary>
        /// *
        /// </summary>
        public const string Operator_Times = "*";

        /// <summary>
        /// /
        /// </summary>
        public const string Operator_Divided = "/";

        /// <summary>
        /// %
        /// </summary>
        public const string Operator_Modulo = "%";

        /// <summary>
        /// ^
        /// </summary>
        public const string Operator_Power = "^";

        private static List<string> toInfixList(string iInfix)
        {
            List<string> mResult = new List<string>();

            string mElement = ConstString.Empty;

            for (int i = ConstValue.StartIndex; i < iInfix.Length; ++i)
            {
                char mChar = iInfix[i];

                if (char.IsNumber(mChar) ||
                    (mChar == '.') ||
                    ((mChar == '-') && ((i == ConstValue.StartIndex) || (iInfix[i - ConstNumberValue.One] == ConstString.CharOpenParenthesis))))
                {
                    mElement += mChar;

                    continue;
                }
                else if (!string.IsNullOrWhiteSpace(mElement))
                {
                    mResult.Add(mElement);
                }

                mResult.Add(mChar.ToString()); //mChar is an operator.

                mElement = ConstString.Empty;
            }

            if (!string.IsNullOrWhiteSpace(mElement))
            {
                mResult.Add(mElement);
            }

            return mResult;
        }

        private static int getPriority(string iOperator)
        {
            switch (iOperator)
            {
                case ConstString.OpenParenthesis:
                    return ConstNumberValue.One;

                case Operator_Plus:
                    return ConstNumberValue.Two;

                case Operator_Minus:
                    return ConstNumberValue.Two;

                case Operator_Times:
                    return ConstNumberValue.Three;

                case Operator_Divided:
                    return ConstNumberValue.Three;

                case Operator_Modulo:
                    return ConstNumberValue.Three;

                case Operator_Power:
                    return ConstNumberValue.Three;

                default:
                    return ConstValue.NotFound;
            }
        }

        private static List<string> toPostfixList(List<string> ioInfix)
        {
            List<string> mResult = new List<string>();

            Stack<string> mOperators = new Stack<string>();

            foreach (string mElement in ioInfix)
            {
                decimal mNumber = ConstNumberValue.Zero;

                if (decimal.TryParse(mElement, out mNumber))
                {
                    mResult.Add(mElement);

                    continue;
                }

                switch (mElement)
                {
                    case ConstString.OpenParenthesis:
                        mOperators.Push(mElement);
                        break;

                    case Operator_Plus:
                    case Operator_Minus:
                    case Operator_Times:
                    case Operator_Divided:
                    case Operator_Modulo:
                    case Operator_Power:
                        {
                            while ((mOperators.Count > ConstValue.Empty) && (getPriority(mOperators.Peek()) >= getPriority(mElement)))
                            {
                                mResult.Add(mOperators.Pop());
                            }

                            mOperators.Push(mElement);
                        }
                        break;

                    case ConstString.CloseParenthesis:
                        {
                            while (mOperators.Peek() != ConstString.OpenParenthesis)
                            {
                                mResult.Add(mOperators.Pop());
                            }

                            mOperators.Pop();
                        }
                        break;

                    default:
                        throw new NotSupportedException($"[default:][{mElement}]");
                }
            }

            while (mOperators.Count > ConstValue.Empty)
            {
                mResult.Add(mOperators.Pop());
            }

            return mResult;
        }

        private static decimal calculate(decimal iNumber2, decimal iNumber1, string iOperator)
        {
            switch (iOperator)
            {
                case Operator_Plus:
                    return (iNumber1 + iNumber2);

                case Operator_Minus:
                    return (iNumber1 - iNumber2);

                case Operator_Times:
                    return (iNumber1 * iNumber2);

                case Operator_Divided:
                    return (iNumber1 / iNumber2);

                case Operator_Modulo:
                    return (iNumber1 % iNumber2);

                case Operator_Power:
                    return (decimal)Math.Pow((double)iNumber1, (double)iNumber2);

                default:
                    throw new NotSupportedException($"[default:][{iNumber1}][{iNumber2}][{iOperator}]");
            }
        }

        private static decimal execute(List<string> ioPostfix)
        {
            decimal mResult = ConstNumberValue.Zero;

            Stack<decimal> mStack = new Stack<decimal>();

            foreach (string mBackExpression in ioPostfix)
            {
                decimal mNumber = ConstNumberValue.Zero;

                if (decimal.TryParse(mBackExpression, out mNumber))
                {
                    mStack.Push(mNumber);

                    continue;
                }

                mResult = calculate(mStack.Pop(), mStack.Pop(), mBackExpression);

                mStack.Push(mResult);
            }

            return mResult;
        }

        /// <summary>
        /// Parse the infix expression to a decimal value.
        /// </summary>
        /// <param name="iExpression"></param>
        /// <returns></returns>
        public static decimal ParseInfix(string iExpression)
        {
            decimal mNumber = ConstNumberValue.Zero;

            if (string.IsNullOrWhiteSpace(iExpression))
            {
                throw new ArgumentNullException($"[string.IsNullOrWhiteSpace(iExpression)][{iExpression}]");
            }
            else if (decimal.TryParse((iExpression = iExpression.Replace(ConstString.Blank, ConstString.Empty).Replace(ConstString.HorizontalTab, ConstString.Empty).Replace(ConstString.CarriageReturn, ConstString.Empty).Replace(ConstString.LineFeed, ConstString.Empty)), out mNumber))
            {
                return mNumber;
            }

            mNumber = execute(toPostfixList(toInfixList(iExpression)));

            return mNumber;
        }
    }
}
