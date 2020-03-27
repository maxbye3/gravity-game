using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class forceTest : MonoBehaviour
{
    public GameObject power;
    public GameObject target;
    public GameObject[] planets;
    protected Rigidbody bullet;
    public float gravity = 10;
    
    // Multiplier that determines how fast the bullet travels (powerConstant * powerChosenByUser)
    public int powerConstant = 10; 
    private bool shotFired = false;

    void Start()
    {
      bullet = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
      int powerLevel = power.GetComponent<power>().powerLevel;
      // Fire at a target with level
      if(powerLevel != 0 && !shotFired){
        Vector2 newVector = target.transform.position - transform.position;
        // distance from ship to target so shot power is uniform
        float dist = Vector3.Distance(target.transform.position, transform.position);
        // add force
        bullet.AddForce((newVector * powerLevel * powerConstant)/ dist);
        powerLevel = 0; 
        shotFired = true; // not sure why this was needed and the above line didn't work
        Debug.Log("firing" + powerLevel);
      } 
      // Fire at planets
      // planets = GameObject.FindGameObjectsWithTag("Planet");
      // foreach (GameObject planet in planets)
      //   {
      //     Vector3 direction = planet.transform.position - transform.position;
      //     bullet.AddForce(gravity * direction);
      //   }        
    }
}
