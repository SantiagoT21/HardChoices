using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpConttroller : MonoBehaviour
{
    public GameObject target;


    void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;

       
    }

    IEnumerator OnTriggerEnter2D (Collider2D col)
    {
        col.GetComponent<Animator>().enabled = false;
        col.GetComponent<SoftwareStudent>().enabled = false;
        

        yield return new WaitForSeconds(1.5f);

        col.transform.position = target.transform.GetChild (0).transform.position;

        
        col.GetComponent<Animator>().enabled = true;
        col.GetComponent<SoftwareStudent>().enabled = true;

        
    }

   
}
    
