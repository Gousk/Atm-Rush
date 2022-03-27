using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saatsatiyorum : MonoBehaviour
{
    bool key1, key2, key3 = false;
    [SerializeField] GameObject self; 

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player" || key1 == true || key2 == true || key3 == true)
        {
            Debug.Log("triggered");
            gameObject.GetComponent<AudioSource>().Play(0);
        }
    }
}
