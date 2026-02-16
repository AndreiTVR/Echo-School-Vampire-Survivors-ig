using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public int health = 250;
    public int damage = 10;
    public float attackSpeed = 1.0f;
    public int nectarDropAmount = 2;

    private float nextAttackTime;

    
    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null && Time.time >= nextAttackTime)
        {
            player.TakeDamage(damage);
            nextAttackTime = Time.time + attackSpeed;
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Zombie mort! Ai primit: " + nectarDropAmount + " nectar");

        
        Destroy(gameObject);
    }
}
