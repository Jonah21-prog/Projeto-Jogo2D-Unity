using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;
    public static GameController instance;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString(); //Manipula o texto, modificando o total score 
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);  //Função que ativa um objeto que estava desativado na cena
    }

    public void RestartGame(string LvlName)
    {
        SceneManager.LoadScene(LvlName);
    }
}
