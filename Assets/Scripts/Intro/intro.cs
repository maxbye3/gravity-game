using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class intro : MonoBehaviour
{
    private TextMeshPro countdownTxt;
    public float speed = 1f;

    public int howFarOut; // How far out does the ship start out of screen to fly in (this is a multiplier)
    private GameObject green;
    private  Vector3 readyToGame;
    private  Vector3 outOfTheScreen;
    private  string lostPlayer;
    // Start is called before the first frame update
    void HideInGame()
    {
      GameObject.FindGameObjectWithTag("Target").gameObject.GetComponent<MeshRenderer>().enabled = false;
      GameObject.FindGameObjectWithTag("Power Meter").gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
      GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>().enabled = false;
    }

    public void StartGame()
    {  
      HideInGame();
      countdownTxt = GameObject.FindGameObjectWithTag("Countdown").GetComponent<TextMeshPro>();
      countdownTxt.enabled = true;
      countdownTxt.SetText("3");
      //Start the coroutines we define below named SetText and StartGame.
      StartCoroutine(StopFireworks(0f)); 
      StartCoroutine(SetText(1,"2"));
      StartCoroutine(SetText(2, "1"));
      StartCoroutine(StartGame(3));
      lostPlayer = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().lostPlayer;
      Debug.Log("lostPlayer: " + lostPlayer);
      GameObject.FindGameObjectWithTag(lostPlayer).gameObject.GetComponent<MeshRenderer>().enabled = true;
      readyToGame = GameObject.FindGameObjectWithTag(lostPlayer).gameObject.transform.position;
      outOfTheScreen = new Vector3(readyToGame.x * 2f, 0, 0);
      GameObject.FindGameObjectWithTag(lostPlayer).gameObject.transform.position = outOfTheScreen;
      StartCoroutine(DelayMovement(2));
      
    }

    IEnumerator StopFireworks(float seconds)
    {
      yield return new WaitForSeconds(seconds);
      GameObject.FindGameObjectWithTag("Green Explosion").GetComponent<ParticleSystem>().Stop();
      GameObject.FindGameObjectWithTag("Red Explosion").GetComponent<ParticleSystem>().Stop();
    }
    IEnumerator DelayMovement(int seconds)
    {
      yield return new WaitForSeconds(seconds);
      StartCoroutine(MoveFromTo(GameObject.FindGameObjectWithTag(lostPlayer).gameObject.transform, outOfTheScreen, readyToGame, 10));
    }

    IEnumerator MoveFromTo(Transform objectToMove, Vector3 a, Vector3 b, float speed) {
      float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;
      float t = 0;
      while (t <= 1.0f) {
          
          t += step; // Goes from 0 to 1, incrementing by step each time
          objectToMove.position = Vector3.Lerp(a, b, t); // Move objectToMove closer to b
          yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
      }
      // objectToMove.position = b;
    }

  IEnumerator SetText(int seconds, string text)
  {
    //yield on a new YieldInstruction that waits for seconds.
    yield return new WaitForSeconds(seconds);
    countdownTxt.SetText(text);
    
  }
  IEnumerator StartGame(int seconds)
  { 
    //yield on a new YieldInstruction that waits for seconds.
    yield return new WaitForSeconds(seconds);
   
    // hides the countdown
    countdownTxt.enabled = false;
    // starts the game
    GameObject gameController = GameObject.FindGameObjectWithTag("GameController");    
    // setup the turn of active player
    gameController.GetComponent<Reset>().ResetRound();
    // GameObject hello = GameObject.FindGameObjectWithTag("Green Explosion");
  }

}
