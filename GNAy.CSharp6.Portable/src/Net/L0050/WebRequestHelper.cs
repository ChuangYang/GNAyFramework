﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.IO;
using System.Net;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#if Development
using GNAy.CSharp6.Portable.Const.L0000_ConstNumberValue;
using GNAy.CSharp6.Portable.Const.L0010_ConstValue;
using GNAy.CSharp6.Portable.Utility.L0040_ThreadLocalMemberObserver;
#else
using GNAy.CSharp6.Portable.Const;
using GNAy.CSharp6.Portable.Utility;
#endif
#endregion

#region Alias.
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Utility.L0050_WebRequestHelper
#else
namespace GNAy.CSharp6.Portable.Utility
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public static class WebRequestHelper
    {
        //public static async Task<WebResponse> GetWebResponse(string iURL)
        //{
        //    HttpWebRequest mWebRequest = WebRequest.CreateHttp(iURL);

        //    mWebRequest.Method = "GET"; //GET (Create) / PUT (Read) / POST (Update) / DELETE (Delete)
        //    mWebRequest.ContentType = "application/x-www-form-urlencoded";
        //    //mWebRequest.ContinueTimeout = (5 * 1000);

        //    return await mWebRequest.GetResponseAsync();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static async Task<byte[]> zGetResponseBytes(this WebRequest ioSource)
        {
            using (WebResponse mWebResponse = await ioSource.GetResponseAsync())
            {
                using (Stream mStream = mWebResponse.GetResponseStream())
                {
                    using (MemoryStream mMemoryStream = new MemoryStream())
                    {
                        mStream.CopyTo(mMemoryStream);

                        return mMemoryStream.ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSourceAndBackups"></param>
        /// <returns></returns>
        public static async Task<byte[]> zGetResponseBytes(this IList<WebRequest> ioSourceAndBackups)
        {
            for (int i = ConstValue.StartIndex; i < ioSourceAndBackups.Count; ++i)
            {
                try
                {
                    return await zGetResponseBytes(ioSourceAndBackups[i]);
                }
                catch (Exception mException)
                {
                    if (i == (ioSourceAndBackups.Count - ConstNumberValue.One))
                    {
                        throw mException;
                    }

                    mException.zSaveMemberInfo(mException.StackTrace);
                }
                finally
                { }
            }

            throw new ArgumentException($"[for (int i = ConstValue.StartIndex; i < ioSourceAndBackups.Count; ++i)][{ioSourceAndBackups.Count}]");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSource"></param>
        /// <param name="ioEncoding"></param>
        /// <returns></returns>
        public static async Task<string> zGetResponseString(this WebRequest ioSource, Encoding ioEncoding)
        {
            using (WebResponse mWebResponse = await ioSource.GetResponseAsync())
            {
                using (Stream mStream = mWebResponse.GetResponseStream())
                {
                    using (StreamReader mStreamReader = new StreamReader(mStream, ioEncoding))
                    {
                        return mStreamReader.ReadToEnd();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioSourceAndBackups"></param>
        /// <param name="ioEncoding"></param>
        /// <returns></returns>
        public static async Task<string> zGetResponseString(this IList<WebRequest> ioSourceAndBackups, Encoding ioEncoding)
        {
            for (int i = ConstValue.StartIndex; i < ioSourceAndBackups.Count; ++i)
            {
                try
                {
                    return await zGetResponseString(ioSourceAndBackups[i], ioEncoding);
                }
                catch (Exception mException)
                {
                    if (i == (ioSourceAndBackups.Count - ConstNumberValue.One))
                    {
                        throw mException;
                    }

                    mException.zSaveMemberInfo(mException.StackTrace);
                }
                finally
                { }
            }

            throw new ArgumentException($"[for (int i = ConstValue.StartIndex; i < ioSourceAndBackups.Count; ++i)][{ioSourceAndBackups.Count}]");
        }
    }
}
