using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GlobalData
{
    public string SoftwareEngineeringStudentCreationDate;
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
    public float DevelopsSpeed;
    public string WinnerID;
    public int StudentsWhoHavePlayed;//
    public double Phasesmovements;//
    public double IncompletenessRatio;//
    public double RequirementListTime;//
    public double InstructionsListTime;//
    public double WorkProducts;//
    public double SoftwareSystemReceivedRatio;//


    public GlobalData(Vector2 mov, float DevelopsSpeed1, string identifier1)
    {
        SoftwareEngineeringStudentCreationDate = System.DateTime.Now.ToString("yyyy/MM/dd");
        identifier = identifier1;
        completeness = Completeness.Completeness_instance.getAmountCompleteness();
        consistencyErrorsNumber = Consistency.Consistency_Instance.getNumberOfSolvedErrors();
        ProbabilityOfConsistencyError = Consistency.Consistency_Instance.getProbabilityOfGettingError();
        numberOfWorkProductsStartedtoDevelop = Progress.Progress_Instance.getAmountDeveloped();
        numberOfWorkProductsLaysAside = Progress.Progress_Instance.getWorkProductsLaysAside();
        workProductPickedUp = SaveLoadController.SaveLoadController_instance.workProductPickedUp;
        workProductEnabledToDevelop = SaveLoadController.SaveLoadController_instance.workProductEnabledToDevelop;
        WinnerID = GameController.WinnerName;
        DevelopsSpeed = DevelopsSpeed1;
        movx = mov.x;
        movy = mov.y;
        StudentsWhoHavePlayed = GameController.StudentsWhoHavePlayed;
        Phasesmovements= GameController.RetreatsPhasesRatio;
        IncompletenessRatio = GameController.IncompletenessRatio;
        RequirementListTime = GameController.RequirementListRatio;
        InstructionsListTime = GameController.InstructionsListTime;
        WorkProducts = GameController.WorkProductRatio;
        SoftwareSystemReceivedRatio = GameController.SoftwareSystemReceivedRatio;
    }


}
