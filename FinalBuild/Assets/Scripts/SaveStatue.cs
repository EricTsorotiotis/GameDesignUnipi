using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveStatue : MonoBehaviour
{
    public float lookRadius = 0.5f;
    public LayerMask playerLayer;
    public GameObject savestatue;
    //public TMPro.TextMeshProUGUI text;

    public SavePlayerPos save;
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
            savestatue.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F10))
            {
                save.PlayerPosSave();
                
            }
        }
        else
        {
            savestatue.gameObject.SetActive(false);
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    }
