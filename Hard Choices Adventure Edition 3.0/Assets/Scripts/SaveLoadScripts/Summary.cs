using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summary : MonoBehaviour
{
    public static Summary Summary_Instance;

    [SerializeField] public GameObject Text;
    [SerializeField] public GameObject RawImage;
    [SerializeField] public GameObject RawImage1;
    [SerializeField] public GameObject RawImage2;
    [SerializeField] public GameObject identifier;
    [SerializeField] public GameObject completeness;
    [SerializeField] public GameObject consistencyErrorsNumber;
    [SerializeField] public GameObject ProbabilityOfConsistencyError;
    [SerializeField] public GameObject numberOfWorkProductsLaysAside;
    [SerializeField] public GameObject WinnerID;
    [SerializeField] public GameObject ButtonNext;
    [SerializeField] public GameObject identifierT;
    [SerializeField] public GameObject completenessT;
    [SerializeField] public GameObject consistencyErrorsNumberT;
    [SerializeField] public GameObject ProbabilityOfConsistencyErrorT;
    [SerializeField] public GameObject numberOfWorkProductsLaysAsideT;
    [SerializeField] public GameObject WinnerIDT;
    [SerializeField] public GameObject extra1;
    [SerializeField] public GameObject extra2;


    public Text space1;
    public Text space2;
    public Text identifierText;
    public Text completenessText;
    public Text consistencyErrorsNumberText;
    public Text ProbabilityOfConsistencyErrorText;
    public Text numberOfWorkProductsLaysAsideText;
    public Text WinnerIDText;
    public Text TittleText;

    public Text Tittle1;
    public Text Tittle2;
    public Text Tittle3;
    public Text Tittle4;
    public Text Tittle5;
    public Text Tittle6;
    public Text Tittle7;
    public Text Tittle8;

    void Awake()
    {
        if (Summary_Instance == null)
        {
            Summary_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        disableVisualization();
    }

    public void enableVisualization()
    {
        Summary.Summary_Instance.Text.SetActive(true);
        Summary.Summary_Instance.RawImage.SetActive(true);
        Summary.Summary_Instance.RawImage1.SetActive(true);
        Summary.Summary_Instance.RawImage2.SetActive(true);
        Summary.Summary_Instance.identifier.SetActive(true);
        Summary.Summary_Instance.completeness.SetActive(true);
        Summary.Summary_Instance.consistencyErrorsNumber.SetActive(true);
        Summary.Summary_Instance.ProbabilityOfConsistencyError.SetActive(true);
        Summary.Summary_Instance.numberOfWorkProductsLaysAside.SetActive(true);
        Summary.Summary_Instance.WinnerID.SetActive(true);
        Summary.Summary_Instance.ButtonNext.SetActive(true);
        Summary.Summary_Instance.identifierT.SetActive(true);
        Summary.Summary_Instance.completenessT.SetActive(true);
        Summary.Summary_Instance.consistencyErrorsNumberT.SetActive(true);
        Summary.Summary_Instance.ProbabilityOfConsistencyErrorT.SetActive(true);
        Summary.Summary_Instance.numberOfWorkProductsLaysAsideT.SetActive(true);
        Summary.Summary_Instance.WinnerIDT.SetActive(true);
        Summary.Summary_Instance.extra1.SetActive(true);
        Summary.Summary_Instance.extra2.SetActive(true);

    }

    public void disableVisualization()
    {
        Summary.Summary_Instance.Text.SetActive(false);
        Summary.Summary_Instance.RawImage.SetActive(false);
        Summary.Summary_Instance.RawImage1.SetActive(false);
        Summary.Summary_Instance.RawImage2.SetActive(false);
        Summary.Summary_Instance.identifier.SetActive(false);
        Summary.Summary_Instance.completeness.SetActive(false);
        Summary.Summary_Instance.consistencyErrorsNumber.SetActive(false);
        Summary.Summary_Instance.ProbabilityOfConsistencyError.SetActive(false);
        Summary.Summary_Instance.numberOfWorkProductsLaysAside.SetActive(false);
        Summary.Summary_Instance.WinnerID.SetActive(false);
        Summary.Summary_Instance.ButtonNext.SetActive(false);
        Summary.Summary_Instance.identifierT.SetActive(false);
        Summary.Summary_Instance.completenessT.SetActive(false);
        Summary.Summary_Instance.consistencyErrorsNumberT.SetActive(false);
        Summary.Summary_Instance.ProbabilityOfConsistencyErrorT.SetActive(false);
        Summary.Summary_Instance.numberOfWorkProductsLaysAsideT.SetActive(false);
        Summary.Summary_Instance.WinnerIDT.SetActive(false);
        Summary.Summary_Instance.extra1.SetActive(false);
        Summary.Summary_Instance.extra2.SetActive(false);
    }
}
