using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed;
    public float moveTime;

    private bool dirRight = true;
    private float timer;


    // Update is called once per frame
    void Update()
    {
        if (dirRight)
        {
            //Se verdadeiro a serra vai para direita
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            //Se falso a serra vai para a esquerda
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        timer += Time.deltaTime; //Incrementando o timer e a função deltaTime pega o tempo real do jogo e implementa na variavel 
        if(timer >= moveTime)
        {
            dirRight = !dirRight;
            timer = 0f;
        }
    }
}
