using UnityEngine;


public class Projectile : MonoBehaviour
{
    public float m_Speed = 10f;   // this is the projectile's speed
    public float m_Lifespan = 0.5f; // this is the projectile's lifespan (in seconds)
    private Rigidbody2D m_Rigidbody;

  
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        m_Rigidbody.AddForce(m_Rigidbody.transform.forward * m_Speed);
        m_Rigidbody.velocity = transform.right * m_Speed;
        Destroy(gameObject, m_Lifespan);
    }
}