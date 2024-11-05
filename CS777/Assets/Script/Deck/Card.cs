using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



[Serializable]
public class Card
{

    private CardEffect cardEffect;
    private int damage;
    private int cardNodeIndex;

    private int cardSpirteIndex;

    public int CardSpirteIndex => cardSpirteIndex;

    public int CardNodeIndex => cardNodeIndex;

    public CardEffect CardEffect => this.cardEffect;

    public Card(CardEffect _cardEffect, int _damage, int _cardNodeIndex, int _cardSpirteIndex)
    {
        damage = _damage;
        cardEffect = _cardEffect;
        cardNodeIndex = _cardNodeIndex;
        cardSpirteIndex = _cardSpirteIndex;

    }


}
