using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ena aplo script pou tha kanei thn camera na kineitai me ena mikro delay otan akolothei ton paikth
public class cameramovement : MonoBehaviour
{
    // paikths
    public Transform Target;
    //camera 
    public Transform camTransform;
    
    public Vector3 Offset;
    //poso smooth tha einai h kinhsh
    public float SmoothTime = 0.3f;

    
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        //arxikh position ths camera
        camTransform.position= Target.position + Offset;
        Offset = camTransform.position - Target.position;
    }

    private void LateUpdate()
    {
        // enhmerwnetai h thesi ths camera
        Vector3 targetPosition = Target.position + Offset;
        camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);

       
    }
}
