using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float rate;
    public float setrate;
    public float difficulty;
    public GameObject enemy_run;
    public GameObject enemy_atk;
    public Transform min;
    public Transform max;

    private int maxEnemies;
    private float value;
    public int currentEnemies;

    // Start is called before the first frame update
    void Awake()
    {
        setrate = rate;
        maxEnemies = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentEnemies < maxEnemies) {
            value = Random.Range(0f,1f);
            Spawn(value);
        }
       
    }

    /** Spawn enemies 
    **  If the random value is greater than .5, an enemy runner will spawn
    **  If it is less than or equal to 0.5, an enemy attackeer will spawn
    **  
    **  Runners will move straight towards the other side of the bridge
    **  Fighters will move towards and engage the player
    **/
    void Spawn(float value) {
        float randomPosX = Random.Range(min.position.x, max.position.x);
        float randomPosY = Random.Range(min.position.y, max.position.y);
        Vector3 randomPos = new Vector3(randomPosX, randomPosY, transform.position.z);
    
        if(value > 0.5) {
            GameObject clone = Instantiate(enemy_run, randomPos, Quaternion.identity);
            clone.tag = "Enemy";

            clone.AddComponent<EnemyType>().SetType("Runner");
            clone.name = "Enemy_" + clone.GetType();
            currentEnemies++;

        } else { 
            GameObject clone = Instantiate(enemy_atk, randomPos, Quaternion.identity);
            clone.tag = "Enemy";
    
            clone.AddComponent<EnemyType>().SetType("Fighter");
            clone.name = "Enemy_" + clone.GetType();
            currentEnemies++;
        }

        /*if (difficulty >= setrate / 2) {
            difficulty = setrate / 2;
        } else {
            difficulty += difficulty;
        }*/
    }

    public void SetCurrentEnemies(int number){
        currentEnemies += number;
        Debug.Log("Current enemies: " + currentEnemies);
    }

    /** Generate a unique ID for each enemy object
    **  Used for hit detection 
    **/
    private int GenerateId(){
        return Random.Range(1000,10000);
    }
}
