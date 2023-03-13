using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public interface IPlayerCharacterController
    {
        Vector3 CharacterVelocity { get; set; }
        bool HasJumpedThisFrame { get; }
        bool IsCrouching { get; }
        bool IsDead { get; }
        bool IsGrounded { get; }
        float RotationMultiplier { get; }

        Vector3 GetDirectionReorientedOnSlope(Vector3 direction, Vector3 slopeNormal);
    }
}