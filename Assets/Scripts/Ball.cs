using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private float m_MaxSpeed;

    [SerializeField]
    private float m_SpeedIncBy;

    private Rigidbody2D m_RigidBody2D;
    private Vector2 m_Velocity;

    private float m_InitialSpeed;
    private Vector3 m_InitialPosition;


    void Start()
    {
        m_RigidBody2D = GetComponent<Rigidbody2D>();
        m_Velocity = m_RigidBody2D.velocity;    
    }

    void FixedUpdate()
    {
        
    }
}
