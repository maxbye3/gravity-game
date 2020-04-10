using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class randomGame : MonoBehaviour
{
  void Start()
  {
    randomizeStars();
  }

  public void destoryStars(){
    // Destroy star with new star tag
    var stars = GameObject.FindGameObjectsWithTag ("New Star");
     
     for(var i = 0 ; i < stars.Length ; i ++)
     {
         Destroy(stars[i]);
     }
     // Destroy star with new star text tag
     var starText = GameObject.FindGameObjectsWithTag ("New Star Text");     
     for(var i = 0 ; i < starText.Length ; i ++)
     {
        Destroy(starText[i]);
     }
  }

  // Create a set of random planets
  public void randomizeStars()
  {
    // How many stars between 1 and 3
    int planetNumber = Random.Range(1, 4);
    // Create between 1 and 3  stars 

    for (var i = 0; i <= planetNumber; i++)
    {


      // If first sun being created
      float x = 0;
      float y = 0;
      if (i == 0)
      {
        y = 0.5f; // y has to be 0.5
        x = Random.Range(-3, 3); // has to be between 3 and -3
      }
      else
      {
        while (y == 0)
        {
          y = Random.Range(-4.5f, 4.5f); // has to be between 3 and -3
        }
        // position has to be unique
        x = Random.Range(-3f, 3f);
      }

      // int sun   
      GameObject sun = GameObject.FindGameObjectWithTag("Star");
      // clone old star and position new sun
      GameObject newStar = Instantiate(sun, new Vector3(x, y, 0), Quaternion.identity);
      var starScale = newStar.GetComponent<RectTransform>().localScale;
      // Set size between 1 and 4
      int newScale = Random.Range(1, 4);
      // If first shot
      if (i == 0)
      {
        // Set size between 1 and 2
        newScale = Random.Range(1, 2);
      }
      newStar.GetComponent<RectTransform>().localScale = new Vector3(newScale, newScale, starScale.z);

      // Set mass between 5 and 3
      int mass = Random.Range(1, 6);
      newStar.GetComponent<starsPull>().mass = mass / 2;

      // Set planet color to star
      if (newStar)
      {
        // byte red = Random.Range(0, 255); 
        newStar.GetComponent<Renderer>().material.color = new Color(
          Random.Range(0f, 1f),
          Random.Range(0f, 1f),
          Random.Range(0f, 1f)
        );
      }

      // int sun   
      GameObject starText = GameObject.FindGameObjectWithTag("Star text");
      // clone old star and position new sun
      GameObject newStarText = Instantiate(starText, new Vector3(x, y, -1), Quaternion.identity);
      string path = "Assets/starNames.txt";
      string[] lines = System.IO.File.ReadAllLines(path);
      string starName = lines[Random.Range(0, lines.Length)];
      // assign sun with new tag so they can be destroyed and not the original
      GameObject.FindGameObjectWithTag("Helper").GetComponent<tagHelper>().AddTag("New Star");      
      newStar.transform.gameObject.tag = "New Star";
      // GameObject sunName = newStar.transform.GetChild(0).gameObject;
      newStarText.GetComponent<TextMeshPro>().SetText(starName + " (" + mass + ")");
      GameObject.FindGameObjectWithTag("Helper").GetComponent<tagHelper>().AddTag("New Star Text");
      newStarText.transform.gameObject.tag = "New Star Text";
      // newStar.GetComponent<TextMeshPro>().color = Color.HSVToRGB(color.h, color.s, color.b);
      newStarText.GetComponent<TextMeshPro>().color = new Color(
        Random.Range(0f, 1f),
        Random.Range(0f, 1f),
        Random.Range(0f, 1f)
      );
    }
  }
}
