using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{

    public Vector3 destination;

    float speed = 2;
    public int moveCounter = 0;
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

    public void moveTo(GameObject tile)
    {
        if ((tile.transform.position.x - destination.x <= 0.8821f &&
           tile.transform.position.z - destination.z <= 0.7641f) &&
           (tile.transform.position.x - destination.x >= -0.8821f &&
           tile.transform.position.z - destination.z >= -0.7641f))
        {
            destination = tile.transform.position;
            moveCounter++;
            Debug.Log("Adjecent tile selected");
        }
        else { Debug.Log("Tile not adjcent"); }
    }




}
