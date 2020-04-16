using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addSize : MonoBehaviour
{
  private float size;
  // Start is called before the first frame update
  void Start()
  {
    size = 5;
  }

  // Update is called once per frame
  void Update()
  {
    InputField starSizeInput = GameObject.FindWithTag("Star size input").GetComponent<InputField>();
    // Only integers allowed
    starSizeInput.characterValidation = InputField.CharacterValidation.Integer;
    // turn input into float
    float.TryParse(starSizeInput.text, out size);

    // Make sure size is under 10
    GameObject.FindGameObjectWithTag("Create Star Functionality").GetComponent<starCreation>().outsideLimits(size, "size");
    // Can't be 0
    GameObject.FindGameObjectWithTag("Create Star Functionality").GetComponent<starCreation>().nonZero(size);
    if (size > 10) // make sure star size isn't bigger than 10 otherwise problems
    {
      size = 10;
    }
    // change in size means change in star x and y localscale
    float newScale = size / 5;
    var starScale = GameObject.FindGameObjectWithTag("New Star").GetComponent<RectTransform>().localScale;
    GameObject.FindGameObjectWithTag("New Star").GetComponent<RectTransform>().localScale = new Vector3(newScale, newScale, starScale.z);

  }
}
