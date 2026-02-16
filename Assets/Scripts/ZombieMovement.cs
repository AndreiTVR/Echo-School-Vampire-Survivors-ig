using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float range = 10f;
    public float stopDist = 1.1f;

    [Header("Attack Settings")]
    public int attackDamage = 10;
    public float attackRate = 1.5f; // Seconds between attacks
    private float nextAttackTime = 0f;

    void Update()
    {
        if (player == null) return;

        float dist = Vector2.Distance(transform.position, player.position);

        // 1. Movement Logic
        if (dist < range && dist > stopDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        // 2. Attack Logic
        if (dist <= stopDist && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackRate;
        }
    }

    void Attack()
    {
        // Try to get the PlayerController script from the player object
        PlayerController playerHealth = player.GetComponent<PlayerController>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
            Debug.Log("Zombie bit the player!");
        }
    }
}