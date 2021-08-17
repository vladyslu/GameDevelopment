using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void newGame()
    {
        Application.LoadLevel("MainGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
