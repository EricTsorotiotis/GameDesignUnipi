using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// script gia omalo scene transttion apo ta opening credits sto game
/// </summary>
public class transitionscript : MonoBehaviour
{
    public AudioSource audiosrc;
    public Animator creditanimator;
    string m_ClipName;
    AnimatorClipInfo[] m_CurrentClipInfo;

    float m_CurrentClipLength;
    // Start is called before the first frame update
    void Start()
    {
        m_CurrentClipInfo = this.creditanimator.GetCurrentAnimatorClipInfo(0);
        //Access the current length of the clip
        m_CurrentClipLength = m_CurrentClipInfo[0].clip.length;
        Debug.Log(m_CurrentClipLength + " time");
        /*GetCurrentAnimatorTime(creditanimator);*/
        StartCoroutine(playanim());
        StartCoroutine(StartFade(audiosrc,0));
    }
    IEnumerator playanim()
    {
        
        yield return new WaitForSeconds(105);
        MainMenu.PlayGame();
        //SceneManager.LoadSceneAsync(2);
    }
    public float GetCurrentAnimatorTime(Animator targetAnim, int layer = 0)
    {
        AnimatorStateInfo animState = targetAnim.GetCurrentAnimatorStateInfo(layer);
        float currentTime = animState.normalizedTime % 1;
        Debug.Log(currentTime + "dsadasdasd");
        return currentTime;
    }
    // Update is called once per frame
    public static IEnumerator StartFade(AudioSource audioSource, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        float t=0.025f;
        while (currentTime < 105)
        {
            
            currentTime += Time.deltaTime;
            if (currentTime > 57)
            {   
                Debug.Log("starting fade");
                audioSource.volume = Mathf.Lerp(start, targetVolume, t);
                t += 0.0004f;
            }
            
            yield return null;
        }
        
        yield break;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MainMenu.PlayGame();
        }
    }
}
