using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class match : MonoBehaviour
{
    public List<GameObject> PlacedObjects = new List<GameObject>();
    public GameObject PointA;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (PlacedObjects.Count == 0)
        {
            collision.gameObject.transform.position = PointA.transform.position;
            collision.gameObject.transform.rotation = PointA.transform.rotation;

            Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();
            otherRb.useGravity = false;
            otherRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

            PlacedObjects.Add(collision.gameObject);
        }
        else if (collision.gameObject.transform.name.Contains(PlacedObjects[0].transform.name))
        {
            Destroy(collision.gameObject);
            Destroy(PlacedObjects[0].gameObject);
            PlacedObjects.Clear();
        }
        else
        {
            collision.rigidbody.velocity = new Vector3(0, 1, 1) * 120 * Time.deltaTime;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (PlacedObjects.Contains(other.gameObject))
        {
            PlacedObjects.Remove(other.gameObject);
        }
    }
}
