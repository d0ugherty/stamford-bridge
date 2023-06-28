using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/***    This script controls and tracks the movement of the enemy object
**      Currently, it is a simple "move towards player" method to control the movement
**/
public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed;
    private Transform player;
    private Vector2 lastPosition;
    private GameObject enemy;
    private Transform destroyZone;
    public float xMovement;
    public float yMovement;
    private string type;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        destroyZone = GameObject.FindGameObjectWithTag("Destroy Zone").transform;
        type = gameObject.GetComponent<EnemyType>().GetType();
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        TrackMovement();
        Move();

    }

    private void Move(){
         if(type == "Fighter") {
            MoveTowardsPlayer();
        } else if(type == "Runner"){
            CrossBridge();
        }
    }

    /** Moves the enemy object towards the player's current positon
    **/
    private void MoveTowardsPlayer() {
        
        if (player == null) {
            return;
        }

        Vector2 enemyPosition = transform.position;
        Vector2 playerPosition = player.position;

        Vector2 direction = playerPosition - enemyPosition;
        direction.Normalize();

        Vector2 movementVelocity = direction * movementSpeed;
        transform.Translate(movementVelocity * Time.deltaTime);
     
    }

    /** Moves the enemy object towards a destroy zone
    **  at the other end of the bridge
    **/
    private void CrossBridge(){
        Vector2 enemyPosition = transform.position;
        Vector2 destroyPos = destroyZone.position;
        Vector2 direction = destroyPos - enemyPosition;

        direction.Normalize();

        Vector2 movementVelocity = direction * movementSpeed;

        transform.Translate(movementVelocity * Time.deltaTime);
    }

    /** Stores the last position of the enemy objec
    **/
        private void TrackMovement() {
        Vector2 movement = (Vector2)transform.position - lastPosition;

        lastPosition = transform.position;
        xMovement = movement.x;
        yMovement = movement.y;
    }
}
