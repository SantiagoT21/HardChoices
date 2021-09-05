using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InventoryController : MonoBehaviourPun
{
    public bool inventoryEnabled;

    public int enabledSlots;

    public int random;

    

    public int acum;

    public float aux;

    public bool twice=false;





    void Start()
    {
        Inventary.Inventary_Instance.allSlots = Inventary.Inventary_Instance.SlotHolder.transform.childCount;
        Inventary.Inventary_Instance.slot = new GameObject[Inventary.Inventary_Instance.allSlots];

        for (int i = 0; i < Inventary.Inventary_Instance.allSlots; i++)
        {
            Inventary.Inventary_Instance.slot[i] = Inventary.Inventary_Instance.SlotHolder.transform.GetChild(i).gameObject;

            if (Inventary.Inventary_Instance.slot[i].GetComponent<Slot>().item==null)
            {
                Inventary.Inventary_Instance.slot[i].GetComponent<Slot>().empty = true;
            }
        }
        Points.Points_instance.RanPlenitud();
        Debug.Log("mensajito");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }
        if (inventoryEnabled)
        {
            Inventary.Inventary_Instance.RawImage.SetActive(true);
            Inventary.Inventary_Instance.RawImage1.SetActive(true);
            Inventary.Inventary_Instance.Text.SetActive(true);
            Inventary.Inventary_Instance.SlotHolder.SetActive(true);
        }
        else
        {
            Inventary.Inventary_Instance.RawImage.SetActive(false);
            Inventary.Inventary_Instance.RawImage1.SetActive(false);
            Inventary.Inventary_Instance.Text.SetActive(false);
            Inventary.Inventary_Instance.SlotHolder.SetActive(false);
        }

        
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (photonView.IsMine == true) {
            if (other.tag == "Item")
            {
                GameObject itemPickedUp = other.gameObject;

                Item item = itemPickedUp.GetComponent<Item>();

                for (int i = 0; i < Inventary.Inventary_Instance.allSlots; i++)
                {
                    if (Inventary.Inventary_Instance.slot[i].GetComponent<Slot>().item != item)
                    {
                        AddItem(itemPickedUp, item.ID, item.description, item.icon);
                        break;
                    }
                    
                }

            }

            if (Points.Points_instance.n_points > GameController.maxPoints)
            {
                Points.Points_instance.changeW(Points.Points_instance.Pname, Points.Points_instance.n_points);
                Debug.Log(GameController.randomPlenitud);
            }
        }        
    }

    public void AddItem(GameObject itemObject, int itemID, string itemDescription, Sprite itemIcon )
    {
        for (int i = 0; i < Inventary.Inventary_Instance.allSlots; i++)
        {
            if (Inventary.Inventary_Instance.slot[i].GetComponent<Slot>().empty)
            {

                if(itemObject.GetComponent<Item>().twice == false)
                {
                    Addpoints(itemID);
                    Inventary.Inventary_Instance.n_collected += 1;
                    Error();
                    itemObject.GetComponent<Item>().pickedUp = true;
                    itemObject.GetComponent<Item>().twice = true;
                    Inventary.Inventary_Instance.slot[i].GetComponent<Slot>().item = itemObject;
                    Inventary.Inventary_Instance.slot[i].GetComponent<Slot>().ID = itemID;
                    Inventary.Inventary_Instance.slot[i].GetComponent<Slot>().description = itemDescription;
                    Inventary.Inventary_Instance.slot[i].GetComponent<Slot>().icon = itemIcon;

                    //itemObject.transform.parent = slot[i].transform;
                    itemObject.SetActive(false);


                    Inventary.Inventary_Instance.slot[i].GetComponent<Slot>().UpdateSlot();


                    Inventary.Inventary_Instance.slot[i].GetComponent<Slot>().empty = false;
                    return;
                }
                
            }
            
        }
    }


    public void Error()
    {
        int n = 2 * Inventary.Inventary_Instance.n_collected;
        random = Random.Range(n, n * 2);
        acum += random;
        int randomAux = Random.Range(5,100);
        if(randomAux<= acum)
        {
            Inventary.Inventary_Instance.error = true;
            StartCoroutine(walk());
            RedScreen.RedScreen_Instance.texto.gameObject.SetActive(true);
            acum = 0;
        }
        if (acum >= 100)
        {
            acum = 0;
        }

        float c = (float) 1.3 * acum;
        ErrorBar.ErrorBar_Instance.RawImage1.rectTransform.sizeDelta = new Vector2(c, 20);
        ErrorBar.ErrorBar_Instance.Text1.text = acum + "% probability of Consistency Error";
    }

    IEnumerator walk()
    {
        aux = Points.Points_instance.speed_mul;
        Points.Points_instance.speed_mul = 0;
        yield return new WaitForSeconds(5f);
        Points.Points_instance.speed_mul = aux;
        Points.Points_instance.aux = 0;
        RedScreen.RedScreen_Instance.texto.gameObject.SetActive(false);

    }

    public void Addpoints(int ID)
    {
        switch (ID)
        {
            case 0:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.01f;
                Points.Points_instance.aux = 0;
                break;
            case 1:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.07f;
                Points.Points_instance.aux = 0;
                break;
            case 2:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.035f;
                Points.Points_instance.aux = 0;
                break;
            case 3:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.02f;
                Points.Points_instance.aux = 0;
                break;
            case 4:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.06f;
                Points.Points_instance.aux = 0;
                break;
            case 5:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.025f;
                Points.Points_instance.aux = 0;
                break;
            case 6:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.025f;
                Points.Points_instance.aux = 0;
                break;
            case 7:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.06f;
                Points.Points_instance.aux = 0;
                break;
            case 8:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.02f;
                Points.Points_instance.aux = 0;
                break;
            case 9:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.015f;
                Points.Points_instance.aux = 0;
                break;
            case 10:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.035f;
                Points.Points_instance.aux = 0;
                break;
            case 11:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.035f;
                Points.Points_instance.aux = 0;
                break;
            case 12:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.01f;
                Points.Points_instance.aux = 0;
                break;
            case 13:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.06f;
                Points.Points_instance.aux = 0;
                break;
            case 14:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.025f;
                Points.Points_instance.aux = 0;
                break;
            case 15:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.015f;
                Points.Points_instance.aux = 0;
                break;
            case 16:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.0f;
                Points.Points_instance.aux = 0;
                break;
            case 17:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.015f;
                Points.Points_instance.aux = 0;
                break;
            case 18:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.02f;
                Points.Points_instance.aux = 0;
                break;
            case 19:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.0f;
                Points.Points_instance.aux = 0;
                break;
            case 20:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.025f;
                Points.Points_instance.aux = 0;
                break;
            case 21:
                Points.Points_instance.n_points += 1;
                Points.Points_instance.speed_mul -= 0.06f;
                Points.Points_instance.aux = 0;
                break;

        }
        
    }

}
