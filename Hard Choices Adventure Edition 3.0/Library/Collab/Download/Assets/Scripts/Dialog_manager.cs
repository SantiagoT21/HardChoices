using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialog_manager : MonoBehaviour
{
    
    public Dialog dialog;

    Queue<string> sentences;
    
    public GameObject dialogPanel;
    public TextMeshProUGUI displayText;

    string activateSentence;
    public float typingSpeed;

    AudioSource myAudio;
    public AudioClip speakSound;

    private bool triggerEntered = false ;
    

   
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
    void DisplayNextSentence()
    {
        if(sentences.Count <=0){
            displayText.text=activateSentence;
            return;
        }
        activateSentence=sentences.Dequeue();
        displayText.text=activateSentence;
        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activateSentence));
    }
    IEnumerator TypeTheSentence(string sentence){
        displayText.text="";
        foreach(char letter in sentence.ToCharArray()){
            displayText.text += letter;
            myAudio.PlayOneShot(speakSound);
            yield return new WaitForSeconds(typingSpeed);
        }
    }
       
    private void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Student"))
        {
            dialogPanel.SetActive(true);
            StartDialog();
        }
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Student"))
        {
            triggerEntered = true;
            //if(Input.GetKeyDown(KeyCode.Space)){
              //  DisplayNextSentence();
            //}
        }
    }
    void OnTriggerExit2D(Collider2D obj){
        if(obj.CompareTag("Student")){
            dialogPanel.SetActive(false);
        }
    }
    void Update()
 {
     // We check if user pressed E key and character is inside trigger
     if (Input.GetKeyDown (KeyCode.Space) && triggerEntered == true) 
      {
          DisplayNextSentence();
      }
 }
}
