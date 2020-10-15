using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private bool m_CanDamage = true; //Checks if the enemy can damage

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Hit: " + other.name);
        IDamagable hit = other.GetComponent<IDamagable>(); //Retrieves the IDamagable function from the target

        if (hit != null) //Checks if the target exists
        {
            if (m_CanDamage) //Checks if the target can be damaged
            {
                /*Damages the target before m_CanDamage is set to false and the DamagaeCooling coroutine begins */
                hit.Damage();
				m_CanDamage = false;
				StartCoroutine(DamageCooling());
            }
        }
    }

	IEnumerator DamageCooling(){
        /*The target will have to wait for half a second before attacking again from this coroutine */
		yield return new WaitForSeconds(0.5f);
		m_CanDamage = true;
	}
}
