using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

using BayatGames.SaveGameFree;

public class SaveLoadController : MonoBehaviourPun
{

    public static SaveLoadController SaveLoadController_instance;

    public string identifier;
    public int completeness;
    public int consistencyErrorsNumber;
    public int ProbabilityOfConsistencyError;
    public int numberOfWorkProductsStartedtoDevelop;
    public int numberOfWorkProductsLaysAside;
    public string workProductPickedUp;
    public string workProductEnabledToDevelop;
    public float movx;
    public float movy;
    public string WinnerID;
    public float DevelopsSpeed;

    public string identifier1;
    public string DevelopsSpeed1;
    public string movx1;
    public string movy1;
    public string completeness1;
    public string consistencyErrorsNumber1;
    public string ProbabilityOfConsistencyError1;
    public string winner;
    public string numberOfWorkProductsStartedtoDevelop1;
    public string numberOfWorkProductsLaysAside1;
    public string workProductPickedUp1;
    public string workProductEnabledToDevelop1;


    void Awake()
    {
        if (SaveLoadController_instance == null)
        {
            SaveLoadController_instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //LoadGameplayInformation();
        //identifier = Completeness.Completeness_instance.Pname;
    }


    public void SaveGameplayInformation(Vector2 mov, float DevelopsSpeed, string identifier)
    {
        SaveLoadController.SaveLoadController_instance.identifier = identifier;
        SaveLoadController.SaveLoadController_instance.DevelopsSpeed = DevelopsSpeed;
        SaveLoadController.SaveLoadController_instance.completeness = Completeness.Completeness_instance.getAmountCompleteness();
        SaveLoadController.SaveLoadController_instance.consistencyErrorsNumber = Consistency.Consistency_Instance.getNumberOfSolvedErrors();
        SaveLoadController.SaveLoadController_instance.ProbabilityOfConsistencyError = Consistency.Consistency_Instance.getProbabilityOfGettingError();
        SaveLoadController.SaveLoadController_instance.numberOfWorkProductsStartedtoDevelop = Progress.Progress_Instance.getAmountDeveloped();
        SaveLoadController.SaveLoadController_instance.numberOfWorkProductsLaysAside = Progress.Progress_Instance.getWorkProductsLaysAside();
        SaveLoadController.SaveLoadController_instance.workProductPickedUp = "";
        SaveLoadController.SaveLoadController_instance.workProductEnabledToDevelop = "";
        SaveLoadController.SaveLoadController_instance.movx = mov.x;
        SaveLoadController.SaveLoadController_instance.movy = mov.y;
        SaveLoadController.SaveLoadController_instance.WinnerID = GameController.WinnerName;

        




        foreach (GameObject workProduct in WorkProductsList.WorkProductsList_Instance.phase1)
        {
            GameObject it = workProduct.gameObject;
            WorkProduct workProductAux = it.GetComponent<WorkProduct>();

            if (workProductAux.getDeveloping() == true && workProductAux.getCheckDevelopment() == true)
            {
                workProductPickedUp = workProductPickedUp + "_" + workProductAux.getID();
                
            }
            if (workProduct.activeSelf == true)
            {
                workProductEnabledToDevelop = workProductEnabledToDevelop + "_" + workProductAux.getID();
            }
        }
        foreach (GameObject workProduct in WorkProductsList.WorkProductsList_Instance.phase2)
        {
            GameObject it = workProduct.gameObject;
            WorkProduct workProductAux = it.GetComponent<WorkProduct>();

            if (workProductAux.getDeveloping() == true && workProductAux.getCheckDevelopment() == true)
            {
                workProductPickedUp = workProductPickedUp + "_" + workProductAux.getID();
                
            }
            if (workProduct.activeSelf == true)
            {
                workProductEnabledToDevelop = workProductEnabledToDevelop + "_" + workProductAux.getID();
            }
        }
        foreach (GameObject workProduct in WorkProductsList.WorkProductsList_Instance.phase3)
        {
            GameObject it = workProduct.gameObject;
            WorkProduct workProductAux = it.GetComponent<WorkProduct>();

            if (workProductAux.getDeveloping() == true && workProductAux.getCheckDevelopment() == true)
            {
                workProductPickedUp = workProductPickedUp + "_" + workProductAux.getID();
                
            }
            if (workProduct.activeSelf == true)
            {
                workProductEnabledToDevelop = workProductEnabledToDevelop + "_" + workProductAux.getID();
            }
        }
        foreach (GameObject workProduct in WorkProductsList.WorkProductsList_Instance.phase4)
        {
            GameObject it = workProduct.gameObject;
            WorkProduct workProductAux = it.GetComponent<WorkProduct>();

            if (workProductAux.getDeveloping() == true && workProductAux.getCheckDevelopment() == true)
            {
                workProductPickedUp = workProductPickedUp + "_" + workProductAux.getID();
                
            }
            if (workProduct.activeSelf == true)
            {
                workProductEnabledToDevelop = workProductEnabledToDevelop + "_" + workProductAux.getID();
            }
        }


        //La información a guardar es: 

        SaveGame.Save<string>("GameplayInformation" + identifier+".txt", identifier); //identificador
        SaveGame.Save<string>("GameplayInformation1" + identifier + ".txt", "" + DevelopsSpeed); //velocidad para desarrollar 
        SaveGame.Save<string>("GameplayInformation2" + identifier + ".txt", "" + movx);// posicion en x
        SaveGame.Save<string>("GameplayInformation3" + identifier + ".txt", "" + movy); // posicion en y
        SaveGame.Save<string>("GameplayInformation4" + identifier + ".txt", "" + completeness); // (plenitud)
        SaveGame.Save<string>("GameplayInformation5" + identifier + ".txt", "" + consistencyErrorsNumber); // Cantidad de errores de consistencia
        SaveGame.Save<string>("GameplayInformation6" + identifier + ".txt", "" + ProbabilityOfConsistencyError); // la probabilidad de error de consistencia
        SaveGame.Save<string>("GameplayInformation7" + identifier + ".txt", "" + WinnerID); //identificador del ganador de la partida
        SaveGame.Save<string>("GameplayInformation8" + identifier + ".txt", "" + numberOfWorkProductsStartedtoDevelop); // La cantidad de productos de trabajo que se comenzaron a desarrollados 
        SaveGame.Save<string>("GameplayInformation9" + identifier + ".txt", "" + numberOfWorkProductsLaysAside); // La cantidad de productos de trabajo que se comenzaron a desarrollar pero los dejaron a un lado
        SaveGame.Save<string>("GameplayInformation10" + identifier + ".txt", "" + workProductPickedUp); // los productos de trabajo que sae han desarrollado\
        SaveGame.Save<string>("GameplayInformation11" + identifier + ".txt", "" + workProductEnabledToDevelop); // los productos de trabajo que estan habilitados para desarrollar
    }


    

    public void LoadGameplayInformation()
    {

       // Debug.Log("GameplayInformation" + SaveLoadController.SaveLoadController_instance.identifier + ".txt");

        SaveLoadController.SaveLoadController_instance.identifier1 =  SaveGame.Load<string>("GameplayInformation" + Completeness.Completeness_instance.getPname() + ".txt", "identifier"); //identificador
        SaveLoadController.SaveLoadController_instance.DevelopsSpeed1 =  SaveGame.Load<string>("GameplayInformation1" + Completeness.Completeness_instance.getPname() + ".txt", "DevelopsSpeed"); //velocidad para desarrollar 
        SaveLoadController.SaveLoadController_instance.movx1 =  SaveGame.Load<string>("GameplayInformation2" + Completeness.Completeness_instance.getPname() + ".txt", "movx");// posicion en x
        SaveLoadController.SaveLoadController_instance.movy1 =  SaveGame.Load<string>("GameplayInformation3" + Completeness.Completeness_instance.getPname() + ".txt", "movy"); // posicion en y
        SaveLoadController.SaveLoadController_instance.completeness1 =  SaveGame.Load<string>("GameplayInformation4" + Completeness.Completeness_instance.getPname() + ".txt", "completeness"); // (plenitud)
        SaveLoadController.SaveLoadController_instance.consistencyErrorsNumber1 =  SaveGame.Load<string>("GameplayInformation5" + Completeness.Completeness_instance.getPname() + ".txt", "consistencyErrorsNumber"); // Cantidad de errores de consistencia
        SaveLoadController.SaveLoadController_instance.ProbabilityOfConsistencyError1 =  SaveGame.Load<string>("GameplayInformation6" + Completeness.Completeness_instance.getPname() + ".txt", "ProbabilityOfConsistencyError"); // la probabilidad de error de consistencia
        SaveLoadController.SaveLoadController_instance.winner = SaveGame.Load<string>("GameplayInformation7" + Completeness.Completeness_instance.getPname() + ".txt", "WinnerID"); //identificador del ganador de la partida
        SaveLoadController.SaveLoadController_instance.numberOfWorkProductsStartedtoDevelop1 =  SaveGame.Load<string>("GameplayInformation8" + Completeness.Completeness_instance.getPname() + ".txt", "numberOfWorkProductsStartedtoDevelop"); // La cantidad de productos de trabajo que se comenzaron a desarrollados 
        SaveLoadController.SaveLoadController_instance.numberOfWorkProductsLaysAside1 =  SaveGame.Load<string>("GameplayInformation9" + Completeness.Completeness_instance.getPname() + ".txt", "numberOfWorkProductsLaysAside"); // La cantidad de productos de trabajo que se comenzaron a desarrollar pero los dejaron a un lado
        SaveLoadController.SaveLoadController_instance.workProductPickedUp1 =  SaveGame.Load<string>("GameplayInformation10" + Completeness.Completeness_instance.getPname() + ".txt", "workProductPickedUp"); // los productos de trabajo que se han desarrollado
        SaveLoadController.SaveLoadController_instance.workProductEnabledToDevelop1 = SaveGame.Load<string>("GameplayInformation11" + Completeness.Completeness_instance.getPname() + ".txt", "workProductEnabledToDevelop"); // los productos de trabajo que estan habilitados para desarrollar


        /*
        Debug.Log(movx1);
        Debug.Log(movy1);
        Debug.Log(identifier1);
        Debug.Log(DevelopsSpeed1);
        Debug.Log(completeness1);
        Debug.Log(consistencyErrorsNumber1);
        Debug.Log(ProbabilityOfConsistencyError1);
        Debug.Log(winner);
        Debug.Log(numberOfWorkProductsStartedtoDevelop1);
        Debug.Log(numberOfWorkProductsLaysAside1);
        Debug.Log(workProductPickedUp1);
        Debug.Log(workProductEnabledToDevelop1);
        */

    }
}
