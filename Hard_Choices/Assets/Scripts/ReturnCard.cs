using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor;

public class ReturnCard : MonoBehaviourPun
{
    public static ReturnCard ReturnCard_Instance;
    [SerializeField] public GameObject bridge_button;
    [SerializeField] public GameObject tool_button;
    [SerializeField] public GameObject saw_button;
    [SerializeField] public GameObject screwdriver_button;
    [SerializeField] public GameObject hammer_button;
    public bool turn_on=false;

    public void Awake()
    {
        
        if (ReturnCard_Instance == null)
        {
            ReturnCard_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        ReturnCard_Instance.bridge_button.SetActive(false);
        ReturnCard_Instance.tool_button.SetActive(false);
        ReturnCard_Instance.saw_button.SetActive(false);
        ReturnCard_Instance.hammer_button.SetActive(false);
        ReturnCard_Instance.screwdriver_button.SetActive(false);
    }


    public void onBridge_button()
    {
            ReturnCard_Instance.tool_button.SetActive(false);
            Die.Die_Instance.roll_button.SetActive(false);
            Card.Instance.bridge_counter --;
            Debug.Log("bridge");
            ReturnCard_Instance.bridge_button.SetActive(false);
            //Card.Instance.Change();
            Turn.Turn_Instance.PassTurn_button.SetActive(true);
                
    }
    public void onTool_button()
    {
        //turn_on=true;
        Turn.Turn_Instance.PassTurn_button.SetActive(false);
        if(Card.Instance.saw_counter > 0){
            ReturnCard_Instance.saw_button.SetActive(true);
        }
        if(Card.Instance.hammer_counter > 0){
            ReturnCard_Instance.hammer_button.SetActive(true);
        }
        if(Card.Instance.screwdriver_counter > 0){
            ReturnCard_Instance.screwdriver_button.SetActive(true);
        }      
        ReturnCard_Instance.tool_button.SetActive(false);
        ReturnCard_Instance.bridge_button.SetActive(false);
        

    }
    public void onSaw_button()
    {
        Card.Instance.saw_counter --;
        ReturnCard_Instance.saw_button.SetActive(false);
        ReturnCard_Instance.hammer_button.SetActive(false);
        ReturnCard_Instance.screwdriver_button.SetActive(false);
        Die.Die_Instance.roll_button.SetActive(true);

        
    }
    public void onHammer_button()
    {
        Card.Instance.hammer_counter --;
        ReturnCard_Instance.saw_button.SetActive(false);
        ReturnCard_Instance.hammer_button.SetActive(false);
        ReturnCard_Instance.screwdriver_button.SetActive(false);
        Die.Die_Instance.roll_button.SetActive(true);
        
    }
    public void onscrewdriver_button()
    {
        Card.Instance.screwdriver_counter --;
        ReturnCard_Instance.saw_button.SetActive(false);
        ReturnCard_Instance.hammer_button.SetActive(false);
        ReturnCard_Instance.screwdriver_button.SetActive(false);
        Die.Die_Instance.roll_button.SetActive(true);
        
    }
    
    
   
}

