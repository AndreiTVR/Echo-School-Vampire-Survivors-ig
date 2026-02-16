using UnityEngine;

public class CameraFollowSystem : MonoBehaviour
{
    public Transform player; 
    public float height = 10f; 
    public float smoothSpeed = 0.125f; 

    private Vector3 currentVelocity = Vector3.zero;

    void LateUpdate()
    {
        if (player != null)
        {
           
            Vector3 targetPosition = new Vector3(player.position.x, height, player.position.z);

            
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothSpeed);

            
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }
    }
}