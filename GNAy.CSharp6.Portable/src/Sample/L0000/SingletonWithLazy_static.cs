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

namespace GNAy.CSharp6.Portable.Sample
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class SingletonWithLazy
    {
        private static readonly Lazy<SingletonWithLazy> _instance;

        /// <summary>
        /// Get the thread-safe singleton object.
        /// </summary>
        /// <returns></returns>
        public static SingletonWithLazy Instance //Lazy initialization.
        {
            get
            {
                return _instance.Value;
            }
        }

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
    }
}
