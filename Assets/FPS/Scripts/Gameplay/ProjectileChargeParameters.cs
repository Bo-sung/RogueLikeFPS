using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class ProjectileChargeParameters : MonoBehaviour
    {
        public MinMaxFloat Damage;
        public MinMaxFloat Radius;
        public MinMaxFloat Speed;
        public MinMaxFloat GravityDownAcceleration;
        public MinMaxFloat AreaOfEffectDistance;

        ProjectileBase m_ProjectileBase;

        void OnEnable()
        {
            m_ProjectileBase = GetComponent<ProjectileBase>();
            DebugUtility.HandleErrorIfNullGetComponent<ProjectileBase, ProjectileChargeParameters>(m_ProjectileBase,
                this, gameObject);

            m_ProjectileBase.OnShoot += OnShoot;
        }

        void OnShoot()
        {
            // Apply the parameters based on projectile charge
            ProjectileStandard proj = GetComponent<ProjectileStandard>();
            if (proj)
            {
                proj.projectileData.Damage.Value = Damage.GetValueFromRatio(m_ProjectileBase.InitialCharge);
                proj.projectileData.General.Radius = Radius.GetValueFromRatio(m_ProjectileBase.InitialCharge);
                proj.projectileData.Movement.Speed = Speed.GetValueFromRatio(m_ProjectileBase.InitialCharge);
                proj.projectileData.Movement.GravityDownAcceleration =
                    GravityDownAcceleration.GetValueFromRatio(m_ProjectileBase.InitialCharge);
            }
        }
    }
}