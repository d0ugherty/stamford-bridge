using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitDetection : MonoBehaviour
{
    public GameManager gameManager;
    public SpawnManager spawnManager;
    //public string objectToDestroy = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spawnManager = gameManager.GetComponent<SpawnManager>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Enemy")){
            DestroyEnemyObject(other.gameObject);
        }
    }

    private void DestroyEnemyObject(GameObject enemy) {
        float delay = 0.275f;
        Debug.Log("DestroyEnemyObject called");
        //Destroy(enemy, delay);

        StartCoroutine(UpdateCurrentEnemies(delay, enemy));
    }

    private IEnumerator UpdateCurrentEnemies(float delay, GameObject enemy) {
        yield return new WaitForSeconds(delay);
        if(enemy!= null){
            Debug.Log("Updating currentEnemies");
            spawnManager.SetCurrentEnemies(-1); // Decrease the currentEnemies count
            gameManager.SetScore(5);
            Destroy(enemy);
        }
    }

}

