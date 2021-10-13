using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// to respawn mechanic,apla kanei laod to scene ksana
/// </summary>
public class Respawn : MonoBehaviour
{
 
    public void LoadGame()
    {

        SceneManager.LoadScene("SampleScene");
    }
    // Update is called once per frame
   
}
