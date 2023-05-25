using System.Collections.Generic;

namespace Exadel.Compreface.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class DictionaryHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns></returns>
        public static V GetValueOrDefault<K, V>(this Dictionary<K, V> dictionary, K key)
        {
            return dictionary.TryGetValue(key, out var value) ? value : default;
        }
    }
}