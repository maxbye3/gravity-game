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


    // Start is called before the first frame update
    void Start()
    {
      activePlayer = "Red";
      // Green enters arena
      lostPlayer = "Green";
       GetComponent<whoseTurn>().IntTurn(activePlayer);

    }

   
}
