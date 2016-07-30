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

#if Development
namespace GNAy.CSharp6.Portable.Sample.L0000_SingletonWithLazy
#else
namespace GNAy.CSharp6.Portable.Sample
#endif
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class SingletonWithLazy
    {
        private static readonly Lazy<SingletonWithLazy> _instance;

        static SingletonWithLazy() //The CLR guarantees that the static constructor will be invoked only once for the entire lifetime of the application domain.
        {
            _instance = new Lazy<SingletonWithLazy>(() => new SingletonWithLazy());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool IsInstanceCreated()
        {
            return _instance.IsValueCreated;
        }

        /// <summary>
        /// Get the thread-safe singleton object.
        /// </summary>
        /// <returns></returns>
        public static SingletonWithLazy GetInstance() //Lazy initialization.
        {
            return _instance.Value;
        }
    }
}
