using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviourPun
{
    [SerializeField] private Transform[] spawn_Point = null;
    [SerializeField] private Transform[] spawn_Counter = null;
    [SerializeField] public static Dictionary<int, Marker> Estructura = new Dictionary<int, Marker>();
    [SerializeField] public static int Index = 1;
    public static bool turnBeginning = false;
    [SerializeField] public static int RoundAmount = 2;

    private void Awake()
    {
        int i = PhotonNetwork.CurrentRoom.PlayerCount;

            PhotonNetwork.Instantiate("Marker", spawn_Point[i - 1].position, spawn_Point[i].rotation);
            PhotonNetwork.Instantiate("Score", spawn_Counter[i - 1].position, spawn_Counter[i].rotation);

        if(i == 1)
        {
            turnBeginning = true;
        }
    }
}
