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
        // Aqui o rig irá receber o componente Rigidbody que está anexado a esse script
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Jump();
    }
    void move()
    {// Função do Movimento horizontal
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); 

        // Aqui a variavel Vector3 recebe uma nova variavel Vector3 com as posições 0 no y e 0 no z (0f em ambos)
        // Horizontal já tem algumas configurações pré determinadas dentro do prórpio Unity

        //transform.position += movement * Time.deltaTime * speed;

        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        //Aqui nesses IF a condição de ser maior, menor ou igual a zero é quem determina se o MC está andando para direita
        // esquerda ou simplesmente está parado respectivamente.

        if (movement > 0f)
        {
            anim.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f); // eulerAngels permite rotacionar o objeto 
        }
        if (movement < 0f)
        {
            anim.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (movement == 0f)
        {
            anim.SetBool("Walk", false);
        }


    }
    void Jump()
    {// Função do pulo vertical 
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            } //Se eu estiver pulando essa condição fica como verdadeira
            else
            {
                if (doubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce ), ForceMode2D.Impulse);
                    doubleJump = false;
                    // anim.SetBool("jump", false);
                }// Se eu pressionar novamente o pulo caio nessa condição ---- Evita que haja "pulos infinitos no ar"
            }
           
        }

    // Implementano o pulo duplo...
    void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.layer == 8)
            {
                isJumping = false;
                anim.SetBool("Jump", false);
            }

            if (collision.gameObject.tag == "Spike")
            {
               // Destroy(gameObject);
                GameController.instance.ShowGameOver();
                
                return;
            }  // Nessa função, ao detectar a colisão com os espinhos o gameObject (nosso personagem) é destruido 
            if (collision.gameObject.tag == "Saw")
            {
                GameController.instance.ShowGameOver();
                Destroy(gameObject);
            }
        }
    
    void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 8)
            {
                isJumping = true;
            }
        }
    // Fim da Implementação do pulo duplo
    }
}
