using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ena aplo ui gia  to inventory, to opoio otan energopoieitai,pagwnei o xronos sto paixnidi
public class InventoryMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject invMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (GameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        invMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        invMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
