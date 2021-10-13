using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// systhma gia na akolouthei to minimap ton paikth
/// </summary>
public class Minimap : MonoBehaviour
{
    public Transform Player;
    private void LateUpdate()
    {
        Vector3 newPos = Player.position;
        newPos.y = transform.position.y;
        transform.position = newPos;
    }
}
