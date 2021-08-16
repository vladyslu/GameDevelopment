using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoctorTownDialogue : MonoBehaviour
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



    public GameObject dialogue;
    public EquipmentScript equipment;
    public Inventory inventory;

    public buttonsToDeactivate deactivateButton;

    public void doctorVisit()
    {


        if (statsU.dept == -1)
        {
            statsU.dept = 20000;
            deactivateButton.abroadActivated();
            deptManager.deptDaysLeft = 50;
            dialogueLine.Clear();
            Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;
            // inventory.addSomething(inventory.stick, -20);
            //  inventory.addSomething(inventory.axe, 1);
            doctorDialogue();



        }
        else if (statsU.dept == 20000)
        {
            deptManager.townDept();
        }
        else
        {
            deptManager.nothingToDoHere();
        }





    }

    public void doctorDialogue()
    {



        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;

        dialogueLine.Add("Ah, greetings to you, lad.");
        dialogueLine.Add("Hello, good sir! I have been dealing with an immense pain throughout my entire body, and-");
        dialogueLine.Add("I think you are dying, my friend. As much as I regret to break it down to you like that, there is nothing I can do.");
        dialogueLine.Add("But it cannot be! Are you sure?! Perhaps you know someone who can help?");
        dialogueLine.Add("Ye should look for doctors outside our mighty kingdom. I heard these miracle workers have some very progressive tools in their possession.");
        dialogueLine.Add("Thank you! There is not much time to lose, I am heading there immediately.");
        dialogueLine.Add("Ay ay, not so fast, lad! Ye owe me 20 000 coins for my service. You have 50 days to pay it off. Don't ye dare die before that!");
        dialogueLine.Add("I guess, this is what had to be expected...");


        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = finishDialogue;
        dialogueStarter = 1;
        dialogue.SetActive(true);
        dialoguePlayer.dialogueStart(background, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);


    }







    public void finishDialogue()
    {
        dialogueLine.Clear();
        dialogue.SetActive(false);
    }



}

