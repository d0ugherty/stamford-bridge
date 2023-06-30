using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Script attached to an invisible object to
** detect when an enemy has crossed the bridge. 
** After an enemy has crossed, the enemiesCrossed property in the
** Game manager is incremented.
*/
public class CrossingManager : MonoBehaviour
{
    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

/** Increments enemiesCrossed in the game manager after an enemy
**  has crossed the bridge.
*/
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")) {
            Debug.Log("Enemy has crossed the bridge!");
            gameManager.SetEnemiesCrossed(1);
        }
    }
}
