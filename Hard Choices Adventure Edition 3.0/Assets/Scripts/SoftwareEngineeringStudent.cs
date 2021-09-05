using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SoftwareEngineeringStudent : MonoBehaviourPun
{

    private float speed = 0.75f;
    private float DevelopsSpeed = 0.75f;
    public TextMesh identifier = null;
    private string currentPhase = "Software Context";
    private bool developing = false;

    Animator animation_;
    Rigidbody2D rb2d;
    Vector2 mov;

    // Start is called before the first frame update
    void Start()
    {
        developing = true;
        speed = 0.75f;
        DevelopsSpeed = 0.75f;
        for(int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).name == "Caption_Text")
            {
                identifier = this.transform.GetChild(i).gameObject.GetComponent<TextMesh>();
                identifier.text = string.Format("Software_Engineering_Student_{0}", photonView.ViewID);
                Completeness.Completeness_instance.setPname(identifier.text);
            }
        }
        animation_ = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine == true)
        {
            mov = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );

            UNCMethod.UNCMethod_Instance.applies(mov, animation_);
            currentPhase = Phase.Phase_Instance.getName();

        }
        if (Pause.Pause_Instance.LoadPosition)
        {
            LoadGameInformation();
            Pause.Pause_Instance.LoadPosition = false;
        }
        if (Pause.Pause_Instance.SavePosition)
        {
            SaveLoadController.SaveLoadController_instance.SaveGameplayInformation(this.transform.position, DevelopsSpeed, identifier.text);
            Pause.Pause_Instance.SavePosition = false;
        }
        if (Pause.Pause_Instance.SaveData)
        {
            SaveGameplayData();
            Pause.Pause_Instance.SaveData = false;
        }
        if (Pause.Pause_Instance.NextResume)
        {
            LoadGameplayData();
            Pause.Pause_Instance.NextResume = false;
        }


    }

    void FixedUpdate()
    {
        if (Completeness.Completeness_instance.getAux() == 0)
        {
            DevelopsSpeed = speed * Completeness.Completeness_instance.getSpeed_mul();
            Completeness.Completeness_instance.setAux(1);
        }
        
        rb2d.MovePosition(rb2d.position + mov * DevelopsSpeed * Time.deltaTime);
    }

    public void LoadGameInformation()
    {


        //Debug.Log("GameplayInformation" + Completeness.Completeness_instance.Pname + ".txt");

        SaveLoadController.SaveLoadController_instance.LoadGameplayInformation();

        //Debug.Log(SaveLoadController.SaveLoadController_instance.movx1);
        
        float PosX = float.Parse(SaveLoadController.SaveLoadController_instance.movx1);
        float PosY = float.Parse(SaveLoadController.SaveLoadController_instance.movy1);
        transform.position = new Vector3(PosX, PosY, 0);
        Completeness.Completeness_instance.setAmountCompleteness(int.Parse(SaveLoadController.SaveLoadController_instance.completeness1));
        Consistency.Consistency_Instance.setNumberOfSolvedErrors(int.Parse(SaveLoadController.SaveLoadController_instance.consistencyErrorsNumber1));
        Consistency.Consistency_Instance.setProbabilityOfGettingError(int.Parse(SaveLoadController.SaveLoadController_instance.ProbabilityOfConsistencyError1));
        Progress.Progress_Instance.setAmountDeveloped(int.Parse(SaveLoadController.SaveLoadController_instance.numberOfWorkProductsStartedtoDevelop1));
        Progress.Progress_Instance.setWorkProductsLaysAside(int.Parse(SaveLoadController.SaveLoadController_instance.numberOfWorkProductsLaysAside1));
        identifier.text = SaveLoadController.SaveLoadController_instance.identifier1;
        DevelopsSpeed = float.Parse(SaveLoadController.SaveLoadController_instance.DevelopsSpeed1);

        //productos de trabajo desarrollados 
        ;
        string workProductPickedUpAux = SaveLoadController.SaveLoadController_instance.workProductPickedUp1;
        string[] workProductPickedUpList = workProductPickedUpAux.Split('_');

            //productos de trabajo habilitados para desarrollar 

            string workProductEnabledToDevelopAux = SaveLoadController.SaveLoadController_instance.workProductEnabledToDevelop1;
        string[] workProductEnabledToDevelopList = workProductEnabledToDevelopAux.Split('_');

        foreach (GameObject workProduct in WorkProductsList.WorkProductsList_Instance.phase1)
        {
            GameObject it = workProduct.gameObject;
            WorkProduct workProductAux = it.GetComponent<WorkProduct>();
            for(int i = 0; i< workProductEnabledToDevelopList.Length; i++)
            {
                int aux = 0;
                if(int.TryParse(workProductEnabledToDevelopList[i], out aux)){
                    if (workProductAux.getID() == int.Parse(workProductEnabledToDevelopList[i]))
                    {
                        workProduct.SetActive(true);
                    }
                }
            }

            for (int i = 0; i < workProductPickedUpList.Length; i++)
            {
                int aux = 0;
                if (int.TryParse(workProductPickedUpList[i], out aux))
                {
                    if(workProductAux.getID() == int.Parse(workProductPickedUpList[i]))
                    {
                        for (int j = 0; j < Progress.Progress_Instance.getAllMilestones(); i++)
                        {
                            if (Progress.Progress_Instance.milestone[j].GetComponent<Milestone>().workProduct != workProductAux)
                            {
                                AddWorkProduct(it, workProductAux.getID(), workProductAux.getDescription(), workProductAux.icon);
                                break;
                            }

                        }
                    }
                }                  
            }
        }

        foreach (GameObject workProduct in WorkProductsList.WorkProductsList_Instance.phase2)
        {
            GameObject it = workProduct.gameObject;
            WorkProduct workProductAux = it.GetComponent<WorkProduct>();
            for (int i = 0; i < workProductEnabledToDevelopList.Length; i++)
            {
                int aux = 0;
                if (int.TryParse(workProductEnabledToDevelopList[i], out aux))
                {
                    if (workProductAux.getID() == int.Parse(workProductEnabledToDevelopList[i]))
                    {
                        workProduct.SetActive(true);
                    }
                }
            }

            for (int i = 0; i < workProductPickedUpList.Length; i++)
            {
                int aux = 0;
                if (int.TryParse(workProductPickedUpList[i], out aux))
                {
                    if (workProductAux.getID() == int.Parse(workProductPickedUpList[i]))
                    {
                        for (int j = 0; j < Progress.Progress_Instance.getAllMilestones(); i++)
                        {
                            if (Progress.Progress_Instance.milestone[j].GetComponent<Milestone>().workProduct != workProductAux)
                            {
                                AddWorkProduct(it, workProductAux.getID(), workProductAux.getDescription(), workProductAux.icon);
                                break;
                            }

                        }
                    }
                }
            }
        }

        foreach (GameObject workProduct in WorkProductsList.WorkProductsList_Instance.phase3)
        {
            GameObject it = workProduct.gameObject;
            WorkProduct workProductAux = it.GetComponent<WorkProduct>();
            for (int i = 0; i < workProductEnabledToDevelopList.Length; i++)
            {
                int aux = 0;
                if (int.TryParse(workProductEnabledToDevelopList[i], out aux))
                {
                    if (workProductAux.getID() == int.Parse(workProductEnabledToDevelopList[i]))
                    {
                        workProduct.SetActive(true);
                    }
                }
            }

            for (int i = 0; i < workProductPickedUpList.Length; i++)
            {
                int aux = 0;
                if (int.TryParse(workProductPickedUpList[i], out aux))
                {
                    if (workProductAux.getID() == int.Parse(workProductPickedUpList[i]))
                    {
                        for (int j = 0; j < Progress.Progress_Instance.getAllMilestones(); i++)
                        {
                            if (Progress.Progress_Instance.milestone[j].GetComponent<Milestone>().workProduct != workProductAux)
                            {
                                AddWorkProduct(it, workProductAux.getID(), workProductAux.getDescription(), workProductAux.icon);
                                break;
                            }

                        }
                    }
                }
            }
        }

        foreach (GameObject workProduct in WorkProductsList.WorkProductsList_Instance.phase4)
        {
            GameObject it = workProduct.gameObject;
            WorkProduct workProductAux = it.GetComponent<WorkProduct>();
            for (int i = 0; i < workProductEnabledToDevelopList.Length; i++)
            {
                int aux = 0;
                if (int.TryParse(workProductEnabledToDevelopList[i], out aux))
                {
                    if (workProductAux.getID() == int.Parse(workProductEnabledToDevelopList[i]))
                    {
                        workProduct.SetActive(true);
                    }
                }
            }

            for (int i = 0; i < workProductPickedUpList.Length; i++)
            {
                int aux = 0;
                if (int.TryParse(workProductPickedUpList[i], out aux))
                {
                    if (workProductAux.getID() == int.Parse(workProductPickedUpList[i]))
                    {
                        for (int j = 0; j < Progress.Progress_Instance.getAllMilestones(); i++)
                        {
                            if (Progress.Progress_Instance.milestone[j].GetComponent<Milestone>().workProduct != workProductAux)
                            {
                                AddWorkProduct(it, workProductAux.getID(), workProductAux.getDescription(), workProductAux.icon);
                                break;
                            }

                        }
                    }
                }
            }

            foreach (GameObject analyst in WorkProductsList.WorkProductsList_Instance.analysts)
            {
                analyst.SetActive(true);
            }

        }


    }


    public void AddWorkProduct(GameObject workProductObject, int workProductID, string workProductDescription, Sprite workProductIcon)
    {
        for (int i = 0; i < Progress.Progress_Instance.getAllMilestones(); i++)
        {
            if (Progress.Progress_Instance.milestone[i].GetComponent<Milestone>().getEmpty())
            {

                if (workProductObject.GetComponent<WorkProduct>().getCheckDevelopment() == false)
                {
                    workProductObject.GetComponent<WorkProduct>().setDeveloping(true);
                    workProductObject.GetComponent<WorkProduct>().setCheckDevelopment(true);
                    Progress.Progress_Instance.milestone[i].GetComponent<Milestone>().workProduct = workProductObject;
                    Progress.Progress_Instance.milestone[i].GetComponent<Milestone>().setID(workProductID);
                    Progress.Progress_Instance.milestone[i].GetComponent<Milestone>().setDescription(workProductDescription);
                    Progress.Progress_Instance.milestone[i].GetComponent<Milestone>().icon = workProductIcon;


                    Progress.Progress_Instance.milestone[i].GetComponent<Milestone>().UpdateMilestone();


                    Progress.Progress_Instance.milestone[i].GetComponent<Milestone>().setEmpty(false);
                    return;
                }

            }

        }
    }



    public void SaveGameplayData()
    {
        //se guardan los datos de la partida finalizada        
        SaveSystem.SaveGameplay(this.transform.position, DevelopsSpeed, identifier.text);
    }

    public void LoadGameplayData()
    {
        //se guardan los datos de la partida finalizada


        if (Pause.Pause_Instance.HistoryLastVersion > 0)
        {
            GlobalData data = SaveSystem.LoadGameplay(Pause.Pause_Instance.HistoryLastVersion, this.transform.position, DevelopsSpeed, identifier.text);

            if (data == null)
            {
                Debug.Log("Intenta de nuevo");
            }
            else
            {
                Summary.Summary_Instance.space1.text = "" + data.StudentsWhoHavePlayed;
                Summary.Summary_Instance.space2.text = "" + data.Phasesmovements;
                Summary.Summary_Instance.identifierText.text = "" + data.IncompletenessRatio;
                Summary.Summary_Instance.completenessText.text = "" + data.RequirementListTime + " milliseconds";
                Summary.Summary_Instance.consistencyErrorsNumberText.text = "" + data.InstructionsListTime + " milliseconds";
                Summary.Summary_Instance.ProbabilityOfConsistencyErrorText.text = "" + data.WorkProducts;
                Summary.Summary_Instance.numberOfWorkProductsLaysAsideText.text = "" + data.SoftwareSystemReceivedRatio;
                Summary.Summary_Instance.WinnerIDText.text = data.SoftwareEngineeringStudentCreationDate;
            }            
        }
        else
        {
            Debug.Log(Pause.Pause_Instance.HistoryLastVersion);
        }
            
            
        //Debug.Log(data.movx);
       // Debug.Log(movy1);
        //Debug.Log(identifier1);
       // Debug.Log(DevelopsSpeed1);
        //Debug.Log(Resume.Resume_Instance.completenessText.text);
        /*Debug.Log(consistencyErrorsNumber1);
        Debug.Log(ProbabilityOfConsistencyError1);
        Debug.Log(winner);
        Debug.Log(numberOfWorkProductsStartedtoDevelop1);
        Debug.Log(numberOfWorkProductsLaysAside1);
        Debug.Log(workProductPickedUp1);
        Debug.Log(workProductEnabledToDevelop1);
        */
        
    }
}
