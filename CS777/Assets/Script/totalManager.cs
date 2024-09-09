using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totalManager : MonoBehaviour
{


    public DeckManager _deckManager;
    private DeckManager deckManager;

    [SerializeField]
    private List<Sprite> cardSprites = new List<Sprite>();
    public static totalManager _totalManager;

    public void CreateCard()
    {

    }

    public void CreateOneCard(int index)
    {
        Card card = DeckManager.deckManager.playerHand[index];
        GameObject cardObject = new GameObject("Card" + index);
        cardObject.AddComponent<SpriteRenderer>().sprite = cardSprites[card.CardSpirteIndex];
        Vector2 cardPosition = new Vector2(100 * index, 0);
        NodeManager.nodeManager.CreateNode(index);// createnode 짜야함

    }


}
