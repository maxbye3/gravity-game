using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void lastShot()
    {
      // Debug.Log("Last Shot");
      // Number of old bullets in game
      int numberOfOldBullets = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().bulletNumber;
      // Debug.Log("Number of old bullets in game: " + numberOfOldBullets);
      int bulletToReplay = numberOfOldBullets - 1;
      // Debug.Log("Bullet to replay: " + bulletToReplay);
      // What number of bullet to shoot
      GameObject.FindGameObjectWithTag("GameController").GetComponent<replay>().bulletToReplay = bulletToReplay;

      var roundTimes = GameObject.FindGameObjectWithTag("GameController").GetComponent<replay>().roundStartTimes;
      // Obtain the time last shot started:
      // int lastShot = (int) roundTimes[(roundTimes.Count - 1)];
      //  Debug.Log("Last shot:" + lastShot);
      GameObject.FindGameObjectWithTag("GameController").GetComponent<replay>().roundTime = 0;
      // Go into replay mode
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "replay";
    }
    public void shotBeforeLast()
    {
        Debug.Log("Shot before last");
    }

    // Update is called once per frame
    public void thirdShotBack()
    {
        Debug.Log("Shot before the one before last");
    }

  public void onButtonEnter()
  {
    GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "button hover"; // We are in game state (not intro)
  }

    public void onButtonExit()
  {
    if (GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState == "button hover")
    { // button not clicked
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "game"; // We are in game state (not intro)
    }
  }

}
