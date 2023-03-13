using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Unity.FPS.Data
{
    public partial class Table
    {
        public static class CrossHair
        {
            [TableLoad(typeof(TableCrossHair[]), "CrossHair.json")]
            public static TableCrossHair[] tableCrossHair;

            private static Dictionary<string, TableCrossHair> m_dic_TableWeapons;

            /// <summary>
            /// 크로스 헤어 데이터 불러오기.
            /// </summary>
            /// <param name="_id"></param>
            /// <returns></returns>
            public static TableCrossHair GetData(string _id)
            {
                if (m_dic_TableWeapons == null)
                {
                    m_dic_TableWeapons = new Dictionary<string, TableCrossHair>();
                    foreach (var item in tableCrossHair)
                    {
                        m_dic_TableWeapons.Add(item.id, item);
                    }
                }

                if (m_dic_TableWeapons.ContainsKey(_id))
                    return m_dic_TableWeapons[_id];
                else
                    return null;
            }
        }
    }
}