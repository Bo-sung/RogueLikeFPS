﻿using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Unity.FPS.Data
{
    public partial class Table
    {
        public class CrossHair
        {
            [TableLoad(typeof(TableCrossHair[]), "Weapon")]
            public static TableCrossHair[] tableWeapons;

            private static Dictionary<string, TableCrossHair> m_dic_TableWeapons;

            /// <summary>
            /// 크로스 헤어 데이터 불로오기.
            /// </summary>
            /// <param name="_id"></param>
            /// <returns></returns>
            public static TableCrossHair GetData(string _id)
            {
                if (m_dic_TableWeapons == null)
                {
                    m_dic_TableWeapons = new Dictionary<string, TableCrossHair>();
                    foreach (var item in tableWeapons)
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