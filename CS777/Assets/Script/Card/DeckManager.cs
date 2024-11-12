using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    // Start is called before the first frame update
  

   private static DeckManager instance;
   public List<CardSlot> cardSlots;

   
    public static DeckManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DeckManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("DeckManager");
                    instance = obj.AddComponent<DeckManager>();
                }
            }
            return instance;
        }
    }

    public List<Card> DeckTemplate;
    private List<Card> InGameDeck;

    private List<Card> InGameGrave;
    private int drawCardNum = 5;

    public void InitDeck()
    {
        InGameDeck = new List<Card>();
        InGameGrave = new List<Card>();

        foreach (Card card in DeckTemplate)
        {
            InGameDeck.Add(card);
        }
    }

    public void DrawCard(int n){
        if(InGameDeck.Count < n){
            GraveToDeck();
        }
        ShuffleDeck();
        for(int i = 0; i<n; i++){
            Card card = InGameDeck[0];
            InGameDeck.RemoveAt(0);
            cardSlots[i].SetCard(card);
        }

        

    }

    public void ShuffleDeck(){
        for(int i = 0; i<InGameDeck.Count; i++){
            Card temp = InGameDeck[i];
            int randomIndex = Random.Range(i, InGameDeck.Count);
            InGameDeck[i] = InGameDeck[randomIndex];
            InGameDeck[randomIndex] = temp;
        }
    }

    public void GraveToDeck(){
        foreach(Card card in InGameGrave){
            InGameDeck.Add(card);
        }
        InGameGrave.Clear();
    }
    public void CardToGrave(int n)
    {

        Card card = cardSlots[n].Card;
        InGameGrave.Add(card);
        cardSlots[n].resetCard();
    }

}
