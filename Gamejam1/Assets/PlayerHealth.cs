using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;
    //public int currentHealth;

    //public int maxHealth = 100;
    public static float currentHealth;

    //public Healthbar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        //healthbar.SetMaxHealth(startingHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            
            SceneManager.LoadScene("GameOver");
        }
        print("ikbengeraakt");
        
    }


    public void HurtPlayer(int damageAmount)
    {
        currentHealth -= damageAmount;

        //healthbar.SetHealth(currentHealth);
    }

    
}
