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

    void Update(){
    }

   
}
