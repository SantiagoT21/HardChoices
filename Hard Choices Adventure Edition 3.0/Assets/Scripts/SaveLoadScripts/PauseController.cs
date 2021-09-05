using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PauseController : MonoBehaviourPun
{

    void Update()
    {
            if (Input.GetKeyDown(KeyCode.P))
            {
                PauseAvaliable();
            }
            if (Pause.Pause_Instance.aux)
            {
                PauseUnavaliable();
                Pause.Pause_Instance.aux = false;
            }
            if (Pause.Pause_Instance.aux1)
            {
                PauseAvaliable();
                Pause.Pause_Instance.aux1 = false;
            }
            if (GameController.PauseEnabled)
                {
                    transform.GetComponent<Animator>().enabled = false;
                    transform.GetComponent<SoftwareEngineeringStudent>().enabled = false;

                    Pause.Pause_Instance.enableVisualization();

            }
            else
            {
                transform.GetComponent<Animator>().enabled = true;
                transform.GetComponent<SoftwareEngineeringStudent>().enabled = true;

                Pause.Pause_Instance.disableVisualization();
        }
    }


    [PunRPC]
    void PauseAvaliableSet()
    {
        GameController.PauseEnabled = true;
    }

    public void PauseAvaliable()
    {
        photonView.RPC("PauseAvaliableSet", RpcTarget.AllViaServer);
    }

    [PunRPC]
    void PauseUnavaliableSet()
    {
        GameController.PauseEnabled = false;
    }

    public void PauseUnavaliable()
    {
        photonView.RPC("PauseUnavaliableSet", RpcTarget.AllViaServer);
    }
}
