using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class firingBullet : MonoBehaviour
{
  /*
   * Firing Bullet
   * Fires the bullet if the power has been specified
   */
  public Vector3 bulletInitialRedPos = new Vector3(-6.6f, 0.5f, 0); // Export the bullets initial position when game is reset.
  public Vector3 bulletInitialGreenPos = new Vector3(6.6f, 0.5f, 0); // Export the bullets initial position when game is reset.
  public int powerConstant = 10; // Multiplier that determines how fast the bullet travels (powerConstant * powerChosenByUser).
  public bool shotFired = false; // Determines if the shot has been fired or not.
  public int timeout = 4; // amount of time bullet flies before resetting player
  public Vector3 bulletForce;

  /*
   * Fire Bullet
   * If there's power assigned to the bullet then fire the bullet
   */
  void FireBullet(int powerLevel)
  {
    
    /*
     * Target & bullet
     */
    GameObject target = GameObject.FindGameObjectWithTag("Target"); // int target
    GameObject bullet = GameObject.FindGameObjectWithTag("Active Bullet"); // int bullet
    // Hide target
    GameObject.FindGameObjectWithTag("Target").gameObject.GetComponent<MeshRenderer>().enabled = false;
    // Calculate the vector from from target to ship to know which direction to fire in.
    Vector2 vectorToTarget = target.transform.position - bullet.transform.position;
    // Calculate distance from ship to target so shot power is uniform.
    float distanceToTarget = Vector3.Distance(target.transform.position, bullet.transform.position);

    // Add force to active bullet 
    bulletForce = (vectorToTarget * powerLevel * powerConstant) / distanceToTarget;
    GameObject.FindGameObjectWithTag("Active Bullet").GetComponent<Rigidbody>().AddForce(bulletForce);

    // Reset power level
    powerLevel = 0;
    // Not sure why this bool was needed and the above line doesn't stop force being added to bullet but it is
    shotFired = true;

    // Start timeout counter and change player if bullets faffing about
    StartCoroutine(GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<gameStates>().TurnTimeout(timeout));

    // Everytime shot is fired take note of previous MAX BYE
    // GameObject.FindGameObjectWithTag("GameController").GetComponent<replay>().activeBulletMovement.Clear();
    // roundStartTime.Add();
    
    // bookmarks the time that a round starts
    GameObject.FindGameObjectWithTag("GameController").GetComponent<replay>().bookmarkTime();



    // Clear star data
    int numberOfStars = GameObject.FindGameObjectWithTag("Intro").GetComponent<levelGenerator>().numberOfStars;
    for (var j = 0; j < numberOfStars; j++)
    {
      GameObject.FindGameObjectWithTag("GameController").GetComponent<replay>().starMovements[j].Clear();
    }


    /*
    * TURNS ACTIVE BULLET INTO OLD BULLET
    */
      /* 
      * Bullet tracking
      * Create the correct number of lists to track bullets
      */
      // GameObject.FindGameObjectWithTag("Last Bullet Functionality").GetComponent<replyLastShot>().bulletMovements.Add(new List<Vector3>());
      GameObject.FindGameObjectWithTag("GameController").GetComponent<replay>().bulletMovements.Add(new List<Vector3>());
      

      // Make bullet harmful
      GameObject.FindGameObjectWithTag("Active Bullet").gameObject.GetComponent<SphereCollider>().enabled = true;

      /*
      * TURN ACTIVE BULLET INTO OLD BULLET
      */
      // Clone bullet
      GameObject newBullet = Instantiate(bullet, GameObject.FindGameObjectWithTag("GameController").GetComponent<startGame>().playerSpecifics(), Quaternion.identity);
      
      bullet.tag = "Untagged";
      // Change bullet tag so old bullet just floats till round end
      int bulletNumber = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().bulletNumber;
      // Debug.Log("bulletNumber: " + bulletNumber);
      bullet.transform.gameObject.name = "Old Bullet" + bulletNumber;
      bullet.transform.gameObject.tag = "Old Bullet";
      // Show old bullet
      bullet.gameObject.GetComponent<MeshRenderer>().enabled = true;
      // Iterate bullet number
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().bulletNumber += 1;
    // turn active bullet into old bullet
  }

  void Update() // Update is called once per frame.
  {
    // Get the bullet's power level.
    int powerLevel = GameObject.FindGameObjectWithTag("Power Meter").GetComponent<power>().powerLevel;

    if (
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState == "game" // We are in game state (not intro)
      &&
      powerLevel != 0 // If power level is defined 
      &&
      !shotFired // Shots have not been defined
    )
    {
      FireBullet(powerLevel); // Fire!
    }

  }
}