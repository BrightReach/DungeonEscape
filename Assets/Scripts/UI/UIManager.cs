using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    private static UIManager instance;
    public static UIManager m_Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("UI Manager does not exist");

            return instance;
        }
    }
    public Text m_GemCount;
    public Image m_Selection;
    public Text m_GemCountUI;
    [SerializeField]
    private Image[] m_HealthBars;

    
	private void Awake() {
		instance = this;
	}

    public void UpdateGemCount(int gems){
        m_GemCountUI.text = gems + "G";
    }

    public void OpenShop(int gems){
        m_GemCount.text = gems + "G";
    }

    public void UpdateItemSelect(int yPos){
        m_Selection.rectTransform.anchoredPosition = new Vector2(m_Selection.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateLives(int lives){
        for (int i = 0; i <= lives; i++)
        {
            if(i == lives)
                m_HealthBars[i].enabled = false;
        }

    }

}
