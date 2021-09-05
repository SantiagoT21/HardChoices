using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class WinnerController : MonoBehaviour
{
    [SerializeField] private Text Winner_name = null;
    [SerializeField] private int maxPoints = 0;
    [SerializeField] private Score verificar;
    public bool loadingStarted = false;
    public float secondsLeft = 0;

    void Start()
    {
        /*for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i ++)
        {
            verificar = GameController.Estructura.Dequeue();
            if (verificar.cardPoints > maxPoints)
            {
                Card.Instance.OnWin(verificar.Pname);
            }
            
        }*/
        Winner_name.text = GameController.WinnerName;
        StartCoroutine(DelayLoadLevel(15));
        
    }

    IEnumerator DelayLoadLevel(float seconds)
    {
        secondsLeft = seconds;
        loadingStarted = true;
        do
        {
            yield return new WaitForSeconds(1);
        } while (--secondsLeft > 0);
        SceneManager.LoadScene("Debrief session");
    }

    

}
