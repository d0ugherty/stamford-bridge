using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float flightSpeed;
    public float m_Lifespan = 3.0f;
    private Transform player;
    private Vector2 initialPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player != null) {
            initialPlayerPosition = player.position;
        }   

        Destroy(gameObject, m_Lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        FlyTowardsPlayer();
    }

    private void FlyTowardsPlayer() {
        if (player == null){
            return;
        }

        Vector2 directionToPlayer = initialPlayerPosition - (Vector2)transform.position;

        Vector2 normalizedDirection = directionToPlayer.normalized;

        float distanceToMove = flightSpeed * Time.deltaTime;

        transform.Translate(normalizedDirection * distanceToMove);

        float angle = Mathf.Atan2(normalizedDirection.y, normalizedDirection.x) * Mathf.Rad2Deg;

        Transform arrowHeadTransform = transform.Find("head"); // Replace "ArrowHead" with the actual name of the arrow head GameObject
        if (arrowHeadTransform != null)
        {
            arrowHeadTransform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
