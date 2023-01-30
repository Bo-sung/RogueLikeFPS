using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Serialization;

namespace Unity.FPS.Utility
{
    public class JsonNewtonsoft
    {
        public static object DeserializeObject(string strJson)
        {
            return JsonConvert.DeserializeObject(strJson);
        }

        public static T DeserializeObject<T>(string strJson)
        {
            return JsonConvert.DeserializeObject<T>(strJson);
        }

        public static object DeserializeObject(string strJson, System.Type type)
        {
            return JsonConvert.DeserializeObject(strJson, type);
        }

        public static string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }

    public class Json
    {
        public static object DeserializeObject(string _json, System.Type _type)
        {
            return JsonUtility.FromJson(_json, _type);
        }

        public static T DeserializeObject<T>(string _json)
        {
            return JsonUtility.FromJson<T>(_json);
        }

        public static void DeserializeObject(string _json, object _overwriteTarget)
        {
            JsonUtility.FromJsonOverwrite(_json, _overwriteTarget);
        }

        public static string SerializeObject(object _obj)
        {
            return JsonUtility.ToJson(_obj);
        }

        public static string SerializeObject(object _obj, bool _Is_spread)
        {
            return JsonUtility.ToJson(_obj, _Is_spread);
        }
    }

}