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
        public static class Entity
        {
            [TableLoad(typeof(TableEntity[]), "Entity.json")]
            public static TableEntity[] tableCurves;

            public static string PlayerID;
            private static Dictionary<string, TableEntity> m_Dic_TableEntity;
            public static TableEntity GetData(string _id)
            {
                if (m_Dic_TableEntity == null)
                {
                    m_Dic_TableEntity = new Dictionary<string, TableEntity>();
                    foreach (var item in tableCurves)
                    {
                        m_Dic_TableEntity.Add(item.id, item);
                    }
                }

                if (m_Dic_TableEntity.ContainsKey(_id))
                    return m_Dic_TableEntity[_id];
                else
                    return null;
            }

            public static TableEntity GetPlayerData()
            {

                if (m_Dic_TableEntity == null)
                {
                    m_Dic_TableEntity = new Dictionary<string, TableEntity>();
                    foreach (var item in tableCurves)
                    {
                        m_Dic_TableEntity.Add(item.id, item);
                    }
                }

                if (m_Dic_TableEntity.ContainsKey(PlayerID))
                    return m_Dic_TableEntity[PlayerID];
                else
                    return null;
            }
        }
    }
}
