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

    private AudioSource m_AudioSource;

    private Rigidbody2D m_RigidBody2D;
    private Rigidbody2D m_WallMiddle;
    private Vector2 m_Velocity;

    private float m_InitialSpeed;
    private Vector3 m_InitialPosition;


    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        m_Velocity = m_Speed
            * (Random.Range(0,100) < 50 ? Vector2.left : Vector2.right);

        m_RigidBody2D = GetComponent<Rigidbody2D>();
        m_RigidBody2D.velocity = m_Velocity;

        m_InitialSpeed = m_Speed;
        m_InitialPosition = transform.position;   

        m_AudioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        
        
    }

    void OnCollisionEnter2D(Collision2D other) 
    {

        if (other.gameObject.name == "WallMiddle")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        m_AudioSource.Play();        
        switch(other.gameObject.name) 
        {
            case "PaddleP1":
                IncSpeed();
                UpdateVelocity(1.0f, GetHitYAxis(other));
                break;

            case "PaddleP2":
            case "PaddleCPU":
                IncSpeed();
                UpdateVelocity(-1.0f, GetHitYAxis(other));
                break;                

            case "WallUp":
            case "WallBottom":
                UpdateVelocity(m_Velocity.x, -m_Velocity.y);
                break;

            case "WallLeft":
                GameplayManager.Instance.IncScore(GameplayManager.PlayerType.P2);
                ResetSpeed();
                UpdateVelocity(1.0f, 0.0f);
                transform.position = m_InitialPosition;
                break; 

            case "WallRight":
                GameplayManager.Instance.IncScore(GameplayManager.PlayerType.P1);
                ResetSpeed();
                UpdateVelocity(-1.0f, 0.0f);
                transform.position = m_InitialPosition;
                break;            
        }

        float GetHitYAxis(Collision2D paddle)
        {
            return (transform.position.y - paddle.transform.position.y) 
                / paddle.collider.bounds.size.y;
        }

        void ResetSpeed()
        {
            m_Speed = m_InitialSpeed;
        }
        
        void IncSpeed()
        {
            m_Speed += m_SpeedIncBy;
            if(m_Speed > m_MaxSpeed)
            {
                m_Speed = m_MaxSpeed;
            }
        }
    
        void UpdateVelocity(float x, float y)
        {
            m_Velocity.x = x;
            m_Velocity.y = y;
            m_Velocity = m_Velocity.normalized * m_Speed;
            m_RigidBody2D.velocity = m_Velocity;
        }
    }    
}
