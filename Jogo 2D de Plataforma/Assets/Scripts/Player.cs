using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        // Aqui o rig irá receber o componente Rigidbody que está anexado a esse script
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Jump();
    }
    void move()
    {// Função do Movimento horizontal
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        // Aqui a variavel Vector3 recebe uma nova variavel Vector3 com as posições 0 no y e 0 no z (0f em ambos)
        // HOrizontal já tem algumas configurações pré determinadas dentro do prórpio Unity
        transform.position += movement * Time.deltaTime * speed;

    }
    void Jump()
    {// Função do pulo vertical 
        if (Input.GetButtonDown("Jump"))
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }
}
