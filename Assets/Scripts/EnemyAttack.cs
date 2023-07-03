using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject hitzonePrefab;
    public GameObject clone;
    public AudioManager audioManager;
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
        audioManager = FindObjectOfType<AudioManager>();
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
            audioManager.Play("sword2");
            flash.TakeHit(playerRenderer);
            gameManager.DecHP();
        } else {
            audioManager.Play("sword4");
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
