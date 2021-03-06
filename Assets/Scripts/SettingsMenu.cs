using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void FullscreenOn ()
    {
        Screen.fullScreen = true;
    }

    public void FullscreenOff()
    {
        Screen.fullScreen = false;
    }
}
