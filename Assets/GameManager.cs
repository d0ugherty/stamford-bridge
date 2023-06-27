using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public int enemiesCrossed;
    public TextMeshProUGUI enemiesCrossedTxt;
    public 

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScoreText();
        enemiesCrossed = 0;
        UpdateCrossedTxt();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesCrossed >= 15) {
            GameOver();
        }
        
    }

    public void SetScore(int pts){ 
        score += pts;
        UpdateScoreText();
    }

    public void SetEnemiesCrossed(int n){
        enemiesCrossed += n;
        UpdateCrossedTxt();
    }

    private void UpdateScoreText(){
        scoreText.text = "Foemen Hewed: " + score;
    }

    private void UpdateCrossedTxt(){
        enemiesCrossedTxt.text = "Foemen Crossed: " + enemiesCrossed;
    }

    private void GameOver(){
        SceneManager.LoadScene("MainMenu");
    }
}
