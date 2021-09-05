using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public class GameController : MonoBehaviourPun
{
    [SerializeField] private Transform[] spawn_Point = null;
    [SerializeField] public static int maxCompleteness = 0;
    [SerializeField] public static string WinnerName = "";
    [SerializeField] public static int minimumCompletenessRequired;
    [SerializeField] public static int finishPlayers=0;
    [SerializeField] public static int finishCompleteness=3;
    [SerializeField] public static bool PauseEnabled = false;
    [SerializeField] public static string Type = "Target";
    [SerializeField] public static int StudentsWhoHavePlayed=0;
    [SerializeField] public static double RetreatsPhasesRatio=0;
    [SerializeField] public static double IncompletenessRatio = 0;
    [SerializeField] public static int RejectedSoftwareSystem=0;
    [SerializeField] public static double RequirementListRatio;
    [SerializeField] public static double InstructionsListTime;
    [SerializeField] public static double WorkProductRatio=0;
    [SerializeField] public static double SoftwareSystemReceived=0;
    [SerializeField] public static double SoftwareSystemReceivedRatio = 0;
    [SerializeField] public static double PhasesmovementsAdvance = 0;
    [SerializeField] public static double PhasesmovementsRetreat = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        int i = PhotonNetwork.CurrentRoom.PlayerCount;
        PhotonNetwork.Instantiate("SoftwareEngineeringStudent", spawn_Point[i - 1].position, spawn_Point[i -1].rotation);
        
    }

}
