using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Milestone : MonoBehaviour, IPointerClickHandler
{ 
    public GameObject workProduct;
    private int ID;
    private string description;
    private bool empty;
    public Sprite icon;
    public Sprite deletedicon;
    public Text texto;

    public void setMilestone(bool empty, GameObject workProduct, int ID, string description, string texto)
    {
        this.empty = empty;
        this.workProduct = workProduct;
        this.ID = ID;
        this.description = description;
        this.texto.text = texto;
    }

    public void setMilestone(bool empty, GameObject workProduct, int ID, string description, Sprite icon, string texto)
    {
        this.empty = empty;
        this.workProduct = workProduct;
        this.ID = ID;
        this.description = description;
        this.icon = icon;
    }


    public void UpdateMilestone()
    {
        this.GetComponent<Image>().sprite = icon;
        texto.text = description;
    }

    public void DeleteMilestone()
    {
        this.GetComponent<Image>().sprite = deletedicon;
    }

    public void DropWorkProductToProgress()
    {
        if (workProduct != null)
        {
            WorkProductController.WorkProductController_Instance.LaysAside(Progress.Progress_Instance.milestone, workProduct, ID);
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        DropWorkProductToProgress();
    }

    public bool getEmpty()
    {
        return empty;
    }
    public void setEmpty(bool empt)
    {
        empty = empt;
    }

    public void setID(int id)
    {
        ID = id;
    }

    public void setDescription(string desc)
    {
        description = desc;
    }
}
