using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public GameObject hitzonePrefab;
    private Rigidbody2D playerRigidBody;
    private Vector2 movementInput;
    private bool isAttacking;
    private bool isFacingRight;

    private void Start() {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateFacingDirection();
        Attack();
    }

    private void Attack() {
        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            GameObject clone = Instantiate(hitzonePrefab, transform.position, Quaternion.identity);
        }
    }

    private void UpdateFacingDirection(){
        if (movementInput.x > 0) {
            isFacingRight = true;
        } else if (movementInput.x < 0) {
            isFacingRight = false;
        }
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



