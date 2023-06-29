using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtkAnimations : MonoBehaviour
{
    public GameObject hitzonePrefab;
    private Animator animator;
    private float distToPlayer;
    private GameObject player;
    private GameObject clone;
    private EnemyMovement mv;
    //for tracking
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        mv = gameObject.GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("XAtkDirection", mv.lastXMovement);
        if(mv.IsInAtkDistance()){
            Attack();
        } else {
            //animator.SetBool("IsAttacking", false);
        }
    }

     /*void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
           Attack();
        } else {
            animator.SetBool("IsAttacking", false);
        }
     }*/
     
     private void Attack(){
        animator.SetTrigger("Attack");
        ResetTriggerDelayed("Attack");
        //animator.SetBool("IsAttacking", true);
    }

    /** Coroutine & method to invoke the coroutine to delay the trigger reset
    **  if ResetTrigger() is called without a delay, the 
    ** the attack trigger is reset before the animation can play
    */

    private IEnumerator DelayTriggerReset(string triggerName){
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f) {
                yield return null;
        }
        animator.ResetTrigger(triggerName);
    }

    private void ResetTriggerDelayed(string triggerName){
        StartCoroutine(DelayTriggerReset(triggerName));
    }
}
