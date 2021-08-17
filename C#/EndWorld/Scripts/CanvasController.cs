using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{

    public GameObject Controls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenControls()
    {
        Time.timeScale = 0;
        Controls.SetActive(true);
    }


    public void Quit()
    {
        Application.Quit();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Quit();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (Controls.activeSelf)
            {
                Time.timeScale = 1;
                Controls.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                Controls.SetActive(true);
            }
        }


    }
}
