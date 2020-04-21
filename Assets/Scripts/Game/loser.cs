using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class loser : MonoBehaviour
{
  private TextMeshPro redWins;
  private TextMeshPro greenWins;


  void Start() // Start is called before the first frame update
  {
    DisableWinnerTexts();

  }

  public void DisableWinnerTexts()
  {
    redWins = GameObject.FindGameObjectWithTag("Green Lost Text").GetComponent<TextMeshPro>();
    redWins.enabled = false;
    greenWins = GameObject.FindGameObjectWithTag("Red Lost Text").GetComponent<TextMeshPro>();
    greenWins.enabled = false;
  }

  /*
   * Someone lost the game! 
   * If a bullet hits another player then do the following:
   * - Change the UI
   * - Launch replay
   */
  public void Loser(string player, string hitBy)
  {
    // Show bullet (if hidden)
    GameObject.FindGameObjectWithTag("Active Bullet").gameObject.GetComponent<MeshRenderer>().enabled = true;
 
    // iterate round number
    GetComponent<gameStates>().round += 1;

    // Hide these game ui bits
    GameObject.FindGameObjectWithTag("Target").gameObject.GetComponent<MeshRenderer>().enabled = false;
    GameObject.FindGameObjectWithTag("Power Meter").gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;

    // Rescale the power meter to original size.
    GameObject.FindGameObjectWithTag("Power Meter").GetComponent<power>().ResetPowerMeter();

    // Change game state to replay
    GetComponent<gameStates>().gameState = "replay";

    // Turn off box collider on Active Bullet (it fucks the replay and initial bullet position)
    GameObject.FindGameObjectWithTag("Active Bullet").gameObject.GetComponent<SphereCollider>().enabled = false;

    // Set what the player was hit by
    GameObject.FindGameObjectWithTag("GameController").GetComponent<replay>().destroyedBy = hitBy;
    // Set the player text to read "Replay"
    GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>().SetText("Replay");

    // Lets other scripts know whose lost
    GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().lostPlayer = player;

    // Show text of winner 
    GameObject.FindGameObjectWithTag(player + " Lost Text").GetComponent<TextMeshPro>().enabled = true;
  }
}
