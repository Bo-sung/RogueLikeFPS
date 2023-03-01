using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
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
            StreamReader sr;
            sr = new StreamReader(string.Format("Assets/Resources/Data/Table/{0}", path));
            return Utility.JsonNewtonsoft.DeserializeObject(sr.ReadToEnd(),type);
        }

        public virtual void SetValue(object obj)
        {
            StreamWriter sw;
            sw = new StreamWriter(string.Format("Assets/Resources/Data/Table/{0}", path));
            sw.WriteLine(Utility.JsonNewtonsoft.SerializeObject(obj));
            sw.Close();
        }
    }
}