using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDungeon : MonoBehaviour
{
    public float alpha ;
    public GameObject ceiling1;
    public GameObject ceiling2;
    public GameObject ceiling3;
    public static Vector3 enterposition;
    public bool inside;
    private int i = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //inside = true;
        if (inside==false)
        {
            ChangeAlpha(ceiling1.GetComponent<Renderer>().material, 1);
            ChangeAlpha(ceiling2.GetComponent<Renderer>().material, 1);
            ChangeAlpha(ceiling3.GetComponent<Renderer>().material, 1);
            inside = true;
            //ceiling1.SetActive(false);
            return;
        }
        if (inside==true)
        {
            //ceiling.SetActive(false);
            ChangeAlpha(ceiling1.GetComponent<Renderer>().material, alpha);
            ChangeAlpha(ceiling2.GetComponent<Renderer>().material, alpha);
            ChangeAlpha(ceiling3.GetComponent<Renderer>().material, alpha);
            inside = false;
            return;    
        }
        //i += 1;
        /*if(inside == false) 
        {
            ChangeAlpha(ceiling.GetComponent<Renderer>().material, 1);
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);

    }
}
