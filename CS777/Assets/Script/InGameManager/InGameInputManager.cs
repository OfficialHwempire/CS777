using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using UnityEngine.Windows;
using System;
public class InGameInputManager :MonoBehaviour
{
    // Start is called before the first frame update
    
    public NodeManager NodeManager;
  
   private static InGameInputManager instance;
    public RelicSlots relicslots;
    

   private int totalBreakCount;
    public InGamePlayer ingp;
    public NodeManager node_manager;

    public InGameCardCalculator card_calculator;
   
   

      private void Update()
    {
        if (InGameManager.Instance.turnState == TurnState.playerTurn)
        {
            totalBreakCount = ingp.breakCount;
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
        }
    }

   private Dictionary<string,int> cardInputDic = new Dictionary<string, int>(){
    {"Q",0},
    {"W",1},
    {"E",2},
    {"R",3},
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
        if (!InGameManager
            .Instance.isinputAble
            ) return;

    int index = cardInputDic[inputString];
    Debug.Log("current count : "+ NodeManager.moveControllers[0].current_count);
    foreach(PendulumMoveController controller in NodeManager.moveControllers)
        {
            controller.resetNode();
        }
    if(!checkSuccess(index)){
        IfFail(index);
        
      
      return;
    }
    if(DeckManager.Instance.CardSlots[index]
            == InGameCardSlot.Able){

            DeckManager.Instance.useCard(index);
      int SuccessCount =0;
            InGameManager.Instance.usedcardCount++;

      foreach(var element in DeckManager.Instance.CardSlots){
       if(element == InGameCardSlot.Used && element == InGameCardSlot.Discard){
           SuccessCount++;
       }

      }
            if (DeckManager.Instance.InGameHand[index].CardEffects[4] ==1 && SuccessCount ==1)
            {
                card_calculator.initialize(DeckManager.Instance.InGameHand[index].CardEffects, true, index);
                card_calculator.action();
            }
            else if(DeckManager.Instance.InGameHand[index].CardEffects[4] == 1 && SuccessCount != 1)
            {
                card_calculator.initialize(DeckManager.Instance.InGameHand[index].CardEffects, false, index);
                card_calculator.action();
            }

            else if(DeckManager.Instance.InGameHand[index].CardEffects[5] == 1 && SuccessCount == 4)
            {
                card_calculator.initialize(DeckManager.Instance.InGameHand[index].CardEffects, true, index);
                card_calculator.action();
            }

            else if(DeckManager.Instance.InGameHand[index].CardEffects[5] == 1 && SuccessCount != 4)
            {
                card_calculator.initialize(DeckManager.Instance.InGameHand[index].CardEffects, false, index);
                card_calculator.action();
            }
            else
            {
                card_calculator.initialize(DeckManager.Instance.InGameHand[index].CardEffects, true, index);
                card_calculator.action();
            }
      if(SuccessCount == 4){
          DeckManager.Instance.totalReset();
          
      }

        
    }
    
    
    




    Debug.Log("Success:    "  + index);
    
   
   }

   public void IfFail(int index){

        InGameManager.Instance.currentTurnTime -= 5f;

   }
   //public void breakChange(){
   //   foreach(var element in DeckManager.Instance.cardSlots){
   //     element.SetBreak();
   //   }

   //}
   //public void breakReset(){
   //     node_manager.setNode();
   //}

   public bool checkSuccess(int n )
   {
    if(totalBreakCount>0){
        totalBreakCount --;
        return true;
    }
        float currentCount = node_manager.moveControllers[0].current_count;
        int cardType = DeckManager.Instance.InGameHand[n].NodeType;
        if(cardType == 0)
        {
            if (currentCount >= 0 && currentCount < 25) return true;
            else return false;
        }
        if(cardType == 1)
        {
            if(currentCount >=25 && currentCount <50) return true;
            else return false;
        }
        if(cardType == 2)
        {

            if (currentCount >= 50 && currentCount < 75) return true;
            else return false;
        }
        if(cardType == 3)
        {
            if (currentCount >= 75 && currentCount < 100) return true;
            else return false;
            }
        


        return false;

   }
}
