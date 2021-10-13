using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// kanei save thn thesi tou paikth
/// </summary>
public class SavePlayerPos : MonoBehaviour
{
    public PauseMenu pausmn;
    public GameObject player;
    public CartoonHeroMovementScript player1;
    private int remhealth;
    private int maxhealth;
    public Animator popup;
    public TMPro.TextMeshProUGUI popuptext;
    private void Start()//kanei load to position tou paikth(me syntetagmenes px,py,pz), kai to health tou paikth
    {
        if (PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
        {
            float pX = player.transform.position.x;
            float pY = player.transform.position.y;
            float pZ = player.transform.position.z;

            pX = PlayerPrefs.GetFloat("p_x");
            pY = PlayerPrefs.GetFloat("p_y");
            pZ = PlayerPrefs.GetFloat("p_z");
            HealthSystem.Instance.hitPoint = PlayerPrefs.GetInt("barremaining");
            
            player1.currentHealth = PlayerPrefs.GetInt("remainingHealth");
            //HealthSystem.Instance.maxHitPoint = PlayerPrefs.GetInt("barmaxremainingg");
            player1.maxHealth = PlayerPrefs.GetInt("maxHealth");
            player.transform.position = new Vector3(pX, pY, pZ);

            PlayerPrefs.SetInt("TimeToLoad", 0);
            PlayerPrefs.Save();
            
        }
        

        

    }
    private IEnumerator savePopUp()//deixnei to minima oti to paixnidi egine saved ston xrhsth,anoigontas to katallhlo ui gia ta notifications(to idio kai me to chest)
    {
        popuptext.alignment = TMPro.TextAlignmentOptions.Center;
        popuptext.text = "Saved the Game!";
        popup.SetBool("isOpen", true);
        yield return new WaitForSeconds(5);
        popup.SetBool("isOpen", false);
        popuptext.text = "";
    }
    public void PlayerPosSave()//kanei save ta dedomena to xrhsth
    {
        PlayerPrefs.SetFloat("p_x", player.transform.position.x);
        PlayerPrefs.SetFloat("p_y", player.transform.position.y);
        PlayerPrefs.SetFloat("p_z", player.transform.position.z);
        maxhealth = player1.maxHealth;
        remhealth = player1.currentHealth;
        PlayerPrefs.SetInt("remainingHealth", remhealth);
        PlayerPrefs.SetInt("barremaining", remhealth);
        PlayerPrefs.SetInt("maxHealth", maxhealth);
        PlayerPrefs.SetInt("barmaxremaining", maxhealth);
        Debug.Log("Max helath bar is" + PlayerPrefs.GetInt("barmaxremaining"));
        
        PlayerPrefs.SetInt("Saved", 1);
        Debug.Log("Game Saved!");
        pausmn.Resume();
        
        StartCoroutine(savePopUp());
        PlayerPrefs.Save();

    }

    public void PlayerPosLoad()//kanei load to paixnidi
    {
        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
        Debug.Log("Game Loaded!");
    }
}
