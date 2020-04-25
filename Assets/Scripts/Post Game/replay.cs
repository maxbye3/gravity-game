using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class replay : MonoBehaviour
{
  public List<Vector3> activeBulletMovement = new List<Vector3>();
  public List<List<Vector3>> starMovements = new List<List<Vector3>>();
  public List<List<Vector3>> bulletMovements = new List<List<Vector3>>();
  public string destroyedBy;
  public int roundStartTime = 0;

  public int roundTime = 0;
  public List<int> roundStartTimes = new List<int>();
  public int bulletToReplay;

  public int starCounter = 0;
  void Start()
  {
    roundStartTimes.Add(0);
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    // Number of old bullets in game
    int numberOfOldBullets = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().bulletNumber;

    // Number of stars in game
    int numberOfStars = GameObject.FindGameObjectWithTag("Intro").GetComponent<levelGenerator>().numberOfStars;



    // Record position of bullet as soon as ball starts moving
    if (
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState == "game" // if in game state record                                                                                                        // && GameObject.FindGameObjectWithTag("Active Bullet").GetComponent<firingBullet>().shotFired // shot fired
      )
    {
      // Counting round time
      // Debug.Log("round time: " + roundStartTime);
      // Debug.Log("activeBulletMovement: " + activeBulletMovement.Count);


      // Collecting data
      // activeBulletMovement.Add(GameObject.FindGameObjectWithTag("Active Bullet").GetComponent<firingBullet>().transform.position);
     

      // Record old bullets

      if (numberOfOldBullets > 0)
      { // if old bullets exist


      // RECORD STARS    
      Debug.Log("Recording stars");
      for (var j = 0; j < numberOfStars; j++)
      {
        starMovements[j].Add(GameObject.Find("New Star" + j).transform.position);
      }

        // Debug.Log("old bullet position: " + GameObject.Find("Old Bullet0").transform.position);
        for (int k = 0; k < numberOfOldBullets; k++)
        {
          // Debug.Log(k);
          // Debug.Log("numberOfOldBullets: " + GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().bulletNumber);
          // Debug.Log("roundStartTime:" + roundStartTime);
          roundStartTime += 1;
          bulletMovements[k].Add(GameObject.Find("Old Bullet" + k).transform.position);
          // Debug.Log("bulletMovements[k].Count: " + bulletMovements[k].Count);
        }
      }


    }
    else if (
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState == "replay" // if in game in replay state then replay shot
    )
    {

      // Replay on stars   
      for (var j = 0; j < numberOfStars; j++)
      {
        if (roundTime < starMovements[j].Count)
        {
          GameObject.Find("New Star" + j).transform.position = starMovements[j][roundTime];
        }
      }

      // Replay on bullets    
      //   for (var k = 0; k < numberOfOldBullets; k++)
      //   {
      //     // Debug.Log("bulletMovements[k]:" + bulletMovements[k].Count);
      //     {
      //       GameObject.Find("Old Bullet" + k).transform.position = bulletMovements[k][roundTime];
      //     }

      //     // Clear bullet data
      //     // clearReplayData();

      //   }
      // }

          Debug.Log("roundTime:" + roundTime);
          Debug.Log("bulletMovements[bulletToReplay].Count:" + bulletMovements[bulletToReplay].Count);
      if (roundTime < bulletMovements[bulletToReplay].Count){
        GameObject.Find("Old Bullet" + bulletToReplay).transform.position = bulletMovements[bulletToReplay][roundTime];
      } else {
          // GameObject.Find("Old Bullet" + bulletToReplay).GetComponent<MeshRenderer>().enabled = false;
        }
      // Debug.Log("Amount of replay time:" + i);
      roundTime += 1;

    }
  }

  public void clearReplayData()
  {
   

    // Number of old bullets in game
    int numberOfOldBullets = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().bulletNumber;

    for (var i = 0; i < numberOfOldBullets; i++)
    {
      if (roundTime >= bulletMovements[i].Count) // replay is over
      {
        // Create new game
        GameObject.FindGameObjectWithTag("Intro").GetComponent<levelGenerator>().CreateNewLevel();
        Debug.Log("Clear bullets");
        // Clear bullet record
        bulletMovements[i].Clear();

        // Delete bullet movement lists
        //  Debug.Log("destroyed By Old Bullet: " + numberOfOldBullets);
        // Debug.Log("DESTROY OLD BULLETS");
        roundTime = 0;

        // Clear star data
        int numberOfStars = GameObject.FindGameObjectWithTag("Intro").GetComponent<levelGenerator>().numberOfStars;
        if (i < numberOfStars)
        {
          starMovements[i].Clear();
        }
      }
    }
  }

  public void bookmarkTime()
  {
    roundStartTimes.Add(roundStartTime);
  }
}

// Debug.Log("destroyedBy: " + destroyedBy);

// Replay on bullet
// if (destroyedBy == "Active Bullet")
// {
//   // Debug.Log("destroyed By Active Bullet: " + destroyedBy);
//   GameObject.FindGameObjectWithTag("Active Bullet").transform.position = activeBulletMovement[roundTime];
// }

// BEFORE COUNTDOWN INT TIMER
// float timeBeforeImpact = activeBulletMovement.Count - i;
// if(timeBeforeImpact < 100){ // one second before impact
//   // Start countdown
//   GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "intro";
//   timeBeforeImpact = 0;
// }