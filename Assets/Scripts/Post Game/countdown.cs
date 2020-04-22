using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class countdown : MonoBehaviour
{
  /*
   * Countdown
   * Deals with the countdown between rounds - introduces the round
   */

  private TextMeshPro countdownTxt;
  public float speed = 1f;

  public int howFarOut; // How far out does the ship start out of screen to fly in (this is a multiplier)
  private GameObject green;
  private Vector3 readyToGame;
  private Vector3 outOfTheScreen;
  private string lostPlayer;


  /*
  * Player death
  * After replay has occurred perform a set of animations to reset round
  */
  public void lostPlayerRebirth()
  {
    // Int the player who lost last game
    lostPlayer = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().lostPlayer;
    // Set off fireworks at position
    GameObject.FindGameObjectWithTag(lostPlayer).GetComponent<fireworks>().StartFireworks(lostPlayer);
    // Set the player who lost last game off screen
    readyToGame = GameObject.FindGameObjectWithTag(lostPlayer).gameObject.transform.position;
    outOfTheScreen = new Vector3(readyToGame.x * 2f, 0.5f, 0);
    GameObject.FindGameObjectWithTag(lostPlayer).gameObject.transform.position = outOfTheScreen;

    // Move the destroyed player back on screen after two seconds
    StartCoroutine(DelayMovement(2));
  }

  /*
 * Start Game
 * Start the countdown
 */
  public void StartCountdown()
  {
    // Hide bullet TEMP
    // GameObject.FindGameObjectWithTag("Active Bullet").gameObject.GetComponent<MeshRenderer>().enabled = false;

    // Show countdown text
    countdownTxt = GameObject.FindGameObjectWithTag("Countdown").GetComponent<TextMeshPro>();
    countdownTxt.enabled = true;
    countdownTxt.SetText("3"); // always start on 3

    //Start the coroutines we define below named SetText and then end countdown.
    StartCoroutine(SetText(1, "2"));
    StartCoroutine(SetText(2, "1"));
    StartCoroutine(EndCountdown(3)); // start the game
    lostPlayerRebirth();
  }

  // Delays the player from moving onto the screen
  IEnumerator DelayMovement(int seconds)
  {
    yield return new WaitForSeconds(seconds);
    // Move lost player
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

  // REMOVE OLD BULLETS
  void removeOldBullets()
  {
    // number of old bullets
    int numberOfOldBullets = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().timeout;

    for (int i = 0; i < numberOfOldBullets; i++)
    { // Destroy every old bullet
      Destroy(GameObject.Find("Old Bullet" + i));
    }
  }


  // Countdown ends after 3 seconds and game is started
  IEnumerator EndCountdown(int seconds)
  {
    // Remove old bullets
    removeOldBullets();
    //yield on a new YieldInstruction that waits for seconds.
    yield return new WaitForSeconds(seconds);

    // hides the countdown
    countdownTxt.enabled = false;

    // Show player
    GameObject.FindGameObjectWithTag(lostPlayer).gameObject.GetComponent<MeshRenderer>().enabled = true;

    GameObject gameController = GameObject.FindGameObjectWithTag("GameController"); // int global game state
    // Reset game
    gameController.GetComponent<nextTurn>().NextTurn();
    // Find whose turn it is
    gameController.GetComponent<startGame>().StartGame();
  }

}