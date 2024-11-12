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

   public static InGameInputManager Instance{
         get{
              if(instance == null){
                instance = new InGameInputManager();
              }
              return instance;
              
         }
   }
   
   public void getInput(string inputString){
    if (totalBreakCount>0){
        breakChange();
    }
    if(UnityEngine.Input.GetKeyDown(KeyCode.Q)){
        float current_count = NodeManager.Instance.current_count;
        int nodeType=DeckManager.Instance.cardSlots[0].Card.NodeType;

        if(current_count>25*nodeType && current_count<25*(nodeType+1))
        {
            DeckManager.Instance.CardToGrave(0);
            
        }


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
}
