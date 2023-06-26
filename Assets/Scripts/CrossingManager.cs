using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossingManager : MonoBehaviour
{
    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")) {
            Debug.Log("Enemy has crossed the bridge!");
            gameManager.SetEnemiesCrossed(1);
        }
    }
}
