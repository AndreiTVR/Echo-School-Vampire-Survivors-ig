using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health = 100;
    [SerializeField] int maxHealth = 100;

    [Header("Shooting Settings")]
    public GameObject projectilePrefab; 
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
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
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