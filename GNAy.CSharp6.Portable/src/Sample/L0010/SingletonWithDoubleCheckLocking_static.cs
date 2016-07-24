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
using GNAy.CSharp6.Portable.Utility;
#endregion

#region Alias.
#endregion

namespace GNAy.CSharp6.Portable.Sample
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class SingletonWithDoubleCheckLocking
    {
        private static readonly object _syncRoot;
        private static volatile SingletonWithDoubleCheckLocking _instance;

        /// <summary>
        /// Get the thread-safe singleton object.
        /// </summary>
        /// <returns></returns>
        public static SingletonWithDoubleCheckLocking Instance //Lazy initialization.
        {
            get
            {
                if (_instance.zIsNull())
                {
                    lock (_syncRoot) //Double-Check Locking
                    {
                        if (_instance.zIsNull())
                        {
                            _instance = new SingletonWithDoubleCheckLocking();
                        }
                    }
                }

                return _instance;
            }
        }

        static SingletonWithDoubleCheckLocking() //The CLR guarantees that the static constructor will be invoked only once for the entire lifetime of the application domain.
        {
            _syncRoot = new Object();
            _instance = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool IsInstanceCreated()
        {
            return _instance.zIsNotNull();
        }
    }
}
