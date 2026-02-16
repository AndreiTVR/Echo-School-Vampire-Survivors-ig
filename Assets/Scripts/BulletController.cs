using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 30f;          
    public float maxDistance = 20f;  

    private int damageToDeal;          
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    
    public void Setup(int damage)
    {
        damageToDeal = damage;
    }

    void Update()
    {
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

       
        if (Vector3.Distance(startPosition, transform.position) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        ZombieController zombie = other.GetComponent<ZombieController>();

        if (zombie != null)
        {
            zombie.TakeDamage(damageToDeal); 
        }


        Destroy(gameObject);
    }
}