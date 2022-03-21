using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FridgeCollider : MonoBehaviour
{
    GameObject self;
    Transform leftDoor;
    AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject;
        leftDoor = self.transform.GetChild(0);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            leftDoor.GetComponent<Collider>().enabled = false;
            Debug.Log("triggerIn");
            Vector3 goalRotation = new Vector3(0, 55.16f, 0);
            leftDoor.transform.DORotate(goalRotation, 0.5f).OnComplete(() =>
            leftDoor.GetComponent<Collider>().enabled = true);   
        }     
    }
    void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            leftDoor.GetComponent<Collider>().enabled = false;
            Debug.Log("triggerOut");
            Vector3 firstRotation = new Vector3(0, 0, 0);
            leftDoor.transform.DORotate(firstRotation, 0.5f).OnComplete(() =>
            leftDoor.GetComponent<Collider>().enabled = true); 
        }  
    }
}
