using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class startGame : MonoBehaviour
{

  /*
  * This class is called everytime a game starts
  */

  private TextMeshPro playerTxt;

  private GameObject bullet; // the bullet

  /*
   * Show these things
   * A series of game objects to show while the game is happening
   */
  void ShowInGame()
  {
    GameObject.FindGameObjectWithTag("Target").gameObject.GetComponent<MeshRenderer>().enabled = true;
    GameObject.FindGameObjectWithTag("Power Meter").gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
    GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>().enabled = true;
    // hide the winner text
    GameObject.FindGameObjectWithTag("GameController").GetComponent<loser>().DisableWinnerTexts();
  }

  /*
   * Depending on whose turn it is
   * Do the following stuff (text change)
   * Return the ball position of whoever's turn it is  
   */
  public Vector3 playerSpecifics()
  {
    playerTxt = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>(); // int player text
    bullet = GameObject.FindGameObjectWithTag("Active Bullet"); // bullet
    playerTxt.enabled = false;
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
  public void StartGame()
  {
    // Reset number of old bullets floating about
    GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().bulletNumber = 0;
    
    
    // Remove force from bullet
    GameObject.FindGameObjectWithTag("Active Bullet").transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
    GameObject.FindGameObjectWithTag("Active Bullet").transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    // Turn off box collider on Active Bullet (it fucks with the initial bullet position)
    GameObject.FindGameObjectWithTag("Active Bullet").gameObject.GetComponent<SphereCollider>().enabled = false;

    // Change global game state
    GetComponent<gameStates>().gameState = "game";
    // Show bunch of stuff to do with game
    ShowInGame();
    // Put bullet into position
    GameObject.FindGameObjectWithTag("Active Bullet").transform.position = playerSpecifics();
    // Remove force from bullet doesn't quite work so I made a timeout as well
    GameObject.FindGameObjectWithTag("Active Bullet").transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
    GameObject.FindGameObjectWithTag("Active Bullet").transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    // This timeout stops the active bullet moving  
    StartCoroutine(StopBullet(0.2f));
    
    // Show whose turn it is
    var playerTxt = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>(); // int player text
    playerTxt.enabled = true;

    // Hide bullet
    GameObject.FindGameObjectWithTag("Active Bullet").gameObject.GetComponent<MeshRenderer>().enabled = false;

  }

  IEnumerator StopBullet(float seconds)
  {
    yield return new WaitForSeconds(seconds);
    // Remove force from bullet
    GameObject.FindGameObjectWithTag("Active Bullet").transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
    GameObject.FindGameObjectWithTag("Active Bullet").transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;    
  }
}