using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



[CreateAssetMenu(fileName = "CardEffect", menuName = "ScriptableObjects/CardEffect", order = 1)]
public class CardEffect
{
    [SerializeField]
    private List<CardKeywordData> cardKeywordDatas;
    public List<CardKeywordData> CardKeywords => cardKeywordDatas;

    private string cardEffectJson => ToJson();
    public string CardEffectJson => cardEffectJson;

    bool IsKeywordInEnum(string keyword)
    {
        return Enum.TryParse(typeof(CardKeyword), keyword, out _);
    }
    public void CardEffectChaining(params object[] args)
    {
        cardKeywordDatas = new List<CardKeywordData>();
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] is string keyword)
            {
                if (!IsKeywordInEnum(keyword)) throw new ArgumentException("Invalid keyword");
                if (i + 1 < args.Length && args[i + 1] is int value)
                {

                    cardKeywordDatas.Add(new CardKeywordData(keyword, value));
                    i++; // Skip the next argument as it is already processed
                }
                else
                {
                    throw new ArgumentException("Keyword must be followed by an integer value");
                }
            }
            else
            {
                throw new ArgumentException("Not a string");
            }
        }


    }
    [Serializable]
    private class CardKeywordDataListWrapper
    {
        public List<CardKeywordData> cardKeywordDatas;
    }
    public string ToJson()
    {
        return JsonUtility.ToJson(new CardKeywordDataListWrapper { cardKeywordDatas = cardKeywordDatas }, true);
    }



}
