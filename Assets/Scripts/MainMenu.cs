using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public ParticleSystem lava;

    public GameObject mainMenu;
    public GameObject tutorialMenu;
    public GameObject characterSelection;

    public GameObject pinkPlayerUnlocked;
    public GameObject pinkPlayerLocked;

    public GameObject rainbowPlayerUnlocked;
    public GameObject rainbowPlayerLocked;

    public GameObject blueToOrangeUnlocked;
    public GameObject blueToOrangeLocked;

    public GameObject smileSkinUnlocked;
    public GameObject smileSkinLocked;

    public Text highScoreNumber;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);

        lava.Play();
    }

    private void Start()
    {
        highScoreNumber.text = PlayerPrefs.GetFloat("Highscore").ToString();
        lava.Play();
    }

    private void Update()
    {
        CheckForPinkSkin();
        CheckForRainbowSkin();
        CheckForBlueToOrangeSkin();
        CheckForSmileSkin();
    }

    private void CheckForSmileSkin()
    {
        if(PlayerPrefs.GetFloat("Highscore") >= 80)
        {
            SmileSkinUnlocked();
        }
        else
        {
            smileSkinLocked.SetActive(true);
            smileSkinUnlocked.SetActive(false);
        }
    }

    private void SmileSkinUnlocked()
    {
        smileSkinLocked.SetActive(false);
        smileSkinUnlocked.SetActive(true);
    }

    private void CheckForBlueToOrangeSkin()
    {
        if(PlayerPrefs.GetFloat("Highscore") >= 60)
        {
            BlueToOrangeSkinUnlock();
        }
        else
        {
            blueToOrangeLocked.SetActive(true);
            blueToOrangeUnlocked.SetActive(false);
        }
    }

    private void BlueToOrangeSkinUnlock()
    {
        blueToOrangeLocked.SetActive(false);
        blueToOrangeUnlocked.SetActive(true);
    }

    private void CheckForRainbowSkin()
    {
        if (PlayerPrefs.GetFloat("Highscore") >= 40)
        {
            RainbowSkinUnlock();
        }
        else
        {
            rainbowPlayerLocked.SetActive(true);
            rainbowPlayerUnlocked.SetActive(false);
        }
    }

    private void CheckForPinkSkin()
    {
        if(PlayerPrefs.GetFloat("Highscore") >= 20)
        {
            PinkSkinUnlock();
        }
        else
        {
            pinkPlayerLocked.SetActive(true);
            pinkPlayerUnlocked.SetActive(false);
        }
    }

    private void RainbowSkinUnlock()
    {
        rainbowPlayerLocked.SetActive(false);
        rainbowPlayerUnlocked.SetActive(true);
    }

    private void PinkSkinUnlock()
    {
        pinkPlayerLocked.SetActive(false);
        pinkPlayerUnlocked.SetActive(true);
    }

    public void LoadDefaultSkinScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(6);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadCharacterSelection()
    {
        lava.Stop();
        mainMenu.SetActive(false);
        tutorialMenu.SetActive(false);
        characterSelection.SetActive(true);
    }

    public void LoadPinkSkinScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadRainbowSkinScene()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadBlueToOrangeSkinScene()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadSmileSkinLevel()
    {
        SceneManager.LoadScene(5);
    }
}
