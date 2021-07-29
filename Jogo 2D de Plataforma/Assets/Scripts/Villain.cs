using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villain : MonoBehaviour
{
    private Rigidbody2D rig ;
    private Animator anim;

    public float speed;

    public LayerMask layer;
    public Transform rightCol;        //Dois pontos para definir a rota do personagem
    public Transform leftCol;

    public Transform headPoint;     // O inimigo morrerá estilo mário ( com um pisão na cabeça

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;

    private bool colliding;     //Nome sugestivo: Detectar a colisão

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y); //Defino que meu personagem se movimenta unicamente para os lados

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer); //Criei dois objetos invisíveis a direita e a esquerda do vilão 

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y); //Aqui eu rotaciono o eixo x em -1
            speed *= -1f;
        }
        bool playerDestroyed;
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                float height = col.contacts[0].point.y - headPoint.position.y; //Checo se a posição do box collider é menor que a do headposition
                Debug.Log(height);
                if (height > 0 && !playerDestroyed)
                {
                    col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                    speed = 0;
                    anim.SetTrigger("Die");
                    boxCollider2D.enabled = false;
                    circleCollider2D.enabled = false;
                    rig.bodyType = RigidbodyType2D.Kinematic;

                    Destroy(gameObject, 0.33f); //Faço aqui com que a animação e o efeito do pulo sejam executadas
                }
                else
                {
                    playerDestroyed = true;
                    GameController.instance.ShowGameOver();
                    Destroy(col.gameObject);
                }
            }

        }
    }
}
