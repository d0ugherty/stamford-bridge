using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public float rate;
    public float setrate;
    public float difficulty;
    int count = 0;
    public GameObject enemy;
    public Transform min;
    public Transform max;

    // Start is called before the first frame update
    void Awake()
    {
        setrate = rate;
    }

    // Update is called once per frame
    void Update()
    {
        if (count < 5) {
            Spawn();
            count++;
        }
    }
    /** Spawn enemies 
    **  I should really learn how how this acutally works with the difficulty stuff
    **/
    void Spawn() {
        float randomPosX = Random.Range(min.position.x, max.position.x);
        float randomPosY = Random.Range(min.position.y, max.position.y);
        Vector3 randomPos = new Vector3(randomPosX, randomPosY, transform.position.z);
    
        GameObject clone = Instantiate(enemy, randomPos, Quaternion.identity);
        int id = GenerateId();
        clone.name = "Enemy_" + id;
        //automatically attach the EnemyID script containing a unique id
        clone.AddComponent<EnemyID>().SetId(id);
        
        if (difficulty >= setrate / 2) {
            difficulty = setrate / 2;
        } else {
            difficulty += difficulty;
        }
    }

    /** Generate a unique ID for each enemy object
    **  Used for hit detection 
    **/
    private int GenerateId(){
        return Random.Range(1000,10000);
    }
}
