using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace Originn.Game.NPC.Enemy
{
    public class Monster : MonoBehaviour
    {
        public Transform[] waypoints;
        public float idleTime = 2f;
        public Transform player;

        private Animator animator;
        private NavMeshAgent agent;
        private int currentWaypointIndex = 0;
        private float idleTimer = 0f;
        private bool isPlayerDetected = false;

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
            if (isPlayerDetected)
            {
                FollowPlayer();
            }
            else
            {
                RoamBetweenWaypoints();
            }
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

        void FollowPlayer()
        {
            if (player == null)
                return;

            agent.SetDestination(player.position);

            Vector2 velocity = agent.velocity;
            float speed = velocity.magnitude;

            animator.SetFloat("Speed", speed);
            animator.SetFloat("Horizontal", Mathf.Round(velocity.x));
            animator.SetFloat("Vertical", Mathf.Round(velocity.y));
        }

        void MoveToNextWaypoint()
        {
            if (waypoints.Length == 0)
                return;

            agent.SetDestination(waypoints[currentWaypointIndex].position);
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("OnTriggerEnter2D called with: " + other.gameObject.name);
            if (other.CompareTag("Player"))
            {
                isPlayerDetected = true;
                Debug.Log("Player detected.");
                SceneManager.LoadScene("BattleScene");
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("OnTriggerExit2D called with: " + other.gameObject.name);
            if (other.CompareTag("Player"))
            {
                isPlayerDetected = false;
                MoveToNextWaypoint();
            }
        }
    }
}