using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
  /*
    * Target
    * Follow the mouse pointer until mouse click
    */
  private float distance_to_screen;
  private Vector3 pos_move;
  public bool targetActive = true;

  // Update is called once per frame
  void Update()
  {
    // We are in game state
    bool isGame = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState == "game";
    // Follow the mouse pointer
    if (
      targetActive && isGame // target is active
    )
    {
      distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
      pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
      transform.position = new Vector3(pos_move.x, pos_move.y, pos_move.z);
    }
    // If user clicks the mouse then don't follow the mouse pointer
    if (
      (Input.GetMouseButton(1) || Input.GetMouseButton(0))
      && isGame
      )
    {
      targetActive = false;
    }
  }
}
