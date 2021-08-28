using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text hpText;
    public PlayerHealthManager playerHealth;

    private PlayerStats playerStats;
    public Text lvlText;

    private static bool UIExist;

    // Start is called before the first frame update
    void Start()
    {
        if (!UIExist)
        {
            UIExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        playerStats = GetComponent<PlayerStats>();

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        hpText.text = "Can: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        lvlText.text = "Lvl:" + playerStats.currentLevel;
    }
}
