using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    private float direction;
    private bool isProjectileActive = false;
    private Rigidbody2D currentProjectile;
    public float distance;
    public Rigidbody2D projectile;

    // Update is called once per frame
    void Update()
    {
        direction = transform.localScale.x;

        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isProjectileActive){
            Vector2 projectileVelocity = new Vector2(distance * direction, 0f);
            projectile = Resources.Load<Rigidbody2D>("Prefabs/Projectile.prefab");

            Rigidbody2D clone = Instantiate(projectile, transform.position, Quaternion.identity);
            clone.velocity = projectileVelocity;
            isProjectileActive = true;
        }

       // if (currentProjectile != null && currentProjectile.GetComponent<Projectile>().IsDestroyed) {
         //   currentProjectile = null;
           // isProjectileActive = false;
        //}

    }
}
