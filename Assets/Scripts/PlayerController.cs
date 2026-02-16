using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;
   [SerializeField] int maxHealth = 100;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
