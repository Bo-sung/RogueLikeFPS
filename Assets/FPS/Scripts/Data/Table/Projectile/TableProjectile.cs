using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.FPS.Data
{
    [System.Serializable]
    public class TableProjectile
    {
        public int index;
        public string id;
        public string prefab_id;
        public Parameter_General general;
        public Parameter_Movement movement;
        public Parameter_Damage damage;
    }

    [System.Serializable]
    public struct Parameter_General
    {
        public float radius;
        public float maxLifeTime;
        public string impacktVFX_id;
        public float impactVFXLifetime;
        public float impactVFXSpawnOffset;
        public string impacktSFXClip_id;
        public LayerMask hittableLayers;
    }

    [System.Serializable]
    public struct Parameter_Movement
    {
        public float speed;
        public float gravityDownAcceleration;
        public float trajectoryCorrectionDistance;
        public bool inheritWeaponVelocity;
    }

    [System.Serializable]
    public struct Parameter_Damage
    {
        public float value;
        public Parameter_DamageArea damageArea;
    }

    [System.Serializable]
    public struct Parameter_DamageArea
    {
        public float areaOfEffectDistance;
        public string damageRatioOverDistance_AnimCurve;
        public float Debug_AreaOfEffectColor_R;
        public float Debug_AreaOfEffectColor_G;
        public float Debug_AreaOfEffectColor_B;
        public float Debug_AreaOfEffectColor_A;
    }

}
