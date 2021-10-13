using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// akrivws to idio script me to shieldswitching
/// </summary>
public class WeaponSwitching : MonoBehaviour
{

    public int selectedWeapon = 1;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {

        int previousSelectedWeapon = selectedWeapon;

    }

    void SelectWeapon()
    {
        Debug.Log("select weapon was called");
        int i = 1;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                //Debug.Log("setting acticec weapon");
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
    public void ButtonClicked(Button button)
    {
        if (button.name == "BasicWeapon")
        {
            
            selectedWeapon = 1;
            Update();
            SelectWeapon();
            Debug.Log("buttonclcisdked");
        }
        if (button.name == "HeavyWeapon")
        {
            Debug.Log("HeavySword");
            selectedWeapon = 2;
            Debug.Log("Selected Weapon is :"+selectedWeapon);
            //Update();
            SelectWeapon();
        }
    }
}
