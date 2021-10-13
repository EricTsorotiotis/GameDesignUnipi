using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetsUpgradedSword : MonoBehaviour
{
    //public Button popupbutton;
    public TMPro.TextMeshProUGUI popuptext;
    public Animator popup;
    public Button buttonheavy;
    public GameObject heavyweaponchest;
    public AudioSource master;
    public AudioClip getitemsound;
    public float volume;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("PickedupWeapon");
            buttonheavy.gameObject.SetActive(true);
            
            popup.SetBool("isOpen", true);
            popuptext.text = "Obtained the Sabre of Druids.It seems to have an outworldy amount of power within it.You can find it in your inventory(Press I).";
            StartCoroutine(PlaySoundAndDestroyAfterwards());
            //master.PlayOneShot(getitemsound,volume);

            
        }
    }
    void Start()
    {
        //master.clip = getitemsound;
    }
    public void closePopUp()
    {
        popup.SetBool("isOpen", false);
        popuptext.text = "";

    }
    private IEnumerator PlaySoundAndDestroyAfterwards()
    {
        AudioSource blockDestroyedSound = master;
        blockDestroyedSound.Play();

        while (blockDestroyedSound.isPlaying)
        {
            yield return null;
        }
        heavyweaponchest.SetActive(false);
        //Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
