using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateClue : MonoBehaviour
{


    public void activate(string name)
    {
        GameObject manager = GameObject.Find("myClueManager");
        ClueManager clueManager = manager.GetComponent<ClueManager>();
        //Debug.Log("check if started");
        for (int i = 0; i < clueManager.clueList.Count; i++)
        {
            if (clueManager.clueList[i].name == name )
            {
                clueManager.clueList[i].active = true;
                //Debug.Log("clue added success");
                //  manager.GetComponent<TriggerObjective>().OnTrigger();
                GameObject gameManager = GameObject.Find("_GAMEUI");
                gameManager.GetComponent<HFPS_GameManager>().ShowHint("Clue Added", 4f, null);
                manager.GetComponent<AudioSource>().Play();
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
