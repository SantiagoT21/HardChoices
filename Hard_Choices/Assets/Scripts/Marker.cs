using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor;

public class Marker : MonoBehaviourPun
{
    private TextMesh caption = null;
    int pos;
    int pos1;
    int direction=0;
    public bool hard_choice= false;
    private string ID;
    private int photonID;

    private void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).name == "Caption_Text")
            {
                caption = this.transform.GetChild(i).gameObject.GetComponent<TextMesh>();
                caption.text = string.Format("Player{0}", photonView.ViewID);
                this.ID = caption.text;
                Card.Instance.Pname = caption.text;
                photonID = photonView.ViewID;
                if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
                { //photonView.ViewID==1001
                    Die.Die_Instance.roll_button.SetActive(true);
                }
            }
        }
    }
    void Update()
    {
        if (Card.Instance.posaux1>0)
        {
            StartCoroutine(MoveRound());
            Card.Instance.posaux1 = 0;
            pos = 0;
            GameController.endPlayers = 0;
            Card.Instance.posaux = false;
            for (int i = 0; i < 55; i++)
            {
                Card.Instance.history[i] = false;
            }
        }
        if (pos1 > 50)
        {
            Die.Die_Instance.backward_button.SetActive(false);
        }
        if (Die.Die_Instance.shortcut)
        {
            switch (pos)
            {
                case 3:
                    pos = 54;
                    break;
                case 8:
                    pos = 51;
                    break;
                case 19:
                    pos = 50;
                    break;
                case 30:
                    pos = 52;
                    break;
                case 39:
                    pos = 53;
                    break;
            }
            Die.Die_Instance.shortcut = false;
            if (Die.Die_Instance.random > 0)
            {
                Die.Die_Instance.forward_button.SetActive(true);
            }
        }
        if (photonView.IsMine == true)
        {
            if (Die.Die_Instance.back)
            {
                pos1 = pos;
                pos--;
                StartCoroutine(Move());
                Die.Die_Instance.random--;
                Die.Die_Instance.back = false;
                if (Die.Die_Instance.random > 0)
                {
                    if (GameController.endPlayers == 0)
                    {
                        Die.Die_Instance.backward_button.SetActive(true);
                        Die.Die_Instance.forward_button.SetActive(true);
                    }
                    else
                    {
                        Die.Die_Instance.forward_button.SetActive(true);
                    }

                }
                else
                {
                    Die.Die_Instance.roll_button.SetActive(false);
                    //Card.Instance.Change();
                    Turn.Turn_Instance.PassTurn_button.SetActive(true);
                    if(Card.Instance.saw_counter > 0 || Card.Instance.hammer_counter > 0 || Card.Instance.screwdriver_counter > 0 ){
                        ReturnCard.ReturnCard_Instance.tool_button.SetActive(true);
                    }
                    
                                  
                }
            }
            else if (Die.Die_Instance.forw)
            {
                pos1 = pos;
                if (pos < 49)
                {
                    pos++;
                }
                if (pos1 == 49)
                {
                    pos = 55;
                }
                StartCoroutine(Move());
                switch (pos1)
                {
                    case 54:
                        pos = 11;
                        break;
                    case 51:
                        pos = 19;
                        break;
                    case 50:
                        pos = 33;
                        break;
                    case 53:
                        pos = 46;
                        break;
                    case 52:
                        pos = 39;
                        break;
                    default:
                        break;
                }
                Die.Die_Instance.random--;
                Die.Die_Instance.forw = false;
                if (Die.Die_Instance.random > 0)
                {
                    if (GameController.endPlayers == 0)
                    {
                        Die.Die_Instance.backward_button.SetActive(true);
                        Die.Die_Instance.forward_button.SetActive(true);
                    }
                    else
                    {
                        Die.Die_Instance.forward_button.SetActive(true);
                    }
                }
                else 
                {
                    Die.Die_Instance.roll_button.SetActive(false);
                    //Card.Instance.Change();
                    Turn.Turn_Instance.PassTurn_button.SetActive(true);
                    if(Card.Instance.saw_counter > 0 || Card.Instance.hammer_counter > 0 || Card.Instance.screwdriver_counter > 0 ){
                        ReturnCard.ReturnCard_Instance.tool_button.SetActive(true);
                    }
                    
                }
            }
        }
        
        
    }


    IEnumerator Move()
    {
        if (pos == 1)
        {
            direction = -1;
        }
        Vector3 sigPos = Way.Instance.Posicion[pos + direction].position;
        while (MovetoNext(sigPos))
        {
                yield return null;
        }
        if (pos == 3 || pos == 8 || pos == 19 || pos == 30 || pos == 39)
        {
            if (pos1 == pos - 1 || pos1 == pos + 1)
            {
                if(Die.Die_Instance.random < 1)
                {
                    Die.Die_Instance.roll_button.SetActive(false);
                }
                Die.Die_Instance.backward_button.SetActive(false);
                Die.Die_Instance.forward_button.SetActive(false);
                Die.Die_Instance.yes_button.SetActive(true);
                Die.Die_Instance.no_button.SetActive(true);
                Die.Die_Instance.HC_Text.text = "Do you want to take the shortcut to the bridge?";
            }
        }
        yield return new WaitForSeconds(0.5f);
        if (pos1 == pos - 1 || pos1 == pos + 1 || pos == 55)
        {
            Card.Instance.GetComponent<Card>().ChoiceIcon(pos, pos1);
        }
        else if (pos1 > 49)
        {
            Card.Instance.GetComponent<Card>().ChoiceIcon(pos1, pos);
        }
    }

    bool MovetoNext(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
    }

    public string getID()
    {
        return this.ID;
    }
    public string getName()
    {
        return this.caption.text;
    }
    public int getphotonID()
    {
        return this.photonID;
    }





    IEnumerator MoveRound()
    {
        int posSpawn = 23;
        if (Card.Instance.finishPoints == 7)
        {
            posSpawn = 0;
        }
        else if (Card.Instance.finishPoints == 3)
        {
            posSpawn = 1;
        }
        else if (Card.Instance.finishPoints == 1)
        {
            posSpawn = 2;
        }
        else
        {
            posSpawn = 3;
        }
        Vector3 sigPos = Way.Instance.spawn_Counter[posSpawn].position;
        while (MovetoNext(sigPos))
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        GameController.RoundAmount--;
    }
}
