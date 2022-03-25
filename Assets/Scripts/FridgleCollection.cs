using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FridgleCollection : MonoBehaviour
{
    GameObject self;
    GameObject fridgeObject;
    GameObject playerObject;
    FridgeCollider fridgeCollider;
    Collection collectionScript;
    // Start is called before the first frame update
    void Start()
    {  
        self = gameObject;
        fridgeObject = GameObject.FindGameObjectWithTag("Fridge");
        fridgeCollider = fridgeObject.GetComponent<FridgeCollider>();

        playerObject = GameObject.FindGameObjectWithTag("Player");
        collectionScript = playerObject.GetComponent<Collection>();    
    }

    void Update() 
    {
        self.GetComponent<TextMesh>().text = collectionScript.score.ToString();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Collected" || other.tag == "Upgrade1" || other.tag == "Upgrade2")
        {
            Vector3 scale = other.transform.localScale;
            Vector3 goalScale = scale * 0;

            other.transform.DOScale(goalScale, 0.3f);
            collectionScript.Foods.Remove(other.transform);
            Destroy(other.gameObject, 0.3f);
            switch (other.tag)
            {
              case "Collected":
              collectionScript.score+=5;
              break; 
              case "Upgrade1":
              collectionScript.score+=10;
              break;
              case "Upgrade2":
              collectionScript.score+=15;
              break;
            }       
        }

        if (other.tag == "Player")
        {
            self.GetComponent<TextMesh>().text = " ";
        }         
    }
}
