using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using UnityEngine.Windows;

public class InGameInputManager 
{
    // Start is called before the first frame update
    cardEffectCalculator cardKeywordCalculator = new cardEffectCalculator();

   private static InGameInputManager instance;

   private int totalBreakCount;

   

   private Dictionary<string,int> cardInputDic = new Dictionary<string, int>(){
    {"Q",0},
    {"W",1},
    {"E",2},
    {"R",3},
    {"T",4}
   };

   public static InGameInputManager Instance{
         get{
              if(instance == null){
                instance = new InGameInputManager();
              }
              return instance;
              
         }
   }
   
   public void getInput(string inputString){
    int index = cardInputDic[inputString];
    if(!checkSuccess(index)){
      DeckManager.Instance.CardToGrave(0);

    }





    
   
   }
   public void breakChange(){
      foreach(var element in DeckManager.Instance.cardSlots){
        element.SetBreak();
      }

   }
   public void breakReset(){
      foreach(var element in DeckManager.Instance.cardSlots){
        element.reSetBreak();
      }

   }

   public bool checkSuccess(int n )
   {
    if(totalBreakCount>0){
        totalBreakCount --;
        breakReset();
        return true;
    }
    int cardType = DeckManager.Instance.cardSlots[n].Card.NodeType;
    float current_count = NodeManager.Instance.current_count;
    if(cardType*25< current_count&& cardType*25>current_count-25){
        return true;
    }
    
    return false;

   }
}
