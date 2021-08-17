using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonPopulatorConclusions : MonoBehaviour
{
    
    
    public ClueManager clueManager;
    public GameObject newButton;


    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        for (int i = 0; i < clueManager.clueList.Count; i++)
        {
            for (int j = 0; j < clueManager.clueList[i].clueChoiseList.Count; j++)
            {

                if (clueManager.clueList[i].clueChoiseList[j].active && clueManager.clueList[i].clueChoiseList[j].buttonActive == false)
            {

                //clue buttons creating
                newButton = Instantiate(buttonTemplate, transform);
                newButton.transform.GetChild(0).GetComponent<Text>().text = clueManager.clueList[i].clueChoiseList[j].shortDescription;
                newButton.GetComponent<Button>().onClick.AddListener(delegate { ShowChoiceList(); });
                clueManager.clueList[i].clueChoiseList[j].buttonActive = true;
                newButton.SetActive(true);


               
                }

            }
        }
    }

    void ShowChoiceList()
    {
        
    }

  

}
