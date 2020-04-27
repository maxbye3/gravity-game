using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class starTextFunctionality : MonoBehaviour
{
  // Turn off all stars
  public void disableStars()
  {
    // Number of stars in game
    int numberOfStars = GameObject.FindGameObjectWithTag("Intro").GetComponent<levelGenerator>().numberOfStars;
    for (var i = 0; i < numberOfStars; i++)
    {
      // Turn off
      GameObject.Find("New Star Text" + i).GetComponent<TextMeshPro>().enabled = false;
    }
  }
  // Turn on all stars
  public void enableStars()
  {
    // Number of stars in game
    int numberOfStars = GameObject.FindGameObjectWithTag("Intro").GetComponent<levelGenerator>().numberOfStars;
    for (var i = 0; i < numberOfStars; i++)
    {
      // Turn off
      GameObject.Find("New Star Text" + i).GetComponent<TextMeshPro>().enabled = true;
    }
  }

  // Re-align star text to star position
  public void realignStarText(){
        // Number of stars in game
    int numberOfStars = GameObject.FindGameObjectWithTag("Intro").GetComponent<levelGenerator>().numberOfStars;
    for (var i = 0; i < numberOfStars; i++)
    {
      // set position to star
      GameObject.Find("New Star Text" + i).transform.position = GameObject.Find("New Star" + i).transform.position;
    }
  }
}
