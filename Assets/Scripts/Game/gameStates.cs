using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStates : MonoBehaviour {
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

  void Start () { // Start is called before the first frame update
    activePlayer = "Red"; // Red starts
    if (howDoesGameStart == "intro") {
      /*
       * If you want to start the game with intro animation
       */
      lostPlayer = "Green"; // Green enters arena (disabled)
      // Plays intro first
      GameObject.FindGameObjectWithTag ("Intro").GetComponent<intro> ().StartGame ();
      // Global game state
      gameState = "intro";
    } else {
      /*
       * Otherwise if you want to start the game immediately (uncomment and comment line 24)
       */
      GetComponent<whoseTurn> ().IntTurn ();
      gameState = "game";
    }

  }

  /*
   * Turn Timeout
   * After so many seconds because let's say
   * the bullet is orbiting a planet 
   * Then move the turn on to the other player
   */
  public IEnumerator TurnTimeout (int seconds) {
    // The round at the beginning of timeout
    int roundAtTimeOfShot = round;
    yield return new WaitForSeconds (seconds);
    
    if (round == roundAtTimeOfShot) { // Check if we're in the same round
      GetComponent<reset> ().ResetRound (); // Reset the game

      GameObject bullet = GameObject.FindGameObjectWithTag ("Bullet"); // int bullet

      // Clone bullet
      GameObject newBullet = Instantiate (bullet, GetComponent<whoseTurn> ().playerSpecifics (), Quaternion.identity);
      // Change bullet tag so old bullet just floats till round end (TO DO: tag should be unique)
      bullet.transform.gameObject.tag = "Old Bullet";
      // Remove force from new bullet
      GameObject.FindGameObjectWithTag ("Bullet").transform.GetComponent<Rigidbody> ().velocity = Vector3.zero;
      GameObject.FindGameObjectWithTag ("Bullet").transform.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;

      // Iterate round number (round over)
      GetComponent<gameStates> ().round += 1;

    }
  }

}