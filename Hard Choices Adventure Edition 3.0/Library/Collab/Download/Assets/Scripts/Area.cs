using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Area : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public IEnumerator ShowArea(string name)
    {
        anim.Play("Area_show");
        transform.GetChild(0).GetComponent<Text>().text = name; 
        //transform.GetChild(1).GetComponent<Text>().text = name;
        yield return new WaitForSeconds(1.5f);
        anim.Play("Area_fadeOut");
    }
}
