using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class starName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputField starNameInput = GameObject.FindWithTag ("Star name input").GetComponent<InputField>() as InputField;
        // If creating a planet then feel free to name it
        if(GameObject.FindGameObjectWithTag("Create Star Functionality").GetComponent<starCreationMenu>().sunCreated == true) {
          // get mass of star
          float mass = GameObject.FindWithTag ("Star mass input").GetComponent<addMass>().mass; 
          GameObject.FindWithTag ("New Star Name").GetComponent<TextMeshPro>().SetText(starNameInput.text + " (" + mass + ")");
        }
    }
}
