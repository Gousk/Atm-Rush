using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public List<GameObject> cubes;
    int numCol = 0;
    bool go = false;
    Collider otherD;
    private void OnTriggerEnter(Collider other) 
    {
        go = true; 
        otherD = other; 
        numCol = numCol + 1;
        Debug.Log(numCol);
    }

    void Update()
    {
        if (go == true)
        {
            Collecting(otherD);
        }    
    }

    void Collecting(Collider otherAc)
    {
        Debug.Log("triggered");
        if (otherAc.gameObject.CompareTag("Collect"))
        {
            otherAc.gameObject.transform.position = transform.position + (Vector3.forward*3 + Vector3.up); 
                 
        }
    }
}
