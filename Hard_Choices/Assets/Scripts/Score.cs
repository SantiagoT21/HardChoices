using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor;

public class Score : MonoBehaviourPun
{
    public static Score Instance;
    public TextMesh caption = null;
    public int cardPoints = 0;
    private int b;
    public string Pname;
    

    private void Start()


    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).name == "Caption_Text")
            {
                caption = this.transform.GetChild(i).gameObject.GetComponent<TextMesh>();
                caption.text = Card.Instance.Pname;
                Pname = caption.text;
            }
            GameController.Estructura.Enqueue(this);
        }
    }

    void Update()
    {
        if (photonView.IsMine == true)
        {
            b= Card.Instance.bridge_counter;
            for (int i = 0; i < this.transform.childCount; i++)
            {
                if(this.transform.GetChild(i).name == "Bridge_count")
                {
                    caption = this.transform.GetChild(i).gameObject.GetComponent<TextMesh>();
                    caption.text = "" + b;
                }
                else if (this.transform.GetChild(i).name == "Hammer_count")
                {
                    caption = this.transform.GetChild(i).gameObject.GetComponent<TextMesh>();
                    caption.text = "" + Card.Instance.hammer_counter;
                }
                else if(this.transform.GetChild(i).name == "Saw_count")
                {
                    caption = this.transform.GetChild(i).gameObject.GetComponent<TextMesh>();
                    caption.text = "" + Card.Instance.saw_counter;
                }
                else if (this.transform.GetChild(i).name == "Screwdriver_count")
                {
                    caption = this.transform.GetChild(i).gameObject.GetComponent<TextMesh>();
                    caption.text = "" + Card.Instance.screwdriver_counter;
                }
                else if(this.transform.GetChild(i).name == "Points")
                {
                    if (GameController.GCcardNumber == 0)
                    {
                        cardPoints = (Card.Instance.hammer_counter*5) + Card.Instance.saw_counter + Card.Instance.screwdriver_counter + Card.Instance.finishPoints;
                    }
                    else if (GameController.GCcardNumber == 2)
                    {
                        cardPoints = Card.Instance.hammer_counter - Card.Instance.saw_counter + Card.Instance.screwdriver_counter + Card.Instance.finishPoints;
                    }
                    else
                    {
                        cardPoints = Card.Instance.hammer_counter + Card.Instance.saw_counter + Card.Instance.screwdriver_counter + Card.Instance.finishPoints;
                    }
                    caption = this.transform.GetChild(i).gameObject.GetComponent<TextMesh>();
                    caption.text = "" + cardPoints;
                }
                if (cardPoints > GameController.maxPoints)
                {
                    Card.Instance.changeW(Pname, cardPoints);
                }
            }
        }
    }
}
