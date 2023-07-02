using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public int hitsTaken;
    public TextMeshProUGUI hitsTxt;
    public TextMeshProUGUI scoreText;
    public int enemiesCrossed;
    public TextMeshProUGUI enemiesCrossedTxt;
    public int atksBlocked;
    public TextMeshProUGUI atksBlockedTxt;
    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScoreText();
        enemiesCrossed = 0;
        UpdateCrossedTxt();
        hitsTaken = 0;
        UpdateHitsTxt();
        atksBlocked = 0;
        UpdateAtksBlockedTxt();
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

    public void SetHitsTaken(int n) {
        hitsTaken += n;
        UpdateHitsTxt();
    }

    public void SetAttksBlocked(int n) {
        atksBlocked += n;
        UpdateAtksBlockedTxt();
    }

    private void UpdateScoreText(){
        scoreText.text = "Foemen Hewed: " + score;
    }

    private void UpdateCrossedTxt(){
        enemiesCrossedTxt.text = "Foemen Crossed: " + enemiesCrossed;
    }

    private void UpdateHitsTxt(){
        hitsTxt.text = "Hits Taken " + hitsTaken;
    }

    private void UpdateAtksBlockedTxt(){
        atksBlockedTxt.text = "Attacks Blocked " + atksBlocked;
    }

    private void GameOver(){
        SceneManager.LoadScene("MainMenu");
    }
}
