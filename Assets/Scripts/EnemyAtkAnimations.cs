using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtkAnimations : MonoBehaviour
{
    public GameObject hitzonePrefab;
    private Animator animator;
    public bool isFacingRight;
    private GameObject player;
    private GameObject clone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollision2DEnter(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
           Attack();
        }
     }
     
     public void Attack(){
        animator.SetBool("IsAttacking", true);
    }
}
