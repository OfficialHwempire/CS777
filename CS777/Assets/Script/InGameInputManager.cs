using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using UnityEngine.Windows;
using System;
public class InGameInputManager :MonoBehaviour
{
    // Start is called before the first frame update
    
    public PendulumMoveController pendulumMoveController;
    cardEffectCalculator cardKeywordCalculator = new cardEffectCalculator();
    playerTotalCalculator playerTotalCalculator = new playerTotalCalculator();
    public totalManager totalManager;
  
   private static InGameInputManager instance;

   private int totalBreakCount;

   

      private void Update()
    {
        // 입력 감지 및 GetInput 메서드 호출
        if (UnityEngine.Input.GetKeyDown(KeyCode.Q))
        {
            getInput("Q");
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.W))
        {
            getInput("W");
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.E))
        {
            getInput("E");
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.R))
        {
            getInput("R");
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.T))
        {
            getInput("T");
        }
    }

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
    Debug.Log("current count : "+ pendulumMoveController.current_count);
    pendulumMoveController.resetNode();
    if(!checkSuccess(index)){
        IfFail(index);
        totalManager.timeBarHealthChange();
      
      return;
    }
    if(DeckManager.Instance.cardSlots[index].isSuccess == false){
      totalManager.enemyHpBar.Damage(5);
      DeckManager.Instance.cardSlots[index].SuccessCard();
      int SuccessCount =0;
      foreach(var element in DeckManager.Instance.cardSlots){
       if(element.isSuccess == true){
           SuccessCount++;
       }

      }
      if(SuccessCount == 5){
          DeckManager.Instance.totalReset();
          
      }
        
    }
    
    
    




    Debug.Log("Success:    "  + index);
    
   
   }

   public void IfFail(int index){
    
    Debug.Log("Fail:    "  + index);
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
    float current_count = pendulumMoveController.current_count;
    if(cardType*25< current_count&& cardType*25>current_count-25){
        return true;
    }
    
    return false;

   }
}
