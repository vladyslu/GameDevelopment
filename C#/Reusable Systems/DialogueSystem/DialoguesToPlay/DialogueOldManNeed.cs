
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DialogueOldManNeed : MonoBehaviour
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
    public LocationManager locations;

    //fade screen vars
    public GameObject fade;
    public Image fadeImage;
    public Animator fadeAnimation;

    public Sprite forestBackground;
    public Sprite shackOutsideBackground;
    public Sprite shackInsideBackground;

    public GameObject dialogue;
    public EquipmentScript equipment;
    public Inventory inventory; 

   

    public void askAxe()
    {

        dialogueLine.Clear();
        
        if (inventory.inventoryScriptable.getAmount(new Item(inventory.stick)) >= 20)
        {

            inventory.addSomething(inventory.stick, -20);
            inventory.addSomething(inventory.axe, 1);
            EnoughStickDialogue();
          
            
            

        }
        else
        {
            notEnoughStickDialogue();
            
        }

    }


    



    public void notEnoughStickDialogue()
    {
        
        dialogue.SetActive(true);
        
        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;
        
        dialogueLine.Add("I’ll need you to find me, say...about 20 sticks." );
        dialogueLine.Add("Okay." );
        dialogueLine.Add("And if you have any questions, do not hesitate to ask me." );
        DynamicDialogueScript.MyDelegate myDelegate; 
        myDelegate = finishDialogue;
        dialogueStarter = 1;
        dialoguePlayer.dialogueStart(background, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);

        
    }



    public void EnoughStickDialogue()
    {

        dialogue.SetActive(true);
        
        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;

        dialogueLine.Add("Here’s your sticks." );
        dialogueLine.Add("Aha! Good work, and these are some study ones, too! Give me a second while I fix my axe.");
        dialogueLine.Add( "..." );
        
        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = startFade;
        dialogueStarter = 0;
        dialoguePlayer.dialogueStart(background, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);


    }

    public void EnoughStickDialogue2()
    {

        dialogueLine.Clear();

        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;

        dialogueLine.Add("And here it is !");
        dialogueLine.Add("Thanks! Now, I guess I should go get to chopping, huh? ");
        dialogueLine.Add("Indeed. I’ll be ready to help once you have the proper amount needed for your home.");


        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = finishDialogue;
        dialogueStarter = 1;
        dialoguePlayer.dialogueStart(background, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);


    }


    public void startFade()
    {
        StartCoroutine("FadeForAxe");
    }


    IEnumerator FadeForAxe()
    {




        fade.SetActive(true);

        yield return new WaitUntil(() => fadeImage.color.a == 1f);

        fadeAnimation.SetTrigger("FaderAlt");
        //cleaner = 0;
        //dialogue2.SetActive(false);
        //chapter2Dialogue.SetActive(true);
        EnoughStickDialogue2();
        yield return new WaitUntil(() => fadeImage.color.a == 0f);
       
        fade.SetActive(false);

        // oldManInsideCuttageDialogue();
        // StartCoroutine("Fadeout");

    }






    public void buildShack()
    {
        dialogueLine.Clear();

        if (inventory.inventoryScriptable.getAmount(new Item(inventory.wood)) >= 50 && statsU.currentMood > 20)
        {

            locations.moveToForest();
           // StartCoroutine("FadeForHouse");
            //EnoughStickDialogue();
            buildShackDialogue();




        }
        else if (statsU.currentMood <= 20)
        {
            //too tired
            notEnoughMood();

        }
        else if (inventory.inventoryScriptable.getAmount(new Item(inventory.wood)) < 50)
        {
            notEnoughWood();
            //need more wood
        }
    }

    //IEnumerator FadeForHouse()
    //{




    //    fade.SetActive(true);
        
    //    yield return new WaitUntil(() => fadeImage.color.a == 1f);

    //    fadeAnimation.SetTrigger("FaderAlt");
    //    //cleaner = 0;
    //    //dialogue2.SetActive(false);
    //    //chapter2Dialogue.SetActive(true);
    //    dialogue.SetActive(true);
        
    //    yield return new WaitUntil(() => fadeImage.color.a == 0f);
    //    //EnoughStickDialogue2();
    //    buildShackDialogue();
    //    fade.SetActive(false);


    //    // oldManInsideCuttageDialogue();
    //    // StartCoroutine("Fadeout");

    //}



    public void notEnoughWood()
    {
        dialogue.SetActive(true);

        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;

        dialogueLine.Add("You need 50 wood logs and to be energetic(20% mood) to build yourself a shack.");
        dialogueLine.Add("Okay.");
        dialogueLine.Add("And if you have any questions, do not hesitate to ask me.");
        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = finishDialogue;
        dialogueStarter = 1;
        dialoguePlayer.dialogueStart(forestBackground, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);
    }

    public void notEnoughMood()
    {
        dialogue.SetActive(true);

        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;

        dialogueLine.Add("You look tired. Go rest somewhere before building yourself a shack.");
        dialogueLine.Add("Okay.");
        dialogueLine.Add("And if you have any questions, do not hesitate to ask me.");
        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = finishDialogue;
        dialogueStarter = 1;
        dialoguePlayer.dialogueStart(forestBackground, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);
    }

    public void buildShackDialogue()
    {

        dialogue.SetActive(true);

        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;

        dialogueLine.Add("Wow, my own place, built with my own two hands!");
        dialogueLine.Add("And mine. ");
        dialogueLine.Add("Seriously, this is a first for me. Now...it just needs furnishings.");
        dialogueLine.Add("All I can provide is a bedroll, I’m afraid. You’ll have to figure out the rest on your own.");
        dialogueLine.Add("Well, the first thing I need to do is make a tanning rack for leather. ");
        dialogueLine.Add("Indeed! I have the strings, just gather some 20 sticks and 10 wood and we should be well on our way.");
        dialogueLine.Add("Alright, I’ll be right back.");
        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = finishDialogue;
        dialogueStarter = 0;
        dialoguePlayer.dialogueStart(shackOutsideBackground, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);
    }



    public void askRack()
    {
        dialogueLine.Clear();

        if (inventory.inventoryScriptable.getAmount(new Item(inventory.wood)) >= 10 && inventory.inventoryScriptable.getAmount(new Item(inventory.stick)) >= 20)
        {

            inventory.addSomething(inventory.stick, -20);
            inventory.addSomething(inventory.wood, -10);
            inventory.addSomething(inventory.bow, 1);

            gettingRackDialogue();
           




        }
        else if (locations.homeID != locations.forestID)
        {
            //no home
            notEnoughHouseDialogue();

        }

        else 
        {
            //not enough stuff
            notEnoughStickforRackDialogue();

        }
        
    }



    public void notEnoughHouseDialogue()
    {

        dialogue.SetActive(true);

        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;

        dialogueLine.Add("You need a house first");
        dialogueLine.Add("Okay.");

        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = finishDialogue;
        dialogueStarter = 1;
        dialoguePlayer.dialogueStart(background, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);


    }





    public void gettingRackDialogue()
    {

        dialogue.SetActive(true);

        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;
        dialogueLine.Add("I got what we needed.");
        dialogueLine.Add("Splendid, lad, splendid! Let us retire to my abode where we can craft ourselves a tanning rack.");
        
        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = startFadeForRack;
        dialogueStarter = 0;
        dialoguePlayer.dialogueStart(background, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);


    }


    public void notEnoughStickforRackDialogue()
    {

        dialogue.SetActive(true);

        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;
        dialogueLine.Add("I’ll need you to find me, say...about 20 sticks and 10 wood.");
        dialogueLine.Add("Okay.");
        dialogueLine.Add("And if you have any questions, do not hesitate to ask me.");


        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = finishDialogue;
        dialogueStarter = 1;
        dialoguePlayer.dialogueStart(background, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);


    }

    public void startFadeForRack()
    {
        StartCoroutine("FadeForRack");
    }

    IEnumerator FadeForRack()
    {




        fade.SetActive(true);

        yield return new WaitUntil(() => fadeImage.color.a == 1f);

        fadeAnimation.SetTrigger("FaderAlt");
        //cleaner = 0;
        //dialogue2.SetActive(false);
        //chapter2Dialogue.SetActive(true);
        notEnoughStickforRackDialogue2();
        yield return new WaitUntil(() => fadeImage.color.a == 0f);
        
        fade.SetActive(false);

        // oldManInsideCuttageDialogue();
        // StartCoroutine("Fadeout");

    }



    public void notEnoughStickforRackDialogue2()
    {

        dialogue.SetActive(true);

        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;

        dialogueLine.Add("It’s not much, but it’ll work.");
        dialogueLine.Add("Now all I need is leather. Do you have a bow?");
        dialogueLine.Add("Indeed I do. Why?");
        dialogueLine.Add("To hunt");
        dialogueLine.Add("Well, here’s mine. I never took you for the kind of man who can use a bow.");
        dialogueLine.Add("Summer camp.");
        dialogueLine.Add("What’s a summer camp?");
        dialogueLine.Add("Uh...doesn’t matter.");
        dialogueLine.Add("If you say so...now go off into the forest and return when you have acquired 40 scraps of leather. Some deer, or even rabbits, will do.");
        dialogueLine.Add("Understood!");
        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = finishDialogue;
        dialogueStarter = 1;
        dialoguePlayer.dialogueStart(shackInsideBackground, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);


    }






    public void askCraftingSet()
    {
        dialogueLine.Clear();

        if (inventory.inventoryScriptable.getAmount(new Item(inventory.leather)) >= 40 && statsU.currentHealth >10)
        {

            inventory.addSomething(inventory.leather, -40);
            inventory.addSomething(equipment.craftedEquipment, 1);
            statsU.MinusHours(24);
            gettingCraftedSetDialogue();
            
            





        }
        else if (statsU.currentHealth <= 10)
        {

            notEnoughHPDialogue();

        }
        
        else
        {
            
            notEnoughleatherDialogue();

        }





    }

    public void notEnoughHPDialogue()
    {
        dialogueLine.Clear();
        dialogue.SetActive(true);

        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;
        dialogueLine.Add("It may take a full day to finish the clothes. Go eat something because you may not survive this.");
        dialogueLine.Add("Understood!");
        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = finishDialogue;
        dialogueStarter = 1;
        dialoguePlayer.dialogueStart(background, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);


    }

    public void notEnoughleatherDialogue()
    {
        dialogueLine.Clear();
        dialogue.SetActive(true);

        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;
        dialogueLine.Add("Go off into the forest and return when you have acquired 40 scraps of leather. Some deer, or even rabbits, will do.");
        dialogueLine.Add("Understood!");
        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = finishDialogue;
        dialogueStarter = 1;
        dialoguePlayer.dialogueStart(background, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);


    }



    public void gettingCraftedSetDialogue()
    {
        dialogueLine.Clear();
        dialogue.SetActive(true);

        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;

        dialogueLine.Add("Alright, I got a couple of deer.");
        dialogueLine.Add("Hmm...we could make something out of this.");
        dialogueLine.Add("...");
        dialogueLine.Add("So... I guess now we skin them, huh?");
        dialogueLine.Add("Indeed, I even have my knives!");
        dialogueLine.Add("Oh, cool...uh, why don’t you do it?");
        dialogueLine.Add("...");
       
        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = gettingCraftedSetDialogue2;
        dialogueStarter = 0;
        dialoguePlayer.dialogueStart(background, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);


    }


    public void gettingCraftedSetDialogue2()
    {
        dialogueLine.Clear();
        dialogue.SetActive(true);

        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;

       
        dialogueLine.Add("You’re not getting out of this.");

        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = startFadeForSet;
        dialogueStarter = 1;
        dialoguePlayer.dialogueStart(background, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);


    }



    public void startFadeForSet()
    {
        StartCoroutine("FadeForSet");
    }

    IEnumerator FadeForSet()
    {




        fade.SetActive(true);

        yield return new WaitUntil(() => fadeImage.color.a == 1f);

        fadeAnimation.SetTrigger("FaderAlt");
        //cleaner = 0;
        //dialogue2.SetActive(false);
        //chapter2Dialogue.SetActive(true);
        gettingCraftedSetDialogue3();
        yield return new WaitUntil(() => fadeImage.color.a == 0f);
       
        fade.SetActive(false);

        // oldManInsideCuttageDialogue();
        // StartCoroutine("Fadeout");

    }



    public void gettingCraftedSetDialogue3()
    {
        dialogueLine.Clear();
        dialogue.SetActive(true);

        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;


        dialogueLine.Add("Wasn’t that fun?");
        dialogueLine.Add("Yeah...a blast, really.");
        dialogueLine.Add("We’ll soak the skins in the water, then stretch them out on the racks. They won’t be ready until the morrow. However, we do have a good amount of meat for a feast. ");
        dialogueLine.Add("Yeah, actually. This is a lot of meat. Well, I have only been eating berries for a while. Some meat will do me good. ");
        dialogueLine.Add("I’ll place the skins in water, then we can get to cooking. While we eat, I’ll give you some advice on making some clothes from leather.");

        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = startFadeForSet2;
        dialogueStarter = 1;
        dialoguePlayer.dialogueStart(background, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);


    }

    public void startFadeForSet2()
    {
        StartCoroutine("FadeForSet2");
    }

    IEnumerator FadeForSet2()
    {




        fade.SetActive(true);

        yield return new WaitUntil(() => fadeImage.color.a == 1f);

        fadeAnimation.SetTrigger("FaderAlt");
        //cleaner = 0;
        //dialogue2.SetActive(false);
        //chapter2Dialogue.SetActive(true);
        gettingCraftedSetDialogue4();
        yield return new WaitUntil(() => fadeImage.color.a == 0f);
       
        fade.SetActive(false);

        // oldManInsideCuttageDialogue();
        // StartCoroutine("Fadeout");

    }


    public void gettingCraftedSetDialogue4()
    {
        dialogueLine.Clear();
        dialogue.SetActive(true);

        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;


        dialogueLine.Add("Oh god, what a night. Next time, I should stuff my face so full of meat. Alright, the skins should be ready. ");
        

        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = startFadeForSet3;
        dialogueStarter = 0;
        dialoguePlayer.dialogueStart(shackOutsideBackground, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);


    }

    public void startFadeForSet3()
    {
        StartCoroutine("FadeForSet3");
    }

    IEnumerator FadeForSet3()
    {




        fade.SetActive(true);

        yield return new WaitUntil(() => fadeImage.color.a == 1f);

        fadeAnimation.SetTrigger("FaderAlt");
        //cleaner = 0;
        //dialogue2.SetActive(false);
        //chapter2Dialogue.SetActive(true);
        gettingCraftedSetDialogue5();
        yield return new WaitUntil(() => fadeImage.color.a == 0f);
        
        fade.SetActive(false);

        // oldManInsideCuttageDialogue();
        // StartCoroutine("Fadeout");

    }


    public void gettingCraftedSetDialogue5()
    {
        dialogueLine.Clear();
        dialogue.SetActive(true);

        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;


        dialogueLine.Add("There we go! Now I can actually look like a proper member of society...1485 society, but society nonetheless!");


        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = gettingCraftedSetDialogue6;
        dialogueStarter = 0;
        dialoguePlayer.dialogueStart(shackOutsideBackground, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);


    }


    public void gettingCraftedSetDialogue6()
    {
        dialogueLine.Clear();
        dialogue.SetActive(true);

        Sprite _bodyRight = equipment.playerPrefab.transform.GetComponent<Image>().sprite;


        dialogueLine.Add("Now all I need to do is wear my new clothes and present myself to the village guard, then the doctor, then it's goodbye pain!");


        DynamicDialogueScript.MyDelegate myDelegate;
        myDelegate = finishDialogue;
        dialogueStarter = 0;
        dialoguePlayer.dialogueStart(shackOutsideBackground, iconLeft, iconRight, bodyLeft, _bodyRight, dialogueStarter, dialogueLine, myDelegate);


    }




    public void finishDialogue()
    {
        dialogueLine.Clear();
        dialogue.SetActive(false);
    }





    // Update is called once per frame
    void Update()
    {
        
    }

}
