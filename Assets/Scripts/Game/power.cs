using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power : MonoBehaviour
{
  /*
  * How much power behind the bullet?
  * Onclick - the power meter charges
  * Onmouse release - the power reading is sent to the bullet Assets/Scripts/firingBullet.cs
  */
  private Vector3 scaleChange;
  public int powerLevel = 0; // Power level sent to the bullet
  private int buildingPower = 0; // Power amount while building
  public int powerMeter = 50; // How quickly to fill the meter
  public float fillPowerMeter = 0.5f; // How quickly t fill the meter
  private int previousCyclesPower = 0; // Check buildingPower per cycle to confirm it's still building
  void Start() // Start is called before the first frame update    
  {

  }

  /*
  * Reset Power
  * Rescale the power meter to original size
  */
  public void ResetPowerMeter()
  {
    GameObject.FindGameObjectWithTag("Power Meter").GetComponent<Collider>().transform.localScale = new Vector3(1f, 1f, 1f);
  }

  /*
  * Set Power
  * Sets the final power value
  */
  void setPower()
  {
    powerLevel = buildingPower;
    buildingPower = 0;
  }

  // Update is called once per frame
  void Update()
  {
    previousCyclesPower = buildingPower; // Check buildingPower per cycle to confirm it's still building
                                         // Build power on click till it reaches powerLimit
    if (
      powerLevel == 0 
      && buildingPower <= powerMeter 
      && (Input.GetMouseButton(1) || Input.GetMouseButton(0)) // mouse is down
      && GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState == "game") // we're actually playing the game
    {
      Collider powerMeter = GetComponent<Collider>();
      // Increases the size of the meter
      powerMeter.transform.localScale += new Vector3(fillPowerMeter, 0, 0);
      // Increases value per cycle
      buildingPower += 1;
    }
    // On release of click set power level
    if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
    {
      setPower();
    }
  }
}
