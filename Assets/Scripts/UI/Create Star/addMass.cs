using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class addMass : MonoBehaviour
{
  public float mass;
  // Update is called once per frame
  void Update()
  {
    InputField starMassInput = GameObject.FindWithTag("Star mass input").GetComponent<InputField>();
    // Only integers allowed
    starMassInput.characterValidation = InputField.CharacterValidation.Integer;
    // turn input into float
    float.TryParse(starMassInput.text, out mass);
    // Make sure mass is under 10
    GameObject.FindGameObjectWithTag("Create Star Functionality").GetComponent<starCreation>().outsideLimits(mass, "mass");
    // Can't be 0
    GameObject.FindGameObjectWithTag("Create Star Functionality").GetComponent<starCreation>().nonZero(mass);
    if (mass > 10) // make sure star mass isn't bigger than 10 otherwise problems
    {
      mass = 10;
    }
    // add mass to planet
    GameObject.FindGameObjectWithTag("New Star").GetComponent<starsPull>().mass = mass/2;

  }
}
