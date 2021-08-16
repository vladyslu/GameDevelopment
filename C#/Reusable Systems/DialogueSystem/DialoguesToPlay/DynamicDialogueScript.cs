using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicDialogueScript : MonoBehaviour
{
    public Text DialogueText;
    public AudioSource dialogueAudio;
    public int cleaner = 0;
    //public List<string> dialogueLine = new List<string>();
    private Color colorBright = new Color(255f / 255f, 255f / 255f, 255f / 255f);
    private Color colorDark = new Color(142 / 255f, 142 / 255f, 142 / 255f);
    public delegate void MyDelegate();
    public Image iconLeft;
    public Image iconRight;
    public Image background;
    public Image bodyLeft;
    public Image bodyRight;

    public int buttonPressed = 0;
    IEnumerator autoType;

    public void dialogueStart(Sprite _background, Sprite _iconLeft, Sprite _iconRight, Sprite _bodyLeft, Sprite _bodyRight, int _dialogueStarter, List<string> _dialogueLine, MyDelegate finishDialogue)
    {



        StartCoroutine(dialogueStarts( _background,  _iconLeft,  _iconRight,  _bodyLeft,  _bodyRight,  _dialogueStarter, _dialogueLine,  finishDialogue));

        //  string dialogueString = "";


    }


    IEnumerator dialogueStarts(Sprite _background, Sprite _iconLeft, Sprite _iconRight, Sprite _bodyLeft, Sprite _bodyRight, int _dialogueStarter, List<string> _dialogueLine, MyDelegate finishDialogue)
    {

        buttonPressed = 0;
        background.GetComponent<Image>().sprite = _background;
        iconLeft.GetComponent<Image>().sprite = _iconLeft;
        iconRight.GetComponent<Image>().sprite = _iconRight;
        bodyLeft.GetComponent<Image>().sprite = _bodyLeft;
        bodyRight.GetComponent<Image>().sprite = _bodyRight;
        


        foreach (string msg in _dialogueLine)
        {
            autoType = AutoType(msg.ToString());
            if (_dialogueStarter == 0)
            {
                iconLeft.color = colorDark;
                iconRight.color = colorBright;
                _dialogueStarter = 1;
            }
            else if (_dialogueStarter == 1)
            {
                iconRight.color = colorDark;
                iconLeft.color = colorBright;
                _dialogueStarter = 0;
            }
            
            yield return StartCoroutine(autoType);

            yield return new WaitUntil(() => buttonPressed >= 2);
           

            buttonPressed = 0;
        }


        finishDialogue();




    }








        public void nextButtonPressed()
    {
        if(buttonPressed == 0)
        {
            buttonPressed = 1;
        }
        else if(buttonPressed == 1)
        {
            
            buttonPressed = 2;
            //Debug.Log("Button pressed " + buttonPressed);
        }
        
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

}
