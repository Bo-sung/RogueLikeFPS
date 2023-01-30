using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.FPS.Data;

namespace Unity.FPS.Game
{
    [System.Serializable]
    public class WeaponData
    {
        [Header("Information")]
        public WeaponInfo Info;

        [Header("Shoot Parameters")]
        public ShootParameter shootParameters;

        [Header("Ammo Parameters")]
        public AmmoParameter ammoParameters;

        [Header("Charging parameters (charging weapons only)")]
        public ChargingParameter chargingParameters;

        [Header("Audio & Visual")]
        public AudioVisualData audioVisualData;

        public WeaponData(TableWeapon _tableData )
        {
            this.Info = new WeaponInfo(_tableData.info);
        }
    }

    [System.Serializable]
    public class CrosshairData : ScriptableObject
    {
        [Tooltip("The image that will be used for this weapon's crosshair")]
        public Sprite CrosshairSprite;

        [Tooltip("The size of the crosshair image")]
        public int CrosshairSize;

        [Tooltip("The color of the crosshair image")]
        public Color CrosshairColor;

        public CrosshairData(TableCrossHair _tableData)
        {
            CrosshairSprite = Resources.Load<Sprite>(string.Format("ArtResources/CrossHair/{0}",_tableData.crossHairSprite_id));
            CrosshairSize = _tableData.crossHairSize;
            CrosshairColor = new Color(_tableData.Color_R, _tableData.Color_G, _tableData.Color_B, _tableData.Color_A);
        }
    }

    [System.Serializable]
    public class WeaponInfo
    {
        [Header("Information")]
        [Tooltip("The name that will be displayed in the UI for this weapon")]
        public string WeaponName;

        [Tooltip("The image that will be displayed in the UI for this weapon")]
        public Sprite WeaponIcon;

        [Tooltip("Default data for the crosshair")]
        public CrosshairData CrosshairDataDefault;

        [Tooltip("Data for the crosshair when targeting an enemy")]
        public CrosshairData CrosshairDataTargetInSight;

        public WeaponInfo(Weapon_Info _info)
        {
            this.WeaponName = _info.name;
            this.WeaponIcon = Resources.Load<Sprite>(string.Format("ArtResources/WeaponIcon/{0}", _info.icon_id));
            this.CrosshairDataDefault = new CrosshairData(Table.CrossHair.GetData(_info.crosshairDefault_Data_id));
            this.CrosshairDataTargetInSight = new CrosshairData(Table.CrossHair.GetData(_info.crosshairTargetInSight_Data_id));
        }
    }

    [System.Serializable]
    public class ShootParameter
    {
        [Tooltip("The type of weapon wil affect how it shoots")]
        public Data.WeaponShootType ShootType;

        [Tooltip("The projectile prefab")]
        public ProjectileBase ProjectilePrefab;

        [Tooltip("Minimum duration between two shots")]
        public float DelayBetweenShots;

        [Tooltip("Angle for the cone in which the bullets will be shot randomly (0 means no spread at all)")]
        public float BulletSpreadAngle;

        [Tooltip("Amount of bullets per shot")]
        public int BulletsPerShot;

        [Tooltip("Force that will push back the weapon after each shot")]
        [Range(0f, 2f)]
        public float RecoilForce;

        [Tooltip("Ratio of the default FOV that this weapon applies while aiming")]
        [Range(0f, 1f)]
        public float AimZoomRatio;

        [Tooltip("Translation to apply to weapon arm when aiming with this weapon")]
        public Vector3 AimOffset;

        public ShootParameter(Parameter_Shoot _param)
        {
            var projectileData = Table.Projectile.GetData(_param.projectile_id);
            this.ShootType = _param.weaponShootType;
            this.ProjectilePrefab = ProjectileBase.GetPrefab(projectileData.prefab_id);
            this.ProjectilePrefab.SetData(new Gameplay.ProjectileData(projectileData)); 
            this.DelayBetweenShots = _param.delayBetweenShots;
            this.BulletSpreadAngle = _param.bulletSpreadAngle;
            this.BulletsPerShot = _param.bulletPerShot;
            this.RecoilForce = _param.recoilForce;
            this.AimZoomRatio = _param.aimZoomRatio;
            this.AimOffset = new Vector3(_param.AimOffset_x, _param.AimOffset_y, _param.AimOffset_z);
        }
    }

