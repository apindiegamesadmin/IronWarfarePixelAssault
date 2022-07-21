using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    // To store dialogue sentences as a string array
    [TextArea(3,10)]
    public string[] sentences;
}
