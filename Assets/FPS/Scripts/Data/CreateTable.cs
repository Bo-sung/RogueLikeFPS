using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Unity.FPS.Data
{
    [System.Serializable]
    public class AnimCurve_EditorDisplay
    {
        public int index;
        public string id;
        public AnimationCurve Curve;

        public TableCurve Convert()
        {
            var temp = new TableCurve();
            var _frames = Curve.keys;
            temp.frames = new _KeyFrame[_frames.Length];
            for (int i = 0; i < _frames.Length; ++i)
            {
                temp.frames[i] = new _KeyFrame();
                temp.frames[i].time = _frames[i].time;
                temp.frames[i].value = _frames[i].value;
                temp.frames[i].inTangent = _frames[i].inTangent;
                temp.frames[i].outTangent = _frames[i].outTangent;
                temp.frames[i].inWeight = _frames[i].inWeight;
                temp.frames[i].outWeight = _frames[i].outWeight;
            }
            return temp;
        }

        public AnimCurve_EditorDisplay(TableCurve _data)
        {
            this.index = _data.index;
            this.id = _data.id;
            this.Curve = new AnimationCurve(Data.Table.Curve.Convert_Keyframe(_data.frames));
        }
    }


    [SerializeField]
    public class CreateTable : MonoBehaviour
    {
        [SerializeField]
        public TableWeapon[] m_TableWeapon => Data.Table.Weapon.tableWeapons;

        [SerializeField]
        public TableCrossHair[] m_TableCrosshair => Data.Table.CrossHair.tableCrossHair;

        [SerializeField]
        public TableProjectile[] m_TableProjectile => Data.Table.Projectile.tableProjectile;

        [SerializeField]
        public AnimCurve_EditorDisplay[] Curves;

        TableCurve[] m_TableCurve = Data.Table.Curve.tableCurves;

        public bool Table = false;
        public bool CrossHair = false;
        public bool Projectile = false;
        public bool Curve = false;

        private void Awake()
        {
            var temp = new TableCurve[2];
            //temp[0] = new TableCurve();
            //temp[0].index = 0;
            //temp[0].id = "0";
            //temp[0].frames = new _KeyFrame[2];
            //temp[0].frames[0].time = 0.0f;
            //temp[0].frames[0].value = 1.0f;
            //temp[0].frames[0].inTangent = -0.004528313f;
            //temp[0].frames[0].outTangent = -0.004528313f;
            //temp[0].frames[0].inWeight = 0.0f;
            //temp[0].frames[0].outWeight = 0.5208333f;
            //temp[0].frames[1].time = 1.0f;
            //temp[0].frames[1].value = 0.0f;
            //temp[0].frames[1].inTangent = -2.88679123f;
            //temp[0].frames[1].outTangent = -2.88679123f;
            //temp[0].frames[1].inWeight = 0.0416666865f;
            //temp[0].frames[1].outWeight = 0.0f;
            //temp[1] = new TableCurve();
            //temp[1].index = 1;
            //temp[1].id = "1";
            //temp[1].frames = new _KeyFrame[2];
            //temp[1].frames[0].time = 0.0f;
            //temp[1].frames[0].value = 1.0f;
            //temp[1].frames[0].inTangent = -0.004528313f;
            //temp[1].frames[0].outTangent = -0.004528313f;
            //temp[1].frames[0].inWeight = 0.0f;
            //temp[1].frames[0].outWeight = 0.5208333f;
            //temp[1].frames[1].time = 1.0f;
            //temp[1].frames[1].value = 0.0f;
            //temp[1].frames[1].inTangent = -2.88679123f;
            //temp[1].frames[1].outTangent = -2.88679123f;
            //temp[1].frames[1].inWeight = 0.0416666865f;
            //temp[1].frames[1].outWeight = 0.0f;
            //
            //var temp2 = Utility.JsonNewtonsoft.SerializeObject(temp);

            //var obj = Utility.JsonNewtonsoft.DeserializeObject(temp2, typeof(TableCurve[]));
            
            Data.Table.Curve.tableCurves = temp;
            for (int i = 0; i < Curves.Length; ++i)
            {
                Data.Table.Curve.tableCurves[i] = Curves[i].Convert();
            }
            Data.Table.LoadData();
        }

        [ContextMenu("PushTable")]
        void SaveTable()
        {
            for (int i = 0; i < Curves.Length; ++i)
            {
                Data.Table.Curve.tableCurves[i] = Curves[i].Convert();
            }
            Data.Table.SaveData();
        }

        [ContextMenu("PullTable")]
        void LoadTable()
        {
            StreamReader sw;
            Data.Table.LoadData();

            Curves = new AnimCurve_EditorDisplay[m_TableCurve.Length];
            for (int i = 0; i < Curves.Length; ++i)
            {
                Curves[i] = new AnimCurve_EditorDisplay(m_TableCurve[i]);
            }
        }
    }
}