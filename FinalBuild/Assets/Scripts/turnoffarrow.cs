using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// script pou apla kleinei to waypoint tokso, otan o paikths mpei se ena waypoint 
/// </summary>
public class turnoffarrow : MonoBehaviour
{
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            arrow.SetActive(false);
        }
    }
}
