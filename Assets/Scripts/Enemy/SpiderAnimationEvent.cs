using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour {

	private Spider m_Spider;

	private void Start() {
		m_Spider = GetComponentInParent<Spider>();
	}

	public void Fire(){
		Debug.Log("Spider-Fire!!");
		m_Spider.Fire();
	}

	public void Death(){
		Destroy(transform.parent.gameObject);
	}
}
