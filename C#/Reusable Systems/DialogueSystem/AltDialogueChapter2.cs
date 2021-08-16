using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltDialogueChapter2 : MonoBehaviour
{

    public LoadScirpt loadScript;
    public Text leftDialogueText;

    string leftText;

    public AudioSource audioSource;
    public GameObject dialogue;
    public buttonsToDeactivate buttonsActivate;


    public Image iconRight;
    public Image iconLeft;
    public Image bodyRight;
    public Image bodyLeft;

    //public GameObject dialogue1Object;
    public GameObject LastOutsideDialogue;
    public GameObject backgroundInside;
    public GameObject backgroundOutside;



    private Color colorBright = new Color(255f / 255f, 255f / 255f, 255f / 255f);
    private Color colorDark = new Color(142 / 255f, 142 / 255f, 142 / 255f);

    int counter = 0;

    int cleaner = 0;




    // Start is called before the first frame update
    void Start()
    {


    }

    public void StartInHouseOldManDialogue()
    {
        counter = 0;
        cleaner = 0;
        dialogue.SetActive(true);
        dialogue1(0);
        // dialogue2played = 1;
        //  playDialogue2(0);
    }



    public void oldManCottageDialogueFirst()
    {
    //    if (dialogue2played == 0)
    //    {
    //        counter = 0;
    //        cleaner = 0;
    //        dialogue2.SetActive(true);
    //        dialogue2played = 1;
    //        playDialogue2(0);
    //        buttonsActivate.villageActivated();
    //    }
    //    else if (dialogue2played >= 1 && dialogueManager3.dialogue3played == 0)
    //    {
    //        counter = 0;
    //        cleaner = 0;
    //        dialogue2.SetActive(true);
    //        dialogue2played = 2;
    //        playDialogue2Alt(0);
    //        //buttonsActivate.villageActivated();
    //    }
    //    else if (dialogueManager3.dialogue3played >= 1 && dialogue2played <= 2)
    //    {
    //        counter = 0;
    //        cleaner = 0;
    //        dialogue2.SetActive(true);
    //        dialogue2played = 3;
    //        playDialogue2BackFromVillage(0);
    //        locations.ActivateDeactivate.OldManMenuStart();
    //        //buttonsActivate.villageActivated();

    //    }

    }


    public void dialogue1(int myCounter)
    {
       
        if (myCounter == 0)
        {
            LastOutsideDialogue.SetActive(false);
            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "Young man!";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 1)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "Ahhh, god...where am I?";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 2)
        {
           iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "Aha, you’ve finally awoken. Had me worried there, young man. With your ravings and fainting. ";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 3)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "I fainted?";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 4)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "Indeed, dropped like a sack. Almost believed you passed on to the afterlife, haha! Thankfully not! ";
            StartCoroutine("AutoTypeLeft");


        }
        if (myCounter == 5)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "Is it still 1485?";
            StartCoroutine("AutoTypeLeft");


        }
        if (myCounter == 6)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "Correct.";
            StartCoroutine("AutoTypeLeft");


        }
        if (myCounter == 7)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "How…";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 8)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "Young man, I wouldn’t speak like that near any of the folk. They might take you for a warlock. ";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 9)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "And what would happen there?";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 10)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "Most likely, they’d burn you alive.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 11)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "Uhh…";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 12)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "Quite unpleasant.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 13)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "Crap...what do I do? ";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 14)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "Perhaps, I can be of some help?";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 15)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "In what way?";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 16)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "Well, for the pain coursing through your body, you need a doctor. To get to a doctor in the village, you need clothing. I could assist you in acquiring some. ";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 17)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "Got any hand-me-downs? I’m not sure if we are the same size.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 18)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "I’ve had some experience in making clothes from leather. However, I don’t have a tanning rack, so we’ll have to make one. ";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 19)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "Alright...how do we start? ";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 20)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "First, you must build a house.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 21)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "…";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 22)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;
            leftText = "Wait, what?";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 23)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "Yes. I’m afraid my humble abode is only meant for one. You’ll need to make a place for yourself, as I while I’m averse to putting a young lad out in the cold, I cannot sustain another.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 24)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;
            leftText = "I...have no building experience! ";
            StartCoroutine("AutoTypeLeft");
        }

        if (myCounter == 25)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "Fret not, for I can help! Come with me outside.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 26)
        {
            //change the pic to outside
            backgroundOutside.SetActive(true);
            backgroundInside.SetActive(false);


            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "I built my home many years ago, and it took me not so long.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 27)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;
            

            leftText = "I could see that...it’s pretty simple.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 28)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "Yet it serves me well!";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 29)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;


            leftText = "So...what, you suggest I go out into the woods, chop down some trees, and just build a house? ";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 30)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "Yes! I’m afraid the axe I have is a bit worn out. The handle may need some fixing, thus I’ll need you to find me 20 sticks.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 31)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;


            leftText = "What kinds? ";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 32)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "Strong kinds, something that won’t break when you strike a tree with it.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 33)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;


            leftText = "Okay.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 34)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "And if you have any questions, do not hesitate to ask me.";
            StartCoroutine("AutoTypeLeft");
        }

        if (myCounter == 35)
        {

            dialogue.SetActive(false);
            cleaner = 0;
        }






    }







    //I created a separated next button for every dialogue

    //next chat for first dialogue
    public void nextChat()
    {
        if (cleaner == 0)
        {
            //counter++;
            StopAllCoroutines();
            //dialogue1(counter);
            leftDialogueText.text = leftText;
            cleaner = 1;
        }
        else
        {
            counter++;
            StopAllCoroutines();
            dialogue1(counter);
            cleaner = 0;
        }

    }


    ////next button for dialogue 2
    //public void nextChat2()
    //{
    //    if (dialogue2played == 1)
    //    {
    //        if (cleaner == 0)
    //        {
    //            // counter++;
    //            StopAllCoroutines();
    //            //dialogue1(counter);
    //            leftDialogueText.text = leftText;
    //            cleaner = 1;
    //        }
    //        else
    //        {
    //            counter++;
    //            StopAllCoroutines();
    //            playDialogue2(counter);
    //            cleaner = 0;
    //        }
    //    }
    //    else if (dialogue2played == 2)
    //    {
    //        if (cleaner == 0)
    //        {
    //            // counter++;
    //            StopAllCoroutines();
    //            //dialogue1(counter);
    //            leftDialogueText.text = leftText;
    //            cleaner = 1;
    //        }
    //        else
    //        {
    //            counter++;
    //            StopAllCoroutines();
    //            playDialogue2Alt(counter);
    //            cleaner = 0;
    //        }
    //    }
    //    else if (dialogue2played == 3)
    //    {
    //        if (cleaner == 0)
    //        {
    //            // counter++;
    //            StopAllCoroutines();
    //            //dialogue1(counter);
    //            leftDialogueText.text = leftText;
    //            cleaner = 1;
    //        }
    //        else
    //        {
    //            counter++;
    //            StopAllCoroutines();
    //            playDialogue2BackFromVillage(counter);
    //            cleaner = 0;
    //        }
    //    }


    //}

    ////next button for dialogue 3
    //public void nextChat3()
    //{



    //    if (Alt3ToPlay == 1)
    //    {
    //        if (cleaner == 0)
    //        {
    //            // counter++;
    //            StopAllCoroutines();
    //            //dialogue1(counter);
    //            //playAltDialogue3(counter);
    //            leftDialogueText.text = leftText;
    //            cleaner = 1;
    //        }
    //        else
    //        {
    //            counter++;
    //            StopAllCoroutines();
    //            playAltDialogue3(counter);
    //            cleaner = 0;
    //        }
    //    }
    //    else if (Alt3ToPlay == 0)
    //    {
    //        if (cleaner == 0)
    //        {
    //            // counter++;
    //            StopAllCoroutines();
    //            //dialogue1(counter);
    //            leftDialogueText.text = leftText;
    //            cleaner = 1;
    //        }
    //        else
    //        {
    //            counter++;
    //            StopAllCoroutines();
    //            playDialogue3(counter);
    //            cleaner = 0;
    //        }
    //    }

    //}



    IEnumerator AutoTypeLeft()
    {

        leftDialogueText.text = "";
        foreach (char letter in leftText.ToCharArray())
        {
            leftDialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
            audioSource.Play();
        }
        cleaner = 1;
    }

    IEnumerator AutoTypeRight()
    {

        leftDialogueText.text = "";
        foreach (char letter in leftText.ToCharArray())
        {
            leftDialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
            audioSource.Play();
        }
        cleaner = 1;
    }


    public void finishDialogues()
    {
        cleaner = 0;
    }


    // Update is called once per frame
    void Update()
    {

    }
}