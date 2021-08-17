using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonPopulator : MonoBehaviour
{
    public GameObject panelCase;
    public GameObject buttonTemplate;
    public GameObject cWindowTemplate;
    public GameObject cbuttonTemplate;
    public ClueManager clueManager;
    public GameObject newButton;
    public GameObject newChoiceWindow;
    public GameObject newCButton;

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
            if (clueManager.clueList[i].active && clueManager.clueList[i].buttonActive == false)
            {

                //clue buttons creating
                newButton = Instantiate(buttonTemplate, transform);
                newButton.transform.GetChild(0).GetComponent<Text>().text = clueManager.clueList[i].name;
                newButton.GetComponent<Button>().onClick.AddListener(delegate { ShowChoiceList(newChoiceWindow); });
                clueManager.clueList[i].buttonActive = true;
                newButton.SetActive(true);


                //make clue choice buttons(conclusions)
                newChoiceWindow = Instantiate(cWindowTemplate, panelCase.transform);
                for (int j = 0; j < clueManager.clueList[i].clueChoiseList.Count; j++)
                {

                    GameObject ButtonList = newChoiceWindow.transform.Find("ConcludeMenu").gameObject.transform.Find("ButtonListLeft").gameObject;
                    newCButton = Instantiate(ButtonList.transform.Find("buttonTemplateCase").gameObject, ButtonList.transform);
                    newCButton.transform.GetChild(0).GetComponent<Text>().text = clueManager.clueList[i].clueChoiseList[j].shortDescription;
                    clueChoises choice = clueManager.clueList[i].clueChoiseList[j];
                    newCButton.GetComponent<Button>().onClick.AddListener(delegate { ActivateChoice(choice, newChoiceWindow); });
                    newCButton.SetActive(true);
                }

            }
        }
    }

    void ShowChoiceList(GameObject newChoiceWindowFull)
    {
        newChoiceWindowFull.SetActive(true);
    }

    void ActivateChoice(clueChoises choice, GameObject ChoiceWindow)
    {
        choice.active = true;
        newChoiceWindow.SetActive(false);
        //newChoiceWindowFull.SetActive(true);
    }

}
