using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Unity.FPS.Data
{
    [SerializeField]
    public class CreateTable : MonoBehaviour
    {
        [SerializeField]
        public TableWeapon[] m_TableWeapon;

        [SerializeField]
        public TableCrossHair[] m_TableCrosshair;

        [SerializeField]
        public TableProjectile[] m_TableProjectile;

        public bool Table = false;
        public bool CrossHair = false;
        public bool Projectile = false;

        [ContextMenu("CreateTable")]
        void Create()
        {
            StreamWriter sw;
            if (Table)
            {
                sw = new StreamWriter("Assets/Resources/Data/Table/TableWeapon.json");
                sw.WriteLine(Utility.JsonNewtonsoft.SerializeObject(m_TableWeapon));
                sw.Close();
            }
            if (CrossHair)
            {
                sw = new StreamWriter("Assets/Resources/Data/Table/TableCrossHair.json");
                sw.WriteLine(Utility.JsonNewtonsoft.SerializeObject(m_TableCrosshair));
                sw.Close();
            }
            if (Projectile)
            {
                sw = new StreamWriter("Assets/Resources/Data/Table/TableProjectile.json");
                sw.WriteLine(Utility.JsonNewtonsoft.SerializeObject(m_TableProjectile));
                sw.Close();
            }
        }
    }
}