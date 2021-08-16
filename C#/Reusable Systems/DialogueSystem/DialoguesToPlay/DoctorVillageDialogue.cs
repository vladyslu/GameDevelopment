using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoctorVillageDialogue : MonoBehaviour
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


        if (statsU.dept == 0) {
            statsU.dept = 10000;
            deactivateButton.townActivated();
            deptManager.deptDaysLeft = 50;
            dialogueLine.Clear();
            Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;
            // inventory.addSomething(inventory.stick, -20);
            //  inventory.addSomething(inventory.axe, 1);
            doctorDialogue();



        }
        else if (statsU.dept == 10000)
        {
            deptManager.villageDept();
        }
        else 
        {
            deptManager.nothingToDoHere();
        }





    }

    public void doctorDialogue()
    {

        

        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;

        dialogueLine.Add("Ah, greetings, lad.");
        dialogueLine.Add("Hello, sir!");
        dialogueLine.Add("May I ask why you’ve come to my clinic? Is it disease? Are you sick?");
        dialogueLine.Add("No, sir. I have been feeling immense pain throughout my entire body, mostly starting at my, uh...my ass.");
        dialogueLine.Add("Interesting. What kind of pain is it?");
        dialogueLine.Add("Bad kind.");
        dialogueLine.Add("Sharp or dull?");
        dialogueLine.Add("Uh...how can you tell?");
        dialogueLine.Add("Ugh...alright lad, considering you don’t really understand, I guess we can just start with some herbal medicine that should dull the pain.");
        dialogueLine.Add("Yes please. Anything to stop the pain.");
        dialogueLine.Add("Not stop, but dull. We must figure the reason for such pain. I may have to resort to bleeding you.");
        dialogueLine.Add("Bleeding?");
        dialogueLine.Add("Of course. It could be corruption in the blood. If we let some of that blood out, it could prove fruitful.");
        dialogueLine.Add("...");
        dialogueLine.Add("But first...herbs.");
        dialogueLine.Add("Yes, please.");
        dialogueLine.Add("I could probably throw something together with what I have here. However, we should talk about money.");
        dialogueLine.Add("Uh... money...");
        dialogueLine.Add("Yes. I am no charity, I can’t possibly do this for nothing.");
        dialogueLine.Add("Crap. And I suppose you don’t put anything on tabs?");
        dialogueLine.Add("Tabs?");
        dialogueLine.Add("Letting me pay later?");
        dialogueLine.Add("I’m afraid not. Either provide the money, or get it. Which reminds me...");
        dialogueLine.Add("Uh...what?");
        dialogueLine.Add("You’ll need to pay for this consultation.");
        dialogueLine.Add("Excuse me!?");
        dialogueLine.Add("My words do not come cheap. My time is valuable, and you have taken that time to get yourself better. So now you’ll need to pay for my time.");
        dialogueLine.Add("Are you kidding me? You didn’t even help me!");
        dialogueLine.Add("I do not kid much in my field, lad.");
        dialogueLine.Add("Where am I supposed to get money around here?");
        dialogueLine.Add("There’s a job board in the village square. The jobs aren’t much, but they pay.");
        dialogueLine.Add("Okay, so I have to pay for both your time and your treatment");
        dialogueLine.Add("Of course! It’s my duty...once the money is in my hand, that is. ");
        dialogueLine.Add("Even in 1485, the doctors have crappy payment issues...");
        dialogueLine.Add("Your bill is 10000 coins. You have 50 days to pay it off.");
        dialogueLine.Add("Maybe I should find the clothest town and see if they have a doctor who actually can help me.");
       
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
