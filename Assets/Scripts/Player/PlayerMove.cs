using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float m_jumpForce = 4;

    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;


    private readonly float m_interpolation = 10;

    private bool m_wasGrounded;
    private Vector3 m_currentDirection = Vector3.zero;

    //jump timer status
    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;
    [SerializeField]private bool m_jumpInput = false;
    [SerializeField]private bool go_down = false;
    public bool m_dash = false;
    [SerializeField]private bool dash_availabe = false;

    private bool m_isGrounded;

    private List<Collider> m_collisions = new List<Collider>();

    LevelManager levelManager;

    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Rigidbody>(); }
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        dash_availabe = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider))
                {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if (validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        }
        else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }

    private void Update()
    {
        if (!m_jumpInput && Input.GetKey(KeyCode.Space))
        {
            m_jumpInput = true;
        }

        if(!go_down && !m_isGrounded && Input.GetKeyDown(KeyCode.S)){
            go_down = true;
        }

        if(dash_availabe && Input.GetKeyDown(KeyCode.D)){
            m_dash = true;
            dash_availabe = false;
            m_animator.speed += 0.5f;
            levelManager.increseMove();
        }
    }

    private void FixedUpdate()
    {
        m_animator.SetBool("Grounded", m_isGrounded);

        DirectUpdate();
        m_wasGrounded = m_isGrounded;
        m_jumpInput = false;
        go_down = false;
        dash_availabe = true;
    }

    private void DirectUpdate()
    {
        Transform camera = Camera.main.transform;

        Vector3 direction = camera.right;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if (direction != Vector3.zero)
        {
            m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);

            transform.rotation = Quaternion.LookRotation(m_currentDirection);
            
            m_animator.SetFloat("MoveSpeed", direction.magnitude);
        }

        JumpingAndLanding();
    }

    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (jumpCooldownOver && m_isGrounded && m_jumpInput)
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }

        if (!m_isGrounded && go_down)
        {

            m_rigidBody.AddForce(Vector3.down * m_jumpForce*2, ForceMode.Impulse);
        }

        if (m_dash)
        {
            m_dash = false;
            m_rigidBody.AddForce(Vector3.right * m_jumpForce/2, ForceMode.Impulse);
        }


        if (!m_wasGrounded && m_isGrounded)
        {
            m_animator.SetTrigger("Land");
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            m_animator.SetTrigger("Jump");
        }
    }
}
