using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class nextTurn : MonoBehaviour
{
  /*
   * Next turn
   * If bullet flies out of bounds then reset the round / give next turn by doing the following:
   * - Show and re-enable the target 
   * - Reset bullet position and remove force 
   * - Reset the power meter
   */
  public float offScreenRight = 10; // right of the game screen
  public float offScreenLeft = -10; // left of the game screen
  public float offScreenTop = 6; // top of the game screen
  public float offScreenBottom = -6; // bottom of the game screen 
  private GameObject bullet; // the bullet

  public void NextTurn()
  {
    // Debug.Log("Next turn begin");
    // Int target
    GameObject target = GameObject.FindGameObjectWithTag("Target");
    // Make new bullet not harmful
    GameObject.FindGameObjectWithTag("Active Bullet").gameObject.GetComponent<SphereCollider>().enabled = false;
    // Show target
    target.gameObject.GetComponent<MeshRenderer>().enabled = true;
    // Re-enable target
    target.GetComponent<target>().targetActive = true;
    // Rescale the power meter to original size
    GameObject.FindGameObjectWithTag("Power Meter").GetComponent<power>().ResetPowerMeter();
    // Set power to 0
    GameObject.FindGameObjectWithTag("Power Meter").GetComponent<power>().powerLevel = 0;
    // Let bullet be shot again and stop resetting of game
    GameObject.FindGameObjectWithTag("Active Bullet").GetComponent<firingBullet>().shotFired = false;

    // Hide bullet
    GameObject.FindGameObjectWithTag("Active Bullet").gameObject.GetComponent<MeshRenderer>().enabled = false;


    // Show whose turn it is
    var playerTxt = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>(); // int player text
    playerTxt.enabled = true;


  }

}
