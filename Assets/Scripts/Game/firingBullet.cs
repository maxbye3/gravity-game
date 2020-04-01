using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (Rigidbody))]
public class firingBullet : MonoBehaviour {
  /*
   * Firing Bullet
   * Fires the bullet if the power has been specified
   */
  public Vector3 bulletInitialRedPos = new Vector3 (-6.6f, 0.5f, 0); // Export the bullets initial position when game is reset.
  public Vector3 bulletInitialGreenPos = new Vector3 (6.6f, 0.5f, 0); // Export the bullets initial position when game is reset.
  public int powerConstant = 10; // Multiplier that determines how fast the bullet travels (powerConstant * powerChosenByUser).
  public bool shotFired = false; // Determines if the shot has been fired or not.
  public int timeout = 4; // amount of time bullet flies before resetting player

  /*
   * Fire Bullet
   * If there's power assigned to the bullet then fire the bullet
   */
  void FireBullet (int powerLevel) {

    // Remove force from bullet
    GameObject.FindGameObjectWithTag("Bullet").transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
    GameObject.FindGameObjectWithTag("Bullet").transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; 
    
    // Set position of bullet
    GameObject.FindGameObjectWithTag("Bullet").transform.position = GameObject.FindGameObjectWithTag("GameController").GetComponent<whoseTurn>().playerSpecifics();
    
    /*
     * target & bullet
     */
    GameObject target = GameObject.FindGameObjectWithTag ("Target"); // int target
    GameObject bullet = GameObject.FindGameObjectWithTag ("Bullet"); // int bullet
    // Hide target
    GameObject.FindGameObjectWithTag ("Target").gameObject.GetComponent<MeshRenderer> ().enabled = false;
    // Calculate the vector from from target to ship to know which direction to fire in.
    Vector2 vectorToTarget = target.transform.position - bullet.transform.position;
    // Calculate distance from ship to target so shot power is uniform.
    float distanceToTarget = Vector3.Distance (target.transform.position, bullet.transform.position);
    // Add force to active bullet 
    GameObject.FindGameObjectWithTag ("Bullet").GetComponent<Rigidbody> ().AddForce ((vectorToTarget * powerLevel * powerConstant) / distanceToTarget);
    // target and bullet

    // Reset power level
    powerLevel = 0;
    // Not sure why this bool was needed and the above line doesn't stop force being added to bullet but it is
    shotFired = true;
    // Start timeout counter and change player if bullets faffing about
    StartCoroutine (GameObject.FindGameObjectWithTag ("GameController").gameObject.GetComponent<gameStates> ().TurnTimeout (timeout));
  }

  void Update () // Update is called once per frame.
  {
    // Get the bullet's power level.
    int powerLevel = GameObject.FindGameObjectWithTag ("Power Meter").GetComponent<power> ().powerLevel;

    if (
      GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameStates> ().gameState == "game" // We are in game state (not intro)
      &&
      powerLevel != 0 // If power level is defined 
      &&
      !shotFired // Shots have not been defined
    ) {
      FireBullet (powerLevel); // Fire!
    }
  }
}