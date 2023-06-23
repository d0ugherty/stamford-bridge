using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int pts){ 
        score += pts;
        UpdateScoreText();
    }

    private void UpdateScoreText(){
        scoreText.text = "Score: " + score;
    }
}
