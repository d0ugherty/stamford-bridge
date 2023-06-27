using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemies : MonoBehaviour
{
    private GameManager gameManager;
    private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spawnManager = gameManager.GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Enemy")){
            DestroyEnemyObject(other.gameObject);
        }
    }

    private void DestroyEnemyObject(GameObject enemy) {
        float delay = 0.5f;
        Debug.Log("DestroyEnemyObject called");
        //Destroy(enemy, delay);

        StartCoroutine(UpdateCurrentEnemies(delay, enemy));
    }

    private IEnumerator UpdateCurrentEnemies(float delay, GameObject enemy) {
        yield return new WaitForSeconds(delay);
        if(enemy!= null){
            Debug.Log("Updating currentEnemies");
            spawnManager.SetCurrentEnemies(-1); // Decrease the currentEnemies count
            Destroy(enemy);
        }
    }
}
