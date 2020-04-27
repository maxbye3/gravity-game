using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moveStars : MonoBehaviour
{
  private float distance_to_screen;
  private Vector3 pos_move;
  private bool starSelected;
  private GameObject star;

  // Update is called once per frame
  void LateUpdate()
  {

    if (starSelected)
    {

      // Star becomes cursor
      distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
      pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
      transform.position = new Vector3(pos_move.x, pos_move.y, pos_move.z);
    }
  }

  //Triggered when you click on the star
  private void OnMouseDown()
  {
    if (GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState == "drag stars")
    { // if star draggin state
      starSelected = !starSelected;
      // Enable star text
      


    }
  }
}
