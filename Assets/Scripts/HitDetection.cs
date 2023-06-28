using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitDetection : MonoBehaviour
{
    public GameManager gameManager;
    public SpawnManager spawnManager;
    private EnemyMovement enemyMovement;
    private Flash flash;
    public Renderer enemyRenderer;

    
    //public Collider2D enemyCollider;
    //public Collider2D playerHitZone;

    //public string objectToDestroy = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spawnManager = gameManager.GetComponent<SpawnManager>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Enemy")){
            enemyMovement = other.gameObject.GetComponent<EnemyMovement>();
            enemyRenderer = other.gameObject.GetComponent<Renderer>();
            enemyMovement.movementSpeed = 0;
            
            flash = other.gameObject.GetComponent<Flash>();
            flash.TakeHit(enemyRenderer);
            DestroyEnemyObject(other.gameObject);
        }
    }

    private void DestroyEnemyObject(GameObject enemy) {
        float delay = 0.2f;
        Debug.Log("DestroyEnemyObject called");
        //Destroy(enemy, delay);

        StartCoroutine(UpdateCurrentEnemies(delay, enemy));
    }

    private IEnumerator UpdateCurrentEnemies(float delay, GameObject enemy) {
        yield return new WaitForSeconds(delay);
        if(enemy!= null){
            Debug.Log("Updating currentEnemies");
            spawnManager.SetCurrentEnemies(-1); // Decrease the currentEnemies count
            gameManager.SetScore(1);
            Destroy(enemy);
        }
    }

}

