using UnityEngine;

public class SwordHit : MonoBehaviour
{
    public int damageAmount = 10;

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the target object
        if (collision.gameObject.CompareTag("Target"))
        {
            // Apply the desired effects
            Debug.Log("Sword hit!");

            // Deal damage to the target object (you can implement your own health system)
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damageAmount);
            }
        }
    }*/
}
