using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;
    public int[] toLevelUp;
    public int[] hpLevels;
    public int[] atackLevels;
    public int[] defenceLevels;

    public int currentHp;
    public int currentAttack;
    public int currentDefence;

    private PlayerHealthManager playerHealth;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHp = hpLevels[1];
        currentAttack = atackLevels[1];
        currentDefence = defenceLevels[1];
        playerHealth = FindObjectOfType<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( currentExp >= toLevelUp[currentLevel])
        {
            //currentLevel++;
            LevelUp();
        }
        
    }

    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;
    }

    public void LevelUp()
    {
        currentLevel++;
        currentHp = hpLevels[currentLevel];
        playerHealth.playerMaxHealth = currentHp;
        playerHealth.playerCurrentHealth += currentHp - hpLevels[currentLevel - 1];

        currentAttack = atackLevels[currentLevel];
        currentDefence = defenceLevels[currentLevel];

    }
}
