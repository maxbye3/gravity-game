using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonBehaviour : MonoBehaviour
{
   int n;
   public void OnButtonPress(){
    n++;
    Debug.Log("Button clicked " + n + " times.");
   }
   public void onButtonEnter(){
    GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "ui"; // We are in game state (not intro)
    Debug.Log("Button enter");
   }
   public void onButtonExit(){
    Debug.Log("Button exit");
    GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "game"; // We are in game state (not intro)
   }

   public void onButtonClick(){
    Debug.Log("Button click");
    GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "drag stars"; // We are in game state (not intro)
   }
}
