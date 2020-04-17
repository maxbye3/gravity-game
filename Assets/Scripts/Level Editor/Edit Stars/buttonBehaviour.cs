using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buttonBehaviour : MonoBehaviour
{
  public bool starEditing = false;
  private Vector3 initialPosGreen;
  private Vector3 initialPosRed;
  private Vector3 initialPosBullet;

  public GameObject createStarBtn;

  public void onButtonEnter()
  {
    GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "button hover"; // We are in game state (not intro)
    // Star creator mode is on
    if(GameObject.FindGameObjectWithTag("Create Star Functionality").GetComponent<starCreation>().sunCreated == true) { 
      starEditing = true; // set button back to game
    }
  }
  public void onButtonExit()
  {
    if (GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState == "button hover")
    { // button not clicked
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "game"; // We are in game state (not intro)
    }
  }

  // Get the positions of bullet and player
  public void initialPosOfPlayers()
  {
    initialPosGreen = GameObject.FindGameObjectWithTag("Green").transform.position;
    initialPosRed = GameObject.FindGameObjectWithTag("Red").transform.position;
    initialPosBullet = GameObject.FindGameObjectWithTag("Active Bullet").transform.position;
  }

  public void onButtonClick()
  {    
    GameObject.FindGameObjectWithTag("Create Star Functionality").GetComponent<starCreation>().closeMenu();
    TextMeshProUGUI buttonText = GameObject.FindGameObjectWithTag("Edit Stars Text").GetComponent<TextMeshProUGUI>();
    if (!starEditing) // Moving planets
    {
      // Hide Create Star Button
      createStarBtn.SetActive(false);

      // Hide target
      GameObject.FindGameObjectWithTag("Target").gameObject.GetComponent<MeshRenderer>().enabled = false;

      // Get the positions of bullet and player
      initialPosOfPlayers(); 

      // Hide the players / put it somewhere crazy
      GameObject.FindGameObjectWithTag("Green").transform.position = new Vector3(2000f, 2000f, 2000f);
      GameObject.FindGameObjectWithTag("Red").transform.position = new Vector3(4000f, 4000f, 4000f);
      
      // We are dragging stars
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "drag stars"; 
      // Button text change
      buttonText.SetText("Back to game");
      // New instruction (will get overwritten if in star creation mode)
      GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>().SetText("Click and drag stars. Click star to place it.");
      // If in star creation mode then save new star
      GameObject.FindGameObjectWithTag("Create Star Functionality").GetComponent<starCreation>().saveStar();
      // Cancel star moving next click
      starEditing = !starEditing;
      
    }
    else // Back to fame
    {
      // Show create star btn
      createStarBtn.SetActive(true);
      // Show target
      GameObject.FindGameObjectWithTag("Target").gameObject.GetComponent<MeshRenderer>().enabled = false;
      // Reset button text
      buttonText.SetText("Move stars");
      // Return the positions of bullet and player to initial
      GameObject.FindGameObjectWithTag("Green").transform.position = initialPosGreen;
      GameObject.FindGameObjectWithTag("Red").transform.position = initialPosRed;
      // GameObject.FindGameObjectWithTag("Active Bullet").transform.position = GameObject.FindGameObjectWithTag("Active Bullet").GetComponent<firingBullet>().bulletInitialRedPos;
      starEditing = !starEditing;
      // Green re-enters
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().lostPlayer = "Green"; // Green enters arena (disabled)
      // Start inro animation
      GameObject.FindGameObjectWithTag("Intro").GetComponent<countdown>().StartCountdown();
      
      // Destroy the new planet
      GameObject.FindGameObjectWithTag("Create Star Functionality").GetComponent<starCreation>().destroyStar();

    }
  }
}
