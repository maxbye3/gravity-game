using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class whoseTurn : MonoBehaviour
{
  private TextMeshPro playerTxt;

  private GameObject bullet; // the bullet

  void Start() {
    
  }

  /*
   * Show these things
   * A series of game objects to show while the game is happening
   */
  void ShowInGame()
  {
    GameObject.FindGameObjectWithTag("Bullet").gameObject.GetComponent<MeshRenderer>().enabled = true;
    GameObject.FindGameObjectWithTag("Target").gameObject.GetComponent<MeshRenderer>().enabled = true;
    GameObject.FindGameObjectWithTag("Power Meter").gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
    GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>().enabled = true;
    // hide the winner text
    GameObject.FindGameObjectWithTag("Win Text").GetComponent<TextMeshPro>().enabled = false;
  }

  /*
   * Depending on whose turn it is
   * Do the following stuff (text change)
   * Return the ball position of whoever's turn it is  
   */
  public Vector3 playerSpecifics()
  {
    playerTxt = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>(); // int player text
    bullet = GameObject.FindGameObjectWithTag("Bullet"); // bullet

    // get active player
    string player = GetComponent<gameStates>().activePlayer;
    if (player == "Red")
    {
      // Text
      playerTxt.SetText("Red's turn");
      // Switch player text
      GetComponent<gameStates>().activePlayer = "Green";
      // Return Red's original bullet position 
      return bullet.GetComponent<firingBullet>().bulletInitialRedPos;
    }
    // Else it's the green player
    // Text
    playerTxt.SetText("Green's turn");
    // Switch player text
    GetComponent<gameStates>().activePlayer = "Red";
    // Return Green's original bullet position 
    return bullet.GetComponent<firingBullet>().bulletInitialGreenPos;
  }

  /*
   * Whose Round (is it anyway?)
   * Depending on whose round change the environments
   * - Show and re-enable the target 
   */
  public void IntTurn()
  {    
    // Change global game state
    GetComponent<gameStates>().gameState = "game";
    // Show bunch of stuff to do with game
    ShowInGame();
  }
}