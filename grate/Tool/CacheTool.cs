using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Collections;

namespace Com.Tool
{
    public class CacheTool
    {
        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string CacheKey)
        {           
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }
        public static void ClearCache()
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            foreach (DictionaryEntry i in objCache)
            {
                objCache.Remove(i.Key.ToString());
            }
        }
        public static object RemoveCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache.Remove(CacheKey);
        }
        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, absoluteExpiration, Cache.NoSlidingExpiration);
        }
        public static void SetCache(string CacheKey, object objObject,  TimeSpan slidingExpiration)
        {
            Cache objCache = HttpRuntime.Cache;
            
            objCache.Insert(CacheKey, objObject, null, Cache.NoAbsoluteExpiration, slidingExpiration);
        }

    }
}
