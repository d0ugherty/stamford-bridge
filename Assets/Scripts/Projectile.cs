using UnityEngine;

public class Projectile : MonoBehaviour {

    private Vector2 initialPosition;
    public float maxDistance;
    public bool IsDestroyed = false;
    public GameObject gameObject;

    private void Start(){
        initialPosition = transform.position;
    }

    private void Update() {
        float distance = Vector2.Distance(initialPosition, transform.position);

        if (distance >= maxDistance) {
            IsDestroyed = true;
            Destroy(gameObject);
        }
    }
}