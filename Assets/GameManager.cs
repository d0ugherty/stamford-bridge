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
    public TextMeshProUGUI hpTxt;
    public TextMeshProUGUI scoreText;
    public int enemiesCrossed;
    public TextMeshProUGUI enemiesCrossedTxt;
    public int atksBlocked;
    public TextMeshProUGUI atksBlockedTxt;
    private string hpString;
    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScoreText();
        enemiesCrossed = 0;
        UpdateCrossedTxt();
        //hitsTaken = 0;
        hpString = "zZzZzZzZzZ";
        UpdateHPTxt();
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

    private void UpdateHPTxt(){
        hpTxt.text = hpString;
    }

    private void UpdateAtksBlockedTxt(){
        atksBlockedTxt.text = "Attacks Blocked " + atksBlocked;
    }

    private void GameOver(){
        SceneManager.LoadScene("MainMenu");
    }

    public void DecHP(){
        hpString = TrimLastCharacter(hpString);
        UpdateHPTxt();
    }


    private static string TrimLastCharacter(string hpString) {
        if (string.IsNullOrEmpty(hpString) ||hpString.Length == 1){
            return string.Empty;
        } else {
            return hpString.Substring(0, hpString.Length - 1);
        }
    }
}
