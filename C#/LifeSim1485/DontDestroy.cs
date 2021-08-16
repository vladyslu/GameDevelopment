using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    //public GameObject music;
    // Start is called before the first frame update


    public void Awake()
    {
        DontDestroyOnLoad(this);

        if (GameObject.FindGameObjectsWithTag("BackgroundMusic").Length > 1)
        {
            Destroy(gameObject);
        }
    }

    


    // Update is called once per frame
    void Update()
    {
        
    }
}
