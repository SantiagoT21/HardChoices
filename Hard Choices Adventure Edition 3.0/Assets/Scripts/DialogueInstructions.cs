using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueInstructions 
{
    [TextArea(3,10)]
    public string [] Type1;
    public string [] Type2;
    public string [] Type3;
    public string [] Type4;
}
