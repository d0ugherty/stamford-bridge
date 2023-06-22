using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    public GameObject projectilePrefab;
    private Rigidbody2D playerRigidBody;
    public float projectileSpeed = 5f;
    public float maxDistance = 5f;

    private bool isAttacking = false;

    private void Start() {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isAttacking)
        {
            isAttacking = true;
            playerRigidBody.isKinematic = true;
            Vector2 projectileDirection = transform.localScale.x > 0f ? Vector2.right : Vector2.left;

            GameObject projectileClone = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D projectileRigidbody = projectileClone.GetComponent<Rigidbody2D>();
            projectileRigidbody.velocity = projectileDirection * projectileSpeed;

            StartCoroutine(ResetPlayerPhysics(projectileClone));
        }
    }

    private IEnumerator ResetPlayerPhysics(GameObject obj){
        yield return new WaitForSeconds(maxDistance / projectileSpeed);
        Destroy(obj, maxDistance / projectileSpeed);
        playerRigidBody.isKinematic = false;
        isAttacking = false;
    }

    /*private float direction;
    private bool isProjectileActive = false;
    private Rigidbody2D currentProjectile;
    public float distance;
    public Rigidbody2D projectile; //projectile
    public Rigidbody2D clone;
    private Vector2 initialPosition;
    public float maxDistance;
    public bool IsDestroyed = false;

    // Update is called once per frame
    /*void Update()
    {
        direction = transform.localScale.x;

        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isProjectileActive){
            Vector2 projectileVelocity = new Vector2(distance * direction, 0f);
            //projectile = Resources.Load<Rigidbody2D>("Prefabs/Projectile.prefab");

            clone  = Instantiate(projectile, transform.position, Quaternion.identity);
            clone.velocity = projectileVelocity;
            isProjectileActive = true;
        }

        initialPosition = transform.position;

        float travel = Vector2.Distance(initialPosition, transform.position);

        if (travel >= maxDistance && clone != null) {
            IsDestroyed = true;
            Destroy(clone.gameObject);
        }
    }*/


}
