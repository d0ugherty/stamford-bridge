using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator animator;
    public float speed;

    void Start(){
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", true);
        animator.GetBool("isJumping");
    }
    void Update(){
        if (Input.GetButtonUp("Directional Button")) {
            animator.SetBool("IsWalking", false);
        }

        if(Input.GetButton("Directional Buttons")){
            animator.SetBool("IsWalking", true);
            //square_rbody.velocity += (Vector2.up * speed * Time.deltaTime);
            Walk();
        }
        
    }
    
    void Walk(){
        Vector2 facing = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        animator.SetFloat("XInput", facing.x);
        animator.SetFloat("YInput", facing.y);
    }


}
