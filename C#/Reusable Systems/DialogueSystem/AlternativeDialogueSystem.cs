using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class AlternativeDialogueSystem : MonoBehaviour
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
    public Sprite _bodyRight;
    //old man dialogue
    public GameObject dialogue2;
    public int dialogue2played = 0;
    public AlternativeDialogueSystem dialogueManager3;
    public GameObject fade;
    public Image fadeImage;
    public Animator fadeAnimation;
    public AudioSource faintSound;
    public AudioSource fallingSound;

    //  public GameObject hoursLaterText;
    public AltDialogueChapter2 chapter2Script;
    public GameObject chapter2Dialogue;




    //villager dialogue
    public GameObject dialogue3;
    public int dialogue3played = 0;
    public EquipmentScript equipments;
    public LocationManager locations;
    public int Alt3ToPlay = 0;



    private Color colorBright = new Color(255f/255f, 255f/ 255f, 255f/ 255f);
    private Color colorDark = new Color(142/255f, 142/255f, 142/255f);

    int counter = 0;

    int cleaner = 0;



    public GameObject demoBackground;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void StartFirstDialogue()
    {
        dialogue1(0);
    }



    public void oldManCottageDialogueFirst()
    {
        if (dialogue2played == 0)
        {
            counter = 0;
            cleaner = 0;
            dialogue2.SetActive(true);
            dialogue2played = 1;
            playDialogue2(0);
            buttonsActivate.villageActivated();
        }
        else if(dialogue2played >= 1 && dialogueManager3.dialogue3played == 0) 
        {
            counter = 0;
            cleaner = 0;
            dialogue2.SetActive(true);
            dialogue2played = 2;
            playDialogue2Alt(0);
            //buttonsActivate.villageActivated();
        }
        else if(dialogueManager3.dialogue3played >= 1 && dialogue2played <= 2)
        {
            counter = 0;
            cleaner = 0;
            dialogue2.SetActive(true);
            dialogue2played = 3;
            playDialogue2BackFromVillage(0);
            locations.ActivateDeactivate.OldManMenuStart();
           //buttonsActivate.villageActivated();

        }else if(dialogue2played == 3)
        {
            locations.ActivateDeactivate.OldManMenuStart();
        }
        
    }

    public void oldManInsideCuttageDialogue()
    {
        chapter2Script.StartInHouseOldManDialogue();
    }

    public void playDialogue2BackFromVillage(int myCounter)
    {
        if (myCounter == 0)
        {
            
            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "Ahh, young man, you have returned! How are you feeling?";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 1)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "Still hurts, thank you! Yeah, they didn’t even let me into the village! They said I was ‘in nothing but rags’";
            StartCoroutine("AutoTypeRight");
        }
        if (myCounter == 2)
        {

            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "Hmm, yes you do seem to be missing the appropriate clothing.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 3)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "I am aware. It’s not like I chose to wake up shirtless...so what am I supposed to do? I don’t know any place that sells clothes like they wore!";
            StartCoroutine("AutoTypeRight");
        }
        if (myCounter == 4)
        {

            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "Young man, are you feeling okay? You sound as if you’re under the weather with your mad ramblings.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 5)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "No, I’m not okay! My body is in pain and every person I talk to is nuts! It feels like it’s another time!";
            StartCoroutine("AutoTypeRight");
        }
        if (myCounter == 6)
        {

            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "That’s queer, it’s always been 1485, last I checked with the scribes.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 7)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "Wait, wait...what did you just say?";
            StartCoroutine("AutoTypeRight");
        }
        if (myCounter == 8)
        {

            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "1485. The current year, as far as I’m aware.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 9)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "No...no, it’s 2020!";
            StartCoroutine("AutoTypeRight");
        }
        if (myCounter == 10)
        {

            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "I don’t think so.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 11)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "You’re telling me I travelled back in time?!";
            StartCoroutine("AutoTypeRight");
        }
        if (myCounter == 12)
        {

            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "I would sooner think you hit your head on a stone!";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 13)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "No...no, it can’t be! I was...I was...damn, I have no clue what happened that got me here!";
            StartCoroutine("AutoTypeRight");
        }
        if (myCounter == 14)
        {

            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "Hmm, it seems you are struggling.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 15)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "I-I...";
            //faints
            StartCoroutine("AutoTypeRight");
        }
       



        if (myCounter == 16)
        {
            StartCoroutine("playFaintAudio");
            StartCoroutine("Fade");
            

            //   cleaner = 0;
        }
    }



    IEnumerator Fade()
    {

        


        fade.SetActive(true);
        
       
        yield return new WaitUntil(() => fadeImage.color.a == 1f);
        //hoursLaterText.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        fadeAnimation.SetTrigger("FaderAlt");
        cleaner = 0;

        
        //dialogue2.SetActive(false);
        chapter2Dialogue.SetActive(true);


        yield return new WaitUntil(() => fadeImage.color.a == 0f);
        fade.SetActive(false);
        oldManInsideCuttageDialogue();
       // StartCoroutine("Fadeout");

    }

    IEnumerator playFaintAudio()
    {
        fallingSound.Play();
        yield return new WaitWhile(() => fallingSound.isPlaying);
        faintSound.Play();

    }

 




