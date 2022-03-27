using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saatcolıder : MonoBehaviour
{
    [SerializeField] GameObject player;
    Collection collectionS;
    bool isReady = false;
    bool qDown = false;
    bool cDown = false;

    private void Start() 
    {
        collectionS = player.GetComponent<Collection>();
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(0).GetChild(1).GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(0).GetChild(2).GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;  
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            qDown = true;  
        } 
        if (qDown == true && Input.GetKeyDown(KeyCode.C))
        {
            cDown = true;       
        } 
        if (qDown == true && cDown == true && Input.GetKeyDown(KeyCode.K))
        {
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(0).GetChild(2).GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Collider>().enabled = true;         
        }  
    } 
}
