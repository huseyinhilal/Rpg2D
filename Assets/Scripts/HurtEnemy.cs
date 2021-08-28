using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive;
    private int currentDamage;
    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }

    }
}
