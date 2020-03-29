using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class intro : MonoBehaviour
{
private TextMeshPro countdownTxt;
private float timer = 0.0f;
public float    speed = 1f;

public int howFarOut; // How far out does the ship start out of screen to fly in (this is a multiplier)
private GameObject green;
private  Vector3 readyToGame;
private  Vector3 outOfTheScreen;
private  string lostPlayer;
// Start is called before the first frame update
void Start()
{
  StartGame();
}
void StartGame()
{  
  countdownTxt = GameObject.FindGameObjectWithTag("Countdown").GetComponent<TextMeshPro>();
  //Start the coroutines we define below named SetText and HideText.
  countdownTxt.enabled = true;
  //Start the coroutines we define below named SetText and HideText.
  StartCoroutine(SetText(1,"2"));
  StartCoroutine(SetText(2, "1"));
  StartCoroutine(HideText(3));
  
  lostPlayer = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().lostPlayer;
  readyToGame = GameObject.FindGameObjectWithTag(lostPlayer).gameObject.transform.position;
  outOfTheScreen = new Vector3(readyToGame.x * 2f, 0, 0);
  GameObject.FindGameObjectWithTag(lostPlayer).gameObject.transform.position = outOfTheScreen;
  StartCoroutine(DelayMovement(2));
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
    objectToMove.position = b;
 }

IEnumerator SetText(int seconds, string text)
{
  //yield on a new YieldInstruction that waits for seconds.
  yield return new WaitForSeconds(seconds);
  countdownTxt.SetText(text);
}
IEnumerator HideText(int seconds)
{ 
  //yield on a new YieldInstruction that waits for seconds.
  yield return new WaitForSeconds(seconds);
  countdownTxt.enabled = false;
  // Vector3 targetPosition = new Vector3 (-4, -3, -1);  
  //    Vector3 currentPosition = green.transform.position;  
  //    if (Vector3.Distance (currentPosition, targetPosition) > .1f) {  
  //    Vector3 directionOfTravel = targetPosition - currentPosition;  
  //    directionOfTravel.Normalize ();  
  //    green.transform.Translate (  
  //                    (directionOfTravel.x * speed * Time.deltaTime),  
  //                    (directionOfTravel.y * speed * Time.deltaTime),  
  //                    (directionOfTravel.z * speed * Time.deltaTime),  
  //                    Space.World);  
     
  //    }  
}

     
 
 void Update()
 {  

    // countdownTxt.enabled = true;
    // timer += Time.deltaTime;
    // float seconds = timer % 60;
    // if(seconds > 1){
    //   countdownTxt.SetText("2");
    // } 
    // if(seconds > 2){
    //   countdownTxt.SetText("1");
    // } 
    // if(seconds > 3){
    //   countdownTxt.enabled = false;
    // }
 }
}
