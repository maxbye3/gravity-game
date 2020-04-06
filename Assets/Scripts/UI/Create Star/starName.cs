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
        InputField inp1 = GameObject.FindWithTag ("New Star Input").GetComponent<InputField>() as InputField;
        // If creating a planet then feel free to name it
        if(GameObject.FindGameObjectWithTag("Create Star Functionality").GetComponent<starCreation>().sunCreated == true) { 
        GameObject.FindWithTag ("New Star Name").GetComponent<TextMeshPro>().SetText(inp1.text);
        }
    }
}
