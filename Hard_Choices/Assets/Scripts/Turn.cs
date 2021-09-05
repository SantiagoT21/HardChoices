using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Turn : MonoBehaviourPun
{
   public static Turn Turn_Instance;
   public PhotonView gameView;
   [SerializeField] public int current_turn=1;
   public  int turnito;   
   [SerializeField] public GameObject PassTurn_button;
   [SerializeField] public GameObject Finish_button;
    
    void Start(){
        gameView = this.GetComponent<PhotonView>();
    }




    public void Awake()
    {
        if (Turn_Instance == null)
        {
            Turn_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
       Turn_Instance.PassTurn_button.SetActive(false);
       Turn_Instance.Finish_button.SetActive(false);
    }

    public void onPassturn(){
       //photonView.RPC("PassTurn", PhotonTargets.Others);
    }
    [PunRPC]
    void PassTurn(){
        Die.Die_Instance.roll_button.SetActive(true);
    }


}
