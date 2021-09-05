using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor;

public class MovementController : MonoBehaviourPun
{
    public static MovementController Instance;
    public void OnbuttonStartRollDie()
    {
        for (int i = 0; i < GameController.Markers.Count; i++)
        {
            if (GameController.IDs[GameController.turnCounter] == GameController.Markers[i].getID())
            {
                Die.Die_Instance.RollDie();
                if (Die.Die_Instance.random > 0)
                {
                    Die.Die_Instance.roll_button.SetActive(false);
                    if (Die.Die_Instance.roll_counter == 1)
                    {
                        Die.Die_Instance.forward_button.SetActive(true);
                    }
                    else
                    {
                        Die.Die_Instance.backward_button.SetActive(true);
                        Die.Die_Instance.forward_button.SetActive(true);
                    }
                }
                if (GameController.turnCounter == GameController.IDs.Count - 1)
                {
                    GameController.turnCounter = 0;
                }
                else
                {
                    GameController.turnCounter++;
                }
                break;
            }
        }

    }

    public void OnbuttonBackward()
    {
        Die.Die_Instance.backward_button.SetActive(false);
        Die.Die_Instance.forward_button.SetActive(false);
        Die.Die_Instance.back = true;
    }

    public void OnbuttonForward()
    {
        Die.Die_Instance.backward_button.SetActive(false);
        Die.Die_Instance.forward_button.SetActive(false);
        Die.Die_Instance.forw = true;
    }

    public void OnbuttonYes()
    {
        Die.Die_Instance.yes_button.SetActive(false);
        Die.Die_Instance.no_button.SetActive(false);
        if (Die.Die_Instance.random == 0)
        {
            Die.Die_Instance.roll_button.SetActive(true);
        }
            Die.Die_Instance.HC_Text.text = "";
            Die.Die_Instance.shortcut = true;
    }

    public void OnbuttonNo()
    {
        if (Die.Die_Instance.random > 0)
        {
            Die.Die_Instance.backward_button.SetActive(true);
            Die.Die_Instance.forward_button.SetActive(true);
        }
        else
        {
            Die.Die_Instance.roll_button.SetActive(true);

        }
        Die.Die_Instance.yes_button.SetActive(false);
        Die.Die_Instance.no_button.SetActive(false);
        Die.Die_Instance.HC_Text.text = "";
    }

}
