using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script pou dinei hxo sta footsteps tou paikthk,afou prwta parei to index tou terrain gia na paiksei ton katallhlo hxo
/// <summary>
/// gia na dwthei ston paikth to swsto shmeio tou animation pou tha paiksei o hxos, dhmiourghtike event(me onoma step) sto animation tou walk,otan pataei to podi tou katw
/// </summary>

public class footsteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] stoneClips;
    [SerializeField]
    private AudioClip[] mudClips;
    [SerializeField]
    private AudioClip[] grassClips;
    [SerializeField]
    private bool enemy;
    private AudioSource audioSource;
    private TerrainDetector terrainDetector;

    private void Awake()
    {
        //if (enemy == false)
        //{
            audioSource = GetComponent<AudioSource>();
            terrainDetector = new TerrainDetector();
        //}
    }

    private void Step()
    {
        if (enemy == false)
        {
            audioSource.volume = 0.21f;
            AudioClip clip = GetRandomClip();
            audioSource.PlayOneShot(clip);
        }
    }

    private AudioClip GetRandomClip()
    {
        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);//index gia na dei se poio terrain eimaste

        switch (terrainTextureIndex)//paizei ton swsto hxo analoga me to terrain
        {
            case 7:
                return stoneClips[UnityEngine.Random.Range(0, stoneClips.Length)];
            case 5:
                return mudClips[UnityEngine.Random.Range(0, mudClips.Length)];
            case 2:
                return grassClips[UnityEngine.Random.Range(0, grassClips.Length)];
            default:
                //return grassClips[UnityEngine.Random.Range(0, grassClips.Length)];
                return mudClips[UnityEngine.Random.Range(0, mudClips.Length)];

        }

    }
}
