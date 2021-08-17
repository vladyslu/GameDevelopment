using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClueChoise", menuName = "ClueObjects/ClueChoise")]
public class clueChoises : ScriptableObject
{
    public new string name;
    public string shortDescription;
    [System.NonSerialized]
    public bool active = false;
    [System.NonSerialized]
    public bool buttonActive = false;

}
