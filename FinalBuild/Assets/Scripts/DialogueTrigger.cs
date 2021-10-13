using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//to script auto ksekinaei ton dialogo(arxikopoiei diladi to startdialogue() )
public class DialogueTrigger : MonoBehaviour
{
    Animator dialogueanim;
    public Dialogue dialogue;
    public bool druid;
    public bool bossviking;
    public Enemy boss;
    public HealthSystem healthSystem;
    public CartoonHeroMovementScript link;
    public void TriggerDialogue()
    {
        Debug.Log("starting dialogue");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        if (druid == true)
        {
            Debug.Log("added health to player");
            link.currentHealth = 200;
            link.maxHealth = 200;
            healthSystem.maxHitPoint = 200;
            healthSystem.hitPoint = 200;
            druid = false;
        }
        /*if (bossviking == true)
        {
            if (dialogueanim.GetBool("isOpen") == false)
            {
                Debug.Log("Time to fight");
                boss.enabled = true;
                //bossviking = false;
            }
            //boss.enabled = false;

            
        }*/
        if (dialogue.name == "Elsworth")
        {
            Debug.Log("found elsworth");
        }
    }


}
