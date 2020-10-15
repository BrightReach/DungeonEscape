using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	private Animator m_Animator;
	private Animator m_SwordAnim;

	public bool m_HitState{
		get{
			return m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Hit");
		}
	}

	// Use this for initialization
	void Start () {
		
		m_Animator = GetComponentInChildren<Animator>();
		m_SwordAnim = GameObject.Find("SwordArc").GetComponentInChildren<Animator>();
	}
	
	public void Movement(float move) {

		m_Animator.SetFloat("Move", Mathf.Abs(move));
		
	}

	public void Jumping(bool toJump){

		m_Animator.SetBool("Jump", toJump);
	}

	public void Attack(){
		m_Animator.SetTrigger("Attack");
		m_SwordAnim.SetTrigger("Attack");
	}

	public void Hit(int lives){
		m_Animator.SetTrigger("Hit");
		if(lives <= 0)
			m_Animator.SetBool("Death", true);
	}
}
