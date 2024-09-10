using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totalManager : MonoBehaviour
{





    [SerializeField]
    private List<Sprite> cardSprites = new List<Sprite>();
    public static totalManager _totalManager;

    private NodeManager nodeManager => NodeManager.instance;

    private DeckManager deckManager => DeckManager.deckManager;

    public void CreateCard()
    {

    }

    public void CreateOneCard(int index)
    {
        Card card = DeckManager.deckManager.playerHand[index];
        GameObject cardObject = new GameObject("Card" + index);
        cardObject.AddComponent<SpriteRenderer>().sprite = cardSprites[card.CardSpirteIndex];
        Vector2 cardPosition = new Vector2(100 * index, 0);
        NodeManager.instance.CreateNode(index, card);// createnode 짜야함

    }
    public void GetCardClick(KeyInputEnum keyInputEnum)
    {
        int CardIndex = keyInputEnum switch
        {
            KeyInputEnum.FirstCard => 0,
            KeyInputEnum.SecondCard => 1,
            KeyInputEnum.ThirdCard => 2,
            KeyInputEnum.ForthCard => 3,
            KeyInputEnum.FifthCard => 4,
            _ => throw new System.ArgumentException("Invalid keyInputEnum")
        };
        NodeInfo node = nodeManager.nodeInfos[CardIndex];


    }


}
