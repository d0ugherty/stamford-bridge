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

        if (horizontalInput != 0f || verticalInput != 0f) {
            animator.SetBool("IsWalking", true);
            Walk();
        } else {
            animator.SetBool("IsWalking", false);
            Debug.Log("is walking: " + animator.GetBool("IsWalking"));
        }
    }

    void Walk(){
        animator.SetFloat("XInput", horizontalInput);
        animator.SetFloat("YInput", verticalInput);

        movementInput = new Vector2(horizontalInput, verticalInput);
        animator.SetFloat("Direction", movementInput.magnitude);
    }
}

