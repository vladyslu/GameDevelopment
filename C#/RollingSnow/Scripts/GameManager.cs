using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{    
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject MusicTwo;
    public GameObject MusicFive;

    private void Start()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    public void WonGame()
    {
        Time.timeScale = 0f;
        winScreen.SetActive(true);
    }

    public void LostGame()
    {
        Time.timeScale = 0f;
        loseScreen.SetActive(true);
    }

    public void VerySlowThemeSet()
    {
        MusicTwo.SetActive(false);
        MusicFive.SetActive(false);
    }


    public void SlowThemeSet()
    {
        MusicTwo.SetActive(true);
        MusicFive.SetActive(false);
    }

    public void AverageThemeSet()
    {
        MusicTwo.SetActive(false);
        MusicFive.SetActive(false);
    }

    public void FastThemeSet()
    {
        MusicTwo.SetActive(false);
        MusicFive.SetActive(false);
    }


    public void VeryFastThemeSet()
    {
        MusicTwo.SetActive(false);
        MusicFive.SetActive(true);
    }
}
