using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor;

public class Marker : MonoBehaviourPun
{
    private TextMesh caption = null;
    int pos;
    int auxPos;
    int auxPos1;
    int direction = 0;
    public bool hard_choice= false;
    private int ID;

    private void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).name == "Caption_Text")
            {
                caption = this.transform.GetChild(i).gameObject.GetComponent<TextMesh>();
                caption.text = string.Format("Player{0}", photonView.ViewID);
                this.ID = GameController.NumPlayers;
                GameController.Estructura.Add(GameController.NumPlayers, this);
                GameController.NumPlayers++;
                Card.Instance.Pname = caption.text;
                
            }
        }
    }
    void Update()
    {
        if (Die.Die_Instance.shortcut)
        {
            switch (auxPos)
            {
                case 3:
                    pos = 52;
                    break;
                case 8:
                    pos = 49;
                    break;
                case 19:
                    pos = 48;
                    break;
                case 30:
                    pos = 50;
                    break;
                case 39:
                    pos = 51;
                    break;
            }
            Die.Die_Instance.shortcut = false;
            if (Die.Die_Instance.random > 0)
            {
                Die.Die_Instance.forward_button.SetActive(true);
            }
        }
        if (photonView.IsMine == true && this == GameController.Estructura[GameController.Turn])
        {
            Die.Die_Instance.roll_button.SetActive(true);
            if (Die.Die_Instance.back)
            {
                auxPos1 = auxPos;
                pos--;
                StartCoroutine(Move());
                Die.Die_Instance.random--;
                Die.Die_Instance.back = false;
                if (Die.Die_Instance.random > 0)
                {
                    Die.Die_Instance.backward_button.SetActive(true);
                    Die.Die_Instance.forward_button.SetActive(true);
                }
                else
                {
                    GameController.Turn++;
                    Die.Die_Instance.roll_button.SetActive(false);
                }
            }
            else if (Die.Die_Instance.forw)
            {
                auxPos1 = pos;
                if (pos < 49 || pos>0)
                {
                    pos++;
                }
                StartCoroutine(Move());
                switch (auxPos1)
                {
                    case 52:
                        pos = 10;
                        break;
                    case 49:
                        pos = 18;
                        break;
                    case 48:
                        pos = 32;
                        break;
                    case 51:
                        pos = 45;
                        break;
                    case 50:
                        pos = 38;
                        break;
                    case 47:
                        pos = 53;
                        break;
                    default:
                        break;
                }
                Die.Die_Instance.random--;
                Die.Die_Instance.forw = false;
                if (Die.Die_Instance.random > 0)
                {
                    Die.Die_Instance.backward_button.SetActive(true);
                    Die.Die_Instance.forward_button.SetActive(true);
                }
                else 
                {
                    Die.Die_Instance.roll_button.SetActive(true);
                }
            }
        }
    }


    IEnumerator Move()
    {
        Vector3 sigPos = Way.Instance.Posicion[pos + direction].position;
        while (MovetoNext(sigPos))
        {
                yield return null;
        }
        auxPos = pos + 1;
        if (auxPos == 3 || auxPos == 8 || auxPos == 19 || auxPos == 30 || auxPos == 39)
        {
            if (auxPos1 == pos - 1 || auxPos1 == auxPos + 1)
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
        Card.Instance.card_Text.text = "position: " + auxPos;
        Card.Instance.card_Text1.text = "previous" + auxPos1;
        Card.Instance.card_Text2.text = "movements" + Die.Die_Instance.random;
        if(auxPos1 == pos - 1 || auxPos1 == pos + 1)
        {
            Card.Instance.GetComponent<Card>().ChoiceIcon(auxPos);
        }
        else if (auxPos1 != auxPos + 1)
        {
            Card.Instance.GetComponent<Card>().ChoiceIcon(auxPos1);
        }
    }

    bool MovetoNext(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
    }

    public int getID()
    {
        return this.ID;
    }
}
















