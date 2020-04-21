using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStates : MonoBehaviour
{
  /*
   * Game States
   * Sets all the parameters if a game is won or a round is reset.
   * Deals with timeout
   */

  public string lostPlayer; // player that lost
  public string activePlayer; // whose round is it
  public string gameState; // whose round is it
  public string howDoesGameStart;
  public int round = 0; // how many rounds
  public int timeout = 0;

  void Start()
  { // Start is called before the first frame update

    activePlayer = "Red"; // Red starts
    if (howDoesGameStart == "intro")
    {
      /*
       * If you want to start the game with intro animation
       */
      lostPlayer = "Green"; // Green enters arena (disabled)
      // Plays intro first
      GameObject.FindGameObjectWithTag("Intro").GetComponent<countdown>().StartCountdown();
      // Global game state
      gameState = "intro";
      GameObject.FindWithTag("Create Star");
    }
    else
    {
      /*
       * Otherwise if you want to start the game immediately (uncomment and comment line 24)
       */
      GetComponent<startGame>().StartGame();
      gameState = "game";
    }

  }

  /*
   * Turn Timeout
   * After so many seconds because let's say
   * the bullet is orbiting a star 
   * Then move the turn on to the other player
   */
  public IEnumerator TurnTimeout(int seconds)
  {
    // The round at the beginning of timeout
    int roundAtTimeOfShot = round;

    yield return new WaitForSeconds(seconds);
          /* 
      * Bullet tracking
      * Create the correct number of lists to track bullets
      */
      GameObject.FindGameObjectWithTag("GameController").GetComponent<replay>().bulletMovements.Add(new List<Vector3>());
      

    if (
      round == roundAtTimeOfShot // Check if we're in the same round
      && GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState == "game" // if playing game
      )
    {
      GetComponent<nextTurn>().NextTurn(); // Reset the game

      GameObject bullet = GameObject.FindGameObjectWithTag("Active Bullet"); // int bullet

      // Clone bullet
      GameObject newBullet = Instantiate(bullet, GetComponent<startGame>().playerSpecifics(), Quaternion.identity);

      // Change bullet tag so old bullet just floats till round end
      // GameObject.FindGameObjectWithTag("Helper").GetComponent<tagHelper>().AddTag("Old Bullet" + timeout);
      bullet.transform.gameObject.name = "Old Bullet" + timeout;
      // Show old bullet
      bullet.gameObject.GetComponent<MeshRenderer>().enabled = true;

      // Iterate round number (round over)
      round += 1;
      // Iterate round number (round over)
      timeout += 1;

    }
  }

}