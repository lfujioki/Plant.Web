using Plants.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Plants.Web
{
    public static class DictionaryExt
    {
        public static Hashtable _stringValues { get; set; }

        public static Dictionary<string, string> ToDictionary(this Enum @enum)
        {
            var type = @enum.GetType();
            return Enum.GetValues(type).Cast<int>().ToDictionary(e => e.ToString(), e => Enum.GetName(type, e));
        }


        public static Dictionary<string, string> ToDictionary<T>(this T @enum) where T : struct
        {
            var type = @enum.GetType();
            return Enum.GetValues(type).Cast<int>().ToDictionary(e => e.ToString(), e => Enum.GetName(type, e));
        }

        public static KeyValuePair<int, string>[] ToJsonDictionary<T>(this T @enum) where T : struct
        {
            var type = @enum.GetType();
            return Enum.GetValues(type).Cast<int>().Select(e => new
                KeyValuePair<int, string>(Convert.ToInt32(e.ToString()), Enum.GetName(type, e))).ToArray();
        }

        public static Dictionary<string, int> ToDictionary<T>(this T @enum, int minValue) where T : struct
        {
            var type = @enum.GetType();
            return Enum.GetValues(type).Cast<int>().Where(i => i >= minValue).ToDictionary(e => Enum.GetName(type, e), e => e);
        }

        public static Dictionary<int, string> ToDictionaryByValue<T>(this T @enum, int minValue = 0) where T : struct
        {
            Type type = @enum.GetType();

            Dictionary<int, string> dic = new Dictionary<int, string>();

            foreach (var item in Enum.GetValues(@enum.GetType()))
            {
                int val = (int)item;
                if (val >= minValue)
                {
                    dic.Add(val, item.ToString());
                }
            }

            return dic;
        }

        public static Dictionary<string, int> ToDictionaryByName<T>(this T @enum, int minValue = 0) where T : struct
        {
            Type type = @enum.GetType();

            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (var item in Enum.GetValues(@enum.GetType()))
            {
                int val = (int)item;
                if (val >= minValue)
                {
                    dic.Add(item.ToString(), val);
                }
            }

            return dic;
        }
    }
}