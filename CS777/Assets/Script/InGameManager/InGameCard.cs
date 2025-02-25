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
        // 카드 이름에 따라 스프라이트를 Resources 폴더에서 불러옵니다.
        return Resources.Load<Sprite>($"CardSprites/{cardName}");
    }


}
