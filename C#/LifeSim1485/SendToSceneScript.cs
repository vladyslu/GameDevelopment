using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendToSceneScript : MonoBehaviour
{
     static public int checkToLoad = 0;
    public int theNumber;
 


    // Start is called before the first frame update
    

    public void pressedNewGame()
    {
        checkToLoad = 0;
    }

    public void pressedLoad()
    {
        print("pressedLoad");
        checkToLoad = 1;
        
    }

    public void checkTheNumber()
    {
       // print(checkToLoad);

    }

    public void Update()
    {
        theNumber = checkToLoad;
   
    }
}
