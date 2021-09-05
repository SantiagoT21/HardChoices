using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consistency : MonoBehaviour
{
    public static Consistency Consistency_Instance;

    private int probabilityOfGettingError = 0;
    private int NumberOfSolvedErrors = 0;



    void Awake()
    {
        if (Consistency_Instance == null)
        {
            Consistency_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int getProbabilityOfGettingError()
    {
        return probabilityOfGettingError;
    }
    public void setProbabilityOfGettingError(int pr)
    {
        probabilityOfGettingError = pr;
    }

    public int getNumberOfSolvedErrors()
    {
        return NumberOfSolvedErrors;
    }
    public void setNumberOfSolvedErrors(int n)
    {
        NumberOfSolvedErrors = n;
    }

    public void IncreaseNumberOfSolvedErrors()
    {
        NumberOfSolvedErrors+=1;
    }
}
