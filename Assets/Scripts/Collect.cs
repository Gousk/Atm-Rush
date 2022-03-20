using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    GameObject playerObject;
    Vector3 firstScale;
    float goalScale = 1.25f;
    private void Start() 
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        firstScale = transform.localScale;
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Collect"))
        {
            other.transform.parent = null;
            other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<Collider>().isTrigger = true;
            other.gameObject.AddComponent<Collect>();
            other.tag = gameObject.tag;
            playerObject.GetComponent<Collection>().Foods.Add(other.transform);
        }
    }
}

