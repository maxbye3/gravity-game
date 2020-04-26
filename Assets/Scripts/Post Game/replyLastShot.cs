using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class replyLastShot : MonoBehaviour
{

//   /*
//   * NOT QUITE DONE - WORKS BUT NEEDS TO BE REFACTORED INTO REPLAY
//   */ 

//   public List<Vector3> activeBulletMovement = new List<Vector3>();
//   public List<List<Vector3>> starMovements = new List<List<Vector3>>();
//   public List<List<Vector3>> bulletMovements = new List<List<Vector3>>();
//   public string destroyedBy;
//   public int roundStartTime = 0;

//   public int roundTime = 0;
//   public List<int> roundStartTimes = new List<int>();
//   public int bulletToReplay;

//   public int starCounter = 0;
//   void Start()
//   {
//     roundStartTimes.Add(0);
//   }

//   // Update is called once per frame
//   void FixedUpdate()
//   {
//     // Number of old bullets in game
//     int numberOfOldBullets = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().bulletNumber;

//     // Number of stars in game
//     int numberOfStars = GameObject.FindGameObjectWithTag("Intro").GetComponent<levelGenerator>().numberOfStars;



//     // Record position of bullet as soon as ball starts moving
//     if (
//       GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState == "game" // if in game state record                                                                                                        // && GameObject.FindGameObjectWithTag("Active Bullet").GetComponent<firingBullet>().shotFired // shot fired
//       )
//     {
//       if (numberOfOldBullets > 0)
//       { // if old bullets exist


//       // RECORD STARS    
//       for (var j = 0; j < numberOfStars; j++)
//       {
//         starMovements[j].Add(GameObject.Find("New Star" + j).transform.position);
//       }

//         // Debug.Log("old bullet position: " + GameObject.Find("Old Bullet0").transform.position);
//         for (int k = 0; k < numberOfOldBullets; k++)
//         {
//           // Debug.Log("numberOfOldBullets: " + GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().bulletNumber);
//           // Debug.Log("roundStartTime:" + roundStartTime);
//           // Debug.Log("bulletMovements[0].Count: " + bulletMovements[k].Count);
//           // Debug.Log("bulletMovements[1].Count: " + bulletMovements[k].Count);
//           roundStartTime += 1;
//           bulletMovements[k].Add(GameObject.Find("Old Bullet" + k).transform.position);
//         }
//       }


//     }
//     else if (
//       GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState == "last shot" // if in game in replay state then replay shot
//     )
//     {

//       roundTime += 1;

//       // Replay on stars   
//       for (var j = 0; j < numberOfStars; j++)
//       {
//         if (roundTime < starMovements[j].Count)
//         {
//           GameObject.Find("New Star" + j).transform.position = starMovements[j][roundTime];
//         }         
//       }

//       /*
//       * REPLAY ON BULLETS
//       * Bug where bullets dissapear pre-maturely i.e. not recording full bulletMovements[bulletToReplay].Count
//       */
//           // Debug.Log("roundTime:" + roundTime);
//           // Debug.Log("bulletMovements[bulletToReplay].Count:" + bulletMovements[bulletToReplay].Count);
//       if (roundTime < bulletMovements[bulletToReplay].Count){
//         GameObject.Find("Old Bullet" + bulletToReplay).transform.position = bulletMovements[bulletToReplay][roundTime];
//       } else {
//           GameObject.Find("Old Bullet" + bulletToReplay).GetComponent<MeshRenderer>().enabled = false;
//           GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "game";
//           roundTime = 0;
          
//         }
//     }
//   }

//   public void clearReplayData()
//   {
   

//     // Number of old bullets in game
//     int numberOfOldBullets = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().bulletNumber;

//     for (var i = 0; i < numberOfOldBullets; i++)
//     {
//       if (roundTime >= bulletMovements[i].Count) // replay is over
//       {
//         // Create new game
//         GameObject.FindGameObjectWithTag("Intro").GetComponent<levelGenerator>().CreateNewLevel();        

//         // Delete bullet movements lists
//         //  Debug.Log("destroyed By Old Bullet: " + numberOfOldBullets);
//         bulletMovements[i].Clear();

//         // Clear star data
//         int numberOfStars = GameObject.FindGameObjectWithTag("Intro").GetComponent<levelGenerator>().numberOfStars;
//         if (i < numberOfStars)
//         {
//           starMovements[i].Clear();
//         }
//       }
//     }
//   }
}