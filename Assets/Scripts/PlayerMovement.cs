using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    
    public float speed;
    public Animator animator;
    private Vector2 movementInput;
    private Vector2 lastMovementInput;


    private void Start(){
        animator = GetComponent<Animator>();
    }

    private void OnMove(InputValue value){
        movementInput = value.Get<Vector2>();
    }

    private void Update(){
        Move();
        UpdateAnimation();
    }

    private void Move() {
        Vector2 movement = movementInput * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    /**Fixes animation jank**/
     private void UpdateAnimation() {
        if (movementInput.x != 0 || movementInput.y != 0){
            lastMovementInput = movementInput;
        }

        if (lastMovementInput.x < 0){
            animator.SetBool("isMovingLeft", true);
        } else {
            animator.SetBool("isMovingLeft", false);
        }
    }

}