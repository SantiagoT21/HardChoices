using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GCCard : MonoBehaviourPun
{
    public static GCCard Instance;
    public Texture2D[] GCicons;
    public bool loadingStarted = false;
    public float secondsLeft = 0;

    public void Awake()
    {

        //GameController.GCcardNumber = Random.Range(0, 6);

        GetComponent<MeshRenderer>().material.mainTexture = GCicons[GameController.GCcardNumber];
        StartCoroutine(DelayLoadLevel(5));


        IEnumerator DelayLoadLevel(float seconds)
        {
            secondsLeft = seconds;
            loadingStarted = true;
            do
            {
                yield return new WaitForSeconds(1);
            } while (--secondsLeft > 0);

            SceneManager.LoadScene("Game");
            GameController.endPlayers = 0;
        }

    }

}