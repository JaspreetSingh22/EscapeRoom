using UnityEngine;
using UnityEngine.AI;

public class AIBehavior : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public float detectionRange = 10f; // Range within which the player can detect the AI
    public float backupDistance = 5f; // Distance to backup when detected by the player

    private NavMeshAgent agent;
    private bool detectedByPlayer = false;
    private Vector3 backupPosition; // Position to which the AI backs up

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        backupPosition = transform.position;
    }

    void Update()
    {
        if (!detectedByPlayer)
        {
            MoveToPlayer();
        }
        else
        {
            Backup();
        }
    }

    void MoveToPlayer()
    {
        // Calculate distance to player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if player is within detection range
        if (distanceToPlayer <= detectionRange)
        {
            // Check if player can see the AI
            if (CanSeePlayer())
            {
                // Move towards the player
                agent.SetDestination(player.position);
            }
            else
            {
                // Backup if player can't see the AI
                backupPosition = transform.position - (player.position - transform.position).normalized * backupDistance;
                agent.SetDestination(backupPosition);
            }
        }
    }

    bool CanSeePlayer()
    {
        RaycastHit hit;

        // Cast a ray from AI towards the player
        if (Physics.Raycast(transform.position, (player.position - transform.position).normalized, out hit, detectionRange))
        {
            // Check if the object hit by the ray is the player
            if (hit.collider.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }

    void Backup()
    {
        // Check if AI has reached backup position
        if (Vector3.Distance(transform.position, backupPosition) < 0.1f)
        {
            detectedByPlayer = false;
            return;
        }

        // Move towards the backup position
        agent.SetDestination(backupPosition);
    }
}
