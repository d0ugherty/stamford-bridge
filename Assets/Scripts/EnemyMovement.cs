using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
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
}
