using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHit : MonoBehaviour
{

  /*
  * Player Hit
  * If a player is hit by bullet then declare Winner() (in Assets/Scripts/gameStates.cs)
  */
  void OnCollisionEnter(Collision collision) // Detect collisions between the GameObjects with Colliders attached
  {
    //Check for a match with the specific tag on any GameObject that collides with your GameObject
    int numberOfOldBullets = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().timeout;
    for (int i = 0; i < numberOfOldBullets; i++) {
      if (
        (
          collision.gameObject.tag == "Active Bullet"
          || collision.gameObject.tag == "Old Bullet" + i
        )
        && GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState == "game" // have to be playing the game
      )
      {
        // Calls Winner() in Assets/Scripts/gameStates.cs
        GameObject.FindGameObjectWithTag("GameController").GetComponent<loser>().Loser(gameObject.tag);
      }
    }
  }
}
