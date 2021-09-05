using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Card : MonoBehaviourPun
{
    public static Card Instance;
    public Texture2D[] icons;
    public Texture2D[] GCicons;
    public int saw_counter;
    public int hammer_counter;
    public int screwdriver_counter;
    public int bridge_counter;
    public string Pname;
    public Dictionary<int, bool> history =
    new Dictionary<int, bool>();
    public int finishPoints;
    public bool posaux = false;
    public int posaux1 = 0;


    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        for(int i = 0; i < 55; i++)
        {
            Card.Instance.history[i] = false;
        }
    }

    public void ChoiceIcon(int pos, int aux)
    {
        if (Die.Die_Instance.random == 0)
        {
            if (pos == 4 || pos == 22 || pos == 44)
            {
                if (history[pos]==false) {
                    GetComponent<MeshRenderer>().material.mainTexture = icons[3];
                    saw_counter++;
                    history[pos] = true;
                    ReturnCard.ReturnCard_Instance.tool_button.SetActive(true);
                }
            }
            else if (pos == 7 || pos == 15 || pos == 28 || pos == 36 || pos == 42)
            {
                if (history[pos]==false)
                {
                    GetComponent<MeshRenderer>().material.mainTexture = icons[1];
                    hammer_counter++;
                    history[pos] = true;
                    ReturnCard.ReturnCard_Instance.tool_button.SetActive(true);
                }
            }
            else if (pos == 13 || pos == 23 || pos == 38 || pos == 45)
            {
                if (history[pos] == false)
                {
                    GetComponent<MeshRenderer>().material.mainTexture = icons[4];
                    screwdriver_counter++;
                    history[pos] = true;
                    if (GameController.GCcardNumber == 4 && bridge_counter > 0)
                    {
                        bridge_counter--;
                    }
                    ReturnCard.ReturnCard_Instance.tool_button.SetActive(true);
                }
            }
            else if (pos == 54 || pos == 50 || pos == 51 || pos == 52 || pos == 53 || pos == 49)
            {
                if (pos == 53)
                {
                    GetComponent<MeshRenderer>().material.mainTexture = icons[0];
                    bridge_counter++;
                }
                if (aux < 45)
                {
                    GetComponent<MeshRenderer>().material.mainTexture = icons[0];
                    bridge_counter++;
                }
            }
            else if (pos == 55)
            {
                posaux = true;

                if (GameController.endPlayers == 0)
                {
                    finishPoints = 7;
                    photonView.RPC("Change_Gccard", RpcTarget.AllViaServer, Random.Range(0, 6));
                    photonView.RPC("Change_endPlayers", RpcTarget.AllViaServer,1);
                }
                else if (GameController.endPlayers == 1)
                {
                    finishPoints = 3;
                    photonView.RPC("Change_endPlayers", RpcTarget.AllViaServer,2);
                }
                else if (GameController.endPlayers == 2)
                {
                    finishPoints = 1;
                    photonView.RPC("Change_endPlayers", RpcTarget.AllViaServer,3);
                    
                }
            }
        }
        else
        {
            if (pos == 54 || pos == 50 || pos == 51 || pos == 52 || pos == 53 || pos == 49)
            {
                if(pos == 53)
                {
                    GetComponent<MeshRenderer>().material.mainTexture = icons[0];
                    bridge_counter++;
                }
                if (aux < 45)
                {
                    GetComponent<MeshRenderer>().material.mainTexture = icons[0];
                    bridge_counter++;
                }
            }
            else if (pos == 55)
            {
                Die.Die_Instance.backward_button.SetActive(false);
                Die.Die_Instance.forward_button.SetActive(false);
                Turn.Turn_Instance.PassTurn_button.SetActive(true);
                posaux = true;

                if (GameController.endPlayers == 0)
                {
                    finishPoints = 7;
                    photonView.RPC("Change_Gccard", RpcTarget.AllViaServer, Random.Range(0, 6));
                    photonView.RPC("Change_endPlayers", RpcTarget.AllViaServer,1);
                    
                }
                else if (GameController.endPlayers == 1)
                {
                    finishPoints = 3;
                    photonView.RPC("Change_endPlayers", RpcTarget.AllViaServer,2);
                }
                else if (GameController.endPlayers == 2)
                {
                    finishPoints = 1;
                    photonView.RPC("Change_endPlayers", RpcTarget.AllViaServer,3);
                }
            }
            else
            {
                GetComponent<MeshRenderer>().material.mainTexture = icons[5];
            }
        }
    }

    void Update()
    {
        if ((PhotonNetwork.CurrentRoom.PlayerCount) >= 2 && GameController.endPlayers == (PhotonNetwork.CurrentRoom.PlayerCount) - 1)
        {
            if (GameController.RoundAmount == 2)
            {
                photonView.RPC("Change_Cardapp", RpcTarget.AllViaServer);
                photonView.RPC("Change_Spawn", RpcTarget.AllViaServer);

            }
            else 
            {
                Debug.Log("Buenas");
                Turn.Turn_Instance.Finish_button.SetActive(true);
                
            }
        }
    }

    [PunRPC]
    void Change_endPlayers(int number)
    {
        GameController.endPlayers = number;
    }

    [PunRPC]
    void Change_Gccard(int number)
    {
        GameController.GCcardNumber = number;
    }

    [PunRPC]
    void Change_turn()
    {
        
        GameController.turno++;
               
    }

    [PunRPC]
    void Change_Spawn()
    {

        posaux1++;

    }

    [PunRPC]
    void Change_Cardapp()
    {
        GetComponent<MeshRenderer>().material.mainTexture = GCicons[GameController.GCcardNumber];
    }

    public  void Change(){
        photonView.RPC("Change_turn",RpcTarget.AllViaServer);
        //Debug.Log(PhotonNetwork.PlayerList[GameController.turno]);
    }
    public void onPassturn(){
       Card.Instance.Change();
       Turn.Turn_Instance.PassTurn_button.SetActive(false);
       ReturnCard.ReturnCard_Instance.tool_button.SetActive(false);
       //Debug.Log(GameController.turno);
       for (int i = 0; i<PhotonNetwork.CurrentRoom.PlayerCount; i++){
           if(GameController.turno % PhotonNetwork.CurrentRoom.PlayerCount == 0 ){
               photonView.RPC("PassTurn", PhotonNetwork.PlayerList[0]);
           }
           else if(GameController.turno % PhotonNetwork.CurrentRoom.PlayerCount == 1 ){
               photonView.RPC("PassTurn", PhotonNetwork.PlayerList[1]);
           }
           else if(GameController.turno % PhotonNetwork.CurrentRoom.PlayerCount == 2 ){
               photonView.RPC("PassTurn", PhotonNetwork.PlayerList[2]);
           }
           else if(GameController.turno % PhotonNetwork.CurrentRoom.PlayerCount == 3){
               photonView.RPC("PassTurn", PhotonNetwork.PlayerList[3]);
           }
       }     
    }

    [PunRPC]
    void PassTurn(){
        if (posaux)
        {
            Turn.Turn_Instance.PassTurn_button.SetActive(true);
        }

        else
        {
            Die.Die_Instance.roll_button.SetActive(true);

            if (Card.Instance.bridge_counter > 0)
            {
                ReturnCard.ReturnCard_Instance.bridge_button.SetActive(true);
            }


        }
    }
    [PunRPC]
    void Changescene(){
        SceneManager.LoadScene("Winner");
        
        }

    public void Onfinish(){
        photonView.RPC("Changescene", RpcTarget.AllViaServer);
    }

    [PunRPC]
    void Winname(string name)
    {
        GameController.WinnerName = name;

    }

    [PunRPC]
    void maxPoint(int p)
    {
        GameController.maxPoints = p;

    }

    public void changeW(string name, int p)
    {
        photonView.RPC("Winname", RpcTarget.AllViaServer, name);
        photonView.RPC("maxPoint", RpcTarget.AllViaServer, p);
    }


}