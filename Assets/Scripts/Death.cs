using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	public void Destroy(){
		if(this.tag != "Player"){
			Destroy(transform.parent.gameObject);
			}
	}
}
