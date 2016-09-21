using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RealNext.Infrastructure.Utilities
{
    /// <summary>
    /// Json Utility
    /// </summary>
    public class JsonUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string jsonString)
        {
            if (String.IsNullOrEmpty(jsonString))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <param name="jsonSerializerSettings"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string jsonString, JsonSerializerSettings jsonSerializerSettings)
        {
            if (String.IsNullOrEmpty(jsonString))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(jsonString, jsonSerializerSettings);
        }
    }
}
