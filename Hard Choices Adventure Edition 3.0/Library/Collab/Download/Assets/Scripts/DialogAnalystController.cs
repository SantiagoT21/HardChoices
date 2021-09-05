using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class DialogAnalystController : MonoBehaviourPun
{
    
    public Dialog dialog;

    Queue<string> sentences;

    string activateSentence;
    public float typingSpeed;

    AudioSource myAudio;
    public AudioClip speakSound;

    private bool triggerEntered = false ;
    private bool triggerlast = false;

    public int id = 0;



    void Start()
    {
       sentences= new Queue<string>();
       myAudio= GetComponent<AudioSource>();
    }
    void StartDialog(){
        sentences.Clear();

        foreach (string sentence in dialog.sentenceList)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    void StartDialogStake(){
        sentences.Clear();

        foreach (string sentence in dialog.sentenceListStake)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    void StartDialog2(){
        sentences.Clear();
        foreach (string sentence in dialog.sentenceList2)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    void StartDialog3(){
        sentences.Clear();

        foreach (string sentence in dialog.sentenceList3)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    void StartDialog4(){
        sentences.Clear();

        foreach (string sentence in dialog.sentenceList4)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    void StartDialog5()
    {
        sentences.Clear();
        if (Inventary.Inventary_Instance.n_collected >= GameController.randomPlenitud)
        {
            transform.GetComponent<Animator>().enabled = false;
            transform.GetComponent<SoftwareStudent>().enabled = false;
            //GameController.finishPlayers +=1;
            //triggerlast = true;
            last();
            Points.Points_instance.n_points = Points.Points_instance.n_points + GameController.finishPoints;
            foreach (string sentence in dialog.sentenceListStake1)
            {
                sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }
        else
        {
            foreach (string sentence in dialog.sentenceListStake2)
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
            //Debug.Log(id + "");
            if (id == 1)
            {
                foreach (GameObject wp in WorkProd.WorkProd_Instance.phase1)
                {
                    GameObject it = wp.gameObject;
                    Item item = it.GetComponent<Item>();

                    if (item.pickedUp == false)
                    {
                        wp.SetActive(true);
                    }
                }
            }
            if (id == 2)
            {
                foreach (GameObject wp in WorkProd.WorkProd_Instance.phase2)
                {
                    GameObject it = wp.gameObject;
                    Item item = it.GetComponent<Item>();

                    if (item.pickedUp == false)
                    {
                        wp.SetActive(true);
                    }
                }
            }
            if (id == 3)
            {
                foreach (GameObject wp in WorkProd.WorkProd_Instance.phase3)
                {
                    GameObject it = wp.gameObject;
                    Item item = it.GetComponent<Item>();

                    if (item.pickedUp == false)
                    {
                        wp.SetActive(true);
                    }
                }
            }
            if (id == 5)
            {
                foreach (GameObject wp in WorkProd.WorkProd_Instance.phase4)
                {
                    GameObject it = wp.gameObject;
                    Item item = it.GetComponent<Item>();

                    if (item.pickedUp == false)
                    {
                        wp.SetActive(true);
                    }
                }
            }
            if (id == 4)
            {
                foreach (GameObject wp in WorkProd.WorkProd_Instance.analysts)
                {
                    wp.SetActive(true);
                }
            }


            return;
        }
        activateSentence=sentences.Dequeue();
        DialogPanel.DialogPanel_Instance.DisplayText.text=activateSentence;
        //StopAllCoroutines();
        //StartCoroutine(TypeTheSentence(activateSentence));
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
                StartDialog();
            }
            else if (col.CompareTag("Analyst2"))
            {
                DialogPanel.DialogPanel_Instance.RawImage.SetActive(true);
                id = 2;
                StartDialog2();
            }
            else if (col.CompareTag("Analyst3"))
            {
                DialogPanel.DialogPanel_Instance.RawImage.SetActive(true);
                id = 3;
                StartDialog3();
            }
            else if (col.CompareTag("StakeHolder"))
            {
                DialogPanel.DialogPanel_Instance.RawImage.SetActive(true);
                id = 4;
                StartDialogStake();
            }
            else if (col.CompareTag("Analyst4"))
            {
                DialogPanel.DialogPanel_Instance.RawImage.SetActive(true);
                id = 5;
                StartDialog4();
            }
            else if (col.CompareTag("StakeHolder1"))
            {
                DialogPanel.DialogPanel_Instance.RawImage.SetActive(true);
                id = 6;
                StartDialog5();

            }


        }
            
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Analyst"))
        {
            triggerEntered = true;
        }
        else if (other.CompareTag("Analyst2"))
        {
            triggerEntered = true;
        }
        else if (other.CompareTag("Analyst3"))
        {
            triggerEntered = true;
        }
        else if (other.CompareTag("StakeHolder"))
        {
            triggerEntered = true;
        }
        else if (other.CompareTag("Analyst4"))
        {
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
        }
        if (obj.CompareTag("Analyst2"))
        {
            DialogPanel.DialogPanel_Instance.RawImage.SetActive(false);
            triggerEntered = false;
            StopAllCoroutines();
            DialogPanel.DialogPanel_Instance.DisplayText.text = "";
        }
        if (obj.CompareTag("Analyst3"))
        {
            DialogPanel.DialogPanel_Instance.RawImage.SetActive(false);
            triggerEntered = false;
            StopAllCoroutines();
            DialogPanel.DialogPanel_Instance.DisplayText.text = "";
        }
        if (obj.CompareTag("StakeHolder"))
        {
            DialogPanel.DialogPanel_Instance.RawImage.SetActive(false);
            triggerEntered = false;
            StopAllCoroutines();
            DialogPanel.DialogPanel_Instance.DisplayText.text = "";
        }
        if (obj.CompareTag("Analyst4"))
        {
            DialogPanel.DialogPanel_Instance.RawImage.SetActive(false);
            triggerEntered = false;
            StopAllCoroutines();
            DialogPanel.DialogPanel_Instance.DisplayText.text = "";
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
        // We check if user pressed E key and character is inside trigger
        
        if (photonView.IsMine == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && triggerEntered == true)
            {
                DisplayNextSentence();
            }
            if(Input.GetKeyDown(KeyCode.F)  && PhotonNetwork.CurrentRoom.PlayerCount-1== GameController.finishPlayers)
            {
                //Points.Points_instance.finishes();
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
         GameController.finishPoints -=1;
        
    }

    public void last()
    {
       photonView.RPC("lastplayer", RpcTarget.AllViaServer);
        
    }

    public void finishes()
    {
        photonView.RPC("Changescene", RpcTarget.AllViaServer);
        //Debug.Log("jokaka");
    }
}
