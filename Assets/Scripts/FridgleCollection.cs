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
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject;
        fridgeObject = GameObject.FindGameObjectWithTag("Fridge");
        fridgeCollider = fridgeObject.GetComponent<FridgeCollider>();

        playerObject = GameObject.FindGameObjectWithTag("Player");
        collectionScript = playerObject.GetComponent<Collection>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Collected")
        {
            Vector3 scale = other.transform.localScale;
            Vector3 goalScale = scale * 0;

            other.transform.DOScale(goalScale, 0.3f);
            Destroy(other.gameObject, 0.3f); 
            score+= 1; 
            self.GetComponent<TextMesh>().text = score.ToString();    
        }

        if (other.tag == "Player")
        {
            collectionScript.Foods.Remove(other.transform);

            Vector3 firstLocation = fridgeObject.transform.localPosition;
            Vector3 destination = new Vector3(-14.12719f, -10f, -29.65139f);
            fridgeCollider.gameObject.transform.DOMove(destination, 0.3f);

            self.GetComponent<TextMesh>().text = " ";
        }         
    }
}
