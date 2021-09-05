using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SoftwareStudent : MonoBehaviourPun
{

    public float speed = 0.8f;
    public float speed1 = 0.8f;
    private TextMesh caption = null;

    Animator anim;
    Rigidbody2D rb2d;
    Vector2 mov;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.8f;
        speed1 = 0.8f;
        for(int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).name == "Caption_Text")
            {
                caption = this.transform.GetChild(i).gameObject.GetComponent<TextMesh>();
                caption.text = string.Format("Software_Engineering_Student{0}", photonView.ViewID);
                Points.Points_instance.Pname = caption.text;
            }
        }
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine == true)
        {
            mov = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

            if (mov != Vector2.zero)
            {
                anim.SetFloat("movX", mov.x);
                anim.SetFloat("movY", mov.y);
                anim.SetBool("walking", true);
            }
            else
            {
                anim.SetBool("walking", false);
            }
        }

    }

    void FixedUpdate()
    {
        if (Points.Points_instance.aux == 0)
        {
            speed1 = speed * Points.Points_instance.speed_mul;
            Points.Points_instance.aux=1;
        }
        
        rb2d.MovePosition(rb2d.position + mov * speed1* Time.deltaTime);
    }
}
