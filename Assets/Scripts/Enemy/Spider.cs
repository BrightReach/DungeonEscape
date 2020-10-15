using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamagable
{

    [SerializeField]
    private Transform m_AcidSpawn;
    [SerializeField]
    private GameObject m_Acid;

    private void Start()
    {
        m_AcidSpawn = GameObject.Find("AcidSpawn").GetComponent<Transform>();
        Init();
    }

    public override void Init()
    {
        base.Init();
    }
    public int m_IHealth
    {
        get
        {
            return m_Health;
        }

        set
        {
            m_Health = value;
        }
    }

    public void Damage()
    {
        if (m_IsAlive)
        {
            --m_IHealth;
            if (m_IHealth <= 0)
                Dying();
        }
    }

    public void Fire()
    {
        Instantiate(m_Acid, m_AcidSpawn.position, Quaternion.identity);
    }

    public override void Update()
    {

    }

	protected new void Dying(){
		base.Dying();
		GameObject diamond = Instantiate(m_DiamondPrefab, transform.position, Quaternion.identity) as GameObject;
        diamond.GetComponent<Diamond>().m_DiamondValue = base.m_Gems;
        Debug.Log(diamond.GetComponent<Diamond>().m_DiamondValue);
	}
}
