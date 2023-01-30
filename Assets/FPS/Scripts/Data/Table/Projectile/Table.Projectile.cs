using System;
using UnityEngine;
using System.Collections.Generic;

namespace Unity.FPS.Data
{
    public partial class Table
    {
        public class Projectile
        {
            [TableLoad(typeof(TableProjectile[]), "Projectile")]
            public static TableProjectile[] tableProjectile;

            private static Dictionary<string, TableProjectile> m_dic_TableProjectile;

            /// <summary>
            /// Projectile 데이터 불로오기.
            /// </summary>
            /// <param name="_id"></param>
            /// <returns></returns>
            public static TableProjectile GetData(string _id)
            {
                if (m_dic_TableProjectile == null)
                {
                    m_dic_TableProjectile = new Dictionary<string, TableProjectile>();
                    foreach (var item in tableProjectile)
                    {
                        m_dic_TableProjectile.Add(item.id, item);
                    }
                }

                if (m_dic_TableProjectile.ContainsKey(_id))
                    return m_dic_TableProjectile[_id];
                else
                    return null;
            }
        }
    }
}
