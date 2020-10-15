using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamagable
{

    private Rigidbody2D _rb;
    private float m_JumpForce = 5f;
    private bool jumpResetCheck = false;
    private float m_Speed = 3.5f;
    private bool m_IsGrounded;
    private PlayerAnimation m_PlayerAnim;
    public int m_Diamond = 0;
    /*{
        get{return diamond;}
        set {diamond = value;}
    }*/
    private bool m_IsDead = false;

    public int m_IHealth
    {
        get;

        set;
    }

    // Use this for initialization
    void Start()
    {

        _rb = GetComponent<Rigidbody2D>();
        m_PlayerAnim = GetComponent<PlayerAnimation>();
        m_IHealth = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_IsDead && !m_PlayerAnim.m_HitState)
        {
            Movement();
            if (CrossPlatformInputManager.GetButtonDown("A_Button") & IsGrounded())
                m_PlayerAnim.Attack();
        }
        else if (m_IsDead || m_PlayerAnim.m_HitState)
        {
            _rb.velocity = new Vector2(0f * 1f, _rb.velocity.y);
        }

        Debug.Log(m_PlayerAnim.m_HitState);
        Debug.Log(m_IsDead);

    }

    void Movement()
    {
        float xMove = CrossPlatformInputManager.GetAxisRaw("Horizontal"); // Input.GetAxisRaw("Horizontal");
        m_IsGrounded = IsGrounded();

        if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("B_Button")) && IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, m_JumpForce);
            StartCoroutine(JumpReset());
            m_PlayerAnim.Jumping(true);

        }

        _rb.velocity = new Vector2(xMove * m_Speed, _rb.velocity.y);
        m_PlayerAnim.Movement(xMove);
        Flip(xMove);
    }

    private bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);

        if (hitInfo.collider != null)
        {
            if (!jumpResetCheck)
            {
                m_PlayerAnim.Jumping(false);
                return true;
            }
        }

        return false;
    }

    private void Flip(float move)
    {

        if (move > 0)
            transform.localScale = new Vector2(1f, transform.localScale.y);
        if (move < 0)
            transform.localScale = new Vector2(-1f, transform.localScale.y);

    }

    public void CollectGems(int amount)
    {
        m_Diamond += amount;
        UIManager.m_Instance.UpdateGemCount(m_Diamond);
    }

    IEnumerator JumpReset()
    {
        jumpResetCheck = true;
        yield return new WaitForSeconds(1f);
        jumpResetCheck = false;
    }

    public void Damage()
    {
        if (!m_IsDead)
        {
            --m_IHealth;
            UIManager.m_Instance.UpdateLives(m_IHealth);
            m_PlayerAnim.Hit(m_IHealth);
            if (m_IHealth <= 0)
                m_IsDead = true;
        }
    }
}


