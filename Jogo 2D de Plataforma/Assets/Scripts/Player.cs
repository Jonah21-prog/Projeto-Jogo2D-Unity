using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    private Rigidbody2D rig;
    private Animator anim;

    public bool isJumping;
    public bool doubleJump;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        // Aqui o rig ir� receber o componente Rigidbody que est� anexado a esse script
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Jump();
    }
    void move()
    {// Fun��o do Movimento horizontal
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); 

        // Aqui a variavel Vector3 recebe uma nova variavel Vector3 com as posi��es 0 no y e 0 no z (0f em ambos)
        // Horizontal j� tem algumas configura��es pr� determinadas dentro do pr�rpio Unity

        transform.position += movement * Time.deltaTime * speed;

        //Aqui nesses IF a condi��o de ser maior, menor ou igual a zero � quem determina se o MC est� andando para direita
        // esquerda ou simplesmente est� parado respectivamente.

        if (Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f); // eulerAngels permite rotacionar o objeto 
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("Walk", false);
        }


    }
    void Jump()
    {// Fun��o do pulo vertical 
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            } //Se eu estiver pulando essa condi��o fica como verdadeira
            else
            {
                if (doubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce * 2f), ForceMode2D.Impulse);
                    doubleJump = false;
                    anim.SetBool("jump", false);
                }// Se eu pressionar novamente o pulo caio nessa condi��o ---- Evita que haja "pulos infinitos no ar"
            }
           
        }

    // Implementano o pulo duplo...
    void OnCollisionEnter2D(Collider2D collision)
        {
            if(collision.gameObject.layer == 8)
            {
                isJumping = false;
            }
        }
    
    void OnCollisionExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 8)
            {
                isJumping = true;
            }
        }
    // Fim da Implementa��o do pulo duplo
    }
}
