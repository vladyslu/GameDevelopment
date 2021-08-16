using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public static bool GodMode = false;
    public static bool Player2 = false;
    public GameObject ControllerError;


    public void playNewSingle() {
        SceneManager.LoadScene(1);

    }

    public void playNewGodMode()
    {
        GodMode = true;
        SceneManager.LoadScene(1);

    }

    public void startMultiplayerMode()
    {
        if (Input.GetJoystickNames().Length > 0) {
            Debug.Log(Input.GetJoystickNames().Length.ToString());
            Player2 = true;
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log(Input.GetJoystickNames().Length.ToString());
            ControllerError.SetActive(true);
        }
    }

    public void Quit()
    {
   
        
     Application.Quit();
    }

    public void MenuBack()
    {
        GodMode = false;
        Player2 = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }

}
