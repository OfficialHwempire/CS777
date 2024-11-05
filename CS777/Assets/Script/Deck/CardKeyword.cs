using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardKeyword
{
    Combo,
    Echo1,
    Echo2,
    Echo3,
    Echo4,
    Echo5,
    Cancel,
    Vanguard,
    Finish,
    Break,

    Hurt,
    LifeSteal

}
public class CardKeywordData
{
    public CardKeyword keyword;
    public int value;

    public CardKeywordData(string keyword, int value)
    {
        if (Enum.TryParse(typeof(CardKeyword), keyword, out var result) == false)
        {
            throw new System.ArgumentException("Invalid keyword");
        }
        this.keyword = (CardKeyword)result;
        this.value = value;
    }


}
