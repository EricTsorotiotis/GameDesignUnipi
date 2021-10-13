using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// script pou elegxei to menu tou pause , alla kai to help screen
/// </summary>
public class PauseMenu : MonoBehaviour
{
    private string menuscreen = "MenuScene";
    private string dungeonscene = "Dungeon";
    public static bool GameIsPaused = false;

    SavePlayerPos playerPosData;

    public GameObject pauseMenuUI;
    public GameObject helpMenuUI;

    private void Start()
    {
        playerPosData = FindObjectOfType<SavePlayerPos>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))//anoigei to pause menu
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
        if (GameIsPaused == true)
        {
           if (Input.GetKeyDown(KeyCode.Escape))
                {
                    QuitGame();
                }
        }
        if (Input.GetKeyDown(KeyCode.F1))//anoigei to help screen
        {
            helpMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        if (Input.GetKeyUp(KeyCode.F1))//kleinei to help screen
        {
            helpMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void Resume()//epanerxetai h kanonikh roh tou xronou sto paixnidi
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()//stamata ton xrono
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }



   

    public void LoadMenu()//phgainei pisw sto main menu
    {
        Time.timeScale = 1f;
        //playerPosData.PlayerPosSave();
        
        Debug.Log("Loading Menu");
        SceneManager.LoadScene(menuscreen);
    }
    /*public void LoadDungeon()
    {
        Time.timeScale = 1f;
        //playerPosData.PlayerPosSave();

        Debug.Log("Loading Dungeon");
        SceneManager.LoadScene(dungeonscene);
    }*/
    public void QuitGame()//kleinei to paixnidi
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
