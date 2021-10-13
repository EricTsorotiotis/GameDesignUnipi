using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// an mpei mesa sto trigger o paikths, kskekina o dialogos me to boss, kai afou teleiwsei,kanei enable to enemy script tou boss
/// </summary>
public class finaltalk : MonoBehaviour
{
    public DialogueManager manager;
    public DialogueTrigger finalboss;
    public Enemy boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.endeddial == true)//otan teleiwsei o dialogos
        {
            boss.enabled=true;//energopoiei to enemy script tou boss
            Destroy(this);//katastrefei to object me to trigger
        }
    }
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("attempt");
            finalboss.TriggerDialogue();//ksekinaei ton dialogo tou boss
            
            
        }
        else 
        { 
            Debug.Log("Failed");
        }
    }
}
