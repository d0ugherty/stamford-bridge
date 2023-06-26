using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public int enemiesCrossed;
    public Text enemiesCrossedTxt;
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
        GameOver();
        
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
        scoreText.text = "Score: " + score;
    }

    private void UpdateCrossedTxt(){
        enemiesCrossedTxt.text = enemiesCrossed + " English have crossed the bridge!";
    }

    private void GameOver(){

    }
}
