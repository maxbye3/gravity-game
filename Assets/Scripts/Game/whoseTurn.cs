using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class whoseTurn : MonoBehaviour
{
    private TextMeshPro playerTxt;
    
    private GameObject bullet; // the bullet

    // Start is called before the first frame update
    void Start()
    {
        // Int the player text that displays whose turn it is
        
        
       
    }

    // Update is called once per frame
    void ShowInGame()
    {
      GameObject.FindGameObjectWithTag("Bullet").gameObject.GetComponent<MeshRenderer>().enabled = true;
      GameObject.FindGameObjectWithTag("Target").gameObject.GetComponent<MeshRenderer>().enabled = true;
      GameObject.FindGameObjectWithTag("Power Meter").gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
      playerTxt.enabled = true;
      GameObject.FindGameObjectWithTag("Win Text").GetComponent<TextMeshPro>().enabled = false;
    }

     /*
    * Whose Round (is it anyway?)
    * Depending on whose round change the environments
    * - Show and re-enable the target 
    */
    public void IntTurn(string player){
        bullet = GameObject.FindGameObjectWithTag("Bullet");
        playerTxt = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>();
        // global game state
        GetComponent<gameStates>().gameState = "game";
        ShowInGame();
        if(player == "Red"){
          // Text
          playerTxt.SetText("Red's turn");
          // Reset bullet position 
          Vector3 bulletInitialPosition = bullet.GetComponent<firingBullet>().bulletInitialRedPos;
          bullet.transform.position =  bulletInitialPosition;
          // Switch player.
          GetComponent<gameStates>().activePlayer = "Green";
        } else if (player == "Green"){
          // Text
          playerTxt.SetText("Green's turn");
          // Reset bullet position 
          Vector3 bulletInitialPosition = bullet.GetComponent<firingBullet>().bulletInitialGreenPos;
          bullet.transform.position =  bulletInitialPosition;
          // Switch player.
          GetComponent<gameStates>().activePlayer = "Red";
        }
    } 
}
