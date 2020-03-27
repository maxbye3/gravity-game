using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power : MonoBehaviour
{
    // protected GameObject powerMeter;
    // Start is called before the first frame update
    private Vector3 scaleChange;
    private Collider powerMeter;
    public int powerLevel = 0; 
    private int buildingPower = 0; 
    void Start()
    {
        powerMeter = GetComponent<Collider>();
        // width1 = GetComponent.<Collider>().bounds.size
        // width2 = GetComponent.<Renderer>().bounds.size
        // powerMeter.transform.localScale.x = 5;
        Debug.Log(powerMeter.transform.localScale.x);
        scaleChange = new Vector3(0.4f, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      // Build power on click to a max of 50
      if(buildingPower <= 50 && (Input.GetMouseButton(1) || Input.GetMouseButton(0))){
        powerMeter.transform.localScale += scaleChange;
        buildingPower += 1;
          Debug.Log("2");
      } 
      // On release of click set power level
      if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
      {
          powerLevel = buildingPower * 10;
          Debug.Log("1");
      }       
    }
}
