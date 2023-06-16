using System.Collections;
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
        IsPlayerAttacking();
        
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

    /** Check if the space key is being pressed
     **  if so, trigger the attack animation
     **/
    private void IsPlayerAttacking() {
        if (Keyboard.current.spaceKey.wasPressedThisFrame){
            animator.SetTrigger("PlayerAttack");
            ResetTriggerDelayed("PlayerAttack");
            //return true;
        } else {
            //return false;
        }
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

