using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class Speeder : MonoBehaviour
{
    [SerializeField] GameObject player;
    Movement movementScript;
    // Start is called before the first frame update
    void Start()
    {
        movementScript = player.GetComponent<Movement>();       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            StartCoroutine(ScaleSpeed());      
        }   
    }

    public IEnumerator ScaleSpeed()
    {
        movementScript.RoadSpeed = movementScript.RoadSpeed * 2f;
        yield return new WaitForSeconds(3f);
        movementScript.RoadSpeed = movementScript.RoadSpeed * 0.5f; 
    }

}
