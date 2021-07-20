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
        // Aqui o rig ir� receber o componente Rigidbody que est� anexado a esse script
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
        // HOrizontal j� tem algumas configura��es pr� determinadas dentro do pr�rpio Unity
        transform.position += movement * Time.deltaTime * speed;

    }
    void Jump()
    {// Fun��o do pulo vertical 
        if (Input.GetButtonDown("Jump"))
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }
}
