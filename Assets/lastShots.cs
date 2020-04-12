using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastShots : MonoBehaviour
{
  private float time = 0;
  private Vector3 bulletForce;
  float [] bulletDetailArray;
    // Start is called before the first frame update
    public void recordShot()
    { 
      // record the angle
      bulletForce = GameObject.FindGameObjectWithTag("Active Bullet").GetComponent<firingBullet>().bulletForce;
      // record the amount of time taken before shot      
      float timeBeforeShot = time;
      // record the power value
      float powerLevel = GameObject.FindGameObjectWithTag("Power Meter").GetComponent<power>().powerLevel;

      // add to array the above
      float[] shotDetails = new float[4] { bulletForce.x, bulletForce.y, powerLevel, timeBeforeShot };
      bulletDetailArray = shotDetails;
      // Debug.Log("bulletForce.x: " + shotDetails[0]);
      // Debug.Log("bulletForce.y: " + shotDetails[1]);
      // Debug.Log("powerLevel: " + shotDetails[2]);
      // Debug.Log("timeBeforeShot: " + shotDetails[3]);
      // bulletDetailArray = new float [][] { shotDetails };
    }

    public Vector3 shotsRecord(){
      return bulletForce;
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        // count time
        time +=1;
    }
}
