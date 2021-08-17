using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DinamicDialogue : MonoBehaviour
{
    public Text DialogueText;
    public AudioSource dialogueAudio;
    public GameObject DialogueObject;
    public List<string> dialogueLine = new List<string>();


    int dialogueStarter;


    public int buttonPressed = 0;
    IEnumerator autoType;
 

    // Start is called before the first frame update
    void Start()
    {
        dialogueLine.Add("Hey, Why are you crying?");
        dialogueLine.Add("People leave me and everyone hates me.");
        dialogueLine.Add("Don't be sad. This is not the end of the world.");
        dialogueLine.Add("What is it, then?");
        dialogueLine.Add("Find it out yourself.");
        //  DinamicDialogue.MyDelegate myDelegate;
        //  myDelegate = finishDialogue;
        dialogueStarter = 1;
        dialogueStart(dialogueStarter, dialogueLine);
    }










    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (buttonPressed == 0)
            {
                buttonPressed = 1;
            }
            else if (buttonPressed == 1)
            {

                buttonPressed = 2;
                //Debug.Log("Button pressed " + buttonPressed);
            }
        }
        
    }




    //declare dialogue
    public void dialogueStart(int _dialogueStarter, List<string> _dialogueLine)
    {
        
        StartCoroutine(dialogueStarts(_dialogueStarter, _dialogueLine));
        //  string dialogueString = "";

    }




    IEnumerator dialogueStarts(int _dialogueStarter, List<string> _dialogueLine)
    {

        buttonPressed = 0;
        //background.GetComponent<Image>().sprite = _background;
        //iconLeft.GetComponent<Image>().sprite = _iconLeft;
        //iconRight.GetComponent<Image>().sprite = _iconRight;
        //bodyLeft.GetComponent<Image>().sprite = _bodyLeft;
        //bodyRight.GetComponent<Image>().sprite = _bodyRight;



        foreach (string msg in _dialogueLine)
        {
            autoType = AutoType(msg.ToString());
            if (_dialogueStarter == 0)
            {
              //  iconLeft.color = colorDark;
               // iconRight.color = colorBright;
                _dialogueStarter = 1;
            }
            else if (_dialogueStarter == 1)
            {
               // iconRight.color = colorDark;
               // iconLeft.color = colorBright;
                _dialogueStarter = 0;
            }

            yield return StartCoroutine(autoType);

            yield return new WaitUntil(() => buttonPressed >= 2);


            buttonPressed = 0;
        }


        finishDialogue();




    }


  



    IEnumerator AutoType(string myString)
    {

        DialogueText.text = "";

        foreach (char letter in myString.ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
            dialogueAudio.Play();

            if (buttonPressed == 1)
            {

                DialogueText.text = myString;
                yield break;

            }


        }




        buttonPressed = 1;
    }





    public void finishDialogue()
    {
        dialogueLine.Clear();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //    GameObject player = GameObject.Find("Player");

        //  player.GetComponent<PlayerController>().controllerFreez();


    }


}




