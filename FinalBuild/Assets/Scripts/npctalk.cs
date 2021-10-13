using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// script etsi wste otan o paikths paei konta se ena npc, na mporei na milhsei mazi tou(na kanei triggerdialogue() diladi)
/// </summary>
public class npctalk : MonoBehaviour
{
    public float lookRadius = 0.5f;
    public LayerMask playerLayer;
    public GameObject npc ;
    public DialogueTrigger dialogue;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            npc.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.T))
            {
                dialogue.TriggerDialogue();

            }
        }
        else
        {
            npc.gameObject.SetActive(false);
        }
    }
}
