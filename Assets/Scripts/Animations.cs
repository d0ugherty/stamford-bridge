using UnityEngine;
using UnityEngine.InputSystem;

public class Animations : MonoBehaviour
{
    public Animator animator;
    public float horizontalInput;
    public float verticalInput;
    private Vector2 movementInput;

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // if player is moving, play walking animation
        if(IsWalking()) {
            Walk();
        } 
    }

    /** Detect vertical and horizontal input
    **  Returns true if X or Y values do not equal zero
    **  otherwise returns false
    */
    private bool IsWalking(){
       if (horizontalInput != 0f || verticalInput != 0f) {
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
    void Walk() {
        animator.SetFloat("Xinput", horizontalInput);
        animator.SetFloat("Yinput", verticalInput);

        movementInput = new Vector2(horizontalInput, verticalInput);
    }

    private bool IsPlayerAttacking() {
        if (Input.GetButtonDown("Fire")){
            animator.SetBool("IsAttacking", true);
            return true;
        } else {
            animator.SetBool("IsAttacking", false);
            return false;
        }
    }

    void PlayerAttack() {

    }
}

