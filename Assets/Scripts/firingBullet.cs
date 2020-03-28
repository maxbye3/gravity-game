using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class firingBullet : MonoBehaviour
{
  /*
  * Firing Bullet
  * Fires the bullet if the power meter has been specified
  */
    public Vector3 bulletInitialPos; // Export the bullets initial position when game is reset.
    public int powerConstant = 10; // Multiplier that determines how fast the bullet travels (powerConstant * powerChosenByUser).
    public bool shotFired = false; // Determines if the shot has been fired or not.

    void Start()
    {
      bulletInitialPos = transform.position; // Set initial bullet position.
    }

    /*
    * Fire Bullet
    * If there's power assigned to the bullet then fire the bullet
    */
    void FireBullet(int powerLevel){
      GameObject target = GameObject.FindGameObjectWithTag("Target");
      // Hide target
      target.gameObject.GetComponent<MeshRenderer>().enabled = false;
      // Calculate the vector from from target to ship to know which direction to fire in.
      Vector2 vectorToTarget = target.transform.position - transform.position;
      // Calculate distance from ship to target so shot power is uniform.
      float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
      // Add force to bullet 
      transform.GetComponent<Rigidbody>().AddForce((vectorToTarget * powerLevel * powerConstant) / distanceToTarget);
      // Reset power level
      powerLevel = 0; 
      // Not sure why this bool was needed and the above line doesn't stop force being added to bullet but it is
      shotFired = true; 
    }

    void Update() // Update is called once per frame.
    {
      // Get the bullet's power level.
      GameObject power = GameObject.FindGameObjectWithTag("Power Meter");
      int powerLevel = power.GetComponent<power>().powerLevel;

      
      if(powerLevel != 0 && !shotFired){ // If power level is defined then fire the bullet.
        FireBullet(powerLevel);
      } 
      
      // Fire at planets
      // planets = GameObject.FindGameObjectsWithTag("Planet");
      // foreach (GameObject planet in planets)
      //   {
      //     Vector3 direction = planet.transform.position - transform.position;
      //     bullet.AddForce(gravity * direction);
      //   }        
    }
}
