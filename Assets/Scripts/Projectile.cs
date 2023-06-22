using UnityEngine;
using UnityEngine.InputSystem;


public class Projectile : MonoBehaviour
{
    public float m_Speed = 10f;   // this is the projectile's speed
    public float m_Lifespan = 0.5f; // this is the projectile's lifespan (in seconds)
    private Rigidbody2D m_Rigidbody;
    private Vector2 movementInput;

  
    void Awake()
    {
        //m_Rigidbody = GetComponent<Rigidbody2D>();
       // movementInput = value.Get<Vector2>();
    }

    void Start()
    {
       // m_Rigidbody.AddForce(Vector3.forward * m_Speed);
       // m_Rigidbody.velocity = Vector3.forward * m_Speed;
      // m_Rigidbody.transform.Translate(Vector3.forward, Space.World);
      //  Destroy(gameObject, m_Lifespan);
    }
}