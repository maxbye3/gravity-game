using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class starCreationMenu : MonoBehaviour
{
  public GameObject createStarMenu;
  public GameObject createStarButton;
  public GameObject actuallyCreateStarButton;
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
    // We are creating a star
    GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "create star"; // We are creating a star
    createStarMenu.SetActive(true);

    // set star mass
    GameObject.FindWithTag ("Star mass input").GetComponent<InputField>().text = "5";

    // set star size
    GameObject.FindWithTag ("Star size input").GetComponent<InputField>().text = "5";
    // int sun   
    GameObject sun = GameObject.FindGameObjectWithTag("Star");              
    // clone old star and position new sun
    newStar = Instantiate(sun, new Vector3(5, 0, -4), Quaternion.identity);
    // assign sun with new tag
    // GameObject.FindGameObjectWithTag("Helper").GetComponent<tagHelper>().AddTag("New Star");
    newStar.transform.gameObject.tag = "New Star";
    // assign child object with tag
    // GameObject.FindGameObjectWithTag("Helper").GetComponent<tagHelper>().AddTag("New Star Name");
    GameObject sunName = newStar.transform.GetChild(0).gameObject;
    // GameObject.FindGameObjectWithTag("Helper").GetComponent<tagHelper>().AddTag("New Star Name");
    sunName.transform.gameObject.tag = "New Star Name";
  }

  public void saveStar()
  {
    // Star creator mode was just on
    if (sunCreated == true)
    {
      // save this new planet
      newStar.transform.gameObject.tag = "Star";
      GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>().SetText("2. Click and drag star to location");
      sunCreated = false;
    }
  }

  // If star creator is on and the user has clicked cancel then destory star
  public void destroyStar()
  {
    // Star creator mode was just on
    if (sunCreated == true)
    {
      // destroy the new planet
      Destroy(GameObject.FindGameObjectWithTag("New Star"));
      sunCreated = false;
    }
  }

  // What to do when the menu is closed
  public void closeMenu()
  {
    // hide the menu
    createStarMenu.SetActive(false);
    // show the button
    createStarButton.SetActive(true);
    // save the star
    if (sunCreated)
    {
      newStar.transform.position = new Vector3(newStar.transform.position.x, newStar.transform.position.y, 0);
    }
  }
  public void nonZero(float val){
    if(val == 0){
      actuallyCreateStarButton.GetComponent<Button> ().interactable = false;
    }
  }

  // If size or mass is too big then change text and colour of Player Text
  public void outsideLimits(float val, string Type)
  {
    // if input int (val or size) is bigger than 10
    if (val > 10)
    {
      // You cannot create star!
      actuallyCreateStarButton.GetComponent<Button> ().interactable = false;
      GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>().SetText("Please choose a " + Type + " less than 10.");
      GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>().color = new Color32(255, 0, 0, 255);;
    }
    else
    {
      // Go ahead and create star!
      actuallyCreateStarButton.GetComponent<Button> ().interactable = true;
      GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>().SetText("1. Fill in above to create sun");
      GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>().color = new Color32(255, 255, 255, 255);;
    }
  }

}
