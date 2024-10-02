using System;
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

    // public void cardEffectReading(CardEffect cardEffect)
    // {

    //     foreach (CardKeyword cardKeyword in cardEffect.CardKeywords)
    //     {
    //         switch (cardKeyword)
    //         {
    //             case CardKeyword.Combo:
    //                 Debug.Log("Combo");
    //                 break;
    //             case CardKeyword.Echo1:
    //                 Debug.Log("Echo1");
    //                 break;
    //             case CardKeyword.Echo2:
    //                 Debug.Log("Echo2");
    //                 break;
    //             case CardKeyword.Echo3:
    //                 Debug.Log("Echo3");
    //                 break;
    //             case CardKeyword.Echo4:
    //                 Debug.Log("Echo4");
    //                 break;
    //             case CardKeyword.Echo5:
    //                 Debug.Log("Echo5");
    //                 break;
    //             case CardKeyword.Cancel:
    //                 Debug.Log("Cancel");
    //                 break;
    //             case CardKeyword.Vanguard:
    //                 Debug.Log("Vanguard");
    //                 break;
    //             case CardKeyword.Finish:
    //                 Debug.Log("Finish");
    //                 break;
    //             case CardKeyword.Break:
    //                 Debug.Log("Break");
    //                 break;
    //             case CardKeyword.Hurt:
    //                 Debug.Log("Hurt");
    //                 break;
    //             case CardKeyword.LifeSteal:
    //                 Debug.Log("LifeSteal");
    //                 break;
    //             default:
    //                 Debug.Log("Invalid keyword");
    //                 break;
    //         }
    //     }
    // }

}
