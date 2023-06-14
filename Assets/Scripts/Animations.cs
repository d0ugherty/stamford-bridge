using UnityEngine;
using UnityEngine.InputSystem;

public class Animations : MonoBehaviour
{
    public Animator animator;
    public float horizontalInput;
    public float verticalInput;
    private Vector2 movementInput;
    private bool isFacingRight;

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(horizontalInput < 0.0f){
            isFacingRight = false;
            //Flip();
        } else {
            isFacingRight = true;
        }

        if (horizontalInput != 0f || verticalInput != 0f) {
            animator.SetBool("IsWalking", true);
            //Walk();
        } else {
            animator.SetBool("IsWalking", false);
            //Walk();
            Debug.Log("is walking: " + animator.GetBool("IsWalking"));
        }
    }
    /** Not doing anything. 
     ** X & Y inputs are being registered without this method 
     **/
    void Walk(){
        animator.SetFloat("XInput", horizontalInput);
        animator.SetFloat("YInput", verticalInput);

        movementInput = new Vector2(horizontalInput, verticalInput);
        animator.SetFloat("Direction", movementInput.magnitude);
    }
    /** hacky. causes a flicker effect and not really working as intended **/
    void Flip(){
    
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}

