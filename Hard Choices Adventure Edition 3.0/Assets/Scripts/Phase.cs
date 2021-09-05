using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phase : MonoBehaviour
{
    public static Phase Phase_Instance;
    Animator anim;
    private bool EnableToAdvance = false;
    private string name;

    void Awake()
    {
        if (Phase_Instance == null)
        {
            Phase_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public IEnumerator ShowPhaseName(string name)
    {
        anim.Play("Area_show");
        transform.GetChild(0).GetComponent<Text>().text = name;
        yield return new WaitForSeconds(1.5f);
        anim.Play("Area_fadeOut");
        this.name = name;
    }

    public bool getEnableToAdvance()
    {
        return EnableToAdvance;
    }

    public void setEnableToAdvance(bool value)
    {
        EnableToAdvance = value;
    }

    public string getName()
    {
        return name;
    }


}
