using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.AI;

namespace Unity.FPS.AI
{
    public interface IAIController
    {
        DetectionModule DetectionModule { get; }
        bool HadKnownTarget { get; }
        bool IsSeeingTarget { get; }
        bool IsTargetInAttackRange { get; }
        GameObject KnownDetectedTarget { get; }
        NavMeshAgent NavMeshAgent { get; }
        PatrolPath PatrolPath { get; set; }

        WeaponController GetCurrentWeapon();
        Vector3 GetDestinationOnPath();
        void OrientTowards(Vector3 lookPosition);
        void OrientWeaponsTowards(Vector3 lookPosition);
        void ResetPathDestination();
        void SetNavDestination(Vector3 destination);
        void SetPathDestinationToClosestNode();
        bool TryAtack(Vector3 enemyPosition);
        bool TryDropItem();
        void UpdatePathDestination(bool inverseOrder = false);
    }
}