/*
    void Update()
    {
        if (photonView.IsMine == true)
        {
            if (Input.GetKeyDown(KeyCode.W) && !movement)
            {
                Die.Die_Instance.RollDie();
                if (Die.Die_Instance.random > 0)
                {
                    Die.Die_Instance.backward_button.SetActive(true);
                    Die.Die_Instance.forward_button.SetActive(true);
                    StartCoroutine(Move());
                    auxPos = pos;
                }
            }
        }
    }

    IEnumerator Move()
    {
        if (movement)
        {
            yield break;
        }
        movement = true;
        while (Die.Die_Instance.random > 0)
        {
            if (pos == 3 || pos == 8 || pos == 19 || pos == 30 || pos == 39)
            {
                if (auxPos == pos - 1)
                {
                    bool hardChoice = EditorUtility.DisplayDialog("Hard Choice", "Do you want to take the shortcut to the bridge?", "Yes", "Nop");
                    if (hardChoice)
                    {
                        switch (pos)
                        {
                            case 3:
                                pos = 53;
                                break;
                            case 8:
                                pos = 50;
                                break;
                            case 19:
                                pos = 49;
                                break;
                            case 30:
                                pos = 51;
                                break;
                            case 39:
                                pos = 52;
                                break;
                        }
                    }
                }
            }
            Vector3 sigPos = Way.Instance.Posicion[pos + 0].position; //aca se cambia para que se mueva tanto hacia delante como atras
            while (MovetoNext(sigPos))
            {
                yield return null;
            }

            yield return new WaitForSeconds(0.5f);
            Die.Die_Instance.random--;
            auxPos = pos;
            switch (pos)
            {
                case 53:
                    pos = 11;
                    break;
                case 50:
                    pos = 19;
                    break;
                case 49:
                    pos = 33;
                    break;
                case 52:
                    pos = 46;
                    break;
                case 51:
                    pos = 39;
                    break;
                case 48:
                    pos = 54;
                    break;
                default:
                    pos++;
                    break;
            }
        }
        movement = false;
        Die.Die_Instance.backward_button.SetActive(false);
        Die.Die_Instance.forward_button.SetActive(false);
        Card.Instance.GetComponent<Card>().ChoiceIcon(pos);
    }

    bool MovetoNext(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
    }
}






/*
    IEnumerator Move()
    {
        if (movement)
        {
            yield break;
        }
        movement = true;
        while (Die.Die_Instance.random > 0)
        {
            if (pos == 3 || pos == 8 || pos == 19 || pos == 30 || pos == 39)
            {
                if (auxPos == pos - 1)
                {
                    bool hardChoice = EditorUtility.DisplayDialog("Hard Choice", "Do you want to take the shortcut to the bridge?", "Yes", "Nop");
                    if (hardChoice)
                    {
                        switch (pos)
                        {
                            case 3:
                                pos = 53;
                                break;
                            case 8:
                                pos = 50;
                                break;
                            case 19:
                                pos = 49;
                                break;
                            case 30:
                                pos = 51;
                                break;
                            case 39:
                                pos = 52;
                                break;
                        }
                    }
                }
            }
            Vector3 sigPos = Way.Instance.Posicion[pos + 0].position; //aca se cambia para que se mueva tanto hacia delante como atras
            while (MovetoNext(sigPos))
            {
                yield return null;
            }

            yield return new WaitForSeconds(0.5f);
            Die.Die_Instance.random--;
            auxPos = pos;
            switch (pos)
            {
                case 53:
                    pos = 11;
                    break;
                case 50:
                    pos = 19;
                    break;
                case 49:
                    pos = 33;
                    break;
                case 52:
                    pos = 46;
                    break;
                case 51:
                    pos = 39;
                    break;
                case 48:
                    pos = 54;
                    break;
                default:
                    pos++;
                    break;
            }
        }
        movement = false;
        Die.Die_Instance.backward_button.SetActive(false);
        Die.Die_Instance.forward_button.SetActive(false);
        Card.Instance.GetComponent<Card>().ChoiceIcon(pos);
    }

    bool MovetoNext(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
    }
}
*/





/*
if (auxPos == 3 || auxPos == 8 || auxPos == 19 || auxPos == 30 || auxPos == 39)
{
    if (auxPos1 == pos - 1)//organizar
    {
        var result= MessageBox.Show("Hard Choice","Do you want to take the shortcut to the bridge?","Yes","No")

        if (hardChoice)
        {
            switch (auxPos)
            {
                case 3:
                    pos = 53;
                    break;
                case 8:
                    pos = 50;
                    break;
                case 19:
                    pos = 49;
                    break;
                case 30:
                    pos = 51;
                    break;
                case 39:
                    pos = 52;
                    break;
            }
        }
    }
}*/
