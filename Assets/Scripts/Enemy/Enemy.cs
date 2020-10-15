using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    [SerializeField]
    protected int m_Health, m_Gems;
	[SerializeField]
	protected float m_Speed;
    [SerializeField]
    protected Transform pointA, pointB;
	[SerializeField]
    protected Animator m_Anim;
	protected AnimationClip m_DeathClip;
    [SerializeField]
    protected Vector3 m_CurrentTarget;
	[SerializeField]
	protected Transform m_PlayerPos;
	protected float m_Distance;
	protected bool m_IsAlive = true;
    [SerializeField]
    protected GameObject m_DiamondPrefab;

    private void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        m_Anim = GetComponentInChildren<Animator>();
		m_PlayerPos = GameObject.Find("Player").GetComponent<Transform>();
    }

    public virtual void Movement()
    {
		m_Distance = Vector3.Distance(m_PlayerPos.localPosition, transform.localPosition);
		Vector3 direction = m_PlayerPos.transform.localPosition - transform.localPosition;
        if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {

            if (m_CurrentTarget == pointA.position)
                transform.localScale = new Vector2(-1f, transform.localScale.y);
            else
                transform.localScale = new Vector2(1f, transform.localScale.y);

            if (transform.position == pointA.position)
            {
                m_CurrentTarget = pointB.position;
                m_Anim.SetTrigger("Idle");
            }

            else if (transform.position == pointB.position)
            {
                m_CurrentTarget = pointA.position;
                m_Anim.SetTrigger("Idle");
            }
            transform.position = Vector3.MoveTowards(transform.position, m_CurrentTarget, m_Speed * Time.deltaTime);
        }

		if(m_Distance > 2 || m_Distance < -2){
			m_Anim.SetBool("InCombat", false);
		}
		if(m_Anim.GetBool("InCombat"))
		{
			if(direction.x < 0)
			    transform.localScale = new Vector2(-1f, transform.localScale.y);
			else if (direction.x > 0)
			    transform.localScale = new Vector2(1f, transform.localScale.y);
		}

    }

    public virtual void Update()
    {

        if(m_IsAlive)
			Movement();

    }

	protected void Dying(){
		m_IsAlive = false;
		Destroy(pointA.parent.gameObject);
		m_Anim.SetTrigger("Death");
	}
}
