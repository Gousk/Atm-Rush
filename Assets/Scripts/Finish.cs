using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement; 

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject transporter;
    Collection list;
    List<Transform> Mover = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        list = player.GetComponent<Collection>(); 
        gameObject.transform.GetChild(2).GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(2).GetChild(1).GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(2).GetChild(2).GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(2).GetChild(3).GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(2).GetChild(4).GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(2).GetChild(5).GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(2).GetChild(6).GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(2).GetChild(7).GetComponent<MeshRenderer>().enabled = false;  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level1");
        }    
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.name == "Collectible")
        {
            Mover.Add(other.transform);
            list.Foods.Remove(other.transform);
            other.transform.parent = transporter.transform;
            other.transform.DOMoveX(-20f,0.5f);
        }

        if (other.name == "Player") 
        {
            list.Foods.Remove(other.transform);
            player.GetComponent<Movement>().enabled = false;
            other.transform.parent = transporter.transform;       
        } 

        if (list.score == 700) 
        {
            gameObject.transform.GetChild(2).GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(2).GetChild(1).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(2).GetChild(2).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(2).GetChild(3).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(2).GetChild(4).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(2).GetChild(5).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(2).GetChild(6).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(2).GetChild(7).GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<AudioSource>().Play(0);
        }  
    }
}
