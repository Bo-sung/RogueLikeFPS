using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Reflection;

namespace Unity.FPS.Data
{
    public partial class Table
    {
        public static void LoadData()
        {
            var fieldInfos = typeof(Table).GetNestedTypes();
            for (int i = 0, count = fieldInfos.Length; i < count; i++)
            {
                Debug.Log("Load Table." + fieldInfos[i].Name);
                LoadData(fieldInfos[i]);
                Debug.Log("Table." + fieldInfos[i].Name + " Load Complete");
            }
        }

        private static void LoadData(Type type)
        {
            FieldInfo[] fieldInfos = type.GetFields();
            for (int i = 0, count = fieldInfos.Length; i < count; i++)
            {
                TableLoad tableLoad = fieldInfos[i].GetCustomAttribute<TableLoad>();
                if (tableLoad != null)
                {
                    object data = tableLoad.GetValue();
                    fieldInfos[i].SetValue(type, data);
                }
            }
        }
    }
}
