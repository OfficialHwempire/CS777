using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totalManager : MonoBehaviour
{





    [SerializeField]
    private List<Sprite> cardSprites = new List<Sprite>();
    public static totalManager _totalManager;

    private NodeManager _nodeManager => NodeManager.instance;

    private DeckManager deckManager => DeckManager.deckManager;

    public void CreateCard()
    {

    }

    public void CreateOneCard(int index)
    {
        Card card = deckManager.playerHand[index];
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
        NodeInfo node = _nodeManager.nodeInfos[CardIndex];



    }
    public bool checkFailPass(int playerHandIndex)
    {

        return _nodeManager.isNodeInputTrue(playerHandIndex);
    }
    public void clickFailProcess(int playerHandIndex)
    {
        _nodeManager.FailNode(playerHandIndex);
        return;
    }
    public void clickPassProcess(int playerHandIndex)
    {
        string cardEffectJson = deckManager.playerHand[playerHandIndex].CardEffect.CardEffectJson;
        if (cardEffectJson.Contains("Break"))
        {
            _nodeManager.breakTimeExecution();
        }
        _nodeManager.SuccessNode(playerHandIndex);

        return;
    }



}
