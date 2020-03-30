using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet : MonoBehaviour
{
    private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GameObject.FindGameObjectWithTag("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        //  Get bullet distance from planet
        float distance = Vector3.Distance (bullet.transform.position, transform.position);
        // Debug.Log("bullet distance from planet:" + distance);

        // If bullet has been fired
        if(bullet.GetComponent<firingBullet>().shotFired == true){
          // Pulling bullet towards planet
          Vector3 direction =  transform.position - bullet.transform.position;
          bullet.GetComponent<Rigidbody>().AddForce(direction/Mathf.Pow(distance, 1f / 3f));
        }

    }
}
