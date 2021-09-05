using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MilestoneController : MonoBehaviour
{
    public static MilestoneController MilestoneController_Instance;

    void Awake()
    {
        if (MilestoneController_Instance == null)
        {
            MilestoneController_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void discards(GameObject[] milestone, GameObject workProductObject, int workProductID)
    {
        Progress.Progress_Instance.SubAmountDeveloped();

        for (int i = 0; i < Progress.Progress_Instance.getAllMilestones(); i++)
        {
            if (milestone[i].GetComponent<Milestone>().workProduct == workProductObject)
            {
                milestone[i].GetComponent<Milestone>().setMilestone(true, null, 0, null, "");
                milestone[i].GetComponent<Milestone>().DeleteMilestone();
                Completeness.Completeness_instance.Decrease(workProductID);
                workProductObject.GetComponent<WorkProduct>().setCheckDevelopment(false);
            }
        }
    }

}
