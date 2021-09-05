using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhaseNameVisualizationController : MonoBehaviourPun
{
    public GameObject phaseName;

    void Awake()
    {
        phaseName = GameObject.FindGameObjectWithTag("phaseName");
    }

    IEnumerator OnTriggerEnter2D(Collider2D phase)
    {
        if (photonView.IsMine == true)
        {
           if (phase.tag == "phase")
            {
                Phase.Phase_Instance.setEnableToAdvance(true);
                yield return new WaitForSeconds(1.5f);
                string nameAux = phase.ToString();
                string[] name = nameAux.Split(' ');
                Debug.Log(name[0][(name[0].Length)-1]);
                if (name[0].Contains("."))
                {
                    Completeness.Completeness_instance.PhasesmovementBack();
                }
                else
                {
                    Completeness.Completeness_instance.PhasesmovementAdvance();
                }

                StartCoroutine(phaseName.GetComponent<Phase>().ShowPhaseName(name[0]));
            }
        }
    }
}
