using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect 
{
    // Start is called before the first frame update
   private CardKeyword cardKeyword;
   private int cardEffectValue;

    public CardEffect(CardKeyword cardKeyword, int cardEffectValue)
    {
         this.cardKeyword = cardKeyword;
         this.cardEffectValue = cardEffectValue;
    }

    public CardKeyword getCardKeyword()
    {
        return cardKeyword;
    }

    public int getCardEffectValue()
    {
        return cardEffectValue;
    }


    

}
