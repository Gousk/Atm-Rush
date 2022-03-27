using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject road;
    Collection listScrpt;
    List<Transform> DroppedItems = new List<Transform>();
    bool isTriggered = false;
    Transform playerLocation;
    [SerializeField] float forceScale = 1f;
    [SerializeField] GameObject objectRef;

    
    // Start is called before the first frame update
    void Start() 
    {
        listScrpt = player.GetComponent<Collection>();       
    }

    void Update() 
    {
                 
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag != "Player")
        {
            int index = listScrpt.Foods.IndexOf(other.transform);

            if(isTriggered == false)
            {
                if (other.tag == "Collected" || other.tag == "Upgrade1" || other.tag == "Upgrade2")
                { 
                    for (int i = listScrpt.Foods.Count-1; i >= index; i--)
                    {
                        BreakLine(other, index, i);
                        RandomiseDroppedItems();
                    }
                }  
            }

            if (other.tag == "Player")
            {
                Debug.Log("Player");
                player.GetComponent<Rigidbody>().AddForce(Vector3.back * forceScale);

                for (int i = listScrpt.Foods.Count-1; i >= index; i--)
                {
                    BreakLine(other, index = 1, i);
                    RandomiseDroppedItems();
                }        
            }
        }
        
    }

    void BreakLine(Collider other, int index, int i)
    {
        if (other.tag != "Player")
        {
            listScrpt.Foods[i].GetComponent<Collider>().isTrigger = true;
            listScrpt.Foods[i].transform.DOScale(0.9f, 0f);

            isTriggered = true;

            DroppedItems.Add(other.transform);
            DroppedItems.Add(listScrpt.Foods[index]);

            Destroy(listScrpt.Foods[index].GetComponent<Collect>(), 0f);
            if (listScrpt.Foods[index].tag != "Player")
            {
                Destroy(listScrpt.Foods[index].GetComponent<Rigidbody>(), 0f);
            }

            listScrpt.Foods[index].GetComponent<Collect>().prevTag = listScrpt.Foods[index].tag;
            listScrpt.Foods[index].tag = "Collect";
            listScrpt.Foods.RemoveAt(index);

            if (listScrpt.Foods[index].tag != "Player")
            {
                listScrpt.Foods[index].parent = road.transform;
            }

            other.transform.parent = road.transform;
        }
        
    }

    public void RandomiseDroppedItems()
    {
        for(int i = 0; i < DroppedItems.Count; i++)
        {

            Vector3 randomPosition = new Vector3(Random.Range(7f, 20f), objectRef.transform.localPosition.y + 0f, Random.Range(transform.localPosition.z + 10, transform.localPosition.z + 25));

            DroppedItems[i].GetComponent<Collider>().isTrigger = true;
            DroppedItems[i].transform.gameObject.SetActive(true);
            DroppedItems[i].transform.localPosition = randomPosition;

            Vector3 firstScale = objectRef.transform.localScale;
            Vector3 Scale = firstScale * 1.5f;
        }
    } 
}
