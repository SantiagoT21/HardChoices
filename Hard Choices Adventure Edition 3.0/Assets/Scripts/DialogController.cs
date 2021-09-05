using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System;
public class DialogController : MonoBehaviourPun
{
    
    //public Dialog dialog;
    public DialogueInstructions dialogueinstructions;
    public DialogueRequirements dialoguerequirements;
    public DialogueFeedback dialoguefeedback;
    private Queue<string> sentences;
    private string activateSentence;
    private float typingSpeed;
    AudioSource myAudio;
    public AudioClip speakSound;
    private bool triggerEntered = false ;
    private bool triggerlast = false;
    private int id = 0;
    public double TimeEntered;
    public DateTime TimeLast;
    public double RequirementDuration;
    public double InstructionDuration;
    public DateTime BeforeExcutionInstruction;
    public DateTime AftereExcutionInstruction;
    public double Aux;
    public List<double> requirementTime = new List<double>();
    public List<double> instructionTime = new List<double>();
    public bool displayed=false;

    void Start()
    {
       sentences= new Queue<string>();
       myAudio= GetComponent<AudioSource>();
    }
    void receiveinstructions1(){
        sentences.Clear();
        displayed = true;
        foreach (string sentence in dialogueinstructions.Type1)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    void receiverequirementslist(){

        sentences.Clear();
        foreach (string sentence in dialoguerequirements.Requirements)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    void receiveinstructions2(){
        sentences.Clear();
        foreach (string sentence in dialogueinstructions.Type2)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    void receiveinstructions3(){
        sentences.Clear();

        foreach (string sentence in dialogueinstructions.Type3)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    void receiveinstructions4(){
        sentences.Clear();

        foreach (string sentence in dialogueinstructions.Type4)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    void receivefeedback()
    {
        sentences.Clear();
        if (Progress.Progress_Instance.getAmountDeveloped() >= GameController.minimumCompletenessRequired)
        {
            Completeness.Completeness_instance.setSpeed_mul(0);
            //transform.GetComponent<Animator>().enabled = false;
            //transform.GetComponent<SoftwareEngineeringStudent>().enabled = false;
            last();
            //Completeness.Completeness_instance.WorkProducts();
            Completeness.Completeness_instance.WorkProducts(Progress.Progress_Instance.getAmountDeveloped());
            Completeness.Completeness_instance.PlayerIn();
            Completeness.Completeness_instance.setAmountCompleteness(Completeness.Completeness_instance.getAmountCompleteness() + GameController.finishCompleteness);
            dialoguefeedback.setResult("SOFTWARE SYSTEM RECEIVED");

            Pause.Pause_Instance.SaveData = true;
            Debug.Log("Se actualizaron los KPI de la partida");

            SoftwareSystem.delivers();
            foreach (string sentence in dialoguefeedback.Type1)
            {
                sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }
        else
        {
            Completeness.Completeness_instance.SoftwareSystemRejected();
            dialoguefeedback.setResult("INCOMPLETE SOFTWARE SYSTEM");
            foreach (string sentence in dialoguefeedback.Type2)
            {
                sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }
        
        
    }


    void DisplayNextSentence()
    {
        if(sentences.Count <=0){
            
            DialogPanel.DialogPanel_Instance.DisplayText.text=activateSentence;
            if (id == 1)
            {
                //Consistency.Consistency_Instance.ErrorAppears();
                foreach (GameObject workProduct in WorkProductsList.WorkProductsList_Instance.phase1)
                {
                    GameObject it = workProduct.gameObject;
                    WorkProduct workProductAux = it.GetComponent<WorkProduct>();

                    if (workProductAux.getDeveloping() == false)
                    {
                        workProduct.SetActive(true);
                    }
                }
            }
            if (id == 2)
            {
                foreach (GameObject workProduct in WorkProductsList.WorkProductsList_Instance.phase2)
                {
                    GameObject it = workProduct.gameObject;
                    WorkProduct workProductAux = it.GetComponent<WorkProduct>();

                    if (workProductAux.getDeveloping() == false)
                    {
                        workProduct.SetActive(true);
                    }
                }
            }
            if (id == 3)
            {
                foreach (GameObject workProduct in WorkProductsList.WorkProductsList_Instance.phase3)
                {
                    GameObject it = workProduct.gameObject;
                    WorkProduct workProductAux = it.GetComponent<WorkProduct>();

                    if (workProductAux.getDeveloping() == false)
                    {
                        workProduct.SetActive(true);
                    }
                }
            }
            if (id == 5)
            {
                foreach (GameObject workProduct in WorkProductsList.WorkProductsList_Instance.phase4)
                {
                    GameObject it = workProduct.gameObject;
                    WorkProduct workProductAux = it.GetComponent<WorkProduct>();

                    if (workProductAux.getDeveloping() == false)
                    {
                        workProduct.SetActive(true);
                    }
                }
            }
            if (id == 4)
            {
               
                foreach (GameObject analyst in WorkProductsList.WorkProductsList_Instance.analysts)
                {
                    analyst.SetActive(true);
                }
            }


            return;
        }
        activateSentence=sentences.Dequeue();
        DialogPanel.DialogPanel_Instance.DisplayText.text=activateSentence;
    }

    IEnumerator TypeTheSentence(string sentence){
        DialogPanel.DialogPanel_Instance.DisplayText.text="";
        foreach(char letter in sentence.ToCharArray()){
            DialogPanel.DialogPanel_Instance.DisplayText.text += letter;
            //myAudio.PlayOneShot(speakSound);
            yield return new WaitForSeconds(typingSpeed);
        }
    }
       
    private void OnTriggerEnter2D(Collider2D col){
        if (photonView.IsMine == true)
        {
            if (col.CompareTag("Analyst"))
            {
                //Debug.Log(id + "");
                DialogPanel.DialogPanel_Instance.RawImage.SetActive(true);
                id = 1;
                //Debug.Log(id + "");
                instructionTime.Add(PhotonNetwork.ServerTimestamp);
                Debug.Log(PhotonNetwork.ServerTimestamp);
                receiveinstructions1();
            }
            else if (col.CompareTag("Analyst2"))
            {
                DialogPanel.DialogPanel_Instance.RawImage.SetActive(true);
                id = 2;
                receiveinstructions2();
            }
            else if (col.CompareTag("Analyst3"))
            {
                DialogPanel.DialogPanel_Instance.RawImage.SetActive(true);
                id = 3;
                receiveinstructions3();
            }
            else if (col.CompareTag("StakeHolder"))
            {
                DialogPanel.DialogPanel_Instance.RawImage.SetActive(true);
                id = 4;
                receiverequirementslist();
            }
            else if (col.CompareTag("Analyst4"))
            {
                DialogPanel.DialogPanel_Instance.RawImage.SetActive(true);
                id = 5;
                receiveinstructions4();
            }
            else if (col.CompareTag("StakeHolder1"))
            {
                DialogPanel.DialogPanel_Instance.RawImage.SetActive(true);
                id = 6;
                receivefeedback();

            }


        }
            
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Analyst"))
        {
            instructionTime.Add(PhotonNetwork.ServerTimestamp);
            //Debug.Log(PhotonNetwork.ServerTimestamp);
            triggerEntered = true;
        }
        else if (other.CompareTag("Analyst2"))
        {
            instructionTime.Add(PhotonNetwork.ServerTimestamp);
            triggerEntered = true;
        }
        else if (other.CompareTag("Analyst3"))
        {
            instructionTime.Add(PhotonNetwork.ServerTimestamp);
            triggerEntered = true;
        }
        else if (other.CompareTag("StakeHolder"))
        {
            requirementTime.Add(PhotonNetwork.ServerTimestamp);
            triggerEntered = true;
        }
        else if (other.CompareTag("Analyst4"))
        {
            instructionTime.Add(PhotonNetwork.ServerTimestamp);
            triggerEntered = true;
        }
        else if (other.CompareTag("StakeHolder1"))
        {
            triggerEntered = true;
           
        }
    }
    void OnTriggerExit2D(Collider2D obj){
        
        if(obj.CompareTag("Analyst")){
            DialogPanel.DialogPanel_Instance.RawImage.SetActive(false);
            triggerEntered = false;
            StopAllCoroutines();
            DialogPanel.DialogPanel_Instance.DisplayText.text = "";
            //AftereExcutionInstruction = DateTime.Now;
            //Debug.Log(instructionTime[0]);
            //Debug.Log(PhotonNetwork.ServerTimestamp);
            //InstructionDuration=Math.Abs(PhotonNetwork.ServerTimestamp)-Math.Abs(instructionTime[0]);
            Aux =Math.Abs(Aux + Math.Abs(PhotonNetwork.ServerTimestamp) - Math.Abs(instructionTime[0]));
            instructionTime.Clear();           
            //Aux=Math.Abs(InstructionDuration);
            //Debug.Log(Aux);
            //instructionTime.Clear();
            //Completeness.Completeness_instance.InstructionDuration=Aux;
            //Completeness.Completeness_instance.TimeInstruction();
            //Debug.Log(InstructionDuration);
        }
        if (obj.CompareTag("Analyst2"))
        {
            DialogPanel.DialogPanel_Instance.RawImage.SetActive(false);
            triggerEntered = false;
            StopAllCoroutines();
            DialogPanel.DialogPanel_Instance.DisplayText.text = "";
            Aux= Aux + Math.Abs(Aux+Math.Abs(PhotonNetwork.ServerTimestamp)-Math.Abs(instructionTime[0]));
            instructionTime.Clear();
            //Debug.Log("hola");
        }
        if (obj.CompareTag("Analyst3"))
        {
            DialogPanel.DialogPanel_Instance.RawImage.SetActive(false);
            triggerEntered = false;
            StopAllCoroutines();
            DialogPanel.DialogPanel_Instance.DisplayText.text = "";
            Aux = Aux + Math.Abs(Aux + Math.Abs(PhotonNetwork.ServerTimestamp) - Math.Abs(instructionTime[0]));
            instructionTime.Clear();
        }
        if (obj.CompareTag("StakeHolder"))
        {
            DialogPanel.DialogPanel_Instance.RawImage.SetActive(false);
            triggerEntered = false;
            StopAllCoroutines();
            DialogPanel.DialogPanel_Instance.DisplayText.text = "";
            TimeLast = DateTime.Now;
            TimeEntered = requirementTime[0];
            Debug.Log(PhotonNetwork.ServerTimestamp- requirementTime[0]);
            RequirementDuration = (PhotonNetwork.ServerTimestamp- requirementTime[0])/PhotonNetwork.CurrentRoom.PlayerCount;
            Completeness.Completeness_instance.Timerequirement(RequirementDuration);
        }
        if (obj.CompareTag("Analyst4"))
        {
            DialogPanel.DialogPanel_Instance.RawImage.SetActive(false);
            triggerEntered = false;
            StopAllCoroutines();
            DialogPanel.DialogPanel_Instance.DisplayText.text = "";
            Aux = Aux + Math.Abs(Aux + Math.Abs(PhotonNetwork.ServerTimestamp) - Math.Abs(instructionTime[0]));
            instructionTime.Clear();
            //Completeness.Completeness_instance.InstructionDuration=Aux;
            Completeness.Completeness_instance.TimeInstruction(Aux);
        }
        if (obj.CompareTag("StakeHolder1"))
        {
            DialogPanel.DialogPanel_Instance.RawImage.SetActive(false);
            triggerEntered = false;
            StopAllCoroutines();
            DialogPanel.DialogPanel_Instance.DisplayText.text = "";
           
            
        }


    }
    void Update()
 {
       
        if (photonView.IsMine == true)
        {
           
            if (Input.GetKeyDown(KeyCode.Space) && triggerEntered == true)
            {
                DisplayNextSentence();
            }
            if(Input.GetKeyDown(KeyCode.F)  && PhotonNetwork.CurrentRoom.PlayerCount-1== GameController.finishPlayers)
            {
                finishes();
                
                
            }
        }
           
 }
 [PunRPC]
    void Changescene()
    {
        SceneManager.LoadScene("Winner");

    }
[PunRPC]
    void lastplayer()
    {
        GameController.finishPlayers +=1;
         GameController.finishCompleteness -=1;
        
    }

    public void last()
    {
       photonView.RPC("lastplayer", RpcTarget.AllViaServer);
        
    }

    public void finishes()
    {
        photonView.RPC("Changescene", RpcTarget.AllViaServer);
    }

    
}
