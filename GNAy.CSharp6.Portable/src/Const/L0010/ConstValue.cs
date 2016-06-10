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
#endregion

#region Alias.
#endregion

namespace GNAy.CSharp6.Portable.Const
{
    /// <summary>
    /// 
    /// </summary>
    public class ConstValue
    {
        /// <summary>
        /// 0
        /// </summary>
        public const int Empty = ConstNumberValue.Zero;

        /// <summary>
        /// 0
        /// </summary>
        public const int StartIndex = ConstNumberValue.Zero;

        /// <summary>
        /// -1
        /// </summary>
        public const int AllItems = -1;

        /// <summary>
        /// -1
        /// </summary>
        public const int Infinite = Timeout.Infinite;

        /// <summary>
        /// -1
        /// </summary>
        public const int NotFound = (StartIndex - ConstNumberValue.One);
        
        /// <summary>
        /// 2
        /// </summary>
        public const int CharSize = 2;

        /// <summary>
        /// 4
        /// </summary>
        public const int IntSize = 4;

        /// <summary>
        /// 8
        /// </summary>
        public const int LongSize = 8;
    }
}
