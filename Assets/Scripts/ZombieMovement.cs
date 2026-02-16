using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public Transform player;    
    public float speed = 2f;      
    public float range = 10f;   
    public float stopDist = 1.1f; 

    void Update()
    {
        if (player == null) return;

        float dist = Vector2.Distance(transform.position, player.position);

        
        if (dist < range && dist > stopDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}