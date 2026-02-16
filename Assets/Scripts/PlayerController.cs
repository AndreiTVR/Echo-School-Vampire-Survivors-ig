using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int health = 100;
    [SerializeField] int maxHealth = 100;

    [Header("Shooting Settings")]
    public GameObject projectilePrefab;
    public int damage = 10;
    public Transform firePoint;        
    public float fireRate = 0.5f;    

    private float nextFireTime = 0f;   

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    } 
    void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Debug.Log("Shot fired!");
    }
}

   