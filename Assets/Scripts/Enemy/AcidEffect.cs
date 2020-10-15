using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour {

	private float m_Speed = 3f;
    private bool m_CanDamage = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamagable hit = other.GetComponent<IDamagable>();

        if (hit != null && other.tag == "Player")
        {
            if (m_CanDamage)
            {
                hit.Damage();
				m_CanDamage = false;
				StartCoroutine(DamageCooling());
            }
        }
    }

	IEnumerator DamageCooling(){
		yield return new WaitForSeconds(0.5f);
		m_CanDamage = true;
	}

	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.right * m_Speed * Time.deltaTime);

		Destroy(this.gameObject,5f);
		
	}


}
