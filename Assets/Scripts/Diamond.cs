using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour {

	[SerializeField]
	private int count;
	public int m_DiamondValue
	{
		get{return count;}
		set{count = value;}
	}



	private void OnTriggerEnter2D(Collider2D other) {

		if(other != null && other.tag == "Player")
		{

			Player player = other.GetComponent<Player>();

			player.CollectGems(m_DiamondValue);
			Debug.Log(player.m_Diamond);
			Destroy(this.gameObject);
			}
	}
}
