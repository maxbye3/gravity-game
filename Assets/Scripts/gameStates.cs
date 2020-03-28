using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameStates : MonoBehaviour
{
  /*
  * Game States
  * Sets all the parameters if a game is won or a round is reset.
  */

  private GameObject bullet;
  public float offScreenRight = 10;
  public float offScreenLeft = -10;
  public float offScreenTop = 6;
  public float offScreenBottom = -6;
  private TextMeshPro textmeshPro;

      /*
      * Winner
      * If a bullet hits another player then do the following:
      * - Hide Player 2
      * - Play Explosion
      * - Destroy Bullets
      * - Set and display text
      * - Reset the power meter
      */
    public void Winner(){
        // cause player 2 to hide
        GameObject.FindGameObjectWithTag("Player 2").gameObject.GetComponent<MeshRenderer>().enabled = false;
        // cause explosion
        GameObject.FindGameObjectWithTag("Player 2 Explosion").GetComponent<ParticleSystem>().Play();
        // Make all bullets inactive.
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
        {
          bullet.gameObject.SetActive(false);
          // Destroy(bullet);
        }
        // Set and display text.
        textmeshPro.enabled = true;
        textmeshPro.SetText("Red wins");
        // Rescale the power meter to original size.
        ResetPowerMeter();
    }

    // Start is called before the first frame update
    void Start()
    {
      // int bullet game object
      bullet = GameObject.FindGameObjectWithTag("Bullet");
      // Int the win text that displays the winner
      GameObject winnerText = GameObject.FindGameObjectWithTag("Win Text");
      textmeshPro = winnerText.GetComponent<TextMeshPro>();        
      textmeshPro.enabled = false;

      
    }

    void ResetPowerMeter(){
        // Rescale the power meter to original size
        GameObject powerMeter = GameObject.FindGameObjectWithTag("Power Meter");
        powerMeter.GetComponent<Collider>().transform.localScale = new Vector3(1f, 1f, 1f);
    }


    /*
    * Reset round
    * If bullet flies out of bounds then reset the round by doing the following:
    * - Show and re-enable the target 
    * - Reset bullet position and remove force 
    * - Reset the power meter

    */
    void ResetRound(GameObject bullet){    
        
        GameObject target = GameObject.FindGameObjectWithTag("Target");
        // Show target
        target.gameObject.GetComponent<MeshRenderer>().enabled = true;
        // Re-enable target
        target.GetComponent<target>().movingTarget = true;
        // Reset bullet position 
        bullet.GetComponent<firingBullet>().shotFired = false;
        Vector3 bulletInitialPosition = bullet.GetComponent<firingBullet>().bulletInitialPos;
        bullet.transform.position =  bulletInitialPosition;
        // Remove force from bullet
        bullet.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bullet.transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; 
        // Rescale the power meter to original size
        ResetPowerMeter();
        // Set power to 0
        GameObject.FindGameObjectWithTag("Power Meter").GetComponent<power>().powerLevel = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If bullet flied out of bounds then reset the round 
        if(bullet 
          && 
           bullet.transform.position.x > offScreenRight
        || bullet.transform.position.x < offScreenLeft
        || bullet.transform.position.y > offScreenTop
        || bullet.transform.position.y < offScreenBottom
        ) {
          ResetRound(bullet);
        }
       
    }
}
