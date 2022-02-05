using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Player : MonoBehaviour
{
    [SerializeField]
    private string m_InputName;
    [SerializeField]
    private float m_Speed;

    private Rigidbody2D m_RigidBody2D;
    private Vector2 m_Velocity;
    
    void Start()
    {
        m_RigidBody2D = GetComponent<Rigidbody2D>();
        m_Velocity = m_RigidBody2D.velocity;
    }

    
    void FixedUpdate()
    {
        m_Velocity.y = Input.GetAxisRaw(m_InputName) * m_Speed;
        m_RigidBody2D.velocity = m_Velocity;
    }
}
