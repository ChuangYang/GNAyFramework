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
using GNAy.CSharp6.Portable.Utility.L0010_TimeHelper;
#else
using GNAy.CSharp6.Portable.Utility;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Information.L0020_LibraryInformation
#else
namespace GNAy.CSharp6.Portable.Information
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public class LibraryInformation
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime CreationTime;

        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid Guid;

        /// <summary>
        /// 
        /// </summary>
        public static readonly int UniqueID;

        static LibraryInformation()
        {
            CreationTime = TimeHelper.GetTimeNowByPreprocessor();
            Guid = Guid.NewGuid();
            UniqueID = (CreationTime.GetHashCode() ^ Guid.GetHashCode());
        }

        /// <summary>
        /// Initialize the static instance.
        /// </summary>
        public static void Initialize()
        { }
    }
}
