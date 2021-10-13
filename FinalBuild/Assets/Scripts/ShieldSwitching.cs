using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// script gia na mporei na allazei aspida o paikths
/// </summary>
public class ShieldSwitching : MonoBehaviour
{
    public int selectedShield = 1;//arxikh aspida h 1

    // Start is called before the first frame update
    void Start()
    {
        SelectShield();
    }

    // Update is called once per frame
    void Update()
    {

        int previousSelectedShield = selectedShield;

        if (previousSelectedShield != selectedShield)
        {
            SelectShield();
        }

    }

    void SelectShield ()
    {
        int i = 1;
        foreach (Transform shield in transform)//elegxei ton arithmo ths aspidas, kai an einai auth h selected ,thn energopoiei kai apenergopoiei tis alles
        {
            if (i == selectedShield)
            {
                shield.gameObject.SetActive(true);
            }
            else
            {
                shield.gameObject.SetActive(false);
            }
            i++;
        }
    }
    public void ButtonClicked(Button buttonshield)//kanei thn allagei ths aspidas me button(sto interface tha ginei me onbuttonclicked)
    {
        if (buttonshield.name == "BasicShieldButton")
        {
            selectedShield = 1;
            SelectShield();
        }
        if (buttonshield.name == "HeavyShieldButton")
        {
            selectedShield = 2;
            SelectShield();
        }
       
    }
}
