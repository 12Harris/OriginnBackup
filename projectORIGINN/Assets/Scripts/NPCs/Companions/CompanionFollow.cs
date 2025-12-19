using UnityEngine;
using UnityEngine.AI;

namespace Originn.Game.NPC.Companion
{
    public class CompanionFollow : MonoBehaviour
    {

        public float followRange = 1.5f;
        public Vector2 randomOffsetRange = new Vector2(0.5f, 1.5f);

        private Animator animator;
        private NavMeshAgent agent;
        private Vector2 offset;

        [SerializeField]
        private Transform _followTarget;

        public bool FollowCmd{get;set;} = false;

        void Start()
        {
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            offset = new Vector2(
                Random.Range(-randomOffsetRange.x, randomOffsetRange.x),
                Random.Range(-randomOffsetRange.y, randomOffsetRange.y)
            );
        }

        void Update()
        {
            if (_followTarget == null || FollowCmd == false)
                return;

            Vector2 targetPosition = (Vector2)_followTarget.position + offset;
            float distanceToPlayer = Vector2.Distance(transform.position, targetPosition);

            if (distanceToPlayer > followRange)
            {
                agent.SetDestination(targetPosition);

                Vector2 velocity = agent.velocity;
                float speed = velocity.magnitude;

                animator.SetFloat("Speed", speed);
                animator.SetFloat("Horizontal", Mathf.Round(velocity.x));
                animator.SetFloat("Vertical", Mathf.Round(velocity.y));
            }
            else
            {
                agent.ResetPath();
                animator.SetFloat("Speed", 0);
            }
        }
    }
}
