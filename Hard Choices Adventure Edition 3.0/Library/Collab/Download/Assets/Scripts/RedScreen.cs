using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedScreen : MonoBehaviour
{

    public Image red;
    public Text texto;
    public static RedScreen RedScreen_Instance;
    private float r;
    private float g;
    private float b;
    private float a;

    void Awake()
    {
        if (RedScreen_Instance == null)
        {
            RedScreen_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    void Start()
    {
        r = red.color.r;
        g = red.color.g;
        b = red.color.b;
        a = red.color.a;
        texto.gameObject.SetActive(false);
    }

    
    void Update()
    {
        if(Inventary.Inventary_Instance.error)
        {
            a += 0.05f;
            StartCoroutine(black());
            
        }
        a -= 0.0005f;

        a = Mathf.Clamp(a, 0, 1f);
        ChangeColor();
        
    }

    IEnumerator black()
    {

        yield return new WaitForSeconds(0.08f);
        Inventary.Inventary_Instance.error = false;
    }

    private void ChangeColor()
    {
        Color c = new Color(r, g, b, a);
        red.color = c;
    }

}
