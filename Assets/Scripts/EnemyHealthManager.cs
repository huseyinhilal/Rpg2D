using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    private PlayerStats playerStats;
    public int expToGive;

    // Start is called before the first frame update
    void Start()
    {
       currentHealth = maxHealth;

        playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            playerStats.AddExperience(expToGive);
        }

    }
    public void HurtEnemy(int takenDamage)
    {
        currentHealth -= takenDamage;
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
