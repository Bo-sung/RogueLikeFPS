using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.Data
{
    public partial class Table
    {
        public static class Weapon
        {
            [TableLoad(typeof(TableWeapon[]), "Weapon.json")]
            public static TableWeapon[] tableWeapons;

            private static Dictionary<string, TableWeapon> m_dic_TableWeapon;

            /// <summary>
            /// Weapon 데이터 불러오기.
            /// </summary>
            /// <param name="_id"></param>
            /// <returns></returns>
            public static TableWeapon GetData(string _id)
            {
                if (m_dic_TableWeapon == null)
                {
                    m_dic_TableWeapon = new Dictionary<string, TableWeapon>();
                    foreach (var item in tableWeapons)
                    {
                        m_dic_TableWeapon.Add(item.id, item);
                    }
                }

                if (m_dic_TableWeapon.ContainsKey(_id))
                    return m_dic_TableWeapon[_id];
                else
                    return null;
            }
        }
    }
}