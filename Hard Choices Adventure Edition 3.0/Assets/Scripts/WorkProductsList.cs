using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkProductsList : MonoBehaviour
{
    public static WorkProductsList WorkProductsList_Instance;
    [SerializeField] public GameObject[] phase1;
    [SerializeField] public GameObject[] phase2;
    [SerializeField] public GameObject[] phase3;
    [SerializeField] public GameObject[] phase4;
    [SerializeField] public GameObject[] analysts;

    void Awake()
    {
        if (WorkProductsList_Instance == null)
        {
            WorkProductsList_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        foreach (GameObject workProduct in WorkProductsList.WorkProductsList_Instance.phase1)
        {
            workProduct.SetActive(false);
        }

        foreach (GameObject workProduct in WorkProductsList.WorkProductsList_Instance.phase2)
        {
            workProduct.SetActive(false);
        }

        foreach (GameObject workProduct in WorkProductsList.WorkProductsList_Instance.phase3)
        {
            workProduct.SetActive(false);
        }

        foreach (GameObject workProduct in WorkProductsList.WorkProductsList_Instance.phase4)
        {
            workProduct.SetActive(false);
        }

        foreach (GameObject workProduct in WorkProductsList.WorkProductsList_Instance.analysts)
        {
            workProduct.SetActive(false);
        }
    }
}
