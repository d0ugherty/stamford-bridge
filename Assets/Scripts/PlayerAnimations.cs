using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimations : MonoBehaviour
{
    public Animator animator;
    public InputAction attackAction;
    public InputAction blockAction;
    private PlayerInput playerInput;
    public Vector2 movementInput;


    private void Awake() {
        //playerInput = GetComponent<PlayerInput>();
        //movementInput = GetComponent<PlayerMovement>().movementInput;
    }

    private void Update() {
        movementInput = GetComponent<PlayerMovement>().movementInput;

        if(IsWalking()) {
            Walk();
        }
        if(attackAction.triggered) { 
            Debug.Log("Action Variable triggered");
            Attack();
        }

        if(blockAction.triggered) {
            Debug.Log("block action triggered");
            Block();
        }
        
    }

    private void OnEnable() {
        attackAction.Enable();
        blockAction.Enable();
    }

    private void OnDisable() {
        attackAction.Disable();
        blockAction.Disable();
    }

    /** Detect vertical and horizontal input
    **  Returns true if X or Y values do not equal zero
    **  otherwise returns false
    */
    private bool IsWalking(){
       if (movementInput != Vector2.zero) {
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
        animator.SetFloat("Xinput", movementInput.x);
        animator.SetFloat("Yinput", movementInput.y);
    }

    /** Check if the space key is being pressed
     **  if so, trigger the attack animation
     **/
    private void Attack() {
        animator.SetTrigger("PlayerAttack");
        ResetTriggerDelayed("PlayerAttack");
    }

    /** Block/shield animation trigger 
    **/
    private void Block() {
        animator.SetBool("Block", true);
    }

    /** Coroutine & method to invoke the coroutine to delay the trigger reset
    **  if ResetTrigger() is called without a delay, the 
    ** the attack trigger is reset before the animation can play
    */
    private IEnumerator DelayTriggerReset(string triggerName){
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f) {
                yield return null;
        }
        animator.ResetTrigger(triggerName);
    }

    private void ResetTriggerDelayed(string triggerName){
        StartCoroutine(DelayTriggerReset(triggerName));
    }
}

