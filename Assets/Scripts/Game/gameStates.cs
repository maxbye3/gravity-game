using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStates : MonoBehaviour
{
  /*
  * Game States
  * Sets all the parameters if a game is won or a round is reset.
  */

  public string lostPlayer; // player that lost
  public string activePlayer; // whose round is it
  public string gameState; // whose round is it

  public int round = 0; // how many rounds

    // Start is called before the first frame update
    void Start()
    {
      activePlayer = "Red";
      // Green enters arena
      lostPlayer = "Green";
      // Plays intro first
      //  GameObject.FindGameObjectWithTag("Intro").GetComponent<intro>().StartGame();
      // Global game state
      //  gameState = "intro";
      // Starts the game immediately (uncomment and comment line 24)
       GetComponent<whoseTurn>().IntTurn(activePlayer);
       gameState = "game";

    }

    /*
    * Turn Timeout
    * After so many seconds because let's say
    * the bullet is orbiting a planet 
    * Then move the turn on to the other player
    */
public IEnumerator TurnTimeout(int seconds){
      int roundAtTimeOfShot = round; 
      yield return new WaitForSeconds(seconds);
      // If bullet is still being fired then change turns
      if(round == roundAtTimeOfShot){
        GetComponent<Reset>().ResetRound();
      }
    }

   
}
