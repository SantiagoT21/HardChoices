using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseController : MonoBehaviour
{
    public GameObject nextPhase;
    public Image blackScreen;
    private float r;
    private float g;
    private float b;
    private float a;


    void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;

    }

    void Start()
    {
        r = blackScreen.color.r;
        g = blackScreen.color.g;
        b = blackScreen.color.b;
        a = blackScreen.color.a;
    }

    void Update()
    {
        if (Phase.Phase_Instance.getEnableToAdvance())
        {
            a += 0.1f;
            StartCoroutine(showDarkScreen());

        }
        a -= 0.0009f;

        a = Mathf.Clamp(a, 0, 1f);
        changeScreenColor();

    }

    IEnumerator showDarkScreen()
    {
        yield return new WaitForSeconds(1.5f);
        Phase.Phase_Instance.setEnableToAdvance(false);
    }

    private void changeScreenColor()
    {
        Color c = new Color(r, g, b, a);
        blackScreen.color = c;
        
    }


    IEnumerator OnTriggerEnter2D (Collider2D SoftwareEngineeringStudent)
    {
        SoftwareEngineeringStudent.GetComponent<Animator>().enabled = false;
        SoftwareEngineeringStudent.GetComponent<SoftwareEngineeringStudent>().enabled = false;
        

        yield return new WaitForSeconds(1.5f);

        advance(SoftwareEngineeringStudent);

        SoftwareEngineeringStudent.GetComponent<Animator>().enabled = true;
        SoftwareEngineeringStudent.GetComponent<SoftwareEngineeringStudent>().enabled = true;
        
        
    }


    private void advance(Collider2D SoftwareEngineeringStudent)
    {
        SoftwareEngineeringStudent.transform.position = nextPhase.transform.GetChild(0).transform.position;
    }
   
}
    
