using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject m_ShopUI;
    private int m_CurrentItem;
    private int m_CurrentPrice;
    private Player m_Player;


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other != null && other.tag == "Player")
        {
            m_Player = other.GetComponent<Player>();

            if (m_Player != null)
            {
                UIManager.m_Instance.OpenShop(m_Player.m_Diamond);
                m_ShopUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other != null && other.tag == "Player")
            m_ShopUI.SetActive(false);
    }

    public void SelectItem(int item)
    {

        switch (item)
        {
            case 0:
                UIManager.m_Instance.UpdateItemSelect(87);
                m_CurrentItem = 0;
                m_CurrentPrice = 200;
                Debug.Log(m_CurrentItem + " is " + m_CurrentPrice + "G");
                break;
            case 1:
                UIManager.m_Instance.UpdateItemSelect(-19);
                m_CurrentItem = 1;
                m_CurrentPrice = 400;
                break;
            case 2:
                UIManager.m_Instance.UpdateItemSelect(-113);
                m_CurrentItem = 2;
                m_CurrentPrice = 100;
                break;
        }
    }

    public void Purchase()
    {

        if (m_Player.m_Diamond >= m_CurrentPrice)
        {
            m_Player.m_Diamond -= m_CurrentPrice;
            UIManager.m_Instance.OpenShop(m_Player.m_Diamond);
            if(m_CurrentItem == 2)
                GameManager.m_Instance.m_CastleKeyCheck = true;
            m_ShopUI.SetActive(false);
        }
        else
        {
            Debug.Log("Cannot afford it");
            m_ShopUI.SetActive(false);
        }

    }
}
