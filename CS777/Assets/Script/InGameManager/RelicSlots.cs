using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicSlots : MonoBehaviour
{
    List<GameObject> relicPlaceHolders;
    public List<GameObject> relicPrefabs;

    public bool isEndRelicExist = false;
    public bool isHeaderRelicExist = false;
    public bool isFourCardExist = false;
    public bool isDiscardRelicExist = false;
    public  void gainRelic (Relic relic)
       {
        if(relic.relicIndex==2) isDiscardRelicExist=true;
        if (relic.relicIndex == 8) isFourCardExist = true;
        if(relic.relicIndex == 10) isHeaderRelicExist=true;
        if(relic.relicIndex==11) isEndRelicExist=true;
            
         GameObject newObject = Instantiate(relicPrefabs[relic.relicIndex], relicPlaceHolders[relicPlaceHolders.Count - 1].transform);
       }

}
