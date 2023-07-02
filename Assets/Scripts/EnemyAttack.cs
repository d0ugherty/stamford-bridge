using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject hitzonePrefab;
    public GameObject clone;
    public bool playerBlocking;
    private bool isAttacking;
    private EnemyMovement mv;
    private GameObject player;
    public GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        mv = gameObject.GetComponent<EnemyMovement>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
      if(mv.IsInAtkDistance() && !isAttacking){
        StartCoroutine(AttackCoroutine());
      }   
    }

    private void Attack(){
        playerBlocking = player.GetComponent<PlayerBlock>().isBlocking;
        if(!playerBlocking){
            Flash flash = player.gameObject.GetComponent<Flash>();
            Renderer playerRenderer = player.gameObject.GetComponent<Renderer>();
            flash.TakeHit(playerRenderer);
            gameManager.SetHitsTaken(1);
        } else {
            gameManager.SetAttksBlocked(1);
            Debug.Log("Player blocked the attack");
        }
    }

    private IEnumerator AttackCoroutine(){
        isAttacking = true;
        Attack();
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }

}
