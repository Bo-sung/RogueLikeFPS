using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.FPS.Data
{
    [System.Serializable]
    public class TableEntity
    {
        [System.Serializable]
        public struct Parameter_Movement
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
        }

        [System.Serializable]
        public struct Parameter_Audio
        {
            [Tooltip("Amount of footstep sounds played when moving one meter")]
            public float FootstepSfxFrequency;

            [Tooltip("Amount of footstep sounds played when moving one meter while sprinting")]
            public float FootstepSfxFrequencyWhileSprinting;

            [Tooltip("Sound played for footsteps")]
            public string FootstepSfx_id;

            [Tooltip("Sound played when jumping")]
            public string JumpSfx_id;
            [Tooltip("Sound played when landing")]
            public string LandSfx_id;

            [Tooltip("Sound played when taking damage froma fall")]
            public string FallDamageSfx_id;
        }

        [System.Serializable]
        public struct Parameter_etc
        {
            [Header("Fall Damage")]
            [Tooltip("Whether the player will recieve damage when hitting the ground at high speed")]
            public bool RecievesFallDamage;

            [Tooltip("Minimun fall speed for recieving fall damage")]
            public float MinSpeedForFallDamage;

            [Tooltip("Fall speed for recieving th emaximum amount of fall damage")]
            public float MaxSpeedForFallDamage;

            [Tooltip("Damage recieved when falling at the mimimum speed")]
            public float FallDamageAtMinSpeed;

            [Tooltip("Damage recieved when falling at the maximum speed")]
            public float FallDamageAtMaxSpeed;
        }

        public int index;
        public string id;
        public TableEntity.Parameter_Movement movement;
        public TableEntity.Parameter_Audio audio;
        public TableEntity.Parameter_etc etc;
    }
}