    [System.Serializable]
    public class AmmoParameter
    {
        [Tooltip("Should the player manually reload")]
        public bool AutomaticReload;
        [Tooltip("Has physical clip on the weapon and ammo shells are ejected when firing")]
        public bool HasPhysicalBullets;
        [Tooltip("Number of bullets in a clip")]
        public int ClipSize;
        [Tooltip("Bullet Shell Casing")]
        public GameObject ShellCasing;
        [Tooltip("Force applied on the shell")]
        [Range(0.0f, 5.0f)] public float ShellCasingEjectionForce;
        [Tooltip("Maximum number of shell that can be spawned before reuse")]
        [Range(1, 30)] public int ShellPoolSize;
        [Tooltip("Amount of ammo reloaded per second")]
        public float AmmoReloadRate;

        [Tooltip("Delay after the last shot before starting to reload")]
        public float AmmoReloadDelay;

        [Tooltip("Maximum amount of ammo in the gun")]
        public int MaxAmmo;

        public AmmoParameter(Parameter_Ammo _param)
        {
            this.AutomaticReload = _param.automaticReload;
            this.HasPhysicalBullets = _param.hasPysicalBullets;
            this.ClipSize = _param.clipSize;
            this.ShellCasing = Resources.Load<GameObject>(string.Format("Prefabs/ShellCasing/{0}",_param.shellCasing_id));
            this.ShellCasingEjectionForce = _param.shellCasingEjectionForce;
            this.ShellPoolSize = _param.shellPoolSize;
            this.AmmoReloadRate = _param.ammoReloadRate;
            this.AmmoReloadDelay = _param.ammoReloadDelay;
            this.MaxAmmo = _param.maxAmmo;
        }
    }

    [System.Serializable]
    public class ChargingParameter
    {
        [Tooltip("Trigger a shot when maximum charge is reached")]
        public bool AutomaticReleaseOnCharged;

        [Tooltip("Duration to reach maximum charge")]
        public float MaxChargeDuration;

        [Tooltip("Initial ammo used when starting to charge")]
        public float AmmoUsedOnStartCharge;

        [Tooltip("Additional ammo used when charge reaches its maximum")]
        public float AmmoUsageRateWhileCharging;

        public ChargingParameter()
        {

        }

        public ChargingParameter(Parameter_Charging _param)
        {
            this.AutomaticReleaseOnCharged = _param.automaticReleaseOnCharged;
            this.MaxChargeDuration = _param.maxChargeDuration;
            this.AmmoUsedOnStartCharge = _param.ammoUsedOnStartCharge;
            this.AmmoUsageRateWhileCharging = _param.ammoUsageRateWhileCharging;
        }
    }

    [System.Serializable]
    public class AudioVisualData
    {
        [Tooltip("Prefab of the muzzle flash")]
        public GameObject MuzzleFlashPrefab;

        [Tooltip("Unparent the muzzle flash instance on spawn")]
        public bool UnparentMuzzleFlash;

        [Tooltip("sound played when shooting")]
        public AudioClip ShootSfx;

        [Tooltip("Sound played when changing to this weapon")]
        public AudioClip ChangeWeaponSfx;

        [Tooltip("Continuous Shooting Sound")]
        public bool UseContinuousShootSound;
        public AudioClip ContinuousShootStartSfx;
        public AudioClip ContinuousShootLoopSfx;
        public AudioClip ContinuousShootEndSfx;

        public AudioVisualData(Parameter_AudioVisualData _param)
        {
            this.MuzzleFlashPrefab = Resources.Load<GameObject>(string.Format("Prefab/VFX/MuzzleFlash/{0}", _param.muzzleFlashPrefab_id));
            this.UnparentMuzzleFlash = _param.unParrentMuzzleFlash;
            this.ShootSfx = Resources.Load<AudioClip>(string.Format("Audio/SFX/{0}"));
        }

    }
}