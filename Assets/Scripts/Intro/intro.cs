using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class intro : MonoBehaviour
{
  /*
   * Intro
   * Deals with the countdown between rounds - introduces the round
   */

  private TextMeshPro countdownTxt;
  public float speed = 1f;

  public int howFarOut; // How far out does the ship start out of screen to fly in (this is a multiplier)
  private GameObject green;
  private Vector3 readyToGame;
  private Vector3 outOfTheScreen;
  private string lostPlayer;
  // Start is called before the first frame update

  /*
 * Hide these things
 * A series of game objects to hide while the countdown is happening
 */
  void HideInGame()
  {
    GameObject.FindGameObjectWithTag("Target").gameObject.GetComponent<MeshRenderer>().enabled = false;
    GameObject.FindGameObjectWithTag("Power Meter").gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
    GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>().enabled = false;
  }
  /*
 * Start Game
 * Start the countdown
 */
  public void StartGame()
  {
    HideInGame();
    // Show countdown text
    countdownTxt = GameObject.FindGameObjectWithTag("Countdown").GetComponent<TextMeshPro>();
    countdownTxt.enabled = true;
    countdownTxt.SetText("3"); // always start on 3
    //Start the coroutines we define below named SetText and StartGame.
    StartCoroutine(StopFireworks(0f));
    StartCoroutine(SetText(1, "2"));
    StartCoroutine(SetText(2, "1"));
    StartCoroutine(StartGame(3)); // start the game
    // Int the player who lost last game
    lostPlayer = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().lostPlayer;
    // Show the player who lost last game
    GameObject.FindGameObjectWithTag(lostPlayer).gameObject.GetComponent<MeshRenderer>().enabled = true;
    // Set the player who lost last game off screen
    readyToGame = GameObject.FindGameObjectWithTag(lostPlayer).gameObject.transform.position;
    outOfTheScreen = new Vector3(readyToGame.x * 2f, 0, 0);
    GameObject.FindGameObjectWithTag(lostPlayer).gameObject.transform.position = outOfTheScreen;
    StartCoroutine(DelayMovement(2)); // Move the player back on screen after two seconds

  }
  // Stops the player explosion animation
  IEnumerator StopFireworks(float seconds)
  {
    yield return new WaitForSeconds(seconds);
    GameObject.FindGameObjectWithTag("Green Explosion").GetComponent<ParticleSystem>().Stop();
    GameObject.FindGameObjectWithTag("Red Explosion").GetComponent<ParticleSystem>().Stop();
  }
  // Delays the player from moving onto the screen
  IEnumerator DelayMovement(int seconds)
  {
    yield return new WaitForSeconds(seconds);
    StartCoroutine(MoveFromTo(GameObject.FindGameObjectWithTag(lostPlayer).gameObject.transform, outOfTheScreen, readyToGame, 10));
  }
  // Animates the player onto the game screen
  IEnumerator MoveFromTo(Transform objectToMove, Vector3 a, Vector3 b, float speed)
  {
    float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;
    float t = 0;
    while (t <= 1.0f)
    {

      t += step; // Goes from 0 to 1, incrementing by step each time
      objectToMove.position = Vector3.Lerp(a, b, t); // Move objectToMove closer to b
      yield return new WaitForFixedUpdate(); // Leave the routine and return here in the next frame
    }
  }
  // Sets the countdown text
  IEnumerator SetText(int seconds, string text)
  {
    //yield on a new YieldInstruction that waits for seconds.
    yield return new WaitForSeconds(seconds);
    countdownTxt.SetText(text);

  }
  // Start game after 3 secondss
  IEnumerator StartGame(int seconds)
  {
    //yield on a new YieldInstruction that waits for seconds.
    yield return new WaitForSeconds(seconds);

    // hides the countdown
    countdownTxt.enabled = false;

    GameObject gameController = GameObject.FindGameObjectWithTag("GameController"); // int global game state
    // Reset game
    gameController.GetComponent<reset>().ResetRound();
    // Find whose turn it is
    gameController.GetComponent<whoseTurn>().IntTurn();
    // Remove force from bullet
    GameObject.FindGameObjectWithTag("Active Bullet").transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
    GameObject.FindGameObjectWithTag("Active Bullet").transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
  }

}