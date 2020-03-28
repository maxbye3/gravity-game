using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
        private TextMeshPro textmeshPro;
    void Start()
    {
        textmeshPro = GetComponent<TextMeshPro>();
        // textmeshPro.SetText("The first number is {0} and the 2nd is {1:2} and the 3rd is {3:0}.", 4, 6.345f, 3.5f);
        // textmeshPro.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //  textmeshPro.enabled = true;
    }
}
