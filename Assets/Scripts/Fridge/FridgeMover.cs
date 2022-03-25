using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class FridgeMover : MonoBehaviour
{
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject self;

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            scoreText.GetComponent<MeshRenderer>().enabled = false;
            self.transform.DOMoveY(-11.7f, 0.2f);
        }
    }
}
