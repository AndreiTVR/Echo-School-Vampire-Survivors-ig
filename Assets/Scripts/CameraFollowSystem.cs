using UnityEngine;

public class CameraFollowSystem : MonoBehaviour
{
    public Transform player; 
    public float height = 10f; 

    void LateUpdate()
    {
        if (player != null)
        {
            
            transform.position = new Vector3(player.position.x, height, player.position.z);

            transform.rotation = Quaternion.Euler(90, 0, 0);
        }
    }
}