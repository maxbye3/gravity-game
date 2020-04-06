using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class starCreation : MonoBehaviour
{
public GameObject createStarMenu;
    // Start is called before the first frame update
    void Start()
  {
     closeMenu(); // close the level editor
  }
    public void showMenu()
    {
      // Set move star to back to game state

      // Change Move Star text to cancel

      // Hide create button
      
      // Change text of Red player's turn to create sun instruction
      GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>().SetText("1. Fill in above to create sun");

      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "create star"; // We are creating a star
      createStarMenu.SetActive(true);
      // create a new planet
      GameObject sun = GameObject.FindGameObjectWithTag("Star"); // int sun
      // clone and position new sun
      GameObject newSun = Instantiate(sun, new Vector3(5,0 ,-4),Quaternion.identity);
      // assign sun with new tag
      GameObject.FindGameObjectWithTag("Helper").GetComponent<tagHelper>().AddTag("New Star");
      newSun.transform.gameObject.tag = "New Star";
      // assign child object with tag
      GameObject.FindGameObjectWithTag("Helper").GetComponent<tagHelper>().AddTag("New Star Name");
      GameObject sunName = newSun.transform.GetChild (0).gameObject;
      GameObject.FindGameObjectWithTag("Helper").GetComponent<tagHelper>().AddTag("New Star Name");
      sunName.transform.gameObject.tag = "New Star Name";

    }

    // Update is called once per frame
    public void closeMenu()
    {
        createStarMenu.SetActive(false);
    }
}
