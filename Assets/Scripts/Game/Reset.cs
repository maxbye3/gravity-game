using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class reset : MonoBehaviour
{
  /*
   * Reset round
   * If bullet flies out of bounds then reset the round by doing the following:
   * - Show and re-enable the target 
   * - Reset bullet position and remove force 
   * - Reset the power meter
   */
  public float offScreenRight = 10; // right of the game screen
  public float offScreenLeft = -10; // left of the game screen
  public float offScreenTop = 6; // top of the game screen
  public float offScreenBottom = -6; // bottom of the game screen 
  private GameObject bullet; // the bullet

  public void ResetRound()
  {
    GameObject target = GameObject.FindGameObjectWithTag("Target"); // int target
    // Show target
    target.gameObject.GetComponent<MeshRenderer>().enabled = true;
    // Re-enable target
    target.GetComponent<target>().targetActive = true;
    // Rescale the power meter to original size
    GameObject.FindGameObjectWithTag("Power Meter").GetComponent<power>().ResetPowerMeter();
    // Set power to 0
    GameObject.FindGameObjectWithTag("Power Meter").GetComponent<power>().powerLevel = 0;
    // Let bullet be shot again and stop resetting of game
    GameObject.FindGameObjectWithTag("Bullet").GetComponent<firingBullet>().shotFired = false;
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    bullet = GameObject.FindGameObjectWithTag("Bullet"); // int bullet

    // If bullet flied out of bounds then reset the round 
    if (bullet &&
      bullet.transform.position.x > offScreenRight ||
      bullet.transform.position.x < offScreenLeft ||
      bullet.transform.position.y > offScreenTop ||
      bullet.transform.position.y < offScreenBottom
    )
    {
      ResetRound();
      // Change whose round it is (from Green <==> Red)
      GetComponent<whoseTurn>().IntTurn();

      Debug.Log("Remove force on new bullet!");
      // Iterate round number (round over)
      GetComponent<gameStates>().round += 1;
    }

  }

}