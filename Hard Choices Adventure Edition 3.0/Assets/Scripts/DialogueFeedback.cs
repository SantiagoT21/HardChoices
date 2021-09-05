using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueFeedback 
{
    [TextArea(3,10)]
    public string [] Type1; 
    public string [] Type2;
    private string Result;

    public void setResult(string r)
    {
        Result = r;
    }
}
