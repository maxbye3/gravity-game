using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buttonBehaviour : MonoBehaviour
{
  private bool starEditing = false;
  private Vector3 initialPosGreen;
  private Vector3 initialPosRed;
  private Vector3 initialPosBullet;

  public void onButtonEnter()
  {
    GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "ui"; // We are in game state (not intro)
  }
  public void onButtonExit()
  {
    if (GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState != "drag stars")
    { // button not clicked
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "game"; // We are in game state (not intro)
    }
  }

  public void onButtonClick()
  {
    TextMeshProUGUI buttonText = GameObject.FindGameObjectWithTag("Edit Stars Text").GetComponent<TextMeshProUGUI>();
    if (!starEditing)
    {
      // Get the positions of bullet and player
      initialPosGreen = GameObject.FindGameObjectWithTag("Green").transform.position;
      initialPosRed = GameObject.FindGameObjectWithTag("Red").transform.position;
      initialPosBullet = GameObject.FindGameObjectWithTag("Active Bullet").transform.position;
      // Hide the active bullet / put it somewhere crazy
      // GameObject.FindGameObjectWithTag("Active Bullet").transform.position = new Vector3(2000f,2000f, 2000f);
      // Hide the players / put it somewhere crazy
      GameObject.FindGameObjectWithTag("Green").transform.position = new Vector3(2000f,2000f, 2000f);
      GameObject.FindGameObjectWithTag("Red").transform.position = new Vector3(4000f,4000f, 4000f);

      buttonText.SetText("Back to game");
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "drag stars"; // We are dragging planets
      starEditing = !starEditing;
    }
    else
    {
      buttonText.SetText("Move stars");
      // Return the positions of bullet and player to initial
      GameObject.FindGameObjectWithTag("Green").transform.position = initialPosGreen;
      GameObject.FindGameObjectWithTag("Red").transform.position = initialPosRed;
      // GameObject.FindGameObjectWithTag("Active Bullet").transform.position = GameObject.FindGameObjectWithTag("Active Bullet").GetComponent<firingBullet>().bulletInitialRedPos;
      starEditing = !starEditing;
      // Green re-enters
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().lostPlayer = "Green"; // Green enters arena (disabled)
      // Start inro animation
      GameObject.FindGameObjectWithTag("Intro").GetComponent<intro>().StartGame();

    }
  }
}
