using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class Pause : MonoBehaviour
{
    public static Pause Pause_Instance;

    [SerializeField] public GameObject RawImage;
    [SerializeField] public GameObject ButtonExit;
    [SerializeField] public GameObject ButtonSave;
    [SerializeField] public GameObject ButtonLoad;
    [SerializeField] public GameObject ButtonHistory;
    [SerializeField] public GameObject textPause;
    [SerializeField] public GameObject RawImage1;
    [SerializeField] public GameObject ButtonResume;
    [SerializeField] public GameObject XButton;

    public bool aux = false;
    public bool aux1 = false;
    public bool LoadPosition = false;
    public bool SavePosition = false;
    public bool resumeAux = false;
    public bool HistoryAux = false;
    public bool SaveData = false;
    public bool NextResume = false;
    public bool History = false;
    public int HistoryLastVersion = -1;



    void Awake()
    {
        if (Pause_Instance == null)
        {
            Pause_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        disableVisualization();
    }

    public void enableVisualization()
    {
        Pause.Pause_Instance.RawImage.SetActive(true);
        Pause.Pause_Instance.ButtonExit.SetActive(true);
        Pause.Pause_Instance.ButtonSave.SetActive(true);
        Pause.Pause_Instance.ButtonLoad.SetActive(true);
        Pause.Pause_Instance.ButtonHistory.SetActive(true);
        Pause.Pause_Instance.textPause.SetActive(true);
        Pause.Pause_Instance.RawImage1.SetActive(true);
        Pause.Pause_Instance.ButtonResume.SetActive(true);
        Pause.Pause_Instance.ButtonHistory.SetActive(true);
        Pause.Pause_Instance.XButton.SetActive(true);
    }

    public void disableVisualization()
    {
        Pause.Pause_Instance.RawImage.SetActive(false);
        Pause.Pause_Instance.ButtonExit.SetActive(false);
        Pause.Pause_Instance.ButtonSave.SetActive(false);
        Pause.Pause_Instance.ButtonLoad.SetActive(false);
        Pause.Pause_Instance.ButtonHistory.SetActive(false);
        Pause.Pause_Instance.textPause.SetActive(false);
        Pause.Pause_Instance.RawImage1.SetActive(false);
        Pause.Pause_Instance.ButtonResume.SetActive(false);
        Pause.Pause_Instance.ButtonHistory.SetActive(false);
        Pause.Pause_Instance.XButton.SetActive(false);
    }


    public void OnButtonExitPauseMenu()
    {
        aux = true;
        Summary.Summary_Instance.disableVisualization();
    }
    public void OnButtonLoadGameplay()
    {
        //SaveLoadController.SaveLoadController_instance.LoadGameplayInformation();
        LoadPosition = true;
        Debug.Log("Se pudo cargar la información de el ultimo punto de guardado del juego");
    }
    public void OnButtonSaveGameplay()
    {
        SavePosition = true;
        Debug.Log("Se pudo guardar la información de el ultimo punto del juego");
        //SaveData = true;
    }
    public void OnButtonExit()
    {
        SavePosition = true;
        SaveData = true;
        Debug.Log("Se pudo guardar la información de la partida finalizada");
        aux1 = true;
        Application.Quit();
    }

    public void OnNextResume()
    {
        Debug.Log(HistoryLastVersion);
        History = true;
        if (HistoryLastVersion == -1)
        {
            HistoryLastVersion = SaveSystem.version;
            //NextResume = true;
        }
        else
        {
            int auxLastversion = HistoryLastVersion - 1;
            Debug.Log("Cierra el menu de pausa y vuelve a abrir para visualizar la historia de la partida finalizada numero "+ auxLastversion);
            if (HistoryLastVersion == 0)
            {
                HistoryLastVersion = SaveSystem.version;
            }
            else
            {
                NextResume = true;
                HistoryLastVersion--;
                Debug.Log("Se pudo cargar la información de las partidas finalizadas");
            }
            
        }
        
    }

    public void OnButtonHistory()
    {
        if (!History)
        {
            HistoryLastVersion = int.Parse(SaveGame.Load<string>("LastVersion.txt", "version"));
            HistoryLastVersion++;
            Debug.Log(HistoryLastVersion + " este");
        }
        Summary.Summary_Instance.TittleText.text = "KPI";
        HistoryAux = !HistoryAux;
        if(HistoryAux)
        {
            Summary.Summary_Instance.Tittle1.text = "Students Who Have Played:";
            Summary.Summary_Instance.Tittle2.text = "Retreats Phases Ratio";
            Summary.Summary_Instance.Tittle3.text = "Incompleteness Ratio";
            Summary.Summary_Instance.Tittle4.text = "Requirement List Ratio";
            Summary.Summary_Instance.Tittle5.text = "Instructions List Time";
            Summary.Summary_Instance.Tittle6.text = "WorkProduct Ratio";
            Summary.Summary_Instance.Tittle7.text = "Software System Received Ratio";
            Summary.Summary_Instance.Tittle8.text = "Date";


           /* Summary.Summary_Instance.space1.text = "" + data.StudentsWhoHavePlayed;
            Summary.Summary_Instance.space2.text = "" + data.Phasesmovements;
            Summary.Summary_Instance.identifierText.text = "" + data.IncompletenessRatio;
            Summary.Summary_Instance.completenessText.text = "" + data.RequirementListTime;
            Summary.Summary_Instance.consistencyErrorsNumberText.text = "" + data.InstructionsListTime;
            Summary.Summary_Instance.ProbabilityOfConsistencyErrorText.text = "" + data.WorkProducts;
            Summary.Summary_Instance.numberOfWorkProductsLaysAsideText.text = "" + data.SoftwareSystemReceivedRatio;
            Summary.Summary_Instance.WinnerIDText.text = data.SoftwareEngineeringStudentCreationDate;
           */
            Summary.Summary_Instance.enableVisualization();
        }
        else
        {
            Summary.Summary_Instance.disableVisualization();
        }
    }

    public void OnButtonSummary()
    {
        Summary.Summary_Instance.TittleText.text = "SUMMARY";
        resumeAux = !resumeAux;
        if (resumeAux)
        {
            //asignar aca los valores de cada uno

            Summary.Summary_Instance.Tittle1.text = "";
            Summary.Summary_Instance.Tittle2.text = "";
            Summary.Summary_Instance.Tittle3.text = "IDENTIFIER";
            Summary.Summary_Instance.Tittle4.text = "COMPLETENESS";
            Summary.Summary_Instance.Tittle5.text = "TOTAL OF CONSISTENCY ERRORS";
            Summary.Summary_Instance.Tittle6.text = "PROBABILITY OF GETTING A CONSISTENCY ERROR";
            Summary.Summary_Instance.Tittle7.text = "TOTAL OF WORK PRODUCTS SET ASIDE";
            Summary.Summary_Instance.Tittle8.text = "LAST WINNER ID";

            Summary.Summary_Instance.space1.text = "";
            Summary.Summary_Instance.space2.text = "";
            Summary.Summary_Instance.identifierText.text = SaveGame.Load<string>("GameplayInformation" + SaveLoadController.SaveLoadController_instance.identifier + ".txt", "identifier");
            Summary.Summary_Instance.completenessText.text = SaveGame.Load<string>("GameplayInformation4" + SaveLoadController.SaveLoadController_instance.identifier + ".txt", "completeness");
            Summary.Summary_Instance.consistencyErrorsNumberText.text = SaveGame.Load<string>("GameplayInformation5" + SaveLoadController.SaveLoadController_instance.identifier + ".txt", "consistencyErrorsNumber");
            Summary.Summary_Instance.ProbabilityOfConsistencyErrorText.text = SaveGame.Load<string>("GameplayInformation6" + SaveLoadController.SaveLoadController_instance.identifier + ".txt", "ProbabilityOfConsistencyError");
            Summary.Summary_Instance.numberOfWorkProductsLaysAsideText.text = SaveGame.Load<string>("GameplayInformation9" + SaveLoadController.SaveLoadController_instance.identifier + ".txt", "numberOfWorkProductsLaysAside");
            Summary.Summary_Instance.WinnerIDText.text = SaveGame.Load<string>("GameplayInformation7" + SaveLoadController.SaveLoadController_instance.identifier + ".txt", "WinnerID");

            Summary.Summary_Instance.enableVisualization();
        }
        else
        {
            Summary.Summary_Instance.disableVisualization();
        }
    }

}
