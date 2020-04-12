using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class loser : MonoBehaviour
{
  private TextMeshPro playerTxt;
  private TextMeshPro winnerTxt;


  void Start() // Start is called before the first frame update
  {
    // Int the win text that displays the winner
    winnerTxt = GameObject.FindGameObjectWithTag("Win Text").GetComponent<TextMeshPro>();
    winnerTxt.enabled = false;
    // Player text that displays whose turn it is (needs to be hidden
    playerTxt = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>();

  }

  /*
   * Someone lost the game!
   * If a bullet hits another player then do the following:
   * - Hide Green
   * - Play explosion
   * - Reset active bullet
   * - Destroy old bullets
   * - Set and display text
   * - Reset the power meter
   * - Int intro with countdown and new ship entering the battle
   */
  public void Loser(string player)
  {
    // Record round 
    GameObject.FindGameObjectWithTag("GameController").GetComponent<lastShots>().recordShot();
    
    //  launch all bullets
    GameObject.FindGameObjectWithTag("Active Bullet").GetComponent<firingBullet>().AllBullets();
    
    // Reset rounds
    GameObject.FindGameObjectWithTag("Intro").GetComponent<levelGenerator>().destoryStars();
    GameObject.FindGameObjectWithTag("Intro").GetComponent<levelGenerator>().generateLevel();
    

    GetComponent<gameStates>().round += 1;
    // lets other scripts know whose lost
    GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().lostPlayer = player;
    // disables player text
    playerTxt.enabled = false;
    // enables winner text
    winnerTxt.enabled = true;
    if (player == "Green")
    {
      // Set and display text.
      winnerTxt.SetText("Red wins");
      // cause Green to hide
      GameObject.FindGameObjectWithTag("Green").gameObject.GetComponent<MeshRenderer>().enabled = false;
      // cause explosion
      GameObject.FindGameObjectWithTag("Green Explosion").GetComponent<ParticleSystem>().Play();
      // ball resets at Green
    }
    else if (player == "Red")
    {
      // Set and display text.
      winnerTxt.SetText("Green wins");
      // cause Green to hide
      GameObject.FindGameObjectWithTag("Red").gameObject.GetComponent<MeshRenderer>().enabled = false;
      // cause explosion
      GameObject.FindGameObjectWithTag("Red Explosion").GetComponent<ParticleSystem>().Play();
    }

    // number of old bullets
    int numberOfOldBullets = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().timeout;
    // Destroy all old bullets
    for (int i = 0; i < numberOfOldBullets; i++)
    { // for every old bullet
      GameObject oldBullet = GameObject.FindGameObjectWithTag("Old Bullet" + i);
      Destroy(oldBullet); // exert a force towards planet
    }

    GameObject.FindGameObjectWithTag("Active Bullet").gameObject.GetComponent<MeshRenderer>().enabled = false;
    GameObject[] bullets = GameObject.FindGameObjectsWithTag("Old Bullet");
    foreach (GameObject bullet in bullets)
    {
      Destroy(bullet);
    }
    // Rescale the power meter to original size.
    GameObject.FindGameObjectWithTag("Power Meter").GetComponent<power>().ResetPowerMeter();
    // change state to intro
    GetComponent<gameStates>().gameState = "intro";
    // launch intro
    GameObject.FindGameObjectWithTag("Intro").GetComponent<intro>().StartGame();
  }
}
