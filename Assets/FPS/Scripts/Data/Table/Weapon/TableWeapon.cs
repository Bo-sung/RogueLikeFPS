using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.FPS.Data
{
    [System.Serializable]
    public class TableWeapon
    {
        public int index;
        public string id;
        public string prefab_id;
        public Weapon_Info info;
        public Parameter_Shoot shootParam;
        public Parameter_Ammo ammoParam;
        public Parameter_Charging chargingParam;
        public Parameter_AudioVisualData audioVisualData;
    }

    [System.Serializable]
    public struct Weapon_Info
    {
        public string name;
        public string icon_id;
        public string crosshairDefault_Data_id;
        public string crosshairTargetInSight_Data_id;
    }

    [System.Serializable]
    public struct Parameter_Shoot
    {
        public WeaponShootType weaponShootType;
        public string projectile_id;
        public float delayBetweenShots;
        public float bulletSpreadAngle;
        public int bulletPerShot;
        public float recoilForce;
        public float aimZoomRatio;
        public float AimOffset_x;
        public float AimOffset_y;
        public float AimOffset_z;
    }

    [System.Serializable]
    public struct Parameter_Ammo
    {
        public bool automaticReload;
        public bool hasPysicalBullets;
        public int clipSize;
        public string shellCasing_id;
        public float shellCasingEjectionForce;
        public int shellPoolSize;
        public float ammoReloadRate;
        public float ammoReloadDelay;
        public int maxAmmo;
    }

    [System.Serializable]
    public struct Parameter_Charging
    {
        public bool automaticReleaseOnCharged;
        public float maxChargeDuration;
        public float ammoUsedOnStartCharge;
        public float ammoUsageRateWhileCharging;
    }

    [System.Serializable]
    public struct Parameter_AudioVisualData
    {
        public string muzzleFlashPrefab_id;
        public bool unParrentMuzzleFlash;
        public string shootSFX_id;
        public string changeWeaponSFX_id;
        public bool useContinuiusShootSound;
        public string continuousShootStartSFX_id;
        public string continuousShootLoopSFX_id;
        public string continuousShootEndSFX_id;
    }
}





