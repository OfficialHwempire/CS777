using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Lumin;

public class CardSlot :MonoBehaviour
{
    [SerializeField]
    private int slotNumber;
    private List<GameObject> nodePrefabs;

    private GameObject nodeShownObject;


   
    


    private Card card;

    public void SetCard(Card card)
    {
        this.card = card;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = card.CardSprite;   
        
    }



    // Start is called before the first frame update


    // Update is called once per frame

}
