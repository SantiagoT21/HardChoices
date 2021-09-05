using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public string state;
    public Transform[] spawn_Point;
    public int maxCompleteness;
    public string WinnerName;
    public int minimumCompletenessRequired;
    public int finishPlayers;
    public int finishCompleteness;
    public bool PauseEnabled;
    public string Type;
    public int RejectedSoftwareSystem;
    public double SoftwareSystemReceived;
    public double PhasesmovementAdvances;
    public double PhasesmovemenetRetreat;

    void Start()
    {
        state = "started";
    }
 
    void Pauses()
    {
        state = "paused";
    }
    void Resumes()
    {
        state = "resumed";
    }
    void Unpauses()
    {
        state = "unpaused";
    }
}
