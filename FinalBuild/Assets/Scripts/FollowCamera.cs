using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
     public Transform Player;
     public Vector3 Offset;
 
     void LateUpdate ()
     {
        if (Player != null)
        {
            transform.position = Player.position + Offset;
            //transform.Translate(0, 0, Time.deltaTime * 10);
        }
             
     }
}
