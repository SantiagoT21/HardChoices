using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkProductController : MonoBehaviour
{

    public static WorkProductController WorkProductController_Instance; 
    void Awake()
    {
        if (WorkProductController_Instance == null)
        {
            WorkProductController_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void LaysAside(GameObject[] milestone, GameObject workProductObject, int workProductID)
    {
        Progress.Progress_Instance.AddWorkProductsLaysAside();
        workProductObject.SetActive(true);
        MilestoneController.MilestoneController_Instance.discards(milestone, workProductObject, workProductID);
    }

    public void develops(GameObject workProductObject, int workProductID, string workProductDescription, Sprite workProductIcon, GameObject[] milestone)
    {
        for (int i = 0; i < Progress.Progress_Instance.getAllMilestones(); i++)
        {
            if (Progress.Progress_Instance.milestone[i].GetComponent<Milestone>().getEmpty())
            {

                if (workProductObject.GetComponent<WorkProduct>().getCheckDevelopment() == false)
                {
                    Completeness.Completeness_instance.Increase(workProductID);
                    Progress.Progress_Instance.AddAmountDeveloped();
                    ConsistencyError.ConsistencyError_Instance.Check();
                    workProductObject.GetComponent<WorkProduct>().setDeveloping(true);
                    workProductObject.GetComponent<WorkProduct>().setCheckDevelopment(true);
                    milestone[i].GetComponent<Milestone>().setMilestone(false, workProductObject, workProductID, workProductDescription, workProductIcon, "");
                    workProductObject.SetActive(false);
                    Progress.Progress_Instance.milestone[i].GetComponent<Milestone>().UpdateMilestone();

                    return;
                }

            }

        }
    }
}
