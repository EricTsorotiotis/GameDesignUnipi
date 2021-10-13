using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public float lookRadius = 0.5f;
    public LayerMask playerLayer;
    //public GameObject shop;
    //public TMPro.TextMeshProUGUI text;

    public static bool GameIsPaused = false;

    public GameObject shopUI;

    
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            shopUI.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.K))
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
        else
        {
            shopUI.gameObject.SetActive(false);
        }

    }
    public void Resume()
    {
        shopUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        shopUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
