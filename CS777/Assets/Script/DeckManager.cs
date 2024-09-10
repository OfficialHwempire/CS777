using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public static DeckManager deckManager;

    public static DeckManager _deckManager
    {
        get
        {
            if (deckManager == null)
            {
                deckManager = FindObjectOfType<DeckManager>();
                if (deckManager == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(DeckManager).Name;
                    deckManager = go.AddComponent<DeckManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return deckManager;
        }
    }

    public List<Card> deck = new List<Card>();
    public List<Card> OriginalDeck = new List<Card>();

    public List<Card> playerHand = new List<Card>();

    void Awake()
    {
        if (deckManager == null)
        {
            deckManager = this;
            deck = OriginalDeck;
        }
        else if (deckManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void addCardToDeck(Card card)
    {
        deck.Add(card);
    }
    public void addCardToHand(Card card)
    {
        playerHand.Add(card);
    }

    public void removeCardFromDeck(Card card)
    {
        deck.Remove(card);
    }

    public void removeCardFromHand(Card card)
    {
        playerHand.Remove(card);
    }

    public void shuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public void drawCard(int drawCardAmount)
    {

        if (deck.Count < drawCardAmount)
        {
            drawCardAmount = deck.Count;
        }
        for (int i = 0; i < drawCardAmount; i++)
        {
            playerHand.Add(deck[0]);
            deck.RemoveAt(0);
        }
    }

    public void drawCardInGame()
    {
        drawCard(5);
        shuffleDeck();

    }

    public void resetDeck()
    {
        deck = OriginalDeck;
    }




}
