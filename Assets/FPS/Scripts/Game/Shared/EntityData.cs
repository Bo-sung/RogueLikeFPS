using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.FPS.Data;

namespace Unity.FPS.Game
{
    [System.Serializable]
    public class EntityData
    {
        public class Movement
        {
            [Header("Movement")]
            [Tooltip("Max movement speed when grounded (when not sprinting)")]
            public float MaxSpeedOnGround;

            [Tooltip("Sharpness for the movement when grounded, a low value will make the player accelerate and decelerate slowly, a high value will do the opposite")]
            public float MovementSharpnessOnGround;

            [Tooltip("Max movement speed when crouching")]
            [Range(0, 1)]
            public float MaxSpeedCrouchedRatio;

            [Tooltip("Max movement speed when not grounded")]
            public float MaxSpeedInAir;

            [Tooltip("Acceleration speed when in the air")]
            public float AccelerationSpeedInAir;

            [Tooltip("Multiplicator for the sprint speed (based on grounded speed)")]
            public float SprintSpeedModifier;

            [Obsolete("시스템으로 이동 예정")]
            [Tooltip("Height at which the player dies instantly when falling off the map")]
            public float KillHeight;

            [Header("Rotation")]
            [Tooltip("Rotation speed for moving the camera")]
            public float RotationSpeed;

            [Range(0.1f, 1f)]
            [Tooltip("Rotation speed multiplier when aiming")]
            public float AimingRotationMultiplier;

            [Header("Jump")]
            [Tooltip("Force applied upward when jumping")]
            public float JumpForce;

            [Header("Stance")]
            [Tooltip("Ratio (0-1) of the character height where the camera will be at")]
            public float CameraHeightRatio;

            [Tooltip("Height of character when standing")]
            public float CapsuleHeightStanding;

            [Tooltip("Height of character when crouching")]
            public float CapsuleHeightCrouching;

            [Tooltip("Speed of crouching transitions")]
            public float CrouchingSharpness;

            public Movement(TableEntity.Parameter_Movement parameter_Movement)
            {
                this.MaxSpeedOnGround            = parameter_Movement.MaxSpeedOnGround;
                this.MovementSharpnessOnGround   = parameter_Movement.MovementSharpnessOnGround;
                this.MaxSpeedCrouchedRatio       = parameter_Movement.MaxSpeedCrouchedRatio;
                this.MaxSpeedInAir               = parameter_Movement.MaxSpeedInAir;
                this.AccelerationSpeedInAir      = parameter_Movement.AccelerationSpeedInAir;
                this.SprintSpeedModifier         = parameter_Movement.SprintSpeedModifier;
                this.KillHeight                  = parameter_Movement.KillHeight;
                this.RotationSpeed               = parameter_Movement.RotationSpeed;
                this.AimingRotationMultiplier    = parameter_Movement.AimingRotationMultiplier;
                this.JumpForce                   = parameter_Movement.JumpForce;
                this.CameraHeightRatio           = parameter_Movement.CameraHeightRatio;
                this.CapsuleHeightStanding       = parameter_Movement.CapsuleHeightStanding;
                this.CapsuleHeightCrouching      = parameter_Movement.CapsuleHeightCrouching;
                this.CrouchingSharpness          = parameter_Movement.CrouchingSharpness;
            }
        }

        public class Audio
        {
            [Header("Audio")]
            [Tooltip("Amount of footstep sounds played when moving one meter")]
            public float FootstepSfxFrequency;

            [Tooltip("Amount of footstep sounds played when moving one meter while sprinting")]
            public float FootstepSfxFrequencyWhileSprinting;

            [Tooltip("Sound played for footsteps")]
            public AudioClip FootstepSfx;

            [Tooltip("Sound played when jumping")] public AudioClip JumpSfx;
            [Tooltip("Sound played when landing")] public AudioClip LandSfx;

            [Tooltip("Sound played when taking damage froma fall")]
            public AudioClip FallDamageSfx;

            public Audio(TableEntity.Parameter_Audio parameter_Audio)
            {
                try {
                    this.FootstepSfxFrequency = parameter_Audio.FootstepSfxFrequency;
                    this.FootstepSfxFrequencyWhileSprinting = parameter_Audio.FootstepSfxFrequencyWhileSprinting;
                    this.FootstepSfx = Resources.Load<AudioClip>(string.Format("Audio/SFX/Weapon/{0}", parameter_Audio.FootstepSfx_id));
                    this.JumpSfx = Resources.Load<AudioClip>(string.Format("Audio/SFX/Weapon/{0}", parameter_Audio.JumpSfx_id));
                    this.LandSfx = Resources.Load<AudioClip>(string.Format("Audio/SFX/Weapon/{0}", parameter_Audio.LandSfx_id));
                    this.FallDamageSfx = Resources.Load<AudioClip>(string.Format("Audio/SFX/Weapon/{0}", parameter_Audio.FallDamageSfx_id));
                }
                catch
                {
                    Debug.Log("EntityData.Audio LoadFailed");
                }
            }

        }

        public class Etc
        {
            [Header("Fall Damage")]
            [Tooltip("Whether the player will recieve damage when hitting the ground at high speed")]
            public bool RecievesFallDamage;

            [Tooltip("Minimun fall speed for recieving fall damage")]
            public float MinSpeedForFallDamage = 10f;

            [Tooltip("Fall speed for recieving th emaximum amount of fall damage")]
            public float MaxSpeedForFallDamage = 30f;

            [Tooltip("Damage recieved when falling at the mimimum speed")]
            public float FallDamageAtMinSpeed = 10f;

            [Tooltip("Damage recieved when falling at the maximum speed")]
            public float FallDamageAtMaxSpeed = 50f;

            public Etc(TableEntity.Parameter_etc parameter_Etc)
            {
               this.RecievesFallDamage      = parameter_Etc.RecievesFallDamage;
               this.MinSpeedForFallDamage   = parameter_Etc.MinSpeedForFallDamage;
               this.MaxSpeedForFallDamage   = parameter_Etc.MaxSpeedForFallDamage;
               this.FallDamageAtMinSpeed    = parameter_Etc.FallDamageAtMinSpeed;
               this.FallDamageAtMaxSpeed    = parameter_Etc.FallDamageAtMaxSpeed;
            }
        }

        public EntityData.Movement movement;
        public EntityData.Audio audio;
        public EntityData.Etc etc;

        public EntityData(TableEntity entity)
        {
            this.movement = new Movement(entity.movement);
            this.audio = new Audio(entity.audio);
            this.etc = new Etc(entity.etc);
        }
    }
}
