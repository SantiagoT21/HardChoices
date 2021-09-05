using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UNCMethod : MonoBehaviour
{
    public static UNCMethod UNCMethod_Instance;
    [SerializeField] public GameObject RawImage;
    [SerializeField] public GameObject RawImage1;
     

    void Awake()
    {
        if (UNCMethod_Instance == null)
        {
            UNCMethod_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        disableVisualization();
    }

    public void applies(Vector2 mov, Animator animation)
    {
        SoftwareSystem.setDevelopingState("InDevelopment");

        if (mov != Vector2.zero)
        {
            animation.SetFloat("movX", mov.x);
            animation.SetFloat("movY", mov.y);
            animation.SetBool("walking", true);
        }
        else
        {
            animation.SetBool("walking", false);
        }
        
    }

    public void enableVisualization()
    {
        UNCMethod.UNCMethod_Instance.RawImage.SetActive(true);
        UNCMethod.UNCMethod_Instance.RawImage1.SetActive(true);
    }

    public void disableVisualization()
    {
        UNCMethod.UNCMethod_Instance.RawImage.SetActive(false);
        UNCMethod.UNCMethod_Instance.RawImage1.SetActive(false);
    }

}
