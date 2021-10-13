using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// script pou fortwnei to epomeno level,dedixnontas ena loading screen
/// </summary>
public class levelloader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TMPro.TextMeshProUGUI progressText;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));//kanw load asynchronously to epomeno level
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);


        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";//deixnw to progress tou load

            yield return null;
        }
    }

}
