using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject hitzonePrefab;
    public GameObject clone;
    private EnemyMovement mv;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        mv = gameObject.GetComponent<EnemyMovement>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
      if(mv.IsInAtkDistance()){
        Attack();
      }   
    }

    private void Attack(){
        Flash flash = player.gameObject.GetComponent<Flash>();
        Renderer playerRenderer = player.gameObject.GetComponent<Renderer>();
        flash.TakeHit(playerRenderer);
    }

    /*private void Attack(){
        Vector2 spawnPosition = gameObject.transform.position;
        if(mv.lastXMovement > 0.0f) {
            spawnPosition += Vector2.right;
        } else if (mv.lastXMovement < 0.0f) {
            spawnPosition += Vector2.left;
        }
        
        //clone = Instantiate(hitzonePrefab, spawnPosition, Quaternion.identity);
        
         if (clone != null) {
            Destroy(clone, 0.3f);
        }
    }*/

}
