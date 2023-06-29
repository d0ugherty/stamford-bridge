using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAnimations : MonoBehaviour
{

    public Animator animator;
    public GameObject enemy;
    private EnemyMovement enemyMovement;
   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsWalking()) {
            Walk();
        }

    }

    /** Detect movement of enemy object
    ** Returns true if X or Y values do not equal zero
    ** otherwise returns false
    */
    private bool IsWalking(){
        if(enemyMovement.xMovement != 0f || enemyMovement.yMovement != 0f) {
            animator.SetBool("IsWalking", true);
            return true;
        } else {
            animator.SetBool("IsWalking", false);
            return false;
        }
    }

     /** Determine which animation to use depending on player movement directon
     **
     **/
    private void Walk() {
        animator.SetFloat("XInput", enemyMovement.xMovement);
        animator.SetFloat("YInput", enemyMovement.yMovement);

    }
}
