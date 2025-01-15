using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    // Start is called before the first frame update
  
    public TextMeshProUGUI cardCount;
   private static DeckManager instance;
   public List<CardSlot> cardSlots;

    public List<Card> deckTemplate;
    private List<Card> InGameDeck;

    private List<Card> InGameGrave;
    private int drawCardNum = 5;
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
    void Update()
    {
        cardCount.text = InGameDeck.Count.ToString();
    }
    void Start()
    {
        deckTemplate = new List<Card>();
        List<CardEffect> cardEffect1 = new List<CardEffect>{
            new CardEffect(CardKeyword.Attack, 5)
        };
        Card card1 = new Card("samplecard",0,cardEffect1);
        Card card2 = new Card("samplecard",1,cardEffect1);
        Card card3 = new Card("samplecard",2,cardEffect1);
        Card card4 = new Card("samplecard",3,cardEffect1);
        for(int i = 0; i<5; i++){
            deckTemplate.Add(card1);
            deckTemplate.Add(card2);
            deckTemplate.Add(card3);
            deckTemplate.Add(card4);
        }
        InitDeck();
        DrawCard(drawCardNum);

    }



    public void InitDeck()
    {
        InGameDeck = new List<Card>();
        InGameGrave = new List<Card>();

        foreach (Card card in deckTemplate)
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

    public void totalReset(){
        for(int i=0;i<5;i++){
            CardToGrave(i);
        }
        DrawCard(drawCardNum);
    }

}
