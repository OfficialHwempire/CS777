using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Lumin;

public class CardSlot :MonoBehaviour
{
    [SerializeField]
    private int slotNumber;
    private List<GameObject> nodePrefabs;

    public GameObject nodeShownObject;

    

    public List<Sprite> NodeSprites;

    public bool isSuccess = false;


   
    


    private Card card;

    public Card Card => card;
    

    public void SetCard(Card card)
    {
        this.card = card;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = card.CardSprite; 
        this.nodeShownObject.GetComponent<SpriteRenderer>().sprite = NodeSprites[card.NodeType];  
        
    }

    public void resetCard()
    {
        if(card != null)
        {
            card = null;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = null;
            this.nodeShownObject.GetComponent<SpriteRenderer>().sprite = null;
            isSuccess = false;
        }
    }
    public void SuccessCard()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite =Resources.Load<Sprite>($"CardSprites/unablecard");
        isSuccess = true;
    }

    public void SetBreak()
    {
        this.nodeShownObject.GetComponent<SpriteRenderer>().sprite = NodeSprites[4];
    }
    public void reSetBreak()
    {
        this.nodeShownObject.GetComponent<SpriteRenderer>().sprite = NodeSprites[card.NodeType];
    }



    // Start is called before the first frame update


    // Update is called once per frame

}
