using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buttonBehaviour : MonoBehaviour
{
   private bool starEditing = false;
  
   public void onButtonEnter(){
    GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "ui"; // We are in game state (not intro)
   }
   public void onButtonExit(){
    if(GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState != "drag stars") { // button not clicked
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "game"; // We are in game state (not intro)
    }
   }

   public void onButtonClick(){
     TextMeshProUGUI buttonText = GameObject.FindGameObjectWithTag("Edit Stars Text").GetComponent<TextMeshProUGUI>();
     if(!starEditing){
      buttonText.SetText("Back to game");
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "drag stars"; // We are dragging planets
      starEditing = !starEditing;
     } else {
      buttonText.SetText("Move stars");
      starEditing = !starEditing;
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "game"; // We are back in the game
     }
   }
}
