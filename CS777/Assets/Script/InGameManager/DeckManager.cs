using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class DeckManager : MonoBehaviour
{
    // Start is called before the first frame update
  
    public TextMeshProUGUI cardCount;
   private static DeckManager instance;
   public List<GameObject> cardPrefabs;
    public List<InGameCard> InGameDeck;
    public List<InGameCard> InGameHand;
    public List<InGameCardSlot> CardSlots;
    public Vector2 DeckoriginPos;
    public Vector2 GraveOriginPos;
    public List<Vector2> targetPos;
    public float animationDelay = 0.5f;
    public float animationDuration = 1f;
    public float graveYardDuration = 0.3f;
    public float graveYardDelay = 0.2f;
    

    private List<InGameCard> InGameGrave;
    private int drawCardNum = 4;
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


    public void InitDeck(List<InGameCard> deckTemplate)
    {
        InGameDeck = new List<InGameCard>();
        InGameGrave = new List<InGameCard>();

        foreach (InGameCard card in deckTemplate)
        {
            InGameDeck.Add(card);
        }
    }

    public void DrawCard(int n){
        if(InGameHand.Count > 0)
        {
            StartCoroutine(MoveToGraveYard());
        }
        if(InGameDeck.Count < n){
            GraveToDeck();
        }
        ShuffleDeck();
        CardSlots.Clear();
        for(int i = 0; i<n; i++){
            InGameCard card = InGameDeck[0];
            InGameDeck.RemoveAt(0);
            InGameHand.Add(card);

            CardSlots.Add(InGameCardSlot.Able);
        }
        StartCoroutine(DrawAnimation());

        

    }

    public void ShuffleDeck(){
        for(int i = 0; i<InGameDeck.Count; i++){
            InGameCard temp = InGameDeck[i];
            int randomIndex = Random.Range(i, InGameDeck.Count);
            InGameDeck[i] = InGameDeck[randomIndex];
            InGameDeck[randomIndex] = temp;
        }
    }

    public void GraveToDeck(){
        foreach(InGameCard card in InGameGrave){
            InGameDeck.Add(card);
        }
        InGameGrave.Clear();
    }
    public void CardToGrave(int n)
    {

        InGameCard card = InGameHand[n];
        InGameGrave.Add(card);
        InGameHand[n] = null;
    }

    public void totalReset(){
        for(int i=0;i<3;i++){
            CardToGrave(i);
        }
        DrawCard(drawCardNum);
    }
   private IEnumerator DrawAnimation()
    {
        for(int i=0;i< 4; i++)
        {
            cardPrefabs[i].transform.position = DeckoriginPos;
            SpriteRenderer spr = cardPrefabs[i].GetComponent<SpriteRenderer>();
            spr.sprite = InGameHand[i].LoadCardSprite(InGameHand[i].CardName);
            

           
            cardPrefabs[i].transform.DOMove(targetPos[i],animationDuration);
            yield return new WaitForSeconds(animationDelay);
        }
    }

    private IEnumerator MoveToGraveYard()
    {
        for(int i=0;i< 4; i++)
        {
            cardPrefabs[3-i].transform.DOMove(GraveOriginPos,graveYardDuration);
            SpriteRenderer spr = cardPrefabs[(3-i)].GetComponent<SpriteRenderer>();
            spr.sprite = null;
            yield return new WaitForSeconds(graveYardDelay);
        }
    }
   public  void useCard(int slotIndex)
    {
        CardSlots[slotIndex] = InGameCardSlot.Used;
        SpriteRenderer spr = cardPrefabs[slotIndex].GetComponent<SpriteRenderer>(); 
        spr.sprite = Resources.Load<Sprite>($"CardSprites/Used");
    }
    public void disCardCard(int slotindex)
    {
        CardSlots[slotindex] = InGameCardSlot.Discard;
        SpriteRenderer spr = cardPrefabs[slotindex].GetComponent<SpriteRenderer>();
        spr.sprite = Resources.Load<Sprite>($"CardSprites/Discard");
    }

}
