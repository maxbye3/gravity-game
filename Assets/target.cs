using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
   private float distance_to_screen;
   private Vector3 pos_move;
   private bool movingTarget = true;

  // Use this for initialization
  void Start () {
  
  }
  
  // Update is called once per frame
  void Update () {
    if(movingTarget){
     distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
     pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen ));
     transform.position = new Vector3( pos_move.x, pos_move.y, pos_move.z );
    }

      if (Input.GetMouseButton(1) || Input.GetMouseButton(0)) {
        Debug.Log("HIT");
        movingTarget = false;
      }

  }
}
