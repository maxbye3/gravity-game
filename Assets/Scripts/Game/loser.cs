using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class loser : MonoBehaviour
{
    private TextMeshPro playerTxt;
    private TextMeshPro winnerTxt;

    // Start is called before the first frame update
    void Start()
    {
      // Int the win text that displays the winner
      winnerTxt = GameObject.FindGameObjectWithTag("Win Text").GetComponent<TextMeshPro>();        
      winnerTxt.enabled = false;  
       // Player text that displays whose turn it is (needs to be hidden)
      playerTxt = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     /*
      * Someone lost the game!
      * If a bullet hits another player then do the following:
      * - Hide Green
      * - Play Explosion
      * - Destroy Bullets
      * - Set and display text
      * - Reset the power meter
      * - Int intro with countdown and new ship entering the battle
      */
    public void Loser(string player){
      // change state to intro


      // lets other scripts know whose lost
      string lostPlayer = player;

      // disables player text
      playerTxt.enabled = false;
      // enables winner text
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

        // Make all bullets inactive.
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
        {
          bullet.gameObject.SetActive(false);
        }
        // Rescale the power meter to original size.
        GameObject.FindGameObjectWithTag("Power Meter").GetComponent<power>().ResetPowerMeter();
    }
}
