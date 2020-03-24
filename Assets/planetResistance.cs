using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetResistance : MonoBehaviour
{
    public float resistance  = -10;
    public Rigidbody resistantTo;
    protected Rigidbody planet;

    // Start is called before the first frame update
    void Start()
    {
        planet = GetComponent<Rigidbody>();
        resistantTo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 direction = planet.transform.position - resistantTo.transform.position;
      resistantTo.AddForce(resistance * direction);
    }
}
