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
using GNAy.CSharp6.Portable.Threading.L0030_ThreadLocalInformation;
using GNAy.CSharp6.Portable.Utility.L0000_ELoopStatus;
using GNAy.CSharp6.Portable.Utility.L0020_StringHelper;
#else
using GNAy.CSharp6.Portable.Threading;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0040_LoopRecord
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public class LoopRecord
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly int UniqueThreadID;

        private volatile ELoopStatus _status;

        /// <summary>
        /// 
        /// </summary>
        public LoopRecord()
        {
            UniqueThreadID = ThreadLocalInformation.GetUniqueID();
            _status = ELoopStatus.Unknown;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ELoopStatus GetStatus()
        {
            return _status;
        }
        
        internal void SetStatus(ELoopStatus iTarget)
        {
            switch (iTarget)
            {
                //case ELoopStatus.Unknown:
                //    break;

                case ELoopStatus.IsWaiting:
                    {
                        if (ThreadLocalInformation.GetUniqueID() != UniqueThreadID)
                        {
                            throw new ArgumentException(StringHelper.DefaultJoin("ThreadLocalInformation.GetUniqueID() != UniqueThreadID", ThreadLocalInformation.GetUniqueID(), UniqueThreadID, iTarget, GetStatus()));
                        }

                        switch (GetStatus())
                        {
                            //case ELoopStatus.IsWaiting:
                            //    break;

                            case ELoopStatus.Unknown:
                            //break;

                            //case ELoopStatus.IsInvoking:
                            //    break;

                            //case ELoopStatus.IsStopping:
                            //    break;

                            case ELoopStatus.IsPausing:
                                _status = iTarget;
                                break;

                            //case ELoopStatus.IsStopped:
                            //    break;

                            default:
                                throw new ArgumentException(StringHelper.DefaultJoin("default:", ThreadLocalInformation.GetUniqueID(), UniqueThreadID, iTarget, GetStatus()));
                        }
                    }
                    break;

                case ELoopStatus.IsInvoking:
                    {
                        switch (GetStatus())
                        {
                            case ELoopStatus.Unknown:
                            //break;

                            case ELoopStatus.IsWaiting:
                            //break;

                            case ELoopStatus.IsPausing:
                            //break;

                            case ELoopStatus.IsStopping:
                                _status = iTarget;
                                break;

                            case ELoopStatus.IsInvoking:
                                break;

                            //case ELoopStatus.IsStopped:
                            //    break;

                            default:
                                throw new ArgumentException(StringHelper.DefaultJoin("default:", ThreadLocalInformation.GetUniqueID(), UniqueThreadID, iTarget, GetStatus()));
                        }
                    }
                    break;

                case ELoopStatus.IsPausing:
                    {
                        if (ThreadLocalInformation.GetUniqueID() == UniqueThreadID)
                        {
                            throw new ArgumentException(StringHelper.DefaultJoin("ThreadLocalInformation.GetUniqueID() == UniqueThreadID", ThreadLocalInformation.GetUniqueID(), UniqueThreadID, iTarget, GetStatus()));
                        }

                        switch (GetStatus())
                        {
                            //case ELoopStatus.Unknown:
                            //    break;

                            case ELoopStatus.IsWaiting:
                            //break;

                            case ELoopStatus.IsPausing:
                                break;

                            case ELoopStatus.IsInvoking:
                            //break;

                            case ELoopStatus.IsStopping:
                                _status = iTarget;
                                break;

                            //case ELoopStatus.IsStopped:
                            //    break;

                            default:
                                throw new ArgumentException(StringHelper.DefaultJoin("default:", ThreadLocalInformation.GetUniqueID(), UniqueThreadID, iTarget, GetStatus()));
                        }
                    }
                    break;

                case ELoopStatus.IsStopping:
                    {
                        if (ThreadLocalInformation.GetUniqueID() == UniqueThreadID)
                        {
                            throw new ArgumentException(StringHelper.DefaultJoin("ThreadLocalInformation.GetUniqueID() == UniqueThreadID", ThreadLocalInformation.GetUniqueID(), UniqueThreadID, iTarget, GetStatus()));
                        }

                        switch (GetStatus())
                        {
                            //case ELoopStatus.Unknown:
                            //    break;

                            case ELoopStatus.IsWaiting:
                            //break;

                            case ELoopStatus.IsInvoking:
                            //break;

                            case ELoopStatus.IsPausing:
                                _status = iTarget;
                                break;

                            case ELoopStatus.IsStopping:
                                break;

                            //case ELoopStatus.IsStopped:
                            //    break;

                            default:
                                throw new ArgumentException(StringHelper.DefaultJoin("default:", ThreadLocalInformation.GetUniqueID(), UniqueThreadID, iTarget, GetStatus()));
                        }
                    }
                    break;

                case ELoopStatus.IsStopped:
                    {
                        if (ThreadLocalInformation.GetUniqueID() != UniqueThreadID)
                        {
                            throw new ArgumentException(StringHelper.DefaultJoin("ThreadLocalInformation.GetUniqueID() != UniqueThreadID", ThreadLocalInformation.GetUniqueID(), UniqueThreadID, iTarget, GetStatus()));
                        }

                        switch (GetStatus())
                        {
                            //case ELoopStatus.Unknown:
                            //    break;

                            //case ELoopStatus.IsWaiting:
                            //    break;

                            case ELoopStatus.IsInvoking:
                            //break;

                            case ELoopStatus.IsPausing:
                            //break;

                            case ELoopStatus.IsStopping:
                                _status = iTarget;
                                break;

                            //case ELoopStatus.IsStopped:
                            //    break;

                            default:
                                throw new ArgumentException(StringHelper.DefaultJoin("default:", ThreadLocalInformation.GetUniqueID(), UniqueThreadID, iTarget, GetStatus()));
                        }
                    }
                    break;

                default:
                    throw new ArgumentException(StringHelper.DefaultJoin("default:", ThreadLocalInformation.GetUniqueID(), UniqueThreadID, iTarget, GetStatus()));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            SetStatus(ELoopStatus.IsInvoking);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Pause()
        {
            SetStatus(ELoopStatus.IsPausing);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            SetStatus(ELoopStatus.IsStopping);
        }
    }
}
