using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLoad : MonoBehaviour
{
    public GameObject MenuSaveExistsNG;
    public GameObject MenuSaveCannotBeLoaded;


    public GameObject MainMenuCamera;
    public SendToSceneScript checker;



    public void LoadNewGame()
    {
        if (ES3.FileExists("SaveFile.es3"))
        {
            MenuSaveExistsNG.SetActive(true);

        }
        else 
        {
            startANewGame();
        }
    }

    public void startANewGame() {
        ES3.DeleteFile("SaveFile.es3");
        


        checker.pressedNewGame();
        //MainMenuCamera.SetActive(false);
        //SceneManager.LoadScene("LifeSim", LoadSceneMode.Additive);
        SceneManager.LoadScene("LifeSim");

    }

    public void cancelStartNewGame()
    {
        MenuSaveExistsNG.SetActive(false);

    }


    public void CloseMenuSaveCannotBeLoaded()
    {
        MenuSaveCannotBeLoaded.SetActive(false);

    }



    public void LoadLevel()
    {

        if (ES3.FileExists("SaveFile.es3"))
        {

            checker.pressedLoad();
            //MainMenuCamera.SetActive(false);

            //SceneManager.LoadScene("LifeSim", LoadSceneMode.Additive);
            SceneManager.LoadScene("LifeSim");
        }else
        {
            MenuSaveCannotBeLoaded.SetActive(true);
        }

    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
