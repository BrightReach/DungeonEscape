using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamagable
{

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

    public override void Init()
    {
        base.Init();
    }

    public void Damage()
    {
        if (m_IsAlive)
        {
            --m_IHealth;
            if (m_IHealth <= 0)
                Dying();
            else
            {
                m_Anim.SetTrigger("Hit");
                m_Anim.SetBool("InCombat", true);
            }
        }
    }

    protected new void Dying()
    {
        base.Dying();
        GameObject diamond = Instantiate(m_DiamondPrefab, transform.position, Quaternion.identity) as GameObject;
        diamond.GetComponent<Diamond>().m_DiamondValue = base.m_Gems;
        Debug.Log(diamond.GetComponent<Diamond>().m_DiamondValue);
    }
}
