using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class Card
{

    private CardKeyword cardKeyword;
    private int damage;
    private int cardNodeIndex;

    private int cardSpirteIndex;

    public int CardSpirteIndex => cardSpirteIndex;

    public Card(CardKeyword _cardKeyword, int _damage, int _cardNodeIndex, int _cardSpirteIndex)
    {
        damage = _damage;
        cardKeyword = _cardKeyword;
        cardNodeIndex = _cardNodeIndex;
        cardSpirteIndex = _cardSpirteIndex;

    }


}
