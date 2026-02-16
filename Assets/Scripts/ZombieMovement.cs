using UnityEngine;
using UnityEngine.AI; // OBLIGATORIU pentru NavMeshAgent

public class ZombieAI : MonoBehaviour
{
    [Header("Referinte")]
    public Transform player;
    private NavMeshAgent agent;

    [Header("Setari Navigatie")]
    public float range = 10f;
    public float stopDist = 1.1f; 

    [Header("Setari Atac")]
    public int attackDamage = 10;
    public float attackRate = 1.5f;
    private float nextAttackTime = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.stoppingDistance = stopDist;
    }

    void Update()
    {
        if (player == null) return;

        float dist = Vector2.Distance(transform.position, player.position);

        
        if (dist < range)
        {
            
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            
            agent.isStopped = true;
        }

        if (dist <= stopDist + 0.2f && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackRate;
        }

        RotateSprite();
    }

    void Attack()
    {
        PlayerController playerHealth = player.GetComponent<PlayerController>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
            Debug.Log("Zombie a muscat jucatorul!");
        }
    }

    void RotateSprite()
    {
       
        if (agent.velocity.x > 0.1f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (agent.velocity.x < -0.1f)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}