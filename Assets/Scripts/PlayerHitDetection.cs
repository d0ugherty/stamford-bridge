using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHitDetection : MonoBehaviour
{
    public GameManager gameManager;
    public SpawnManager spawnManager;
    private EnemyMovement enemyMovement;
    private Flash flash;
    public Renderer enemyRenderer;
    
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

    /** Forces an enemy backwards when it is hit by the player 
    **
    **/
    private void PushEnemy(Collider2D other){
        Vector2 playerPosition = transform.position; 
        Vector2 enemyPosition = other.transform.position;
        Vector2 pushDirection = (enemyPosition - playerPosition).normalized;
        Rigidbody2D enemyRigidbody = other.gameObject.GetComponent<Rigidbody2D>();

        float pushForce = 10f;

        enemyRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
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

