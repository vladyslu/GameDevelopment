using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public GameObject restartButton;
    public GameObject continueButton;
    public GameObject player2;
    public AudioSource music;
    public AudioSource gameOverSound;
    public int points = 0;
    static public int level = 0;
    public int toBossCounter = 1000;
    public bool pause = false;


    public GameObject[] Bosses;

    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    AudioClip lastClip;

    public void playerHit()
    {
        gameOver();
    }

    public void gameOver()
    {
        pause = true;
        Time.timeScale = 0;
        music.Stop();
        gameOverSound.Play();
        gameOverScreen.SetActive(true);
        restartButton.GetComponent<Button>().Select();
    }
   

    public void pausing()
    {
        pause = true;
        Time.timeScale = 0;
        //music.Stop();
        //gameOverSound.Play();
        pauseScreen.SetActive(true);
        continueButton.GetComponent<Button>().Select();
    }

    public void continuing()
    {
        pause = false;
        Time.timeScale = 1;
        //music.Play();
        //gameOverSound.Play();
        pauseScreen.SetActive(false);
        //continueButton.GetComponent<Button>().Select();
    }
    public void reload()
    {

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }


    public void Update()
    {
        if (toBossCounter <= 0)
        {
           for(int i = 0; i< Bosses.Length; i++)
            {
                Bosses[i].SetActive(true);
            }
        }

      
            if (!audioSource.isPlaying && !pause)
            {
            AudioClip newClip = RandomClip();
            audioSource.PlayOneShot(newClip);

        }

        if ((Input.GetButton("Menu")))
        {
            pausing();

        }
        

    }


  

        void Start()
        {
        if (ButtonControl.Player2)
        {
            player2.SetActive(true);
        }



        pause = false;
        AudioClip newClip = RandomClip();
        audioSource.PlayOneShot(newClip);
        }

        AudioClip RandomClip()
        {
            int attempts = 3;
            AudioClip newClip = audioClipArray[Random.Range(0, audioClipArray.Length)];

            while (newClip == lastClip && attempts > 0)
            {
                newClip = audioClipArray[Random.Range(0, audioClipArray.Length)];
                attempts--;
            }

            lastClip = newClip;
            return newClip;
        }
    

}
