using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class caseCloseManager : MonoBehaviour
{
    
    
    public ClueManager clueManager;
    public GameObject newButton;
    public List<caseClosings> resolutionList;

    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        for (int i = 0; i < resolutionList.Count; i++)
        {
            bool activate = true;
            for (int j = 0; j < resolutionList[i].requiredConclusions.Count; j++)
            {

                if (!resolutionList[i].requiredConclusions[j].active)
            {
                    activate = false;
                }

            }
            if (activate && resolutionList[i].buttonActive ==  false)
            {
                //resolution buttons creating
                newButton = Instantiate(buttonTemplate, transform);
                newButton.transform.GetChild(0).GetComponent<Text>().text = resolutionList[i].name;
                newButton.GetComponent<Button>().onClick.AddListener(delegate { ShowChoiceList(); });
                resolutionList[i].buttonActive = true;
                newButton.SetActive(true);
            }
        }
    }

    void ShowChoiceList()
    {
        
    }

  

}
