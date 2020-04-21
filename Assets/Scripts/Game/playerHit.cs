using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerHit : MonoBehaviour
{

  /*
  * Player Hit
  * If a player is hit by bullet then declare Winner() (in Assets/Scripts/gameStates.cs)
  */
  void OnCollisionEnter(Collision collision) // Detect collisions between the GameObjects with Colliders attached
  {
    if (GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState == "game") // have to be playing the game      
    {
      // Lost player explosion
      GameObject.FindGameObjectWithTag("Red").GetComponent<fireworks>().StartFireworks(gameObject.tag);
      // Declares a loser
      GameObject.FindGameObjectWithTag("GameController").GetComponent<loser>().Loser(gameObject.tag, collision.gameObject.tag);
    }
  }

}
