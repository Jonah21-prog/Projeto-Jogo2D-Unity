using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator anim;

     void Start()
    {
        anim = GetComponent<Animator>();
    }
    public float jumpForce;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Jump");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }//Add a fun��o de pulo no trampolin. Com For�a e medi��o da mesma usando o mesmo m�todo que foi usado na classe Player
    }
}
