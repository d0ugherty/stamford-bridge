using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public GameObject hitzonePrefab;
    public GameObject player;
    private GameObject clone;
    private bool isFacingRight;
    private Rigidbody2D playerRigidBody;
    public PlayerInput playerInput;
    private float horizontalInput;
    private float verticalInput;

    private void Start() {
        playerRigidBody = GetComponent<Rigidbody2D>();
        isFacingRight = true;
    }

    private void Update()
    {
        GetPlayerInput();
        UpdateFacingDirection();
        //Debug.Log("is facing right " + isFacingRight);
        Attack();
    }

    private void Attack() {
        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            Vector2 spawnPosition = player.transform.position;
            if (isFacingRight){
                spawnPosition += Vector2.right;
            } else if (!isFacingRight) {
                spawnPosition += Vector2.left;
            }

            clone = Instantiate(hitzonePrefab, spawnPosition, Quaternion.identity);
        }

        if (clone != null){
            Destroy(clone, 0.3f);
        }
    }

    /* Keep track of player's direction in order
     * To determine where the hit zone is spawned
     */
    private void UpdateFacingDirection(){
        if (horizontalInput > 0) {
            isFacingRight = true;
        } else if (horizontalInput < 0) {
            isFacingRight = false;
        }
    }

    private void GetPlayerInput(){
        horizontalInput = playerInput.actions["Move"].ReadValue<Vector2>().x;
        verticalInput = playerInput.actions["Move"].ReadValue<Vector2>().y;
    }
}





/*private IEnumerator ResetPlayerPhysics(){
        yield return new WaitForSeconds(0.5f);
        //Destroy(obj, maxDistance / projectileSpeed);
        playerRigidBody.isKinematic = false;
        isAttacking = false;
    }

    playerRigidBody.isKinematic = true;

            Vector2 projectileDirection =  isFacingRight ? Vector2.right : Vector2.left;

            GameObject clone = Instantiate(projectilePrefab, m_SpawnTransform.position, Quaternion.identity);
            if (isFacingRight) {
                clone.transform.right = transform.right.normalized;
            } else {
                //clone.transform.left = transform.left.normalized;
            }
            
            //Rigidbody2D projectileRigidbody = projectileClone.GetComponent<Rigidbody2D>();
            //projectileRigidbody.velocity = projectileDirection * projectileSpeed;

            //Debug.Log("isFacingRight: " + isFacingRight);
           // Debug.Log("projectileDirection: " + projectileDirection);
            //Debug.Log(movementInput.x);


            StartCoroutine(ResetPlayerPhysics());
        }*/



