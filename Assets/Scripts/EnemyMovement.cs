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
    private Rigidbody2D rb;
    //tracking
    public float xMovement;
    public float lastXMovement;
    public float yMovement;
    private string type;
    private Vector2 enemyPosition;
    private Vector2 playerPosition;
    public float distToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        destroyZone = GameObject.FindGameObjectWithTag("Destroy Zone").transform;
        type = gameObject.GetComponent<EnemyType>().GetType();
        lastPosition = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
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

        enemyPosition = transform.position;
        playerPosition = player.position;
        distToPlayer = Vector2.Distance(enemyPosition, playerPosition);
        
        if(!IsInAtkDistance()) {
            Vector2 direction = playerPosition - enemyPosition;
            direction.Normalize();
            movementSpeed = 3.0f;
            rb.velocity = Vector2.zero;
            Vector2 movementVelocity = direction * movementSpeed;
            transform.Translate(movementVelocity * Time.deltaTime);
        } else {
            Vector2 direction = playerPosition - enemyPosition;
            movementSpeed = 0.0f;
            direction.Normalize();
        }
    }

    /** Moves the enemy object towards a destroy zone
    **  at the other end of the bridge
    **/
    private void CrossBridge(){
        enemyPosition = transform.position;
        Vector2 destroyPos = destroyZone.position;
        Vector2 direction = destroyPos - enemyPosition;

        direction.Normalize();

        Vector2 movementVelocity = direction * movementSpeed;
        transform.Translate(movementVelocity * Time.deltaTime);
    }

/** Checks distance between an enemy object and the player object
**  Used for attack implementation, movement, and animation control
**/
    public bool IsInAtkDistance(){
        if(distToPlayer <= 2.5f){
            return true;
        } else {
            return false;
        }
    }

    /** Stores the last position of the enemy object
    ** Used for attack implementation, movement, and animation control.
    **/
    private void TrackMovement() {
        Vector2 movement = (Vector2)transform.position - lastPosition;
        lastPosition = transform.position;
        xMovement = movement.x;
        yMovement = movement.y;

        if(xMovement != 0f){
            lastXMovement = xMovement;
        }
    }
}
