using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// aplo script gia na kanei pickup o xrhsths thn trofh kai na tou dinei zwh
/// </summary>
public class pickuphealth : MonoBehaviour
{
    [SerializeField]
    private AudioClip gothealth;
    public HealthSystem healthSystem;
    public CartoonHeroMovementScript link;
    public AudioSource audioSource;
    // Start is called before the first frame update

    /*private void Awake()
    {
        //audioSource = GetComponent<AudioSource>();
    }*/

    private void OnTriggerEnter(Collider other)//an mpei emsa sto trigger o paikths ,tote elegxetai an mporei na to parei, kai na mporei, prostithetai health kai katastrefetai to gameoobject
    {
        if (other.gameObject.tag == "Player" && link.currentHealth  < link.maxHealth)
        {
            
            if (link.currentHealth <= link.maxHealth - 15)
            {
                Debug.Log("Picked up Health");
                link.currentHealth += 15;
                healthSystem.hitPoint += 15;
                
            }
            else
            {
                link.currentHealth =link.maxHealth;
                healthSystem.hitPoint = link.maxHealth;
            }
            audioSource.PlayOneShot(gothealth);
            Destroy(this.gameObject);
            
        }
        /*if((link.currentHealth + 15) > link.maxHealth)
        {
            
            Destroy(this.gameObject);
        }*/
        if (other.gameObject.tag == "Player" && link.currentHealth==link.maxHealth)
        {
            Debug.Log("Full Health");
        }
        
    }
    
}
