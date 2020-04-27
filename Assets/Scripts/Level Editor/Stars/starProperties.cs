using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class starProperties : MonoBehaviour
{
  public bool isRotating;


  // Stars rotate
  public void startRotating()
  {
    if (isRotating)
    {
      // Number of stars in game
      int numberOfStars = GameObject.FindGameObjectWithTag("Intro").GetComponent<levelGenerator>().numberOfStars;

      for (var i = 0; i < numberOfStars; i++)
      {
        // Start rotation
        GameObject.Find("New Star" + i).transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 0, 5), 1);
        var starPos = GameObject.Find("New Star" + i).transform.position;
        GameObject.Find("New Star Text" + i).transform.position = new Vector3(starPos.x, starPos.y, -1);

      }
    }
  }
}
