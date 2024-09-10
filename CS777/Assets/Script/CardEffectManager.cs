using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffectManager : MonoBehaviour
{
    public static CardEffectManager cardEffectManager;
    public static CardEffectManager Instance
    {
        get
        {
            if (cardEffectManager == null)
            {
                cardEffectManager = FindObjectOfType<CardEffectManager>();
                if (cardEffectManager == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(CardEffectManager).Name;
                    cardEffectManager = go.AddComponent<CardEffectManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return cardEffectManager;
        }
    }
    void Awake()
    {
        if (cardEffectManager == null)
        {
            cardEffectManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



}
