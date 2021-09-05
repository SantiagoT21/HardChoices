using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkProduct : MonoBehaviour
{

    public int ID;
    public string description;
    public Sprite icon;
    private bool Developing;
    private bool CheckDevelopment = false;

    public int getID()
    {
        return ID;
    }

    public string getDescription()
    {
        return description;
    }

    public bool getDeveloping()
    {
        return Developing;
    }
    public void setDeveloping(bool PU)
    {
        Developing = PU;
    }

    public bool getCheckDevelopment()
    {
        return CheckDevelopment;
    }

    public void setCheckDevelopment(bool tw)
    {
        CheckDevelopment = tw;
    }

}
