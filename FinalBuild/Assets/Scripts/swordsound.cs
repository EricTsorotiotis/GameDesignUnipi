using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// paizei hxous sta hurt kai attack animations
/// </summary>
public class swordsound : MonoBehaviour
{
    [SerializeField]
    private AudioClip shoutclip;
    [SerializeField]
    private AudioClip shoutlink;
    [SerializeField]
    private AudioClip pain;
    private AudioSource audioSource;
    [SerializeField]
    private bool enemy;

    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Shout()
    {
        audioSource.volume = 0.4f;
        //AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(shoutclip);
        audioSource.PlayOneShot(shoutlink);
    }
    private void Pain()
    {
        audioSource.volume = 0.4f;
        audioSource.PlayOneShot(pain);
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
