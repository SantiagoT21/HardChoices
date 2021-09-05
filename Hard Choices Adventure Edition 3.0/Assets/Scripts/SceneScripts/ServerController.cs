using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class ServerController : MonoBehaviourPunCallbacks
{
    [SerializeField] public GameObject start_Button;
    [SerializeField] public Text status_Text = null;
    private byte maximun_players = 4;


    private void Start()
    {
        PlayerPrefs.DeleteAll();

        PhotonNetwork.ConnectUsingSettings();
        start_Button.SetActive(false);
        Status("Connecting to Server");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.AutomaticallySyncScene = true;
        start_Button.SetActive(true);
        Status("Connectted to " + PhotonNetwork.ServerAddress);
    }

    private void OnButtonStart()
    {
        string roomName = "Room1";
        Photon.Realtime.RoomOptions options = new Photon.Realtime.RoomOptions();
        options.IsOpen = true;
        options.IsVisible = true;
        options.MaxPlayers = maximun_players;

        PhotonNetwork.JoinOrCreateRoom(roomName, options, TypedLobby.Default);
        start_Button.SetActive(false);
        Status("Joining to " + roomName);
    }

    public override void OnJoinedRoom()
    {
            base.OnJoinedRoom();
            SceneManager.LoadScene("Game");
    }

    private void Status(string msg)
    {
        Debug.Log(msg);
        status_Text.text = msg;
    }
}
