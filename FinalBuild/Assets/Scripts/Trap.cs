using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// script gai tis pagides tou dungeon
/// </summary>
public class Trap : MonoBehaviour
{

    public HealthSystem healthSystem;
    public CartoonHeroMovementScript link;

    //public Collision collision = new Collision();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag ("Trap"))
        {
            Debug.Log("We hit the player");
        }
    }*/
    private void OnTriggerEnter(Collider other)//an akoumphsei to collider ths pagidas me ton paikth,tote o paikthw xanei zwh
    {
        if (other.gameObject.tag == "Player")
        {
            link.TakeDamage(10);
            /*link.currentHealth -= 10;
            healthSystem.hitPoint -= 10;
            Debug.Log("We hit the player");*/
        }
    }

}
