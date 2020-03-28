using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHit : MonoBehaviour
{ 
  
  /*
  * Player Hit
  * If a player is hit by the bullet then declare Winner() (in Assets/Scripts/gameStates.cs)
  */
    void OnCollisionEnter(Collision collision) // Detect collisions between the GameObjects with Colliders attached
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Bullet")
        {
          // Calls Winner() in Assets/Scripts/gameStates.cs
          GameObject.FindGameObjectWithTag("MainCamera").GetComponent<gameStates>().Winner();            
        }
    }
}
