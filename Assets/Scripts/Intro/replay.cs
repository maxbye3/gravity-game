using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class replay : MonoBehaviour
{
  public List<Vector3> bulletRecord = new List<Vector3>();
  private int i = 0;

  float[] bulletDetailArray;

  // Update is called once per frame
  void FixedUpdate()
  {
    // Record position of bullet as soon as ball starts moving
    if (
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState == "game" // if in game state record
      && GameObject.FindGameObjectWithTag("Active Bullet").GetComponent<firingBullet>().shotFired // shot fired
      )
    {
      i = 0;
      // Collecting data
      // Debug.Log("Collecting data: " + bulletRecord.Count);
      bulletRecord.Add(GameObject.FindGameObjectWithTag("Active Bullet").GetComponent<firingBullet>().transform.position);
    }
    else if (
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState == "replay" // if in game in replay state then replay shot
    ){
      // Do replay
      GameObject.FindGameObjectWithTag("Active Bullet").transform.position = bulletRecord[i];
      
      // Debug.Log("Amount of replay time:" + i);
      i += 1;
      
      if (i == bulletRecord.Count) // replay is over
      {
        // Create new game
        GameObject.FindGameObjectWithTag("Intro").GetComponent<levelGenerator>().CreateNewLevel();
        
        // Clear bullet record
        bulletRecord.Clear();
      }

    // BEFORE COUNTDOWN INT TIMER
    // float timeBeforeImpact = bulletRecord.Count - i;
    // if(timeBeforeImpact < 100){ // one second before impact
    //   Debug.Log("Time!");
    //   // Start countdown
    //   GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "intro";
    //   timeBeforeImpact = 0;
    // }

    }
  }
}
