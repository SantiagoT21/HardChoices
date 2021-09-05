using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class UNCMethodController : MonoBehaviourPun
{
    private bool UNCMethodEnabled;

    void Update()
    {
        if (photonView.IsMine == true)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                UNCMethodEnabled = !UNCMethodEnabled;
            }
            if (UNCMethodEnabled)
            {
                UNCMethod.UNCMethod_Instance.enableVisualization();
            }
            else
            {
                UNCMethod.UNCMethod_Instance.disableVisualization();
            }
        }
    }

    
}
