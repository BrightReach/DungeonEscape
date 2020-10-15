using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager m_Instance
    {
        get
        {
            if(instance == null)
                Debug.LogError("GameManager does not exist!");

            return instance;
        }
    }
    public bool m_CastleKeyCheck{
        get; set;
    }

    private void Awake() {
        instance = this;
    }
}
