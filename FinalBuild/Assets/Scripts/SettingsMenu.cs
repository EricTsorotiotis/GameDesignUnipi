using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
/// <summary>
/// ta preferences sto main menu
/// </summary>
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audiomixer;
    public CartoonHeroMovementScript player;
    public TMPro.TMP_Dropdown resolutionDropdown;
    
    public TMPro.TMP_Dropdown Difficulty;
    
    public string difficultychosen= "normal";
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();//dhmiourgw mia lista pou mesa tha exei ola ta diathesima resolutions gia thn othonh tou xrhsth
        int currentResolutionIndex = 0;

        for(int i=0; i<resolutions.Length; i++)//prosthetw ola ta diathesima resolutions gia thn othonh tou xrhsth
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
   
    public void SetResolution(int resolutionIndex)//afou parei to index me to epilegmeno resolution apo ton xrhsth, to efarmozei
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
    }

    public void SetVolume(float volume)//thetei ton hxo tou painxidiou sto master 
    {
        audiomixer.SetFloat("Volume",volume);
        Debug.Log(volume);
    }
     public void SetQuality (int qualityIndex)//thetei quality sto paixnidi, analoga me thn epilogh tou paikth(ta level twn qualities epilexthikan apo ta projects settings/graphics
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscreen (bool isFullscreen)//thetei fullscreen mode, an exei epileksei to koutaki o xrhsths
    {
        Screen.fullScreen = isFullscreen;
    }
}
