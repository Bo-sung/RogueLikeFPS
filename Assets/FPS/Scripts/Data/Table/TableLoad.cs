using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Unity.FPS.Data
{
    public class TableLoad : Attribute
    {
        public Type type;
        public string path;

        public TableLoad() { }
        public TableLoad(Type type, string path)
        {
            this.type = type;
            this.path = path;
        }

        public virtual object GetValue()
        {
            string strJson = Resources.Load<TextAsset>(string.Format("Data/Table/{0}", path)).text;
            return Utility.JsonNewtonsoft.DeserializeObject(strJson, type);
        }
    }
}