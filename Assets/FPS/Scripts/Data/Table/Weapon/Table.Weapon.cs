using System;
using UnityEngine;

namespace Unity.FPS.Data
{
    public partial class Table
    {
        public class Weapon
        {
            [TableLoad(typeof(TableWeapon[]), "Weapon")]
            public static TableWeapon[] tableWeapons;
        }
    }
}