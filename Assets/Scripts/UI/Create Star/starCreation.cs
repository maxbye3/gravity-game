using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class starCreation : MonoBehaviour
{
  public GameObject createStarMenu;
  public GameObject createStarButton;
  public bool sunCreated;
  // public GameObject createStarButton;
  private GameObject newStar;
  // Start is called before the first frame update
  void Start()
  {
    closeMenu(); // close the level editor
    //  createStarButton = GameObject.FindGameObjectWithTag("Create Star Button");
  }
  public void showMenu()
  {
    // Sun is being created
    sunCreated = true;
    // Get the positions of bullet and player 
    GameObject.FindGameObjectWithTag("Edit Star Functionality").GetComponent<buttonBehaviour>().initialPosOfPlayers();

    // Change Move Star text to cancel
    GameObject.FindGameObjectWithTag("Edit Stars Text").GetComponent<TextMeshProUGUI>().SetText("Cancel");
    // Hide create button
    createStarButton.SetActive(false);
    // Change text of Red player's turn to create sun instruction
    GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>().SetText("1. Fill in above to create sun");

    GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "create star"; // We are creating a star
    createStarMenu.SetActive(true);
    // create a new planet
    GameObject sun = GameObject.FindGameObjectWithTag("Star"); // int sun
                                                               // clone and position new sun
    newStar = Instantiate(sun, new Vector3(5, 0, -4), Quaternion.identity);
    // assign sun with new tag
    GameObject.FindGameObjectWithTag("Helper").GetComponent<tagHelper>().AddTag("New Star");
    newStar.transform.gameObject.tag = "New Star";
    // assign child object with tag
    GameObject.FindGameObjectWithTag("Helper").GetComponent<tagHelper>().AddTag("New Star Name");
    GameObject sunName = newStar.transform.GetChild(0).gameObject;
    GameObject.FindGameObjectWithTag("Helper").GetComponent<tagHelper>().AddTag("New Star Name");
    sunName.transform.gameObject.tag = "New Star Name";
  }

  public void saveStar() {
      // Star creator mode was just on
    if(sunCreated == true) { 
      // save this new planet
      newStar.transform.gameObject.tag = "Star";
      GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>().SetText("2. Click and drag star to location");
      sunCreated = false;
    }
  }

  public void destroyStar(){
      // Star creator mode was just on
    if(sunCreated == true) { 
      // destroy the new planet
      Destroy(GameObject.FindGameObjectWithTag("New Star"));
      sunCreated = false;
    }
  }

  // Update is called once per frame
  public void closeMenu()
  {
    createStarMenu.SetActive(false);
    createStarButton.SetActive(true);
    if (sunCreated)
    {
      newStar.transform.position = new Vector3(newStar.transform.position.x, newStar.transform.position.y, 0);
    }


  }
}
