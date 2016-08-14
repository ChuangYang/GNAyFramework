using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Threading;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#if Development
using GNAy.CSharp6.Portable.Const.L0000_ConstNumberValue;
using GNAy.CSharp6.Portable.Const.L0010_ConstString;
using GNAy.CSharp6.Portable.Const.L0010_ConstValue;
using GNAy.CSharp6.Portable.Mathematics.L0000_Element;
using GNAy.CSharp6.Portable.Mathematics.L0020_Operator;
#else
using GNAy.CSharp6.Portable.Const;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Mathematics.L0030_Calculator
#else
namespace GNAy.CSharp6.Portable.Mathematics
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public class Calculator
    {
        private static readonly ThreadLocal<List<Element<decimal>>> _threadLocalInfixList;
        private static readonly ThreadLocal<List<Element<decimal>>> _threadLocalPostfixList;

        private static readonly ThreadLocal<Stack<Element<decimal>>> _threadLocalOperators;
        private static readonly ThreadLocal<Stack<decimal>> _threadLocalResults;

        private static List<Element<decimal>> _infixList
        {
            get
            {
                return _threadLocalInfixList.Value;
            }
        }

        private static List<Element<decimal>> _postfixList
        {
            get
            {
                return _threadLocalPostfixList.Value;
            }
        }

        private static Stack<Element<decimal>> _operators
        {
            get
            {
                return _threadLocalOperators.Value;
            }
        }

        private static Stack<decimal> _results
        {
            get
            {
                return _threadLocalResults.Value;
            }
        }

        static Calculator()
        {
            _threadLocalInfixList = new ThreadLocal<List<Element<decimal>>>(() => new List<Element<decimal>>(), true);
            _threadLocalPostfixList = new ThreadLocal<List<Element<decimal>>>(() => new List<Element<decimal>>(), true);

            _threadLocalOperators = new ThreadLocal<Stack<Element<decimal>>>(() => new Stack<Element<decimal>>(), true);
            _threadLocalResults = new ThreadLocal<Stack<decimal>>(() => new Stack<decimal>(), true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iOperator"></param>
        /// <returns></returns>
        public static int GetPriority(string iOperator)
        {
            switch (iOperator)
            {
                case Operator.OpenParenthesis:
                    return ConstNumberValue.One;

                case Operator.Plus:
                case Operator.Minus:
                    return ConstNumberValue.Two;

                case Operator.Times:
                case Operator.Divided:
                case Operator.Modulo:
                case Operator.Power:
                    return ConstNumberValue.Three;

                default:
                    throw new NotSupportedException($"[default:][{iOperator}]");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iNumber2"></param>
        /// <param name="iNumber1"></param>
        /// <param name="iOperator"></param>
        /// <returns></returns>
        public static decimal Execute(decimal iNumber2, decimal iNumber1, string iOperator)
        {
            switch (iOperator)
            {
                case Operator.Plus:
                    return (iNumber1 + iNumber2);

                case Operator.Minus:
                    return (iNumber1 - iNumber2);

                case Operator.Times:
                    return (iNumber1 * iNumber2);

                case Operator.Divided:
                    return (iNumber1 / iNumber2);

                case Operator.Modulo:
                    return (iNumber1 % iNumber2);

                case Operator.Power:
                    return (decimal)Math.Pow((double)iNumber1, (double)iNumber2);

                default:
                    throw new NotSupportedException($"[default:][{iNumber1}][{iNumber2}][{iOperator}]");
            }
        }

        private static void toInfixList(string iInfix)
        {
            _infixList.Clear();

            StringBuilder mElement = new StringBuilder(ConstString.Empty);

            for (int i = ConstValue.StartIndex; i < iInfix.Length; ++i)
            {
                char mCharPiece = iInfix[i];

                if (char.IsNumber(mCharPiece) ||
                    (mCharPiece == ConstString.CharPoint) ||
                    ((mCharPiece == ConstString.CharNegativeNumber) && ((i == ConstValue.StartIndex) || (iInfix[i - ConstNumberValue.One] == ConstString.CharOpenParenthesis))))
                {
                    mElement.Append(mCharPiece);

                    continue;
                }
                else if (mElement.Length > ConstNumberValue.Zero)
                {
                    _infixList.Add(new Element<decimal>(decimal.Parse(mElement.ToString())));
                }

                string mStringPiece = mCharPiece.ToString();

                if (Operator.CheckOrThrow(mStringPiece))
                {
                    _infixList.Add(new Element<decimal>(mStringPiece));
                }

                mElement.Clear();
            }

            if (mElement.Length > ConstNumberValue.Zero)
            {
                _infixList.Add(new Element<decimal>(decimal.Parse(mElement.ToString())));
            }
        }

        private static void toPostfixList()
        {
            _postfixList.Clear();
            _operators.Clear();

            foreach (Element<decimal> mElement in _infixList)
            {
                if (mElement.IsValue)
                {
                    _postfixList.Add(mElement);

                    continue;
                }

                switch (mElement.Operator)
                {
                    case Operator.OpenParenthesis:
                        _operators.Push(mElement);
                        break;

                    case Operator.Plus:
                    case Operator.Minus:
                    case Operator.Times:
                    case Operator.Divided:
                    case Operator.Modulo:
                    case Operator.Power:
                        {
                            while ((_operators.Count > ConstValue.Empty) && (GetPriority(_operators.Peek().Operator) >= GetPriority(mElement.Operator)))
                            {
                                _postfixList.Add(_operators.Pop());
                            }

                            _operators.Push(mElement);
                        }
                        break;

                    case Operator.CloseParenthesis:
                        {
                            while (_operators.Peek().Operator != Operator.OpenParenthesis)
                            {
                                _postfixList.Add(_operators.Pop());
                            }

                            _operators.Pop();
                        }
                        break;

                    default:
                        throw new NotSupportedException($"[default:][{mElement.Operator}]");
                }
            }

            while (_operators.Count > ConstValue.Empty)
            {
                _postfixList.Add(_operators.Pop());
            }
        }

        private static decimal execute()
        {
            decimal mResult = ConstNumberValue.Zero;

            foreach (Element<decimal> mExpression in _postfixList)
            {
                if (mExpression.IsValue)
                {
                    _results.Push(mExpression.Value);

                    continue;
                }

                mResult = Execute(_results.Pop(), _results.Pop(), mExpression.Operator);

                _results.Push(mResult);
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
                throw new ArgumentException($"[string.IsNullOrWhiteSpace(iExpression)][{iExpression}]");
            }
            else if (decimal.TryParse((iExpression = iExpression.Replace(ConstString.Blank, ConstString.Empty).Replace(ConstString.HorizontalTab, ConstString.Empty).Replace(ConstString.CarriageReturn, ConstString.Empty).Replace(ConstString.LineFeed, ConstString.Empty)), out mNumber))
            {
                return mNumber;
            }

            toInfixList(iExpression);
            toPostfixList();

            return execute();
        }
    }
}