public void playDialogue2Alt(int myCounter)
    {
        if (myCounter == 0)
        {

            iconRight.color = colorDark;
            iconLeft.color = colorBright;
           
            leftText = "If you’re looking to feel better, we do have a doctor not too far from here. Should be in the nearest village.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 1)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "Alright. Thanks, old man.";
            StartCoroutine("AutoTypeRight");
        }
       

        if (myCounter == 2)
        {

            dialogue2.SetActive(false);
            cleaner = 0;
        }
    }


    public void playDialogue2(int myCounter)
    {
        if (myCounter == 0)
        {
            
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "Oh! Hey! I see a building...hey! Hey you!";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 1)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright ;

            leftText = "Hm? Oh! A stray traveller! Good greetings to you, young man! May I say, you do look in dire straits… ";
            StartCoroutine("AutoTypeRight");
        }
        if (myCounter == 2)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "I guess you can say that. Uh...why do you talk like that? ";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 3)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "You query my diction? It is the way all landfolk of this region speak! ";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 4)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "All landfolk?";
            StartCoroutine("AutoTypeLeft");


        }
        if (myCounter == 5)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "Pirates are much more vulgar, you understand.";
            StartCoroutine("AutoTypeLeft");


        }
        if (myCounter == 6)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = " I-I really don’t. Listen, I need to find a doctor. Can you point me towards the nearest hospital, please? ‘";
            StartCoroutine("AutoTypeLeft");


        }
        if (myCounter == 7)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "Hospital? Lad, I haven’t a clue what you are on about.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 8)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;
            leftText = "A hospital? A place where people that feel bad go to feel good again? ";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 9)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "I’m afraid I’ve never heard the term. However, if you’re looking to feel better, we do have a doctor not too far from here. Should be in the nearest village. ";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 10)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;
            leftText = "A doctor? Yes, that’s exactly what I’m looking for! Where is this village?";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 11)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "It’s south from here. Just walk in that direction and you’ll eventually reach it.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 12)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;
            leftText = "Alright. Thanks, old man.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 13)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "Hmph…";
            StartCoroutine("AutoTypeLeft");
        }
     

        if (myCounter == 14)
        {

            dialogue2.SetActive(false);
            cleaner = 0;
        }
    }


    public void startVillageFirstDialogue()
    {
        locations.updateLocation(locations.villageID);
        if (equipments.currentEquipment == equipments.startingEquipment)
        {
            locations.updateLocation(locations.forestID);
            if (dialogue3played == 0)
            {
                cleaner = 0;
                dialogue2.SetActive(true);
                dialogue3played = 1;
                playDialogue3(0);
                //loadScript.statsU.MinusHours(4);
            }
            else
            {
                counter = 0;
                Alt3ToPlay = 1;
                cleaner = 0;
                dialogue2.SetActive(true);
                dialogue3played = 1;
                playAltDialogue3(0);
                //loadScript.statsU.MinusHours(4);

            }
        }
        else
        {
            
            if (dialogue3played != 2)
            {
                cleaner = 0;
                Alt3ToPlay = 2;
                dialogue3played = 2;
                dialogue2.SetActive(true);
                _bodyRight = equipments.playerPrefab.transform.GetComponent<Image>().sprite;
                bodyRight.GetComponent<Image>().sprite = _bodyRight;
                //locations.villageButtonPressed();
                playEndingDialogue3(0);
                //demoBackground.SetActive(true);
            }
            else
            {
                
                locations.villageButtonPressed();
            }
            
        }
    }

    //starting dialogue 3
    public void playDialogue3(int myCounter)
    {
        if (myCounter == 0)
        {

            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "Ahh, there it is! Hello!";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 1)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "Halt, stranger! What is your business? ";
            StartCoroutine("AutoTypeRight");
        }
        if (myCounter == 2)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "Well, you see, my body is in deep, deep pain, and I need to see a doctor. ";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 3)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "Pah, not dressed like that, you won’t! ";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 4)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = "You’re in nothing but rags! I’d sooner let a rabid dog step foot in this village before you!";
            StartCoroutine("AutoTypeLeft");


        }
        if (myCounter == 5)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "I-I mean, this is all I got! I woke up like this and-";
            StartCoroutine("AutoTypeLeft");


        }
        if (myCounter == 6)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;

            leftText = " Spare me the anecdote, stranger! Either come back with clothes befitting a decent man or don’t come back at all!";
            StartCoroutine("AutoTypeLeft");


        }
        if (myCounter == 7)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "Or else what?";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 8)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "If you try to step foot in this village indecent, it’d be the pillory for you.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 9)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;
            leftText = "A whattory?";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 10)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "Pillory! You will be restrained and prone to having fruits thrown at you!";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 11)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;
            leftText = "Oh geez...f-fine! I’ll be back with clothes!";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 12)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "Until then, stranger!";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 13)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;
            leftText = "Bastard...";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 14)
        {

            dialogue3.SetActive(false);
            cleaner = 0;
        }


    }

    //if second time dialogue 3 but still no clothes
    public void playAltDialogue3(int myCounter)
    {
        
        if (myCounter == 0)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "Either come back with clothes befitting a decent man or don’t come back at all!";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 1)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;
            leftText = "Bastard...";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 2)
        {

            dialogue3.SetActive(false);
            cleaner = 0;
        }



    }

    //when the player has clothes
    public void playEndingDialogue3(int myCounter)
    {
        if (myCounter == 0)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "Halt! Who goes there?";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 1)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;
            leftText = "It’s me! I have returned with proper attire!";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 2)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "Oh, you...well, it’s not exactly the most proper clothing, but it works better than what you had.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 3)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;
            leftText = "So can I enter?";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 4)
        {
            iconRight.color = colorDark;
            iconLeft.color = colorBright;
            leftText = "Hmm...yes, you can enter. Just don’t cause any trouble.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 5)
        {

            dialogue3.SetActive(false);
            cleaner = 0;
        }
    }


    public void dialogue1(int myCounter)
    {
        if (myCounter == 0)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "Aw geez, the sun is soooo bright. Too bright. Let me sleep a wink longer, please. Ugh, I need a new bed. ";
            StartCoroutine("AutoTypeLeft");

        }
        if (myCounter == 1)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "Wait...this isn’t my bed...and those aren’t my walls...and they aren’t walls.";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 2)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "...";
            StartCoroutine("AutoTypeLeft");
        }
        if(myCounter == 3)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "Crap, I woke up in a forest again…";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 4)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "Well, I should probably make my way back to civilization. No use standing around like-";
            StartCoroutine("AutoTypeLeft");

            
        }
        if (myCounter == 5)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "AGH! My ass! Oh god, why...why? What the hell? What is that? Why does it hurt so much? ";
            StartCoroutine("AutoTypeLeft");


        }
        if (myCounter == 6)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "Is...is this what birth is like? Aw god, please deliver me from this wretched pain.";
            StartCoroutine("AutoTypeLeft");


        }
        if (myCounter == 7)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;

            leftText = "...";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 8)
        {
            iconRight.color = colorBright;
            iconLeft.color = colorDark;
            leftText = "Well, so much for divine intervention. Next plan, degree-received intervention. I need a doctor! Let’s get movin’!";
            StartCoroutine("AutoTypeLeft");
        }
        if (myCounter == 9)
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


    //next button for dialogue 2
    public void nextChat2()
    {
        if(dialogue2played == 1)
        {
            if (cleaner == 0)
            {
                // counter++;
                StopAllCoroutines();
                //dialogue1(counter);
                leftDialogueText.text = leftText;
                cleaner = 1;
            }
            else
            {
                counter++;
                StopAllCoroutines();
                playDialogue2(counter);
                cleaner = 0;
            }
        }else if(dialogue2played == 2)
        {
            if (cleaner == 0)
            {
                // counter++;
                StopAllCoroutines();
                //dialogue1(counter);
                leftDialogueText.text = leftText;
                cleaner = 1;
            }
            else
            {
                counter++;
                StopAllCoroutines();
                playDialogue2Alt(counter);
                cleaner = 0;
            }
        }
        else if (dialogue2played == 3)
        {
            if (cleaner == 0)
            {
                // counter++;
                StopAllCoroutines();
                //dialogue1(counter);
                leftDialogueText.text = leftText;
                cleaner = 1;
            }
            else
            {
                counter++;
                StopAllCoroutines();
                playDialogue2BackFromVillage(counter);
                cleaner = 0;
            }
        }


    }

    //next button for dialogue 3
    public void nextChat3()
    {
        


        if(Alt3ToPlay == 1)
        {
            if (cleaner == 0)
            {
                // counter++;
                StopAllCoroutines();
                //dialogue1(counter);
                //playAltDialogue3(counter);
                leftDialogueText.text = leftText;
                cleaner = 1;
            }
            else
            {
                counter++;
                StopAllCoroutines();
                playAltDialogue3(counter);
                cleaner = 0;
            }
        }
        else if (Alt3ToPlay == 0)
        {
            if (cleaner == 0)
            {
                // counter++;
                StopAllCoroutines();
                //dialogue1(counter);
                leftDialogueText.text = leftText;
                cleaner = 1;
            }
            else
            {
                counter++;
                StopAllCoroutines();
                playDialogue3(counter);
                cleaner = 0;
            }
        }
        else if (Alt3ToPlay == 2)
        {
            if (cleaner == 0)
            {
                // counter++;
                StopAllCoroutines();
                //dialogue1(counter);
                leftDialogueText.text = leftText;
                cleaner = 1;
            }
            else
            {
                counter++;
                StopAllCoroutines();
                playEndingDialogue3(counter);
                cleaner = 0;
            }
        }

    }



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
