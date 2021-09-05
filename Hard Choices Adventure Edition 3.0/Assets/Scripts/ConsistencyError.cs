using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsistencyError : MonoBehaviour
{

    public static ConsistencyError ConsistencyError_Instance;

    //VISUAL REPRESENTATION OF THE PROBABILITY BAR  OF OBTAINING A CONSISTENCY ERROR

    [SerializeField] public GameObject RawImage;
    [SerializeField] public Image RawImage1;
    [SerializeField] public Text Text1;

    //VARIABLES FOR CALCULATIONS

    private int random;

    //VISUAL REPRESENTATION OF CONSISTENCY ERROR ON SCREEN

    private bool appears = false;
    public Image redScreen;
    public Text texto;
    private float r;
    private float g;
    private float b;
    private float a;

    //CONTROLLER METHODS

    void Awake()
    {
        if (ConsistencyError_Instance == null)
        {
            ConsistencyError_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        RawImage1.rectTransform.sizeDelta = new Vector2(0, 20);
    }


    void Start()
    {
        r = redScreen.color.r;
        g = redScreen.color.g;
        b = redScreen.color.b;
        a = redScreen.color.a;
        texto.gameObject.SetActive(false);
    }


    void Update()
    {
        if (appears)
        {
            a += 0.05f;
            StartCoroutine(showRedScreen());

        }
        a -= 0.0005f;

        a = Mathf.Clamp(a, 0, 1f);
        ChangeColor();

    }

    public void Check()
    {
        int n = 2 * Progress.Progress_Instance.getAmountDeveloped();
        random = Random.Range(n, n * 2);
        Consistency.Consistency_Instance.setProbabilityOfGettingError(Consistency.Consistency_Instance.getProbabilityOfGettingError() + random);
        int randomAux = Random.Range(5, 100);
        if (randomAux <= Consistency.Consistency_Instance.getProbabilityOfGettingError())
        {
            Appears();
        }
        if (Consistency.Consistency_Instance.getProbabilityOfGettingError() >= 100)
        {
            
            Consistency.Consistency_Instance.setProbabilityOfGettingError(0);
        }
        UpdateProbabilityBar();
    }


    public void Appears()
    {
        appears = true;
        StartCoroutine(solves());
        texto.gameObject.SetActive(true);
        Consistency.Consistency_Instance.setProbabilityOfGettingError(0);
    }

    


    IEnumerator solves()
    {
        Consistency.Consistency_Instance.IncreaseNumberOfSolvedErrors();

        float auxSpeedMult = Completeness.Completeness_instance.getSpeed_mul();
        Completeness.Completeness_instance.setSpeed_mul(0);


        yield return new WaitForSeconds(5f);


        Completeness.Completeness_instance.setSpeed_mul(auxSpeedMult);


        Completeness.Completeness_instance.setAux(0);
        texto.gameObject.SetActive(false);
    }



    //UPDATE GRAPHIC PART OF THE ConsistencyErrorProbabilityBar

    void UpdateProbabilityBar()
    {
        float c = (float)1.3 * Consistency.Consistency_Instance.getProbabilityOfGettingError();
        RawImage1.rectTransform.sizeDelta = new Vector2(c, 20);
        Text1.text = Consistency.Consistency_Instance.getProbabilityOfGettingError() + "% probability of Consistency Error";
    }

    //UPDATE GRAPHIC PART OF THE RED CONSISTENCY ERROR SCREEN WHEN IT APPEARS

    IEnumerator showRedScreen()
    {

        yield return new WaitForSeconds(0.08f);
        appears = false;
    }

    private void ChangeColor()
    {
        Color c = new Color(r, g, b, a);
        redScreen.color = c;
    }

}
