using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Random=UnityEngine.Random;

using BayatGames.SaveGameFree;



public class Completeness : MonoBehaviourPun
{
    public static Completeness Completeness_instance;
    private int amountCompleteness = 0;
    private float speed_mul=1f;
    private int aux = 1;
    private string Pname;
    void Awake()
    {
        if (Completeness_instance== null)
        {
            Completeness_instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int getAmountCompleteness()
    {
        return amountCompleteness;
    }
    public void setAmountCompleteness(int nc)
    {
        amountCompleteness = nc;
    }

    public float getSpeed_mul()
    {
        return speed_mul;
    }
    public void setSpeed_mul(float sm)
    {
        speed_mul = sm;
    }

    public void setAux(int a)
    {
        aux = a;
    }
    public int getAux()
    {
        return aux;
    }

    public string getPname()
    {
        return Pname;
    }
    public void setPname(string pn)
    {
        Pname = pn;
    }

    [PunRPC]
    void Winname(string name)
    {
        GameController.WinnerName = name;

    }

    [PunRPC]
    void maxPoint(int p)
    {
        GameController.maxCompleteness = p;

    }

    public void changeW(string name, int p)
    {
        photonView.RPC("Winname", RpcTarget.AllViaServer, name);
        photonView.RPC("maxPoint", RpcTarget.AllViaServer, p);
    }

    [PunRPC]
    void Changescene()
    {
        SceneManager.LoadScene("Winner");

    }

    public void finishes()
    {
        photonView.RPC("Changescene", RpcTarget.AllViaServer);
    }

    [PunRPC]
    void RanPlenitudset()
    {
        GameController.minimumCompletenessRequired = Random.Range(20, 24);

    }

    public void RanPlenitud()
    {
        photonView.RPC("RanPlenitudset", RpcTarget.AllViaServer);
    }

    public void Decrease(int workProductID)
    {
        setAmountCompleteness(getAmountCompleteness() - 1);
        setAux(0);
        switch (workProductID)
        {
            case 0:
                setSpeed_mul(getSpeed_mul() + 0.01f);
                break;
            case 1:
                setSpeed_mul(getSpeed_mul() + 0.07f);
                break;
            case 2:
                setSpeed_mul(getSpeed_mul() + 0.035f);
                break;
            case 3:
                setSpeed_mul(getSpeed_mul() + 0.02f);
                break;
            case 4:
                setSpeed_mul(getSpeed_mul() + 0.06f);
                break;
            case 5:
                setSpeed_mul(getSpeed_mul() + 0.025f);
                break;
            case 6:
                setSpeed_mul(getSpeed_mul() + 0.025f);
                break;
            case 7:
                setSpeed_mul(getSpeed_mul() + 0.06f);
                break;
            case 8:
                setSpeed_mul(getSpeed_mul() + 0.02f);
                break;
            case 9:
                setSpeed_mul(getSpeed_mul() + 0.015f);
                break;
            case 10:
                setSpeed_mul(getSpeed_mul() + 0.035f);
                break;
            case 11:
                setSpeed_mul(getSpeed_mul() + 0.035f);
                break;
            case 12:
                setSpeed_mul(getSpeed_mul() + 0.01f);
                break;
            case 13:
                setSpeed_mul(getSpeed_mul() + 0.06f);
                break;
            case 14:
                setSpeed_mul(getSpeed_mul() + 0.025f);
                break;
            case 15:
                setSpeed_mul(getSpeed_mul() + 0.015f);
                break;
            case 16:
                setSpeed_mul(getSpeed_mul() + 0.0f);
                break;
            case 17:
                setSpeed_mul(getSpeed_mul() + 0.015f);
                break;
            case 18:
                setSpeed_mul(getSpeed_mul() + 0.02f);
                break;
            case 19:
                setSpeed_mul(getSpeed_mul() + 0.0f);
                break;
            case 20:
                setSpeed_mul(getSpeed_mul() + 0.025f);
                break;
            case 21:
                setSpeed_mul(getSpeed_mul() + 0.06f);
                break;
            case 22:
                setSpeed_mul(getSpeed_mul() + 0.02f);
                break;
            case 23:
                setSpeed_mul(getSpeed_mul() + 0.01f);
                break;
            case 24:
                setSpeed_mul(getSpeed_mul() + 0.01f);
                break;
            case 25:
                setSpeed_mul(getSpeed_mul() + 0.02f);
                break;
            case 26:
                setSpeed_mul(getSpeed_mul() + 0.02f);
                break;
            case 27:
                setSpeed_mul(getSpeed_mul() + 0.01f);
                break;


        }
    }


    public void Increase(int workProductID)
    {
        setAmountCompleteness(getAmountCompleteness() + 1);
        setAux(0);
        switch (workProductID)
        {
            case 0:
                setSpeed_mul(getSpeed_mul() - 0.01f);
                break;
            case 1:
                setSpeed_mul(getSpeed_mul() - 0.07f);
                break;
            case 2:
                setSpeed_mul(getSpeed_mul() - 0.035f);
                break;
            case 3:
                setSpeed_mul(getSpeed_mul() - 0.02f);
                break;
            case 4:
                setSpeed_mul(getSpeed_mul() - 0.06f);
                break;
            case 5:
                setSpeed_mul(getSpeed_mul() - 0.025f);
                break;
            case 6:
                setSpeed_mul(getSpeed_mul() - 0.025f);
                break;
            case 7:
                setSpeed_mul(getSpeed_mul() - 0.06f);
                break;
            case 8:
                setSpeed_mul(getSpeed_mul() - 0.02f);
                break;
            case 9:
                setSpeed_mul(getSpeed_mul() - 0.015f);
                break;
            case 10:
                setSpeed_mul(getSpeed_mul() - 0.035f);
                break;
            case 11:
                setSpeed_mul(getSpeed_mul() - 0.035f);
                break;
            case 12:
                setSpeed_mul(getSpeed_mul() - 0.01f);
                break;
            case 13:
                setSpeed_mul(getSpeed_mul() - 0.06f);
                break;
            case 14:
                setSpeed_mul(getSpeed_mul() - 0.025f);
                break;
            case 15:
                setSpeed_mul(getSpeed_mul() - 0.015f);
                break;
            case 16:
                setSpeed_mul(getSpeed_mul() - 0.0f);
                break;
            case 17:
                setSpeed_mul(getSpeed_mul() - 0.015f);
                break;
            case 18:
                setSpeed_mul(getSpeed_mul() - 0.02f);
                break;
            case 19:
                setSpeed_mul(getSpeed_mul() - 0.0f);
                break;
            case 20:
                setSpeed_mul(getSpeed_mul() - 0.025f);
                break;
            case 21:
                setSpeed_mul(getSpeed_mul() - 0.06f);
                break;
            case 22:
                setSpeed_mul(getSpeed_mul() - 0.02f);
                break;
            case 23:
                setSpeed_mul(getSpeed_mul() - 0.01f);
                break;
            case 24:
                setSpeed_mul(getSpeed_mul() - 0.01f);
                break;
            case 25:
                setSpeed_mul(getSpeed_mul() - 0.02f);
                break;
            case 26:
                setSpeed_mul(getSpeed_mul() - 0.02f);
                break;
            case 27:
                setSpeed_mul(getSpeed_mul() - 0.01f);
                break;


        }

    }
    [PunRPC]
    void PlayerCounter()
    {
        GameController.StudentsWhoHavePlayed +=1;
        if(GameController.StudentsWhoHavePlayed == PhotonNetwork.CurrentRoom.PlayerCount-1)
        {
            GameController.StudentsWhoHavePlayed +=1;
            String auxStudentsWhoHavePlayed = "";
            auxStudentsWhoHavePlayed = SaveGame.Load<string>("StudentsWhoHavePlayed.txt", "StudentsWhoHavePlayed");
            if (auxStudentsWhoHavePlayed == "")
            {
                GameController.StudentsWhoHavePlayed = 0;
                auxStudentsWhoHavePlayed = ""+GameController.StudentsWhoHavePlayed;
            }

            GameController.StudentsWhoHavePlayed = GameController.StudentsWhoHavePlayed + int.Parse(auxStudentsWhoHavePlayed);
            SaveGame.Save<string>("StudentsWhoHavePlayed.txt", ""+GameController.StudentsWhoHavePlayed); 

            GameController.RequirementListRatio = GameController.RequirementListRatio / (PhotonNetwork.CurrentRoom.PlayerCount);
            GameController.RetreatsPhasesRatio = GameController.RejectedSoftwareSystem / PhotonNetwork.CurrentRoom.PlayerCount;
            GameController.InstructionsListTime = GameController.InstructionsListTime / (PhotonNetwork.CurrentRoom.PlayerCount);
            GameController.WorkProductRatio = GameController.WorkProductRatio / PhotonNetwork.CurrentRoom.PlayerCount;
            GameController.SoftwareSystemReceived = (PhotonNetwork.CurrentRoom.PlayerCount - 1);
            GameController.SoftwareSystemReceivedRatio = GameController.SoftwareSystemReceived / PhotonNetwork.CurrentRoom.PlayerCount;
            GameController.RetreatsPhasesRatio = GameController.PhasesmovementsRetreat / GameController.PhasesmovementsAdvance;

            Debug.Log(GameController.RequirementListRatio);
            Debug.Log(GameController.StudentsWhoHavePlayed);
            Debug.Log(GameController.RejectedSoftwareSystem);
            Debug.Log(GameController.WorkProductRatio);
            Debug.Log(GameController.SoftwareSystemReceivedRatio);
            Debug.Log(GameController.RetreatsPhasesRatio);
        }
        
    }

    public void PlayerIn()
    {
        photonView.RPC("PlayerCounter", RpcTarget.AllViaServer);
    }

  
    [PunRPC]
    void RejectedCounter()
    {
        GameController.RejectedSoftwareSystem +=1;
        Debug.Log(GameController.RejectedSoftwareSystem);
    }

    public void SoftwareSystemRejected()
    {
        photonView.RPC("RejectedCounter", RpcTarget.AllViaServer);
    }

    [PunRPC]
    void TimeRequirementeCounter(double duration)
    {
        GameController.RequirementListRatio = GameController.RequirementListRatio + duration;
        Debug.Log(GameController.RequirementListRatio);

    }

    public void Timerequirement(double duration)
    {
        //Debug.Log(GameController.RequirementListTime);
        photonView.RPC("TimeRequirementeCounter", RpcTarget.AllViaServer, duration);
        
    }
    [PunRPC]
    void TimeInstructionCounter(double duration)
    {
        //Debug.Log(InstructionDuration);
        GameController.InstructionsListTime = GameController.InstructionsListTime + duration;
        Debug.Log(GameController.InstructionsListTime);
        Debug.Log("........");
    }

    public void TimeInstruction(double duration)
    {
        photonView.RPC("TimeInstructionCounter", RpcTarget.AllViaServer, duration);
    }
     [PunRPC]
    void WorkProductsCounter(int workProductsnumber)
    {
        GameController.WorkProductRatio = GameController.WorkProductRatio + workProductsnumber;
        Debug.Log(GameController.WorkProductRatio);
    }

    public void WorkProducts(int workProductsnumber)
    {
        photonView.RPC("WorkProductsCounter", RpcTarget.AllViaServer, workProductsnumber);
    }

    [PunRPC]
    void PhaseCounterAdavance()
    {
        GameController.PhasesmovementsAdvance += 0.5;
        Debug.Log(GameController.PhasesmovementsAdvance);

    }

    public void PhasesmovementAdvance()
    {
        photonView.RPC("PhaseCounterAdavance", RpcTarget.AllViaServer);
    }

    [PunRPC]
    void PhaseCounterBack()
    {
        GameController.PhasesmovementsRetreat += 0.5;
        Debug.Log(GameController.PhasesmovementsRetreat);
    }

    public void PhasesmovementBack()
    {
        photonView.RPC("PhaseCounterBack", RpcTarget.AllViaServer);
    }




}
