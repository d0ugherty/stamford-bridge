using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject hitzonePrefab;
    public GameObject clone;
    public bool playerBlocking;
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
        playerBlocking = player.GetComponent<PlayerBlock>().isBlocking;
        if(!playerBlocking){
            Flash flash = player.gameObject.GetComponent<Flash>();
            Renderer playerRenderer = player.gameObject.GetComponent<Renderer>();
            flash.TakeHit(playerRenderer);
        } else {
            Debug.Log("Player blocked the attack");
        }
    }

}
