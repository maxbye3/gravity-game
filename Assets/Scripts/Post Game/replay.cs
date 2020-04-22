﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class replay : MonoBehaviour
{
  public List<Vector3> activeBulletMovement = new List<Vector3>();
  public List<List<Vector3>> starMovements = new List<List<Vector3>>();
  public List<List<Vector3>> bulletMovements = new List<List<Vector3>>();
  public string destroyedBy;

  private int i = 0;
  List<int> roundStartTime = new List<int>();
  void Start()
  {
    roundStartTime.Add(0);
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    // Number of stars in game
    int numberOfStars = GameObject.FindGameObjectWithTag("Intro").GetComponent<levelGenerator>().numberOfStars;

    // Number of old bullets in game
    int numberOfOldBullets = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().timeout;


    // Record position of bullet as soon as ball starts moving
    if (
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState == "game" // if in game state record
      // && GameObject.FindGameObjectWithTag("Active Bullet").GetComponent<firingBullet>().shotFired // shot fired
      )
    {
      i = 0;
      // Collecting data
      activeBulletMovement.Add(GameObject.FindGameObjectWithTag("Active Bullet").GetComponent<firingBullet>().transform.position);

      // Record stars 
      for (var j = 0; j < numberOfStars; j++)
      {
        starMovements[j].Add(GameObject.Find("New Star" + j).transform.position);
      }

      // Record old bullets
      // Debug.Log("numberOfOldBullets: " + GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().timeout);
      if (numberOfOldBullets > 0)
      { // if old bullets exist
        for (int k = 0; k < numberOfOldBullets; k++)
        {          
          Debug.Log(k);
          bulletMovements[k].Add(GameObject.Find("Old Bullet" + k).transform.position);
        }
      }


    }
    else if (
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState == "replay" // if in game in replay state then replay shot
    )
    {
      // Replay on bullet
      if (destroyedBy == "Active Bullet")
      {
        // Debug.Log("destroyed By Active Bullet: " + destroyedBy);
        GameObject.FindGameObjectWithTag("Active Bullet").transform.position = activeBulletMovement[i];
      }

      // Replay on stars      
      for (var j = 0; j < numberOfStars; j++)
      {
        GameObject.Find("New Star" + j).transform.position = starMovements[j][i];
      }

      // Replay on bullets    
      if (destroyedBy == "Old Bullet")
      {
        // Debug.Log("destroyed By Old Bullet: " + numberOfOldBullets);
        for (var k = 0; k < numberOfOldBullets; k++)
        {
          // Debug.Log("bulletMovements[k]:" + bulletMovements[k].Count);
          // Debug.Log("i:" + i);
          if(i < bulletMovements[k].Count){
            GameObject.Find("Old Bullet" + k).transform.position = bulletMovements[k][i];
          }
        }
      }


      // Debug.Log("Amount of replay time:" + i);
      i += 1;

      if (i == activeBulletMovement.Count) // replay is over
      {
        // Create new game
        GameObject.FindGameObjectWithTag("Intro").GetComponent<levelGenerator>().CreateNewLevel();

        // Clear bullet record
        activeBulletMovement.Clear();

        // Delete bullet movement lists
        Debug.Log("DESTROY OLD BULLETS");
        for (var k = 0; k < numberOfOldBullets; k++)
        {
          bulletMovements[k].Clear();
        }

        // Delete planet movement lists
        for (var j = 0; j < numberOfStars; j++)
        {
          starMovements[j].Clear();
        }

      }

      // BEFORE COUNTDOWN INT TIMER
      // float timeBeforeImpact = activeBulletMovement.Count - i;
      // if(timeBeforeImpact < 100){ // one second before impact
      //   // Start countdown
      //   GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "intro";
      //   timeBeforeImpact = 0;
      // }

    }
  }
}
