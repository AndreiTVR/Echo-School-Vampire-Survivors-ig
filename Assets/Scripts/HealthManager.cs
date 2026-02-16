using UnityEngine;
using UnityEngine.UI;

public class HealthBarDisplay : MonoBehaviour
{
    public Image healthBarFill;   
    public PlayerController player; 

    private float maxHealth;

    void Start()
    {
        if (player != null)
        {
           
            maxHealth = player.health;
        }
    }

    void Update()
    {
        if (player != null && healthBarFill != null)
        {
          
            healthBarFill.fillAmount = (float)player.health / maxHealth;
        }
    }
}