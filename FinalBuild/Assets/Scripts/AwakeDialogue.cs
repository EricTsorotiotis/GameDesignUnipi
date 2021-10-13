using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//kaleitai to trigger dialogue sto prwto farme tou paixnidiou gia na deiksei ston paikth ti prepei na kanei

public class AwakeDialogue : MonoBehaviour
{
    public bool completed=false;
    public DialogueTrigger dialogue;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("firstdial") == 0)
        {
            dialogue.TriggerDialogue();
            completed = true;
            PlayerPrefs.SetInt("firstdial", 1);
            Destroy(this);
        }
    }
}
