using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DialogueHaveSticks : MonoBehaviour
{

    public List<string> dialogueLine = new List<string>();
    public DynamicDialogueScript dialoguePlayer;
    public Sprite background;
    public Sprite iconLeft;
    public Sprite iconRight;
    public Sprite bodyLeft;
    public Sprite bodyRight;
    int dialogueStarter;



    public GameObject dialogue;
    public EquipmentScript equipment;
    public Inventory inventory;



   






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
