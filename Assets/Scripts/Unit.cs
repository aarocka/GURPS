using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{

    public Vector3 destination;

    float speed = 2;

    // Use this for initialization
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards our destination

        Vector3 dir = destination - transform.position;
        Vector3 velocity = dir.normalized * speed * Time.deltaTime;

        // Make sure the velocity doesn't actually exceed the distance we want.
        velocity = Vector3.ClampMagnitude(velocity, dir.magnitude);

        transform.Translate(velocity);

    }


}
