using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer masterAudioMixer;
    public AudioMixer bgmAudioMixer;
    public AudioMixer sfxAudioMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    //seeing what resolutions are available
    private void Start()
    {
        resolutions = Screen.resolutions;

        //clears default list options
        resolutionDropdown.ClearOptions();


        //converting array into string
        List<string> options = new List<string>();

        int currentResolutionsIndex = 0;
        //loop through each element in array
        for (int i = 0; i < resolutions.Length; i++)
        {
            //creates string that displays resolution
            string option = resolutions[i].width + "x" + resolutions[i].height;
            //adds string to options
            options.Add(option);

            //sets dropdown to default resolution
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionsIndex = i;
            }
        }
        //adds options to dropdown
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionsIndex;
        resolutionDropdown.RefreshShownValue();
    }


    public void SetResolution (int resolutionIndex)
    {
        //updates resolution from dropdown
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


    //audio slider
    public void SetMasterVolume (float volume)
    {
        masterAudioMixer.SetFloat("Volume", volume);     
    }
    public void SetSFXVolume (float volume)
    {
        sfxAudioMixer.SetFloat("Volume", volume);
    }

    public void SetBGVolume (float volume)
    {
        bgmAudioMixer.SetFloat("Volume", volume);
    }


    //quality dropdown
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}