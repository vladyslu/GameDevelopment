using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingDialogue : MonoBehaviour
{
    public List<string> dialogueLine = new List<string>();
    public DynamicDialogueScript dialoguePlayer;
    public Sprite background;
    public Sprite iconLeft;
    public Sprite iconRight;
    public Sprite bodyLeft;
    public Sprite bodyRight;
    int dialogueStarter;
    public updateStats statsU;
    public DeptManager deptManager;

    //fade screen vars
    public GameObject fade;
    public Image fadeImage;
    public Animator fadeAnimation;

    public LocationManager locations;

    public GameObject dialogue;
    public EquipmentScript equipment;
    public Inventory inventory;
    public GameObject endingScreen;
    public buttonsToDeactivate deactivateButton;
    public EndingDoctorDialogue doctorDialogue;

    public void endingDialogueStart()
    {


        if (statsU.dept <= 0)
        {


            deactivateButton.abroadDeactivate();
            dialogueLine.Clear();
            Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;
            // inventory.addSomething(inventory.stick, -20);
            //  inventory.addSomething(inventory.axe, 1);
            endingDialogue();



        }
        else 
        {
            locations.shouldDebtFirst.SetActive(true);
        }
      





    }

    public void endingDialogue()
    {



        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;

        dialogueLine.Add("Oh... Wait, what?! Am I going insane or was it not time travel after all?.. Hmm.");
        

        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = finishDialogue;
        dialogueStarter = 0;
        dialogue.SetActive(true);
        dialoguePlayer.dialogueStart(background, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);


    }







    public void finishDialogue()
    {

        dialogueLine.Clear();
        doctorDialogue.endingDialogueStart();

        //dialogue.SetActive(false);
    }



}

