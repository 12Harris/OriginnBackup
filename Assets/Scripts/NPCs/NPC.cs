using UnityEngine;
using UnityEngine.AI;

namespace Originn.Game.NPC
{
    public class NPC : MonoBehaviour
    {
        public Transform[] waypoints;
        public float idleTime = 2f;

        private Animator animator;
        private NavMeshAgent agent;
        private int currentWaypointIndex = 0;
        private float idleTimer = 0f;

        void Start()
        {
            if (waypoints.Length == 0)
            {
                Debug.LogError("No waypoints assigned!");
                return;
            }

            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            MoveToNextWaypoint();
        }

        void Update()
        {

            RoamBetweenWaypoints();

        }

        void RoamBetweenWaypoints()
        {
            if (waypoints.Length == 0)
                return;

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                idleTimer += Time.deltaTime;
                if (idleTimer >= idleTime)
                {
                    idleTimer = 0f;
                    MoveToNextWaypoint();
                }

                animator.SetFloat("Speed", 0);
            }
            else
            {
                Vector2 velocity = agent.velocity;
                float speed = velocity.magnitude;

                animator.SetFloat("Speed", speed);
                animator.SetFloat("Horizontal", Mathf.Round(velocity.x));
                animator.SetFloat("Vertical", Mathf.Round(velocity.y));
            }
        }


        void MoveToNextWaypoint()
        {
            if (waypoints.Length == 0)
                return;

            agent.SetDestination(waypoints[currentWaypointIndex].position);
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

    }
}