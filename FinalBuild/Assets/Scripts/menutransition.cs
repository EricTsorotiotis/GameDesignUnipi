using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// paei apo ta end cerdits sto main menu, xrhsimopoiontas pali to fade gia to omalo transition
/// </summary>
public class menutransition : MonoBehaviour
{
    public Animator transition;
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
        
        StartCoroutine(playanim());
        StartCoroutine(StartFade(audiosrc, 0));
    }
    IEnumerator playanim()
    {

        yield return new WaitForSeconds(40);

        StartCoroutine(LoadLevel(0));
    }
    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(LevelIndex);
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
        float t = 0.025f;
        while (currentTime < 40)
        {

            currentTime += Time.deltaTime;
            if (currentTime > 15)
            {
                Debug.Log("starting fade");
                audioSource.volume = Mathf.Lerp(start, targetVolume, t);
                t += 0.0007f;
            }

            yield return null;
        }

        yield break;
    }
    void Update()
    {

    }
}
