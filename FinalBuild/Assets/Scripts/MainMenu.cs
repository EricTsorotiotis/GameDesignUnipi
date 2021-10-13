using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// to script tou main menu
/// kyriws voitha sto na ksekinhsei to game,kai se periptwsh neou game ,na kanei reset ola ta playerprefs
/// </summary>
public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public AudioSource audiosrc;
    public static void PlayGame()//paw apo opening credits sto game
    {
        PlayerPrefs.DeleteKey("p_x");
        PlayerPrefs.DeleteKey("p_y");
        PlayerPrefs.DeleteKey("p_z");
        PlayerPrefs.DeleteKey("remainingHealth");
        PlayerPrefs.DeleteKey("maxHealth");
        PlayerPrefs.DeleteKey("TimeToLoad");
        PlayerPrefs.DeleteKey("Saved");

        PlayerPrefs.SetInt("firstdial", 0);
        PlayerPrefs.SetInt("remainingHealth", 100);
        PlayerPrefs.SetInt("maxHealth", 100);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    IEnumerator LoadNextScene(int LevelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(LevelIndex);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
    /*public void LoadGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }*/

    public void StarttheGame(TMPro.TMP_Dropdown Difficulty)//paw apo to menu sta opening credits kai thetw to playerpref ths dyskolias
    {
        StartCoroutine(LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1));
        StartCoroutine(StartFade(audiosrc, 0));
        if (Difficulty.value == 0)
        {
            PlayerPrefs.SetString("difficulty", "easy");

        }
        if (Difficulty.value == 1)
        {
            PlayerPrefs.SetString("difficulty", "normal");

        }
        if (Difficulty.value == 2)
        {
            PlayerPrefs.SetString("difficulty", "hard");

        }
    }
    public static IEnumerator StartFade(AudioSource audioSource, float targetVolume)//ksekinaei ena fade ston hxo twn opening credits, gia na ginei omala to transition 
    {
        float currentTime = 0;
        float start = audioSource.volume;
        float t = 0.025f;
        while (currentTime < 5)
        {

            currentTime += Time.deltaTime;
            if (currentTime > 0)
            {
                Debug.Log("starting fade");
                audioSource.volume = Mathf.Lerp(start, targetVolume, t);
                t += 0.025f;
            }

            yield return null;
        }

        yield break;
    }

    public void QuitGame()//kleinei to paixnidi
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
