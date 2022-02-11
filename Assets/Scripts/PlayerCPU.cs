using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerCPU : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Ball;    

    [SerializeField]
    private int m_Level;

    [SerializeField]
    private float m_Speed;
    private Rigidbody2D m_RigidBody2D;
    
    void Start()
    {
        m_RigidBody2D = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {   
        float m_lerpSpeed = 0.8f;
        if (m_Ball.transform.position.y > transform.position.y)
        {
            if (m_RigidBody2D.velocity.y < 0) 
                m_RigidBody2D.velocity = Vector2.zero;
            
            m_RigidBody2D.velocity = Vector2.Lerp(m_RigidBody2D.velocity, Vector2.up * m_Speed, m_lerpSpeed * Time.deltaTime);
        }
        else if (m_Ball.transform.position.y < transform.position.y)
        {
            if (m_RigidBody2D.velocity.y > 0) 
                m_RigidBody2D.velocity = Vector2.zero;
            
            m_RigidBody2D.velocity = Vector2.Lerp(m_RigidBody2D.velocity, Vector2.down * m_Speed, m_lerpSpeed * Time.deltaTime);
        }
        else
        {
            m_RigidBody2D.velocity = Vector2.Lerp(m_RigidBody2D.velocity, Vector2.zero * m_Speed, m_lerpSpeed * Time.deltaTime);
        }      
    }
}
