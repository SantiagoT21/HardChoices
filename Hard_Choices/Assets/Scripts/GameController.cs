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
    [SerializeField] public static int RoundAmount = 2;
    [SerializeField] public static int endPlayers = 0;
    [SerializeField] public static int turno = 1;
    [SerializeField] public static int n = 1;
    [SerializeField] public static int GCcardNumber = 10;
    [SerializeField] public static Queue<Score> Estructura = new Queue<Score>();
    [SerializeField] public static int maxPoints = 0;
    [SerializeField] public static string WinnerName = "";

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        int i = PhotonNetwork.CurrentRoom.PlayerCount;

            PhotonNetwork.Instantiate("Marker", spawn_Point[i - 1].position, spawn_Point[i-1].rotation);
            PhotonNetwork.Instantiate("Score", spawn_Counter[i - 1].position, spawn_Counter[i-1].rotation);
    }
}
