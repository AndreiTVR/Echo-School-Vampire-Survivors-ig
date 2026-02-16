using UnityEngine;
using TMPro; 

public class NectarDisplay : MonoBehaviour
{
    public TextMeshProUGUI textMesh; 
    public PlayerController player;  
    public int nectarTarget = 10;    
    void Update()
    {
        if (player != null)
        {
            
            textMesh.text = "Nectar: " + player.nectarCollected + " / " + nectarTarget;
        }
    }
}