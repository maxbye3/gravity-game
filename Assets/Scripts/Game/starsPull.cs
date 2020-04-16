using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starsPull : MonoBehaviour
{
  private GameObject bullet;
  public float mass;

  /*
    * Star's gravity
    * Put gravity on bullets
    * Put gravity on bullets 
    */
  void Update()
  {
    // If bullet has been fired
    bullet = GameObject.FindGameObjectWithTag("Active Bullet");
    if (
        bullet.GetComponent<firingBullet>().shotFired == true // if bullet is in the game
        && GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState == "game" // game is being played
      )
    {
      planetGravity("Active Bullet"); // do some gravity on that sucker
    }

    // number of old bullets
    int numberOfOldBullets = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().timeout;

    for (int i = 0; i < numberOfOldBullets; i++)
    { // for every old bullet
      planetGravity("Old Bullet" + i); // exert a force towards planet
    }
  }

  /*
  * Planet Gravity
  * Exerts force on items specified by tag towards the planet
  * @param {string} tagname - the tagname of the object to pull towards planet
  */
  void planetGravity(string tagname)
  {
    GameObject nonPlanetObject = GameObject.FindGameObjectWithTag(tagname);
    if (nonPlanetObject)
    { // if exists
      //  Get distance from planet
      float distance = Vector3.Distance(nonPlanetObject.transform.position, transform.position);
      //  Get direction from planet
      Vector3 direction = transform.position - nonPlanetObject.transform.position;
      // Pulling bullet towards planet
      GameObject.FindGameObjectWithTag(tagname).GetComponent<Rigidbody>().AddForce(mass * direction / Mathf.Pow(distance, 1f / 3f));
    }
  }
}
