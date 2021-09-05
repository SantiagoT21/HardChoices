using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ProgressController : MonoBehaviourPun
{
    private bool progressEnabled;

    private int enabledMilestone;

    void Start()
    {
        Progress.Progress_Instance.setAllMilestones(Progress.Progress_Instance.milestoneHolder.transform.childCount);
        Progress.Progress_Instance.milestone = new GameObject[Progress.Progress_Instance.getAllMilestones()];

        for (int i = 0; i < Progress.Progress_Instance.getAllMilestones(); i++)
        {
            Progress.Progress_Instance.milestone[i] = Progress.Progress_Instance.milestoneHolder.transform.GetChild(i).gameObject;

            if (Progress.Progress_Instance.milestone[i].GetComponent<Milestone>().workProduct == null)
            {
                Progress.Progress_Instance.milestone[i].GetComponent<Milestone>().setEmpty(true);
            }
        }
        Completeness.Completeness_instance.RanPlenitud();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            progressEnabled = !progressEnabled;
        }
        if (progressEnabled)
        {
            Progress.Progress_Instance.enableVisualization();
        }
        else
        {
            Progress.Progress_Instance.disableVisualization();
        }

        
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (photonView.IsMine == true) {
            if (other.tag == "Item")
            {
                GameObject workProductPickedUp = other.gameObject;

                WorkProduct workProduct = workProductPickedUp.GetComponent<WorkProduct>();

                for (int i = 0; i < Progress.Progress_Instance.getAllMilestones(); i++)
                {
                    if (Progress.Progress_Instance.milestone[i].GetComponent<Milestone>().workProduct != workProduct)
                    {
                        WorkProductController.WorkProductController_Instance.develops(workProductPickedUp, workProduct.getID(), workProduct.getDescription(), workProduct.icon, Progress.Progress_Instance.milestone);
                        break;
                    }                    
                }

            }

            if (Completeness.Completeness_instance.getAmountCompleteness() > GameController.maxCompleteness)
            {
                Completeness.Completeness_instance.changeW(Completeness.Completeness_instance.getPname(), Completeness.Completeness_instance.getAmountCompleteness());
            }
        }        
    }
    


}
