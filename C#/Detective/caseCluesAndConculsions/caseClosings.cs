using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CaseClosing", menuName = "ClueObjects/caseClosing")]
public class caseClosings : ScriptableObject
{
    public new string name;
    public string shortDescription;
    public List<clueChoises> requiredConclusions;
    [System.NonSerialized]
    public bool buttonActive = false;
}
