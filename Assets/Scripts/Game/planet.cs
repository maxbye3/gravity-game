using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet : MonoBehaviour
{
  private GameObject bullet;

  /*
    * Planet's gravity
    * Put gravity on bullets
    *  TO DO: old bullets
    */
  void Update()
  {
    //  Get bullet distance from planet
    // Debug.Log("bullet distance from planet:" + distance);
    // If bullet has been fired
    bullet = GameObject.FindGameObjectWithTag("Active Bullet");
    if (bullet.GetComponent<firingBullet>().shotFired == true)
    {
      // Pulling bullet towards planet
      float distance = Vector3.Distance(bullet.transform.position, transform.position);
      Vector3 direction = transform.position - bullet.transform.position;
      bullet.GetComponent<Rigidbody>().AddForce(direction / Mathf.Pow(distance, 1f / 3f));
      // GameObject[] bullets = GameObject.FindGameObjectsWithTag("Old Bullet");
      // foreach (GameObject oldBullet in bullets)
      // {
      //   distance = Vector3.Distance (oldBullet.transform.position, transform.position);
      //   direction =  transform.position - oldBullet.transform.position;
      //   oldBullet.GetComponent<Rigidbody>().AddForce(direction/Mathf.Pow(distance, 1f / 3f));
      // }
    }

  }
}
