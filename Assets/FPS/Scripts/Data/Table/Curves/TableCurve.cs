using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.FPS.Data
{
    [System.Serializable]
    public class TableCurve
    {
        public int index;
        public string id;
        public _KeyFrame[] frames;       
    }

    [System.Serializable]
    public struct _KeyFrame
    {
        public float time;
        public float value;
        public float inTangent;
        public float outTangent;
        public float inWeight;
        public float outWeight;
    }
}
