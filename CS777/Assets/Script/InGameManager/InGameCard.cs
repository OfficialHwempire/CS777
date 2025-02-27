using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCard 
{
    private string cardName;
    private int nodeType;

    private List<int> cardEffects;

    private Sprite cardSprite;

    public string CardName => cardName;
    public int NodeType => nodeType;
    public List<int> CardEffects => cardEffects
        ;
    public Sprite CardSprite => cardSprite;

    public InGameCard(string cardName, int nodeType, List<int> cardEffects)
    {
        this.cardName = cardName;
        this.nodeType = nodeType;
        this.cardEffects = cardEffects;
        this.cardSprite = LoadCardSprite(cardName);
    }


    public Sprite LoadCardSprite(string cardName)
    {
        
        return Resources.Load<Sprite>($"CardSprites/{cardName}");
    }


}
