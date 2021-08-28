using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    public int damageToGive;
    public GameObject damageNumber;

    private int currentDamage;
    private PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {

        playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            currentDamage = damageToGive - playerStats.currentDefence;
            if(currentDamage < 0)
            {
                currentDamage = 0;
            }
            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage);
            var clone = (GameObject)Instantiate(damageNumber, collision.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
    }
}
