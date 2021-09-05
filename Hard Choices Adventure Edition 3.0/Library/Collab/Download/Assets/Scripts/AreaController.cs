using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AreaController : MonoBehaviourPun
{
    GameObject area;

    void Awake()
    {
        area = GameObject.FindGameObjectWithTag("Area");
    }

    IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        if (photonView.IsMine == true)
        {
            if (col.tag == "warp")
            {
                Inventary.Inventary_Instance.activator = true;
                yield return new WaitForSeconds(1.5f);
                string name1 = col.ToString();
                string[] words = name1.Split(' ');
                StartCoroutine(area.GetComponent<Area>().ShowArea(words[0]));
            }
        }
    }


}
