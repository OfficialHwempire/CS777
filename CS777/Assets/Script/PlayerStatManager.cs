using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStatsManager : MonoBehaviour
{

    public int playerHealth = 100;
    public bool isWeak = false;
    public bool isVulnerable = false;

    public int breakPoint = 0;

    public static PlayerStatsManager instance;
    public static PlayerStatsManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerStatsManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(PlayerStatsManager).Name;
                    instance = go.AddComponent<PlayerStatsManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;

        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
