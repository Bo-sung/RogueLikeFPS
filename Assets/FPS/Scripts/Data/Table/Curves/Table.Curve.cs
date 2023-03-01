using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.FPS.Data
{
    public partial class Table
    {
        public static class Curve
        {
            [TableLoad(typeof(TableCurve[]), "Curve.json")]
            public static TableCurve[] tableCurves;

            private static Dictionary<string, TableCurve> m_Dic_TableCurves;
            private static Dictionary<string, Keyframe[]> mDicKeyFrames;
            public static TableCurve GetCurve(string _id)
            {
                if(m_Dic_TableCurves == null)
                {
                    m_Dic_TableCurves = new Dictionary<string, TableCurve>();
                    foreach(var item in tableCurves)
                    {
                        m_Dic_TableCurves.Add(item.id, item);
                    }
                }

                if (m_Dic_TableCurves.ContainsKey(_id))
                    return m_Dic_TableCurves[_id];
                else
                    return null;
            }

            public static Keyframe[] Convert_Keyframe(_KeyFrame[] frames)
            {
                Keyframe[] mKeyframe = new Keyframe[frames.Length];
                if (mKeyframe == null)
                {
                    for (int i = 0; i < frames.Length; ++i)
                    {
                        mKeyframe[i] = new Keyframe(frames[i].time, frames[i].value, frames[i].inTangent, frames[i].outTangent, frames[i].inWeight, frames[i].outWeight);
                    }
                }

                return mKeyframe;
            }

            public static Keyframe[] GetKeyframes(string _id)
            {
                if (mDicKeyFrames == null)
                {
                    mDicKeyFrames = new Dictionary<string, Keyframe[]>();
                }

                //저장된거 있으면 넘겨줌
                if (mDicKeyFrames.ContainsKey(_id))
                    return mDicKeyFrames[_id];
                else
                {
                    //없으니까 일단 찾아보고
                    var temp = GetCurve(_id);
                    //찾았는데 없으면 널
                    if (temp == null)
                        return null;
                    //찾았으면 꺼내서 등록
                    mDicKeyFrames.Add(_id, Data.Table.Curve.Convert_Keyframe(temp.frames));

                    //꺼낸거 보냄
                    return mDicKeyFrames[_id];
                }
            }
        }
    }
}
