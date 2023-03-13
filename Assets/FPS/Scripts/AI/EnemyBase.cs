using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.AI
{
    [RequireComponent(typeof(AIController))]
    public class EnemyBase : MonoBehaviour
    {
        public Animator Animator;

        [Tooltip("The random hit damage effects")]
        public ParticleSystem[] RandomHitSparks;

        public ParticleSystem[] OnDetectVfx;
        public AudioClip OnDetectSfx;

        protected AIController m_EnemyController;
        public virtual void Start()
        {
            m_EnemyController = GetComponent<AIController>();
            DebugUtility.HandleErrorIfNullGetComponent<AIController, EnemyBase>(m_EnemyController, this,
                gameObject);
        }

        public virtual void AddEvents()
        {
            m_EnemyController.onDetectedTarget += OnDetectedTarget;
            m_EnemyController.onLostTarget += OnLostTarget;
            m_EnemyController.onAttack += OnAttack;
            m_EnemyController.onDamaged += OnDamaged;
            m_EnemyController.onDie += OnDIe;
            m_EnemyController.onHealed += OnHealed;
        }

        public virtual void RemoveEvents()
        {
            m_EnemyController.onDetectedTarget -= OnDetectedTarget;
            m_EnemyController.onLostTarget -= OnLostTarget;
            m_EnemyController.onAttack -= OnAttack;
            m_EnemyController.onDamaged -= OnDamaged;
            m_EnemyController.onDie -= OnDIe;
            m_EnemyController.onHealed -= OnHealed;
        }

        protected virtual void OnDetectedTarget()
        {

        }

        protected virtual void OnLostTarget()
        {

        }

        protected virtual void OnDamaged()
        {

        }

        protected virtual void OnAttack()
        {

        }

        protected virtual void OnDIe()
        {

        }

        protected virtual void OnHealed(float _value)
        {

        }

    }
}
