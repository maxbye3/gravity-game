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
        // string inputText = (InputField)GameObject.FindGameObjectWithTag("New Star Name").GetComponent<InputField>().text;
        InputField inp1 = GameObject.FindWithTag ("New Star Input").GetComponent<InputField>() as InputField;
        // Debug.Log("Text input text:" + inp1.text);
        GameObject.FindWithTag ("New Star Name").GetComponent<TextMeshPro>().SetText(inp1.text);
    }
}
