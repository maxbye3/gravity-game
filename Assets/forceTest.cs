using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class forceTest : MonoBehaviour
{
    public int impactStrength = 10;
    public GameObject[] planets;
    public float gravity = 10;
    protected Rigidbody bullet;
    // Start is called before the first frame update
    void Start()
    {
      bullet = GetComponent<Rigidbody>();
      bullet.AddForce(Vector2.right * impactStrength);
    }

    // Update is called once per frame
    void Update()
    {
      planets = GameObject.FindGameObjectsWithTag("Planet");
      foreach (GameObject planet in planets)
        {
          Vector3 direction = planet.transform.position - transform.position;
          bullet.AddForce(gravity * direction);
          // Debug.Log("Distance to planet: " + direction);
        }
        
    }
}
