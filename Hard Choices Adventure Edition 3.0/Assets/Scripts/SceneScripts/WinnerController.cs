using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class WinnerController : MonoBehaviourPun
{
    [SerializeField] private Text Winner_name = null;
    [SerializeField] private int maxPoints = 0;
    public bool loadingStarted = false;
    public float secondsLeft = 0;

    void Start()
    {
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
        SceneManager.LoadScene("LogMenu");
    }

    

}
