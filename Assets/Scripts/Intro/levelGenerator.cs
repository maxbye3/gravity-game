using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class levelGenerator : MonoBehaviour
{
  public float[][][] coordinates;
  public GameObject newStar;
  private bool isRotating;
  void Start()
  {
    /*
    * Star layouts
    */
    // First layout that can be generated for round
    float[] x1 = new float[3] { -4, 0, 4 };
    float[] y1 = new float[3] { -3, 0.5f, 3 };
    // Second layout that can be generated for round
    float[] x2 = new float[3] { 4, 0, -4 };
    float[] y2 = new float[3] { 3, 0.5f, -3 };
    // Third layout that can be generated for round
    float[] x3 = new float[3] { 3, 0, -3 };
    float[] y3 = new float[3] { 0.5f, 3f, 0.5f };
    // Fourth layout that can be generated for round
    float[] x4 = new float[3] { 3, 0, -3 };
    float[] y4 = new float[3] { 0.5f, -3f, 0.5f };
    // Fifth layout that can be generated for round
    float[] x5 = new float[4] { 3, 1, -1, -3 };
    float[] y5 = new float[4] { 0.5f, 2, -2, 0.5f };
    // Sixth layou t that can be generated for round 
    float[] x6 = new float[3] { 3, 0, -3 };
    float[] y6 = new float[3] { 0.5f, 0.5f, 0.5f };
    // Seventh layout that can be generated for round 
    float[] x7 = new float[5] { 0, 3, 1, -1, -3 };
    float[] y7 = new float[5] { 3, 0.5f, 2, -2, 0.5f };
    // Eight layout that can be generated for round 
    float[] x8 = new float[6] { 1.5f, -1f, 0, 0, 1.5f, -1.5f };
    float[] y8 = new float[6] { 1f, -1f, 3f, -3f, -1f, 1f };
    // Test Layout
    float[] x9 = new float[1] { 0 };
    float[] y9 = new float[1] { 0 };
    // Test 2 Layout
    float[] x10 = new float[0] { };
    float[] y10 = new float[0] { };

    coordinates = new float[][][] {
      new float[][] { x1, y1 },
      new float[][] { x2, y2 },
      new float[][] { x3, y3 },
      new float[][] { x4, y4 },
      new float[][] { x5, y5 },
      new float[][] { x6, y6 },
      new float[][] { x7, y7 },
      new float[][] { x8, y8 },
      new float[][] { x9, y9 },
      new float[][] { x10, y10 },
    };

    // randomizeStars();
    generateLevel();

  }


  public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angles)
  {
    return angles * (point - pivot) + pivot;
  }
  void rotateStars()
  {
    var stars = GameObject.FindGameObjectsWithTag("New Star");
    var starText = GameObject.FindGameObjectsWithTag("New Star Text");
    for (var i = 0; i < stars.Length; i++)
    {
      stars[i].transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 0, 5), 1);
      var starPos = stars[i].transform.position;
      starText[i].transform.position = new Vector3(starPos.x, starPos.y, -1);

    }
  }

  public void FixedUpdate()
  {
    // 50% chance stars will rotate
    if (isRotating)
    {
      rotateStars();
    }

  }

  /*
  * Create star on preset positions (see above)
  */
  GameObject createStarWithPresetPosition(int val, int range)
  {
    // int sun   
    GameObject sun = GameObject.FindGameObjectWithTag("Star");
    // clone old star and position new sun
    return Instantiate(sun, new Vector3(coordinates[range][0][val], coordinates[range][1][val], 0), Quaternion.identity);
  }


  public void CreateNewLevel()
  {
    // Intro state
    GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "intro";          
    // Get rid of replay text
    GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>().SetText("");
    // Start the game
    GameObject.FindGameObjectWithTag("Intro").GetComponent<intro>().StartCountdown();
    // Destroy stars
    destoryStars();
    // Generate new level
    generateLevel();
  }

  /*
  * Generate randomly one of the 10 pre-set levels 
  */
  public void generateLevel()
  {
    // 50% chance stars will rotates
    if (Random.value >= 0.5)
    {
      isRotating = true;
    }

    // IF RANDOM: How many stars between 1 and 3
    // int planetNumber = Random.Range(1, 4);

    // IF RANDOM: Create between 1 and 3  stars 
    // for (var i = 0; i <= planetNumber; i++)

    // Select layouts 1 to 9
    int range = Random.Range(0, 8);
    // range = 9; // UNCOMMENT FOR TESTING ENVIROMENT (NO STARS)
    for (var i = 0; i < coordinates[range][0].Length; i++)
    {
      // Randomize positions
      // GameObject newStar = createStarRandomPositions(i);

      // Preset positions
      newStar = createStarWithPresetPosition(i, range);

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
      GameObject newStarText = Instantiate(starText, new Vector3(newStar.transform.position.x, newStar.transform.position.y, -1), Quaternion.identity);
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

  /*
  * DESTROY OLD STARS
  */
  public void destoryStars()
  {
    // Destroy star and text with new star tag
    var stars = GameObject.FindGameObjectsWithTag("New Star");
    var starText = GameObject.FindGameObjectsWithTag("New Star Text");

    for (var i = 0; i < stars.Length; i++)
    {
      Destroy(stars[i]);
      Destroy(starText[i]);
    }
  }

  /*
  * COMPLETELY RANDOMIZE POSITIONS
  */
  // GameObject createStarRandomPositions(int val)
  // {
  //   // If first sun being created
  //   float x = 0;
  //   float y = 0;
  //   if (val == 0)
  //   {
  //     y = 0.5f; // y has to be 0.5
  //     x = Random.Range(-3, 3); // has to be between 3 and -3
  //   }
  //   else
  //   {
  //     while (y == 0)
  //     {
  //       y = Random.Range(-4.5f, 4.5f); // has to be between 3 and -3
  //     }
  //     // position has to be unique
  //     x = Random.Range(-3f, 3f);
  //   }

  //   // int sun   
  //   GameObject sun = GameObject.FindGameObjectWithTag("Star");
  //   // clone old star and position new sun
  //   return Instantiate(sun, new Vector3(x, y, 0), Quaternion.identity);
  // }

}
