using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float direction;
    public float distance;
    public Rigidbody2D projectile;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = transform.localScale.x;

        if (Keyboard.current.spaceKey.isPressed){
            Rigid2D clone = Instantiate(projectile, transform.postion, transform.rotation);
            clone.GetComponent<ProjectileHitDetection>().gameManager = gameManager;
            clone.velocity
        }
    }
}
