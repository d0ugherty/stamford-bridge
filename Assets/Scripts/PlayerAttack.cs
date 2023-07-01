using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/** Moved attack animations into the proper file.
    This is the implementation of the player's attack mechanic.
**/

public class PlayerAttack : MonoBehaviour
{
    public GameObject hitzonePrefab;
    public GameObject player;
    private GameObject clone;
    private bool isFacingRight;
    public Vector2 movementInput;
    private Animator animator;
    public InputAction attackAction;

    private void Start() {
        isFacingRight = true;
        animator = player.GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateFacingDirection();
        if(attackAction.triggered){
            Attack();
        }
    }

    private void OnEnable(){
        attackAction.Enable();
    }

    private void OnDisable(){
        attackAction.Disable();
    }


    /** Instantiates and destroys the hit zone prefab
    **
    **/
    private void Attack() {
        Vector2 spawnPosition = player.transform.position;
        if (isFacingRight){
            spawnPosition += Vector2.right;
        } else if (!isFacingRight) {
            spawnPosition += Vector2.left;
        }

        clone = Instantiate(hitzonePrefab, spawnPosition, Quaternion.identity);

        if (clone != null){
            Destroy(clone, 0.3f);
        }
    }

    /* Keep track of player's direction in order
     * To determine where the hit zone is spawned
     */
    private void UpdateFacingDirection(){
        movementInput = GetComponent<PlayerMovement>().movementInput;

        if (movementInput.x > 0) {
            isFacingRight = true;
        } else if (movementInput.x < 0) {
            isFacingRight = false;
        }
    }
}
