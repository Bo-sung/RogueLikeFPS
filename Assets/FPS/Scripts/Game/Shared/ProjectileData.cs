using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;


namespace Unity.FPS.Gameplay
{
    [System.Serializable]
    public class ProjectileData
    {
        [System.Serializable]
        public class _General
        {
            [Tooltip("Radius of this projectile's collision detection")]
            public float Radius = 0.01f;

            [Tooltip("LifeTime of the projectile")]
            public float MaxLifeTime = 5f;

            [Tooltip("VFX prefab to spawn upon impact")]
            public GameObject ImpactVfx;

            [Tooltip("LifeTime of the VFX before being destroyed")]
            public float ImpactVfxLifetime = 5f;

            [Tooltip("Offset along the hit normal where the VFX will be spawned")]
            public float ImpactVfxSpawnOffset = 0.1f;

            [Tooltip("Clip to play on impact")]
            public AudioClip ImpactSfxClip;

            [Tooltip("Layers this projectile can collide with")]
            public LayerMask HittableLayers = -1;

            public _General(Data.Parameter_General _param)
            {
                this.Radius = _param.radius;
                this.MaxLifeTime = _param.maxLifeTime;
                this.ImpactVfx = Resources.Load<GameObject>(string.Format("Prefabs/VFX/{0}",_param.impacktVFX_id));
                this.ImpactVfxLifetime = _param.impactVFXLifetime;
                this.ImpactVfxSpawnOffset = _param.impactVFXSpawnOffset;
                this.ImpactSfxClip = Resources.Load<AudioClip>(string.Format("Audio/SFX/{0}",_param.impacktSFXClip_id));
                this.HittableLayers = _param.hittableLayers;
            }
        }

        [System.Serializable]
        public class _Movement
        {
            [Tooltip("Speed of the projectile")]
            public float Speed = 20f;

            [Tooltip("Downward acceleration from gravity")]
            public float GravityDownAcceleration = 0f;

            [Tooltip("Distance over which the projectile will correct its course to fit the intended trajectory (used to drift projectiles towards center of screen in First Person view). At values under 0, there is no correction")]
            public float TrajectoryCorrectionDistance = -1;

            [Tooltip("Determines if the projectile inherits the velocity that the weapon's muzzle had when firing")]
            public bool InheritWeaponVelocity = false;

            public _Movement(Data.Parameter_Movement _param)
            {
                this.Speed = _param.speed;
                this.GravityDownAcceleration = _param.gravityDownAcceleration;
                this.TrajectoryCorrectionDistance = _param.trajectoryCorrectionDistance;
                this.InheritWeaponVelocity = _param.inheritWeaponVelocity;
            }
        }

        [System.Serializable]
        public class _Damage
        {
            [Tooltip("Damage of the projectile")]
            public float Value = 40f;

            [Tooltip("Area of damage. Keep empty if you don<t want area damage")]
            public DamageArea AreaOfDamage;

            public _Damage(Data.Parameter_Damage _param)
            {
                this.Value = _param.value;
                this.AreaOfDamage = Resources.Load<DamageArea>(string.Format("Data/DamageArea/{0}", _param.areaOfDamage_id));
            }
        }


        [Header("General")]
        public _General General;

        [Header("Movement")]
        public _Movement Movement;

        [Header("Damage")]
        public _Damage Damage;

        public ProjectileData(Data.TableProjectile _tableData)
        {
            General = new _General(_tableData.general);
            Movement = new _Movement(_tableData.movement);
            Damage = new _Damage(_tableData.damage);
        }
    }
}
