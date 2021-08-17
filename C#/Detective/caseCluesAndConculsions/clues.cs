using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Clue", menuName = "ClueObjects/Clues")]
public class clues : ScriptableObject
{
    public new string name;
    public int id;
    public string shortDescription;
    [System.NonSerialized]
    public bool active = false;
    [System.NonSerialized]
    public bool buttonActive = false;
    public List<clueChoises> clueChoiseList;
}
