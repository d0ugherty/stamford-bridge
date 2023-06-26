using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/***    This script controls and tracks the movement of the enemy object
**      Currently, it is a simple "move towards player" method to control the movement
**/
public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    private Transform player;
    private Vector2 lastPosition;
    public Transform bridgeOtherSide;
    public Transform destroyZone;
    public float xMovement;
    public float yMovement;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //bridgeOtherSide = GameObject.FindGameObjectWithTag("Other Side").transform;
        destroyZone = GameObject.FindGameObjectWithTag("Destroy Zone").transform;
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        TrackMovement();
        //MoveTowardsPlayer();
        CrossBridge();
    }

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

    private void CrossBridge(){
        Vector2 enemyPosition = transform.position;
        Vector2 destroyPos = destroyZone.position;
        Vector2 direction = destroyPos - enemyPosition;

        direction.Normalize();

        Vector2 movementVelocity = direction * movementSpeed;

        transform.Translate(movementVelocity * Time.deltaTime);
    }

    private void TrackMovement() {
        Vector2 movement = (Vector2)transform.position - lastPosition;

        lastPosition = transform.position;
        xMovement = movement.x;
        yMovement = movement.y;
    }
}
