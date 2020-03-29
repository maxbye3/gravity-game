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

  public float offScreenRight = 10;
  public float offScreenLeft = -10;
  public float offScreenTop = 6;
  public float offScreenBottom = -6;
  public GameObject playerStart;
  private string activePlayer;
  private TextMeshPro winnerTxt;
  private TextMeshPro playerTxt;
  private GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
      bullet = GameObject.FindGameObjectWithTag("Bullet");
      // int bullet game object
      // Int the win text that displays the winner
      winnerTxt = GameObject.FindGameObjectWithTag("Win Text").GetComponent<TextMeshPro>();        
      winnerTxt.enabled = false;  
      playerTxt = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>();
      // Red player starts
      activePlayer = "Red";
      WhoseRound(activePlayer);
      
    }

      /*
      * Winner
      * If a bullet hits another player then do the following:
      * - Hide Green
      * - Play Explosion
      * - Destroy Bullets
      * - Set and display text
      * - Reset the power meter
      */
    public void Loser(string player){
      Debug.Log("Which player lost: " + player);
      winnerTxt.enabled = true;
      if(player == "Green"){
        // Set and display text.
        winnerTxt.SetText("Red wins");
        // cause Green to hide
        GameObject.FindGameObjectWithTag("Green").gameObject.GetComponent<MeshRenderer>().enabled = false;
        // cause explosion
        GameObject.FindGameObjectWithTag("Green Explosion").GetComponent<ParticleSystem>().Play();
        // ball resets at Green
      } else if (player == "Red"){
        // Set and display text.
        winnerTxt.SetText("Green wins");
        // cause Green to hide
        GameObject.FindGameObjectWithTag("Red").gameObject.GetComponent<MeshRenderer>().enabled = false;
        // cause explosion
        GameObject.FindGameObjectWithTag("Red Explosion").GetComponent<ParticleSystem>().Play();        
      }
        // TEMP - in the future we want to go to some sort of score
        ResetRound(bullet);

        // Make all bullets inactive.
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
        {
          bullet.gameObject.SetActive(false);
        }

        // Rescale the power meter to original size.
        ResetPowerMeter();
    }


    void ResetPowerMeter(){
        // Rescale the power meter to original size
        GameObject powerMeter = GameObject.FindGameObjectWithTag("Power Meter");
        powerMeter.GetComponent<Collider>().transform.localScale = new Vector3(1f, 1f, 1f);
    }


    /*
    * Whose Round (is it anyway?)
    * Depending on whose round change the environments
    * - Show and re-enable the target 
    */
    void WhoseRound(string player){
        if(player == "Red"){
          // Text
          playerTxt.SetText("Red's turn");
          // Reset bullet position 
          Vector3 bulletInitialPosition = bullet.GetComponent<firingBullet>().bulletInitialRedPos;
          bullet.transform.position =  bulletInitialPosition;
          // Switch player.
          activePlayer = "Green";
        } else if (player == "Green"){
          // Text
          playerTxt.SetText("Green's turn");
          // Reset bullet position 
          Vector3 bulletInitialPosition = bullet.GetComponent<firingBullet>().bulletInitialRedPos;
          bullet.transform.position =  bulletInitialPosition;
          // Switch player.
          activePlayer = "Green";
        }
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
        // Let bullet be shot again
        bullet.GetComponent<firingBullet>().shotFired = false;        
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
          WhoseRound(activePlayer);
        }
       
    }
}
