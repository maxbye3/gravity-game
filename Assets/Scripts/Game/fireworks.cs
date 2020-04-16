using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireworks : MonoBehaviour
{
  // Launch and stop fireworks
  // @param the name of the player who lost "green" or "red"
  public void StartFireworks(string losingPlayer)
  { 
    // Lost player explosion
    GameObject.FindGameObjectWithTag(losingPlayer + " Explosion").GetComponent<ParticleSystem>().Play();
    // Bug where firework keeps looping unless this is called
    StartCoroutine(StopFireworks(0f));
  }

  IEnumerator StopFireworks(float seconds)
  {
    yield return new WaitForSeconds(seconds);
    GameObject.FindGameObjectWithTag("Green Explosion").GetComponent<ParticleSystem>().Stop();
    GameObject.FindGameObjectWithTag("Red Explosion").GetComponent<ParticleSystem>().Stop();
  }
}

