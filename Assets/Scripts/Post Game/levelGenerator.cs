using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class levelGenerator : MonoBehaviour
{
  public float[][][] coordinates;
  public GameObject newStar;
  private bool isRotating;
  public int numberOfStars;
  public string testLayout;

  void Start()
  {
    // testLayout =  "no stars";
    // testLayout =  "close star";
    testLayout =  "basic star system";
    
    /*
    * Star layouts
    */
    // Layout that can be generated for round
    float[] x0 = new float[3] { -4, 0, 4 };
    float[] y0 = new float[3] { -3, 0.5f, 3 };
    // Layout that can be generated for round
    float[] x1 = new float[3] { 4, 0, -4 };
    float[] y1 = new float[3] { 3, 0.5f, -3 };
    // Layout that can be generated for round
    float[] x2 = new float[3] { 3, 0, -3 };
    float[] y2 = new float[3] { 0.5f, 3f, 0.5f };
    // Layout that can be generated for round
    float[] x3 = new float[3] { 3, 0, -3 };
    float[] y3 = new float[3] { 0.5f, -3f, 0.5f };
    // Layout that can be generated for round
    float[] x4 = new float[4] { 3, 1, -1, -3 };
    float[] y4 = new float[4] { 0.5f, 2, -2, 0.5f };
    // Layout that can be generated for round 
    float[] x5 = new float[3] { 3, 0, -3 };
    float[] y5 = new float[3] { 0.5f, 0.5f, 0.5f };
    // Layout that can be generated for round 
    float[] x6 = new float[5] { 0, 3, 1, -1, -3 };
    float[] y6 = new float[5] { 3, 0.5f, 2, -2, 0.5f };
    // Layout that can be generated for round 
    float[] x7 = new float[6] { 1.5f, -1f, 0, 0, 1.5f, -1.5f };
    float[] y7 = new float[6] { 1f, -1f, 3f, -3f, -1f, 1f };

    // Test One Planet Layout
    float[] x8 = new float[1] { -4.5f };
    float[] y8 = new float[1] { 0f };
    // Test Two PlanetLayout
    float[] x9 = new float[2] { -2, 2 };
    float[] y9 = new float[2] { -2, 2 };
    // Test No Stars Layout
    float[] x10 = new float[0] { };
    float[] y10 = new float[0] { };

    coordinates = new float[][][] {
      new float[][] { x0, y0 },
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
    for (var i = 0; i < numberOfStars; i++)
    {
      GameObject.Find("New Star" + i).transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 0, 5), 1);
      var starPos = GameObject.Find("New Star" + i).transform.position;
      GameObject.Find("New Star Text" + i).transform.position = new Vector3(starPos.x, starPos.y, -1);

    }
  }

  public void FixedUpdate()
  {
    // 50% chance stars will rotate
    if (isRotating && testLayout != "close star")
    {
      rotateStars();
    }

    if (testLayout == "basic star"){
      rotateStars();
    }
  }

  public void CreateNewLevel()
  {
    // Intro state
    GameObject.FindGameObjectWithTag("GameController").GetComponent<gameStates>().gameState = "intro";
    // Get rid of replay text
    GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshPro>().SetText("");
    // Start the game
    GameObject.FindGameObjectWithTag("Intro").GetComponent<countdown>().StartCountdown();
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
    // range = 10; // UNCOMMENT FOR TESTING ENVIRONMENT (NO STARS) or change layout (see above)
    if(testLayout == "no stars"){
      range = 10;
    }
    if (testLayout == "close star"){
      range = 8;      
    }    
    if (testLayout == "basic star system"){
      range = 9;      
    }

    // record the number of stars
    numberOfStars = coordinates[range][0].Length;
    
    for (var i = 0; i < numberOfStars; i++)
    {
      /* 
      * Star tracking
      * Create the correct number of lists to track stars 
      */
      GameObject.FindGameObjectWithTag("GameController").GetComponent<replay>().starMovements.Add(new List<Vector3>());


      // Get premade star
      GameObject sun = GameObject.FindGameObjectWithTag("Star");

      // Clone premade star and position new sun
      GameObject newStar = Instantiate(sun, new Vector3(coordinates[range][0][i], coordinates[range][1][i], 0), Quaternion.identity);

      // Uncomment to totally randomize star positions
      // newStar = createStarRandomPositions(i);

      /*
      * New star size
      */
      var starScale = newStar.GetComponent<RectTransform>().localScale;
      // Set size between 1 and 4
      int newScale = Random.Range(1, 4);
      if (testLayout == "close star"){
        newScale = 4;
      }        
      newStar.GetComponent<RectTransform>().localScale = new Vector3(newScale, newScale, starScale.z);

      /*
      * New star mass
      */
      // Set mass between 1 and 5
      int mass = Random.Range(1, 6);
      if (testLayout == "close star"){
        mass = 4;
      }   
      newStar.GetComponent<starsPull>().mass = mass / 2;

      // Set planet color to star
      if (newStar)
      {
        /*
        * New star color
        */
        newStar.GetComponent<Renderer>().material.color = new Color(
          Random.Range(0f, 1f),
          Random.Range(0f, 1f),
          Random.Range(0f, 1f)
        );
      }

      /*
      * Sun Tag assignment - unique tag
      * Assign sun with new tag so they it be destroyed (and not the original)
      */
      // GameObject.FindGameObjectWithTag("Helper").GetComponent<tagHelper>().AddTag("New Star" + i);
      newStar.transform.gameObject.name = "New Star" + i;

      /*
      * Sun Text
      */
      // Premade star text   
      GameObject starText = GameObject.FindGameObjectWithTag("Star text");
      // Clone old star text and position
      GameObject newStarText = Instantiate(starText, new Vector3(newStar.transform.position.x, newStar.transform.position.y, -1), Quaternion.identity);

      /*
      * Star name
      */
      string path = "Assets/starNames.txt";
      string[] lines = System.IO.File.ReadAllLines(path);
      string starName = lines[Random.Range(0, lines.Length)];
      /*
      * Star name color
      */
      newStarText.GetComponent<TextMeshPro>().color = new Color(
        Random.Range(0f, 1f),
        Random.Range(0f, 1f),
        Random.Range(0f, 1f)
      );
      /*
      * Random star text
      */
      newStarText.GetComponent<TextMeshPro>().SetText(starName + " (" + mass + ")");
      /*
      * Sun Text Tag assignment - unique tag
      * Assign sun's text with new tag so they it be destroyed (and not the original)
      */
      // GameObject.FindGameObjectWithTag("Helper").GetComponent<tagHelper>().AddTag("New Star Text" + i);
      newStarText.transform.gameObject.name = "New Star Text" + i;
    }
  }

  /*
  * DESTROY OLD STARS
  */
  public void destoryStars()
  {
    // Destroy star and text with new star tag
    for (var i = 0; i < numberOfStars; i++)
    {
      Destroy(GameObject.Find("New Star" + i));
      Destroy(GameObject.Find("New Star Text" + i));
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
